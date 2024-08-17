using System.Net.Sockets;

namespace Backend.Server
{
    internal class CustomEventArgs : EventArgs
    {
        public Socket ClientSocket { get; set; }

        public CustomEventArgs(Socket clientSocket)
        {
            ClientSocket = clientSocket;
        }
    }
}