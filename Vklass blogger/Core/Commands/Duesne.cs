using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace Vklass_blogger.Core.Commands
{
    public class Duesne : ModuleBase <SocketCommandContext>
    {
        [Command("du e sne"), Alias("sned pojk"), Summary("du är sne command")]
        public async Task duärsne()
        {
            await Context.Channel.SendMessageAsync("Ved fan, jag må dåligt");
            await Context.Channel.SendMessageAsync("https://imgur.com/a/zrS2gQl");
        }
    }
}
