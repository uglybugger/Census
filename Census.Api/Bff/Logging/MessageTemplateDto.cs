namespace Census.Api.Bff.Logging
{
    public class MessageTemplateDto
    {
        public string Raw { get; set; }
        public object[] Tokens { get; set; }
        public string Error { get; set; }
    }
}