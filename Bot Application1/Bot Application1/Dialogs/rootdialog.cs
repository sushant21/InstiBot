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
    using Microsoft.Bot.Connector;
    using BestMatchDialog;

    [Serializable]
    public class GreetingsDialog : BestMatchDialog<object>
    {
        [BestMatch(new string[] { "Hi", "Hi There", "Hello there", "Hey", "Hello",
        "Hey there", "Greetings", "Good morning", "Good afternoon", "Good evening", "Good day" },
           threshold: 0.5, ignoreCase: false, ignoreNonAlphaNumericCharacters: false)]
        public async Task WelcomeGreeting(IDialogContext context, string messageText)
        {
            await context.PostAsync("Hello there. How can I help you?");
            context.Done(true);
        }

        [BestMatch(new string[] { "bye", "bye bye", "got to go",
        "see you later", "laters", "adios" })]
        public async Task FarewellGreeting(IDialogContext context, string messageText)
        {
            await context.PostAsync("Bye. Have a good day.");
            context.Done(true);
        }

        public override async Task NoMatchHandler(IDialogContext context, string messageText)
        {
            context.Done(false);
        }
    }
    [LuisModel("2169234a-791c-4837-8c10-91d47720f753", "d2f4209c77be44089a98ccfc89d0ebaa")]
    [Serializable]
    public class RootDialog : LuisDialog<object>
    {
        [LuisIntent("None")]
        [LuisIntent("")]
        public async Task None(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            var cts = new CancellationTokenSource();
            await context.Forward(new GreetingsDialog(), this.GreetingDialogDone, await message, cts.Token);
        }

        private async Task GreetingDialogDone(IDialogContext context, IAwaitable<object> result)
        {
            var success = await result;
            if (success.Equals(false))
                await context.PostAsync("I'm sorry. I didn't understand you.");

            context.Wait(MessageReceived);
        }
        [LuisIntent("Buy")]
        public async Task Buy(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("you wanna buy huh?");
            context.Wait(MessageReceived);
        }
        [LuisIntent("Sell")]
        public async Task Sell(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("you wanna sell huh?");
            context.Wait(MessageReceived);
        }


    }



}



