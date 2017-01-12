using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace Bot_Application1.Dialogs
{
    public class SellDialog
    {

        /////we need to shift control to messagecontroller to save in database.....it cannot be accessed from here.....
        
         /*       // *************************
                // Log to Database
                // *************************
                // Instantiate the BotData dbContext
                                             Models.BotDataEntities DB = new Models.BotDataEntities();
                // Create a new UserLog object
                                             Models.UserLog NewUserLog = new Models.UserLog();
                                            
                // Set the properties on the UserLog object
                                             NewUserLog.Channel = Activity.ChannelId;
                                             NewUserLog.UserID = Activity.From.Id;
                                             NewUserLog.UserName = activity.From.Name;
                                             NewUserLog.created = DateTime.UtcNow;
                                             NewUserLog.Message = description.Truncate(500);    
                                             NewUserLog.Price = price;
                                             NewUserLog.PhoneNumber=num;
                                             NewUserLog.Title = title;  
                                             NewUserLog.Author = Author; 
                                             NewUserLog.Course = Course; 
                // Add the UserLog object to UserLogs
                                             DB.UserLogs.Add(NewUserLog);
                // Save the changes to the database
                                             DB.SaveChanges();
                // Call NumberGuesserDialog
                                             await Conversation.SendAsync(activity, () => new NumberGuesserDialog());
         */
    }
}