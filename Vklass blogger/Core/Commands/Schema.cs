using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace Vklass_blogger.Core.Commands
{
    public class Schema : ModuleBase<SocketCommandContext>
    {
        [Command("schema"), Alias("schema till mig"), Summary("skickar schema")]
        public async Task schemat([Remainder] string input = "")
        {
            if (string.Equals(input, "te16c", StringComparison.InvariantCultureIgnoreCase))
            {
                await Context.Channel.SendFileAsync(@"C:\Users\Danne\source\repos\Vklass blogger\Vklass blogger\Core\Data\TE16C.png");
            }
            else if (string.Equals(input, "te16d", StringComparison.InvariantCultureIgnoreCase))
            {
                await Context.Channel.SendFileAsync(@"C:\Users\Danne\source\repos\Vklass blogger\Vklass blogger\Core\Data\TE16D.png");
            }               
            else if (string.Equals(input, "te17a", StringComparison.InvariantCultureIgnoreCase))
            {
                await Context.Channel.SendFileAsync(@"C:\Users\Danne\source\repos\Vklass blogger\Vklass blogger\Core\Data\TE17A.png");
            }                
            else
            {
                await Context.Channel.SendMessageAsync("Tag anan klass pöjk");
            }
                
                                                
        }
            
    }
}
