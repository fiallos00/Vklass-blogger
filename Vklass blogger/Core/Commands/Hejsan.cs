using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace Vklass_blogger.Core.Commands
{
    public class Hejsan : ModuleBase<SocketCommandContext>
    {
        [Command("hej på dig"), Alias("hello world"), Summary("hello world command")]
        public async Task something()
        {
            await Context.Channel.SendMessageAsync("Hej igen mina fans");
            await Context.Channel.SendMessageAsync("https://imgur.com/pNpMDHg");
        }
    }
}
