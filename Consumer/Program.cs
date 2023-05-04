using System.Text;
using Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Iniciando...");
        const string QUEUE_NAME = "city";

        var factory = new ConnectionFactory() { HostName = "localhost" };

        using (var connection = factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: QUEUE_NAME,
                              durable: false,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);

                while (true)
                {
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var returnMessage = Encoding.UTF8.GetString(body);
                        var message = JsonConvert.DeserializeObject<City>(returnMessage);
                        Console.WriteLine("Id: " + message.Id_City);
                        Console.WriteLine("Cidade: " + message.Description);
                        Console.WriteLine("Data Cadastro: " + message.DtRegister_City);

                        new CityService().PostCity(message);
                    };

                    channel.BasicConsume(queue: QUEUE_NAME,
                                         autoAck: true,
                                         consumer: consumer);

                    Thread.Sleep(2000);
                }
            }
        }
    }
}