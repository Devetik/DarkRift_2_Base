using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkRift;
using DarkRift.Server;

namespace DarkRift_Test
{
    public class DarkRift_Test : Plugin
    {
        public override bool ThreadSafe => false;
        public override Version Version => new Version(1,0,0);
        public DarkRift_Test(PluginLoadData pluginLoadData) : base(pluginLoadData)
        {
            ClientManager.ClientConnected += OnClientConnected;
            ClientManager.ClientDisconnected += OnClientDisconnected;
            Console.WriteLine("TEST OK 4444");
        }

        private void OnClientConnected(object sender, ClientConnectedEventArgs e)
        {
            Console.WriteLine("Client connecté");
            e.Client.MessageReceived += OnMessageReceived;
        }
        private void OnClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            Console.WriteLine("Déconnexion du client");
        }

        private void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            using (Message message = e.GetMessage())
            {
                if(message.Tag == 4)
                {
                    using (DarkRiftReader reader = message.GetReader())
                    {
                        String testMessage = reader.ReadString();
                        Console.WriteLine(testMessage);
                    }
                }
            }
        }
    }
}
