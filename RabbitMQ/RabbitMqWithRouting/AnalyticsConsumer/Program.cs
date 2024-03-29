﻿using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "mytopicexchange", ExchangeType.Topic);


var consumer = new EventingBasicConsumer(channel);
var queueName = channel.QueueDeclare().QueueName;

channel.QueueBind(queue:queueName,exchange: "mytopicexchange", routingKey:"*.europe.*");

consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Analytics -  Recieved new message: {message}");
};

channel.BasicConsume(queue:queueName, autoAck: true, consumer: consumer);

Console.WriteLine("Analytics- Consuming");

Console.ReadKey();