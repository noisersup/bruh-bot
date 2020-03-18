using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace bruh_bot
{
    class Program
    {
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        private DiscordSocketClient _client;
        public async Task MainAsync(){
            _client = new DiscordSocketClient();
            _client.Log += Log;
             
            await _client.LoginAsync(TokenType.Bot,/*Type token here*/);
            
            await _client.StartAsync();
            _client.MessageReceived += MessageReceived;

            await Task.Delay(-1);
        }
        // Returns logs while connecting to api
        private Task Log(LogMessage msg){
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
        private async Task MessageReceived(SocketMessage msg){
            if(msg.Content.ToLower().Contains("bruh") && msg.Author.Id != _client.CurrentUser.Id){
                await msg.Channel.SendMessageAsync("bruh");
                Console.WriteLine(msg.Author.Username+" said \""+msg.Content+"\"");
            }
        }
    }
}
