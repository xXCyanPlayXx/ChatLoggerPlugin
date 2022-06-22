using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLoggerPlugin
{
    public class ChatLoggerConfiguration : IRocketPluginConfiguration
    {

        public string LoadMessage { get; set; }
        public string GetPluginVersion { get; set; }

        public string PlayerChatLoggerWebHook;
        public void LoadDefaults()
        {
            LoadMessage = "You Are Useing ChatLogger By CyanPlays Do not remove this";
            GetPluginVersion = "you are running Version 0.0.1";
            PlayerChatLoggerWebHook = "this is where your chatlogger webhook goses";
        }
        
        

        
    }

    
    
      
    
}
