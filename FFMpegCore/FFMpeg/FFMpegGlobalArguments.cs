using FFMpegCore.Arguments;

namespace FFMpegCore
{
    public sealed class FFMpegGlobalArguments : FFMpegArgumentsBase
    {
        internal FFMpegGlobalArguments() { }

        public FFMpegGlobalArguments WithVerbosityLevel(VerbosityLevel verbosityLevel = VerbosityLevel.Error) => WithOption(new VerbosityLevelArgument(verbosityLevel));
        public FFMpegGlobalArguments WithHideBanner() => WithOption(new HideBannerArgument());
        public FFMpegGlobalArguments WithCustomOption(string argument) => WithOption(new CustomArgument(argument));

        // DJDM - made public so that global options may be extended outside of FFMpegCore
        public FFMpegGlobalArguments WithOption(IArgument argument)
        {
            Arguments.Add(argument);
            return this;
        }
    }
}
