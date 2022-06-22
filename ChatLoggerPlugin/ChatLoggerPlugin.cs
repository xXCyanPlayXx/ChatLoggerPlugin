using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLoggerPlugin
{
    public class ChatLoggerPlugin : RocketPlugin<ChatLoggerConfiguration>
    {
        public object PysicsUtility { get; private set; }

        public static ChatLoggerPlugin Instance;

        protected override void Load()
        {

            Logger.Log($"{Name} {Assembly.GetName().Version} has loaded!", ConsoleColor.Green);
            Logger.Log($"{Name} {Configuration.Instance.LoadMessage} You are Useing Chatlogger By CyanPlays");
            Logger.Log($"{Name} {Assembly.GetName().Version} Has Been Loaded!");
            Logger.Log(Configuration.Instance.GetPluginVersion);

            Instance = this;

            UnturnedPlayerEvents.OnPlayerChatted += UnturnedPlayerEvents_OnPlayerChatted;
        }

        private void UnturnedPlayerEvents_OnPlayerChatted(UnturnedPlayer player, ref UnityEngine.Color color, string message, EChatMode chatMode, ref bool cancel)
        {
            //the chat logger embed

            if (!message.StartsWith("/"))
            {

                WebhookMessage ChatLoggerPlguin = new WebhookMessage()
                .PassEmbed()
                .WithTitle("Player Chat Logger")
                .WithField("Player Name:", Translate("webhook", player.DisplayName, player.CSteamID))
                .WithField("Player Message:", message)
                .WithColor(color)
                .Finalize();



                DiscordWebhookService.PostMessage(Configuration.Instance.PlayerChatLoggerWebHook, ChatLoggerPlguin);
            }
           

        }


        protected override void Unload()
        {
            Logger.Log($"{Name} Has Been Unloaded");
        }







    }
}
