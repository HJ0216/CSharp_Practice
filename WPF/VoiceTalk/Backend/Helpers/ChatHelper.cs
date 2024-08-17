using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Backend.Helpers
{
    public static class ChatHelper
    {
        #region Fields
        public const string CONNECTED = "connected";
        public const string DISCONNECTED = "disconnected";

        #endregion

        public class StateObject
        {
            public Socket ClientSocket = null;
            public const int BUFFER_SIZE = 5242880;
            public byte[] ReceivedBuffer = new byte[BUFFER_SIZE];
            public StringBuilder ReceviedData = new StringBuilder();
        }
    }

    public enum Command
    {
        Broadcast,
        Disconnect,
        SendMessage,
        SendFile,
        Call,
        AcceptCall,
        CancelCall,
        EndCall,
        Busy,
        NameExist,
        Null
    }

    public class ConnectedClient
    {
        private readonly string userName;
        private readonly Socket connection;
        public bool IsConnected { get; set; }
        public Socket Connection
        {
            get { return connection; }
        }
        public string UserName
        {
            get { return userName; }
        }

        public ConnectedClient(string userName, Socket connection)
        {
            this.userName = userName;
            this.connection = connection;
        }
    }

    public class Data
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
        public string ClientAddress { get; set; }
        public byte[] File { get; set; }
        public Command Command { get; set; }

        public Data()
        {
            From = null;
            To = null;
            Message = null;
            ClientAddress = null;
            Command = Command.Null;
        }

        public Data(byte[] data)
        {
            // First four bytes are for the Command
            Command = (Command)BitConverter.ToInt32(data, 0);
            // Next 4 bytes store length of the recipient name
            var next = sizeof(int);
            var nameLength = BitConverter.ToInt32(data, next) * 2;
            next += sizeof(int);
            if (nameLength > 0)
            {
                To = Encoding.Unicode.GetString(data, next, nameLength);
                next += nameLength;
            }
            // Next 4 bytes store length of the sender name
            var senderNameLength = BitConverter.ToInt32(data, next) * 2;
            next += sizeof(int);
            if (senderNameLength > 0)
            {
                From = Encoding.Unicode.GetString(data, next, senderNameLength);
                next += senderNameLength;
            }
            // Next 4 bytes store length of the message
            var messageLength = BitConverter.ToInt32(data, next) * 2;
            next += sizeof(int);
            if (messageLength > 0)
            {
                Message = Encoding.Unicode.GetString(data, next, messageLength);
                next += messageLength;
            }
            // Next 4 bytes store length of file
            var fileLength = BitConverter.ToInt32(data, next);
            next += sizeof(int);
            if (fileLength > 0)
            {
                var file = new byte[fileLength];
                Array.Copy(data, next, file, 0, fileLength);
                File = file;
                next += fileLength;
            }
            // Next 4 bytes store length of the client address (UDP)
            var clientAddressLength = BitConverter.ToInt32(data, next) * 2;
            next += sizeof(int);
            if (clientAddressLength > 0)
            {
                ClientAddress = Encoding.Unicode.GetString(data, next, clientAddressLength);
            }
        }

        private static void Encode(string str, List<byte> result)
        {
            var encoded = Encoding.Unicode.GetBytes(str);
            result.AddRange(BitConverter.GetBytes(str.Length));
            result.AddRange(encoded);
        }

        private static void Encode(IReadOnlyCollection<byte> file, List<byte> result)
        {
            result.AddRange(BitConverter.GetBytes(file.Count));
            result.AddRange(file);
        }

        public byte[] ToByte()
        {
            var zeroBytes = BitConverter.GetBytes(0);
            var result = new List<byte>();
            result.AddRange(BitConverter.GetBytes((int)Command));
            if (To != null)
            {
                Encode(To, result);
            }
            else
                result.AddRange(zeroBytes);

            if (From != null)
            {
                Encode(From, result);
            }
            else
                result.AddRange(zeroBytes);

            if (Message != null)
            {
                Encode(Message, result);
            }
            else
                result.AddRange(zeroBytes);

            if (File != null)
            {
                Encode(File, result);
            }
            else
                result.AddRange(zeroBytes);

            if (ClientAddress != null)
            {
                Encode(ClientAddress, result);
            }
            else
                result.AddRange(zeroBytes);

            return result.ToArray();
        }
    }
}
