string hostName = "goose.rmq2.cloudamqp.com";
string vHost = "vbjpzwcd";
string user = "vbjpzwcd";
string psw = "dFP7zLZEd8Fll6h32fdvgyBQeoby3Vb5";
string queueName = "queue";

var receiver = new RabbitMQReceiver(hostName, vHost, user, psw);
receiver.StartReceiving(queueName);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();

receiver.CloseConnection();

while (true) { }
