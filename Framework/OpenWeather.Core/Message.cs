namespace OpenWeather.Core
{
    public class Message
    {
        public CoreEnum.MessageType Type { get; set; }

        public string MessageText { get; set; }
    }
}
