using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace IMDBSerachBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // Calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            if (activity.Text.ToUpper() == "ADITI")
            {
                await context.PostAsync("Aditi is Nishant's wife :-)");
            }
            else if (activity.Text.ToUpper() == "NISHANT")
            {
                await context.PostAsync("Nishant is Aditi's Husband :-)");
            }
            else
            {
                // Return our reply to the user
                await context.PostAsync($"You sent {activity.Text} which was {length} characters");
            }


            context.Wait(MessageReceivedAsync);
        }
    }
}