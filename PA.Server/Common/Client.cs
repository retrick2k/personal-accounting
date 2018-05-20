using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PA.Server.Common
{
    /// <summary>
    /// Подключенный к серверу клиент
    /// </summary>
    public class Client
    {
        public Thread Thread { get; set; }
        public TcpClient TcpClient { get; set; }
        public int Id { get; set; }
    }

}
