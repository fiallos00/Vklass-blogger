using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;


namespace Vklass_blogger.Core.Commands
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        [Command("hjälp"), Alias("hjälp mig"), Summary("skickar alla kommandon")]
        public async Task Embed()
        {
            EmbedBuilder Embed = new EmbedBuilder();

            Embed.WithTitle("hä e mina kommandon");
            Embed.WithDescription("du e sne" + Environment.NewLine + "hej på dig" + Environment.NewLine + "");
            Embed.WithColor(8454304);
            Embed.WithFooter("PS: ja vil sova");

            await Context.Channel.SendMessageAsync("", false, Embed.Build());
           
        }
    }
}
//public async Task Embed([Remainder]string Input = "None")