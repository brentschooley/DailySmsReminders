#r "Microsoft.WindowsAzure.Storage"
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Net;
using Twilio.TwiML;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, CloudTable table, TraceWriter log)
{
    var data = await req.Content.ReadAsStringAsync();

    log.Info("Data: " + data);

    var formValues = data.Split('&')
        .Select(value => value.Split('='))
        .ToDictionary(pair => pair[0], pair => pair[1]);

    var body = formValues["Body"];
    var phoneNumber = WebUtility.UrlDecode(formValues["From"]);
    var response = new TwilioResponse();

    if (body.Trim('+').ToLower() == "subscribe")
    {
        TableOperation operation = TableOperation.Retrieve<Reminder>("Reminders", phoneNumber);
        TableResult result = table.Execute(operation);

        if (result.Result != null)
        {
            response.Message("You already subscribed!");
        }
        else
        {
            response.Message("Thank you, you are now subscribed. Reply 'STOP' to stop receiving updates.");
            log.Info("Adding entry with phone number: " + phoneNumber);
            var insertOperation = TableOperation.Insert(
                new Reminder()
                {
                    PartitionKey = "Reminders",
                    RowKey = phoneNumber
                }
            );

            table.Execute(insertOperation);
        }
    }
    else
    {
        response.Message("Welcome to Daily Updates. Text 'Subscribe' receive updates.");
    }

    return new HttpResponseMessage
    {
        Content = new StringContent(response.ToString(), System.Text.Encoding.UTF8, "application/xml")
    };
}

public class Reminder : TableEntity
{
}