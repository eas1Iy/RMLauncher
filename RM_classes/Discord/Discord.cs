using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMLauncher.RM_classes.Discord
{
    class Discord
    {
        public DiscordRpcClient client;

		public void Initialize(string project,string state)
		{
			/*
			Create a Discord client
			NOTE: 	If you are using Unity3D, you must use the full constructor and define
					 the pipe connection.
			*/
			client = new DiscordRpcClient("900017317705052160");

			//Set the logger
			client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

			//Subscribe to events
			client.OnReady += (sender, e) =>
			{
				Console.WriteLine("Received Ready from user {0}", e.User.Username);
			};

			client.OnPresenceUpdate += (sender, e) =>
			{
				Console.WriteLine("Received Update! {0}", e.Presence);
			};

			//Connect to the RPC
			client.Initialize();

			//Set the rich presence
			//Call this as many times as you want and anywhere in your code.
			client.SetPresence(new RichPresence()
			{
				Details = project,
				State = state,
				Assets = new Assets()
				{
					LargeImageKey = "logowhite",
					LargeImageText = $"Russian Mafia Launcher v{Application.ProductVersion}"
					//SmallImageKey = "logowhite"
				}
			});
		}

		public void MainMenu()
		{
			this.client.SetPresence(new RichPresence
			{
				Details = "Main menu",
				State = "Waiting...",
				Assets = new Assets
				{
					LargeImageKey = "logowhite",
					LargeImageText = $"Russian Mafia Launcher v{Application.ProductVersion}"
				}
			}); ;
		}

		public void JoinServer(string Name)
        {
			this.client.SetPresence(new RichPresence
			{
				Details = "Playing on the server",
				State = Name,
				Assets = new Assets
				{
					LargeImageKey = "logowhite",
					LargeImageText = $"Russian Mafia Launcher v{Application.ProductVersion}"
				}
			}); ;
		}

		public void Update()
		{
			//Invoke all the events, such as OnPresenceUpdate
			client.Invoke();
		}

		public void Deinitialize()
		{
			client.Dispose();
		}
	}
}
