namespace FFMpegCore.Pipes
{
    public interface IPipeFrame
    {
        Task SerializeAsync(Stream pipe, CancellationToken token);
    }
}
