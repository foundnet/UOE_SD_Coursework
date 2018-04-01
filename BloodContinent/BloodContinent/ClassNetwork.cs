using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;


namespace BloodContinent
{

    struct SysConfig
    {
        public string serverIP;
        public string backupIP;
        public int port;
    }

    class Session
    {
        public static string curName;
        public static bool isOnline;
        public static SysConfig sysConfig;
    }

    enum MsgType { login, logout, synconfig, battle }

    //The network part, only a draft version, can't work now.
    class ClassNetwork
    {
        Socket socketSend;
        string err;
        public string curIP;
        public string curServerIP;
        public bool netStats;

        public ClassNetwork()
        {
            ;
        }

        private string FormatMessage(MsgType type, string body)
        {
            return type.ToString() + body;
        }

        private int _TryConnect(string addrIP, int addrPort)
        {
            try
            {
                if (socketSend == null) socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                if (!socketSend.Connected)
                {
                    netStats = false;
                    IPAddress ip = IPAddress.Parse(addrIP.Trim());
                    socketSend.Connect(ip, addrPort);
                    netStats = true;
                }
                netStats = true;
                return 1;
            }
            catch (Exception ex)
            {
                err = ex.ToString();
                return 0;
            }
        }

        public int Connect(SysConfig config)
        {
            try
            {
                int loop = 2;
                while (!socketSend.Connected)
                {
                    if ((loop -= 1) <= 0) break;
                    if (_TryConnect(config.serverIP, config.port) == 1)
                    {
                        Thread.Sleep(500);
                        _TryConnect(config.backupIP, config.port);
                    }
                }
                if (loop <= 0)
                    throw new Exception("Can not connect to server!");
                return 1;
            }
            catch (Exception ex)
            {
                err = ex.ToString();
                return 0;
            }
        }



        private int SendMessage(string msg)
        {
            try
            {
                if (netStats)
                {
                    byte[] buffer = new byte[2048];
                    buffer = Encoding.Default.GetBytes(msg);
                    int receive = socketSend.Send(buffer);
                    if (receive == msg.Length) return 1;
                }
                throw new Exception("Didn not connect to server.");
            }
            catch (Exception ex)
            {
                err = ex.ToString();
                return 0;
            }
        }

        //To be done
        public int SendBattleCreate(ClassSquad squad)
        {
            try
            {
                if (netStats)
                {
                    ;
                }
                return 1;
            }
            catch (Exception ex)
            {
                err = ex.ToString();
                return 0;
            }
        }
        public int SendBattleMove(int idxofMap, Direction direction, int steps)
        {
            try
            {
                if (netStats)
                {
                    ;
                }
                return 1;
            }
            catch (Exception ex)
            {
                err = ex.ToString();
                return 0;
            }
        }

        public int SendBattleShoot(int idxofMap, int idxofEnemyMap)
        {
            try
            {
                if (netStats)
                {
                    ;
                }
                return 1;
            }
            catch (Exception ex)
            {
                err = ex.ToString();
                return 0;
            }
        }
    }

}

