using System;

namespace YourNamespace // Change this to your actual namespace
{
    public class DiscordPresence
    {
        private DiscordRpcClient? client;

        public object? LogLevel { get; private set; }

        public object? GetLogLevel()
        {
            return LogLevel;
        }

        public void Initialize(object? logLevel)
        {
            client = new DiscordRpcClient("")
            {
                Logger = new ConsoleLogger() { Level = logLevel }
            }; // Replace with your actual Client ID
            client.Initialize();

            // Set the presence
            UpdatePresence();
        }

        private void UpdatePresence()
        {
            var presence = new RichPresence()
            {
                Details = "In the launcher",
                State = "Launching your game...",
                Assets = new Assets()
                {
                    LargeImageKey = "\r\naetherlogo", // The key you uploaded in the portal
                    LargeImageText = "My Game",
                }
            };

            client.SetPresence(presence);
        }

        public void Deinitialize()
        {
            client.Deinitialize();
        }
    }

    internal class RichPresence
    {
        public RichPresence()
        {
        }

        public string Details { get; set; }
        public string State { get; set; }
        public Assets Assets { get; set; }
    }

    internal class ConsoleLogger
    {
        public ConsoleLogger()
        {
        }

        public object Level { get; set; }
    }

    internal class DiscordRpcClient
    {
        private string v;

        public DiscordRpcClient(string v)
        {
            this.v = v;
        }

        public ConsoleLogger Logger { get; internal set; }

        internal void Deinitialize()
        {
            throw new NotImplementedException();
        }

        internal void Initialize()
        {
            throw new NotImplementedException();
        }

        internal void SetPresence(RichPresence presence)
        {
            throw new NotImplementedException();
        }
    }

    internal class Assets
    {
        public Assets()
        {
        }

        public string LargeImageKey { get; set; }
        public string LargeImageText { get; set; }
    }
}
