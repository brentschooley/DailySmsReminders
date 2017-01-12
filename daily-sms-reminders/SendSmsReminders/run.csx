#r "Microsoft.WindowsAzure.Storage"
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using Twilio;

public static void Run(TimerInfo myTimer, CloudTable table, TraceWriter log)
{
    log.Info($"C# Timer trigger function executed at: {DateTime.Now}");

    //var accountSid = System.Configuration.ConfigurationManager.AppSettings["TwilioAccountSid"];
    var accountSid = Environment.GetEnvironmentVariable("TwilioAccountSid");
    var authToken = Environment.GetEnvironmentVariable("TwilioAuthToken");
    var twilio = new TwilioRestClient(accountSid, authToken);
   
    // Construct the query operation for all customer entities where PartitionKey="Smith".
    var query = new TableQuery<Reminder>().Where(
        TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Reminders")
    );

    // Print the fields for each customer.
    foreach (Reminder reminder in table.ExecuteQuery(query))
    {
        var message = twilio.SendMessage(
            Environment.GetEnvironmentVariable("TwilioPhoneNumber"),
            reminder.RowKey,
            Environment.GetEnvironmentVariable("ReminderMessage")
        );

        if (message.RestException != null)
        {
            var error = message.RestException.Message;
            log.Error(error);
        }
    }
}

public class Reminder : TableEntity
{

}