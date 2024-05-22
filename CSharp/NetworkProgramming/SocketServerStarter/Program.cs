using System.Net;
using System.Net.Sockets;

namespace SocketServerStarter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // AddressFamily.InterNetwork: 해당 소켓은 IPv4 주소를 사용하여 네트워크 통신을 수행
            // SocketType.Stream: 스트림 소켓을
            // ProtocolType.Tcp

            IPAddress iPAddress = IPAddress.Any;
            // 서버가 모든 네트워크 인터페이스의 클라이언트 연결을 수락
            // 실제로 0.0.0.0
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 23000);
            // 서버가 해당 포트 번호로 들어오는 연결을 대기할 것임을 나타냄

            listenerSocket.Bind(iPEndPoint);
            // 소켓에 IP 주소와 포트 번호를 연결
            // 서버가 특정 주소와 포트에서 들어오는 연결 요청을 듣기 시작하기 전에 수행
            listenerSocket.Listen(5);
            // 소켓이 클라이언트의 연결 요청을 대기할 준비가 되었음을 시스템에 알림 
            // 5: 소켓이 동시에 대기할 수 있는 최대 연결 요청의 수
            listenerSocket.Accept();
            // 들어오는 연결 요청을 수락 -> 이에 대한 새로운 Socket 객체를 생성
            // 새로운 Socket 객체는 서버와 클라이언트 간의 실제 데이터 교환에 사용
        }
    }
}
