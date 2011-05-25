using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Doorbell_Client
{
    class TCPServer
    {
        // Store the port number for the remote device.
        // Store the port number for the remote device.
        protected const string TCPENDOFTRANSMISSION = "<EOT>";
        private const string TCPSTATUSREQUEST = "<STATUS>";

        private static int ServerPort = Settings.GetTCPPortNumber();

        private static string status = null;

        public static string host = null;

        public static string GetStatus()
        {
            return (status);
        }

        public static void ClearStatus()
        {
            status = null;
        }

        public static void ServerLoop()
        {
            while (true)
            {
                Server();
            }
        }
        private static void Server()
        {
            if (host == null)
            {
                host = Dns.GetHostName();
            }

            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];
            string data;

            IPHostEntry HostInfo = Dns.Resolve(host);
            IPAddress ipAddress = HostInfo.AddressList[0];
            TcpListener listener = new TcpListener(ipAddress, ServerPort);

            // listen for incoming connections.
            try
            {
            listener.Start();
                while (true)
                {
                    // Program is suspended while waiting for an incoming connection.
                    Socket Handler = listener.AcceptSocket();

                    data = null;

                    // An incoming connection needs to be processed.
                    while (true)
                    {
                        bytes = new byte[1024];
                        int bytesRecState = Handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRecState);
                        if (data.IndexOf(TCPENDOFTRANSMISSION) > -1)
                        {
                            break;
                        }
                    }

                    if (data.StartsWith(TCPSTATUSREQUEST))
                    {
                        try
                        {
                            status = data.Substring(TCPSTATUSREQUEST.Length, data.Length - TCPSTATUSREQUEST.Length - TCPENDOFTRANSMISSION.Length);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                    Handler.Close();
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
