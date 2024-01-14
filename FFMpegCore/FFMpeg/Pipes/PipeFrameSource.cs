namespace FFMpegCore.Pipes
{
    /// <summary>
    /// Implementation of <see cref="IPipeSource"/> for a stream of pipe frames that is gathered from <see cref="IEnumerator{IPipeFrame?}"/>.
    /// Stream arguments are set by the caller, which allows for using streams that are not raw video.
    /// </summary>
    public class PipeFrameSource : IPipeSource
    {
        private readonly string _streamArguments;
        private readonly IEnumerator<IPipeFrame?> _framesEnumerator;

        public PipeFrameSource(string streamArguments, IEnumerable<IPipeFrame?> frames)
        {
            _streamArguments = streamArguments;
            _framesEnumerator = frames.GetEnumerator();
        }

        public string GetStreamArguments()
        {
            return _streamArguments;
        }

        public async Task WriteAsync(Stream outputStream, CancellationToken cancellationToken)
        {
            var pipeFrame = _framesEnumerator.Current;
            if (pipeFrame != null)
            {
                await pipeFrame.SerializeAsync(outputStream, cancellationToken).ConfigureAwait(false);
            }

            while (_framesEnumerator.MoveNext())
            {
                pipeFrame = _framesEnumerator.Current;
                if (pipeFrame != null)
                {
                    await pipeFrame.SerializeAsync(outputStream, cancellationToken).ConfigureAwait(false);
                }
            }
        }
    }
}
