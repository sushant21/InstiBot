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
    public class BuyDialog : IDialog<bool>
    {
        public async Task StartAsync(IDialogContext context)
        {
            LuisResult result;
            context.PrivateConversationData.TryGetValue<LuisResult>("luis", out result);
            if (result!=null)
            {
                 //var entities = new List<EntityRecommendation>(result.Entities);
                EntityRecommendation itemEntityRecommendation;
                if (result.TryFindEntity("item", out itemEntityRecommendation)) 
                //if (entities.Any((Entity)=>Entity.Type!=null))
                {
                    await context.PostAsync("Entity detected");
                    // var itemEntity = (entities.Where((Entity) => Entity.Type == "item").First()).Entity;
                    var itemEntity = itemEntityRecommendation.Entity;
                    List<string> cycle = new List<string> { "cycle","cycles","bicycle","bicycles" };
                    List<string> book = new List<string> { "book", "books" };
                    List<string> gadgets = new List<string> { "phone","phones", "laptop", "earphone", "earphones" ,"sd card","memory card"};
                    itemEntity = itemEntity.ToLower();
                    bool is_cycle = cycle.Any(s => itemEntity.Contains(s));
                    bool is_book = book.Any(s => itemEntity.Contains(s));
                    bool is_gadget = book.Any(s => itemEntity.Contains(s));
                    if (is_cycle)
                    {
                        await context.PostAsync("You selected cycle category");
                        context.Done(true);
                    }
                    else if(is_book)
                    {
                        await context.PostAsync("You selected book category");
                        context.Call(new BookDialog(),BookFormComplete);
                        context.Done(true);
                    }
                    else if(is_gadget)
                    {
                        await context.PostAsync("You selected gadget category");
                        context.Done(true);
                    }
                    else
                    {
                        await context.PostAsync("You selected a category which does not exist");
                        context.Done(false);
                    }
                }
                else
                {
                    await context.PostAsync("You did not mention product");
                    context.Done(false);
                }
            }

        }
        private async Task BookFormComplete(IDialogContext context, IAwaitable<bool> result)
        {
            var BookResult = await result;
            //string template =$"Title: {BookResult.book_name}, Author: {BookResult.book_author}, Course:{BookResult.book_course}";

            //await context.PostAsync(template);
            //context.Done(true);
        }
    }
    [Serializable]
    public class BookDialog : IDialog<bool>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Please enter course code");
            context.Wait(MessageReceivedAsync);
        }
        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            if(message.Text=="mtl100")
            {
                await context.PostAsync("Correct");
                context.Done(true);
            }
            else
            {
                await context.PostAsync("Please enter valid course code");
            }

        }
    }
    /*[Serializable]
    public class BookForm
    {
        [Prompt(  "What is the name of the book you are looking for?")]
        public string book_name { get; set; }

        //[Optional]
        [Prompt("Author?(Optional)")]
        public string book_author { get; set; }

        //[Optional]
        [Prompt("Course?(Optional)")]
        public string book_course { get; set; }

        public static IForm<BookForm> BuildForm()
        {
            return new FormBuilder<BookForm>()
                .Field(nameof(book_name))
                .Field(nameof(book_author))
                .Field(nameof(book_course))
                .Build();
        }
    }*/
    
}