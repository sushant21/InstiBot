namespace Bot_Application1
{
    
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Connector;
    using Microsoft.Bot.Builder.Luis;
    using Microsoft.Bot.Builder.Luis.Models;
    [LuisModel("{luis_app_id","{subscription_key}")]
    [Serializable]
    public class RootDialog : LuisDialog<object>
    {
        [LuisIntent("None")]
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry, I didn't get that");
            context.Wait(MessageReceived);    
        }
        [LuisIntent("Buy")]
        public async Task Buy(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("you wanna buy?");
            context.Wait(MessageReceived);
        }
        [LuisIntent("Sell")]
        public async Task Sell(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("you wanna sell?");
            context.Wait(MessageReceived);
        }


    }



}



