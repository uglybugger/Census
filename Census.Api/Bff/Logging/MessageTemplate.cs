namespace Census.Api.Bff.Logging
{
    public class MessageTemplate
    {
        public string Raw { get; set; }
        public object[] Tokens { get; set; }
        public string Error { get; set; }
    }
}