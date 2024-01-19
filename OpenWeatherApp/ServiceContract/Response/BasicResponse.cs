using OpenWeather.Core;
using System.Collections.ObjectModel;
using System.Linq;

namespace OpenWeatherApp.ServiceContract.Response
{
    public class BasicResponse
    {
        #region Fields

        private Collection<Message> _messages;

        #endregion

        #region Properties

        public Collection<Message> Messages => _messages ?? (_messages = new Collection<Message>());

        #endregion

        #region (public) Methods

        public bool IsError()
        {
            return Messages.Count(item => item.Type == CoreEnum.MessageType.Error) > 0;
        }

        public string[] GetMessageErrorTextArray()
        {
            return Messages.Where(item => item.Type == CoreEnum.MessageType.Error)
                .Select(item => item.MessageText)
                .ToArray();
        }

        public string[] GetMessageInfoTextArray()
        {
            return Messages.Where(item => item.Type == CoreEnum.MessageType.Info)
                .Select(item => item.MessageText)
                .ToArray();
        }

        public void AddErrorMessage(string errorMessage)
        {
            Messages.Add(new Message
            {
                MessageText = errorMessage,
                Type = CoreEnum.MessageType.Error
            });
        }

        #endregion
    }
}
