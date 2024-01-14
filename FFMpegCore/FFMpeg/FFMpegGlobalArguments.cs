using FFMpegCore.Arguments;

namespace FFMpegCore
{
    public sealed class FFMpegGlobalArguments : FFMpegArgumentsBase
    {
        internal FFMpegGlobalArguments() { }

        public FFMpegGlobalArguments WithVerbosityLevel(VerbosityLevel verbosityLevel = VerbosityLevel.Error) => WithOption(new VerbosityLevelArgument(verbosityLevel));

        // DJDM - made public so that global options may be extended outside of FFMpegCore
        public FFMpegGlobalArguments WithOption(IArgument argument)
        {
            Arguments.Add(argument);
            return this;
        }
    }
}
