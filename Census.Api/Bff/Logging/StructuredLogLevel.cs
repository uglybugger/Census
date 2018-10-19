namespace Census.Api.Bff.Logging
{
    public enum StructuredLogLevel
    {
        Off = 0,
        Fatal = 1 << 0,
        Error = Fatal | 1 << 1,
        Warning = Error | 1 << 2,
        Information = Warning | 1 << 3,
        Debug = Information | 1 << 4,
        Verbose = Debug | 1 << 5
    }
}