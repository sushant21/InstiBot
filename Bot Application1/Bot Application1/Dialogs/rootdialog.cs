﻿namespace Bot_Application1
{
    
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Connector;
    using Microsoft.Bot.Builder.Luis;
    [LuisModel("{luis_app_id","{subscription_key}")]
    [Serializable]
    public class RootDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        public async Task None(IDialogContext context, Luisresult result)
        {
            await context.PostAsync("Sorry, I didn't get that")
            context.Wait(MessageReceived);    
        }
        [LuisIntent("None")]
        public async Task None(IDialogContext context, Luisresult result)
        {
            await context.PostAsync("Sorry, I didn't get that")
            context.Wait(MessageReceived);
        }
        [LuisIntent("Buy")]
        public async Task Buy(IDialogContext context, Luisresult result)
        {
            await context.PostAsync("You wanna buy haan,,,yo man!!!! hi five")
            context.Wait(MessageReceived);
        }
        [LuisIntent("Sell")]
        public async Task Buy(IDialogContext context, Luisresult result)
        {
            await context.PostAsync("What you wanna sell nigga,,,,how much u got")
            context.Wait(MessageReceived);
        }


    }



}



