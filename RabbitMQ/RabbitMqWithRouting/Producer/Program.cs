using System;
using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "mytopicexchange", type:ExchangeType.Topic);

var userPaymentMessage = "A european user paid for something";

var userPaymentMessageBody = Encoding.UTF8.GetBytes(userPaymentMessage);

channel.BasicPublish("mytopicexchange", "user.europe.payments", null, userPaymentMessageBody);

Console.WriteLine($"Send message: {userPaymentMessageBody}");



var bussinessMessage = "A european business ordered goods";

var bussinessMessageBody = Encoding.UTF8.GetBytes(bussinessMessage);

channel.BasicPublish("mytopicexchange", "business.europe.order", null, bussinessMessageBody);

Console.WriteLine($"Send message: {bussinessMessageBody}");


Console.ReadKey();