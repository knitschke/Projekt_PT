using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace project_pt
{
    class Functions
    {
        public static string target="";
        private const int port = 5007;
        public static string ip = "";
        public static string reply= "";
        public static string time="";
        public static string pwd = "";
        public static string time2 = "";
        public static List<string> vid;
        public static List<string> pic;
        public static string date="";
        public static void tcp(string command)
        {

            try
            {
                TcpClient client = new TcpClient(ip, port);
                string command1 = command;
                NetworkStream ns = client.GetStream();

                byte[] bytes = new byte[1024];
                if (date != "")
                    command1 += (':' + date);
                if (time != "")
                    command1 += (':' + time);
                if (target != "")
                    command1 += (':' + target);
                if (time2 != "")
                    command1 += (':' + time2);
                byte[] bytemsg = Encoding.ASCII.GetBytes(command1);
                ns.Write(bytemsg, 0, bytemsg.Length);

                int bytesRead = ns.Read(bytes, 0, bytes.Length);
                reply = Encoding.ASCII.GetString(bytes, 0, bytesRead);
                Console.WriteLine(reply);
                //int count = 0;
                client.Close();
                string temp1 = "";
                switch (command)
                {
                    case "vid":
                        Functions.vid = new List<string>();
                        for (int i = 1; i < reply.Length; i++)
                        {
                            if (reply[i] == ':')
                            {
                                vid.Add(temp1);
                                
                                temp1 = "";
                            }
                            else temp1 += reply[i];
                        }
                        vid.Add(temp1);
             
                        break;
                    case "pic":
                        Functions.pic = new List<string>();
                        for (int i = 1; i < reply.Length; i++)
                        {
                            if (reply[i] == ':')
                            {
                                pic.Add(temp1);
                                
                                temp1 = "";
                            }
                            else temp1 += reply[i];
                        }
                        pic.Add(temp1);
                        break;
                    case "svid":
                        time = "";
                        target = "";
                        break;
                    case "spic":
                        time = "";
                        target = "";
                        break;
                    case "time":
                        target = "";
                        time2 = reply;
                        break;
                    case "time2":
                        time = "";
                        target = "";
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
            time = "";
            target = "";
            date = "";


        }
    }
}
