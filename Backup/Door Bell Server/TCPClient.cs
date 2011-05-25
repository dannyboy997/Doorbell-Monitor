using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Doorbell_Server
{
    partial class TCPClient
    {
        protected const string TCPENDOFTRANSMISSION = "<EOT>";
        public const string TCPSTATUSREQUEST = "<STATUS>";

        private static string RandomID()
        {
            int size = 10;
            bool lowerCase = true;

            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public static void SendData(string IP, string data)
        {
            if (IP != null && isAlive(IP))
            {
                byte[] bytes = new byte[128];

                // Connect to a remote device.
                try
                {
                    // Establish the remote endpoint for the socket.
                    //IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
                    //IPAddress ipAddress = ipHostInfo.AddressList[0];
                    IPAddress ipAddress = IPAddress.Parse(IP);
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, Settings.GetTCPPortNumber());

                    // Create a TCP/IP  socket.
                    Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sock.SendTimeout = 20;
                    // Connect the socket to the remote endpoint. Catch any errors.
                    sock.Connect(remoteEP);

                    byte[] startmsg = Encoding.ASCII.GetBytes(TCPSTATUSREQUEST + data + TCPENDOFTRANSMISSION);
                    sock.Send(startmsg);
                    sock.Close();
                }
                catch (ArgumentNullException e)
                {
                }
                catch (SocketException e)
                {
                    Settings.SetLog("Error connecting to " + IP);
                }
                catch (Exception e)
                {
                }
            }
        }

        public static bool isAlive(string IP)
        {
            try
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 10;
                PingReply reply = pingSender.Send(IP, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    return (true);
                }
                else
                {
                    Settings.SetLog("Failed to ping " + IP);
                    return (false);
                }
            }
            catch (Exception e)
            {
                Settings.SetLog("Failed to ping " + IP);
                return (false);
            }
        }
    }
}
