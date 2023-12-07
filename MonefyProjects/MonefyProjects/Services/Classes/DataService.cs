using GalaSoft.MvvmLight.Messaging;
using MonefyProjects.Messages;
using MonefyProjects.Models;
using MonefyProjects.Services.Interfaces;

namespace MonefyProjects.Services.Classes
{
    internal class DataService : IDataService
    {
        private readonly IMessenger _messenger;

        public DataService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void SendData<T>(T data)
        {
            _messenger.Send(new DataMessage()
            {
                Data = data
            });
        }

       

    }
}
