using System;
using System.Reflection;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Vklass_blogger
{
    class Program
    {
        private DiscordSocketClient Client;
        private CommandService Commands;

        static void Main(string[] args)
        => new Program().Mainasync().GetAwaiter().GetResult();

        private async Task Mainasync()
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Debug
            });

            Commands = new CommandService(new CommandServiceConfig
            {
                //* olika former ex. /help /HELP /heLp /HElp *//
                CaseSensitiveCommands = true,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });

            Client.MessageReceived += Client_MessageReceived;
            //* Kolla denna om kommandon inte fungerar *//
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly());

            Client.Ready += Client_Ready;
            Client.Log += Client_Log;


            //* Loggar in med Discord Token *// 
            string Token = "NDkxOTY1Nzg5MDQ2NTcxMDE5.DoPpQg.DIDDIWzPPk63eY6hc7Q8yADu13c";
            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();

            //* Delayar clienten från att stanna 4ever *//
            await Task.Delay(-1);

        }

        private async Task Client_Log(LogMessage Message)
        {
            //* $ nödvändigt för att kunna ha med funktioner *// 
            Console.WriteLine($"{DateTime.Now} at {Message.Source}] {Message.Message}");
        }

        //* Visar vad botten gör t.ex. "playing Minecraft" *//
        private async Task Client_Ready()
        {
            await Client.SetGameAsync("Shitpostar på Vklass!", "http://google.com", StreamType.NotStreaming); //* StreamType kan användas för att länka en twitch stream *//
        }

        //* För kommandon *// 
        private async Task Client_MessageReceived(SocketMessage MessageParam)
        {
            var Message = MessageParam as SocketUserMessage;
            var Context = new SocketCommandContext(Client, Message);
            
            //* kollar om meddelandet innehåller något *//
            if (Context.Message == null || Context.Message.Content == "") return;
            if (Context.User.IsBot) return;

            //* kollar första positionen i meddelandet om det finns ett prefix *//
            int ArgPos = 0;
            if (!(Message.HasStringPrefix("!v ", ref ArgPos) || Message.HasMentionPrefix(Client.CurrentUser, ref ArgPos))) return;

            var Result = await Commands.ExecuteAsync(Context, ArgPos);
            if (!Result.IsSuccess)
                Console.WriteLine($"{DateTime.Now} at Commands) Something went wrong with executing a command. Text: {Context.Message.Content} | Error: {Result.ErrorReason}");
         }
    }
}
