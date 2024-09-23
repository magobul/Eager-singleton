using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eager
{
    public class Servers
    {
        private static readonly Servers singleton = new Servers();
        private readonly HashSet<string> serverList;
        private readonly object lockObject = new object();

        private Servers()
        {
            serverList = new HashSet<string>();
        }

        public static Servers Singleton = singleton;

        public bool AddServer(string serverAddress)
        {
            if (string.IsNullOrWhiteSpace(serverAddress) || (!serverAddress.StartsWith("http://") && !serverAddress.StartsWith("https://")))
            {
                return false; 
            }

            lock (lockObject) 
            {
                return serverList.Add(serverAddress); 
            }
        }

        public List<string> GetHttpServers()
        {
            lock (lockObject) 
            {
                var httpServers = new List<string>();
                foreach (var server in serverList)
                {
                    if (server.StartsWith("http://"))
                    {
                        httpServers.Add(server);
                    }
                }
                return httpServers;
            }
        }

        public List<string> GetHttpsServers()
        {
            lock (lockObject) 
            {
                var httpsServers = new List<string>();
                foreach (var server in serverList)
                {
                    if (server.StartsWith("https://"))
                    {
                        httpsServers.Add(server);
                    }
                }
                return httpsServers;
            }
        }
    }
}
