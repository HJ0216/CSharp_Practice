using Backend.Helpers;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace Backend.Server
{
    public class ChatServer
    {
        #region Fields
        private readonly string serverName;
        private readonly int portNumber;
        private readonly NetworkInterface networkInterface;

        private Thread mainThread;
        private TcpListener tcpServer;
        private bool isRunning;
        private readonly List<ConnectedClient> clients = new List<ConnectedClient>();
        public event EventHandler ClientConnected;
        public event EventHandler ClientDisconnected;
        #endregion

        #region Constructors
        public ChatServer(string serverName, int portNumber, object networkInterface)
        {
            this.serverName = serverName;
            this.portNumber = portNumber;
            this.networkInterface = networkInterface as NetworkInterface;
        }
        #endregion

        #region Sever Start/Stop
        public void StartServer()
        {
            mainThread = new Thread(StartListen);
            mainThread.Start();
        }

        public void StartListen()
        {
            IPAddress? ipAddress = (networkInterface != null) ? GetInterfaceIpAddress() : IPAddress.Any;

            tcpServer = new TcpListener(ipAddress, portNumber);
            tcpServer.Start();

            isRunning = true;

            while (true)
            {
                if (!tcpServer.Pending())
                {
                    Thread.Sleep(500);
                    continue;
                }

                Thread clientThread = new Thread(NewClient);
                TcpClient tcpClient = tcpServer.AcceptTcpClient();

                tcpClient.ReceiveTimeout = 30000;
                clientThread.Start(tcpClient.Client);
            }

        }

        private IPAddress? GetInterfaceIpAddress()
        {
            var ipAddresses = networkInterface.GetIPProperties().UnicastAddresses;
            return (from ip in ipAddresses where ip.Address.AddressFamily == AddressFamily.InterNetwork select ip.Address).FirstOrDefault();
        }

        public void StopServer()
        {
            isRunning = false;
            if (tcpServer == null)
                return;

            clients.Clear();
            tcpServer.Stop();
        }
        #endregion

        #region Clients Add/Remove
        private void NewClient(object obj)
        {
            ClientAdded(this, new CustomEventArgs((Socket)obj));
        }

        public void ClientAdded(object sender, EventArgs e)
        {
            Socket socket = ((CustomEventArgs)e).ClientSocket;
            byte[] bytes = new byte[1024];
            var bytesRead = socket.Receive(bytes);

            string newUserName = Encoding.Unicode.GetString(bytes, 0, bytesRead);

            if(clients.Any(client => client.UserName == newUserName))
            {
                SendNameAlreadyExist(socket, newUserName);
                return;
            }

            ConnectedClient newClient = new ConnectedClient(newUserName, socket);
            clients.Add(newClient);

            OnClientConnect(socket, newUserName);

            foreach (ConnectedClient client in clients)
            {
                SendUsers(client.Connection, client.UserName, newUserName, ChatHelper.CONNECTED);
            }

            ChatHelper.StateObject state = new ChatHelper.StateObject
            {
                ClientSocket = socket
            };

            socket.BeginReceive(state.ReceivedBuffer, 0, ChatHelper.StateObject.BUFFER_SIZE, 0, OnReceive, state);
        }

        private void OnReceive(IAsyncResult ar)
        {
            ChatHelper.StateObject state = ar.AsyncState as ChatHelper.StateObject;
            if (state == null)
                return;

            Socket handler = state.ClientSocket;
            if (!handler.Connected)
                return;

            try
            {
                var bytesRead = handler.EndReceive(ar);
                if (bytesRead <= 0)
                    return;

                ParseRequest(state, handler);
            }
            catch (Exception ex)
            {
                DisconnectClient(handler);
            }
        }

        private void ParseRequest(ChatHelper.StateObject state, Socket handlerSocket)
        {
            Data data = new Data(state.ReceivedBuffer);
            if (data.Command == Command.Disconnect)
            {
                DisconnectClient(state.ClientSocket);
                return;
            }

            ConnectedClient? connectedClient = clients.FirstOrDefault(client => client.UserName == data.To);
            if (connectedClient == null)
                return;

            connectedClient.Connection.Send(data.ToByte());
            handlerSocket.BeginReceive(
                state.ReceivedBuffer, 
                0, 
                ChatHelper.StateObject.BUFFER_SIZE, 
                0,
                OnReceive,
                state);
        }

        private void DisconnectClient(Socket clientSocket)
        {
            ConnectedClient? connectedClient = clients.FirstOrDefault(k => k.Connection == clientSocket);
            if (connectedClient == null)
                return;

            connectedClient.IsConnected = false;
            OnClientDisconnected(clientSocket, connectedClient.UserName);

            clientSocket.Close();
            clients.Remove(connectedClient);

            foreach (var client in clients)
            {
                SendUsers(
                    client.Connection, 
                    client.UserName, 
                    connectedClient.UserName, 
                    ChatHelper.DISCONNECTED);
            }
        }


        private void SendUsers(Socket clientSocket, string userName, string changedUser, string state)
        {
            Data data = new Data
            {
                Command = Command.Broadcast,
                To = userName,
                Message = $"{string.Join(",", clients.Select(u => u.UserName).Where(name => name != userName))}|{changedUser}|{state}|{serverName}"
            };

            clientSocket.Send(data.ToByte());
        }

        private void OnClientConnect(Socket socket, string newUserName)
        {
            throw new NotImplementedException();
        }

        private void SendNameAlreadyExist(Socket socket, string newUserName)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event Invokers
        protected virtual void OnClientConnected(Socket clientSocket, string name)
        {
            var handler = ClientConnected;
            handler?.Invoke(name, new CustomEventArgs(clientSocket));
        }

        protected virtual void OnClientDisconnected(Socket clientSocket, string name)
        {
            var handler = ClientDisconnected;
            handler?.Invoke(name, new CustomEventArgs(clientSocket));
        }
        #endregion

    }
}
