using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System.Collections.Generic;
using Microsoft.Bot.Builder.FormFlow;

namespace Bot_Application1
{
    [Serializable]
    public class BookDialog : BuyDialog
    {
        public override async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }
        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            if (message.Text == "mtl100")
            {
                await context.PostAsync("Correct");
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Please enter valid course code");
                context.Wait(MessageReceivedAsync);
            }

        }
    }
}