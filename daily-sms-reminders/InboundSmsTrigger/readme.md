# InboundSmsTrigger

The `InboundSmsTrigger` is used to respond to text messages that are sent to the reminder service. If arbitrary text is sent in we inform the user to send `subscribe` instead. Once they send `subscribe` we add their phone number to Azure Table Storage to use in our SendSmsReminders trigger which will run daily.