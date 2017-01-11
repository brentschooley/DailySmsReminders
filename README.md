# Send Daily SMS Reminders with C#, Azure Functions and Twilio

If you want to set up a daily reminder service you'll probably want to support SMS. [Twilio](https://twilio.com/docs/sms) makes this as simple as making an HTTP request to a server. Don't have a server? Why not use [Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-overview)? Azure Functions has a competitive [pricing model](https://docs.microsoft.com/en-us/azure/azure-functions/functions-overview#pricing) can be developed using many common programming languages.

#### Azure Functions Background
>Azure Functions is a solution for easily running small pieces of code, or "functions," in the cloud. You can write just the code you need for the problem at hand, without worrying about a whole application or the infrastructure to run it. Functions can make development even more productive, and you can use your development language of choice, such as C#, F#, Node.js, Python or PHP. Pay only for the time your code runs and trust Azure to scale as needed.

## How to Use This Project
 - Full documentation with pictures coming soon.
 
### 1. Gather Account Information

The first thing we need to do is grab all the necessary configuration values from our
Twilio account. To set up our reminders, we will need four 
pieces of information:

| Config Value  | Description |
| :-------------  |:------------- |
Account SID | Your primary Twilio account identifier - find this [in the console](https://www.twilio.com/console/).
Auth Token | Used to authenticate - find this [in the console](https://www.twilio.com/console/).
Twilio Phone Number | The Twilio phone number the reminders will be sent from. [Purchase a phone number here](https://www.twilio.com/console/phone-numbers/search).

### 2. Put values values in appsettings.json
Add your `TwilioAccountSid`, `TwilioAuthToken`, `TwilioPhoneNumber`, and a reminder message that you want to send out daily to the appsettings.json file.

```
{
  ...
  "Values": {
    // ...
    "TwilioAccountSid": "",
    "TwilioAuthToken": "",
    "TwilioPhoneNumber": "",
    "ReminderMessage: ""    
  }
}
```

### 3. Configure reminder timing
The timing of the daily reminder can be changed in the `function.json` file by modifying the cron entry.


### 4. Run the project locally or push to Azure!
Need help pushing this to Azure? Take a look at this [step by step guide](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-first-azure-function-azure-portal).

## Tips
 - Fun Fact, Azure Functions doesn't like "."s in project names. This is why the Azure function is called Token.
 
## Requirements
- [Microsoft Azure Account](https://azure.microsoft.com/en-us/services/functions/)
- Windows
 - [Visual Studio for Windows](https://www.visualstudio.com/downloads/)
 - [Azure .NET SDK](https://go.microsoft.com/fwlink/?LinkId=518003&clcid=0x409)
 - [Visual Studio Tools for Azure Functions](https://aka.ms/azfunctiontools)
- Mac
 - [Visual Studio Code](https://code.visualstudio.com/)
 - [Azure Functions CLI](https://www.npmjs.com/package/azure-functions-cli)
 
## Resources
 - [Get Started With Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-first-azure-function)
 - [Running Azure Functions Locally](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local)
 - [Running Azure Functions blog post](https://blogs.msdn.microsoft.com/appserviceteam/2016/12/01/running-azure-functions-locally-with-the-cli/)
 - [How To Deploy Azure Functions From GitHub](http://jameschambers.com/2016/11/deploy-functions-from-github/)
