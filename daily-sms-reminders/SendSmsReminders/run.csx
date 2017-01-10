#r "Microsoft.WindowsAzure.Storage"
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using Twilio;

public static void Run(TimerInfo myTimer, CloudTable table, TraceWriter log)
{
    log.Info($"C# Timer trigger function executed at: {DateTime.Now}");

    var accountSid = "ACaab6eae0c0f0f46633e4d00ab9b8b3c7";
    var authToken = "eec6f61ef3cba61c219955ceedc77d79";
    var twilio = new TwilioRestClient(accountSid, authToken);

    // Construct the query operation for all customer entities where PartitionKey="Smith".
    var query = new TableQuery<Reminder>().Where(
        TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Reminders")
    );

    // Print the fields for each customer.
    foreach (Reminder reminder in table.ExecuteQuery(query))
    {
        var message = twilio.SendMessage(
            "+15167845074",
            reminder.RowKey,
            "Hello, hope you're having a good day!"
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