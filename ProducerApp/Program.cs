using DotPulsar;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ProducerApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = PulsarClient.Builder().Build();

            var producerOptions = new ProducerOptions("persistent://public/default/mytopic");
            var producer = client.CreateProducer(producerOptions);
            while(true)
            {
                Console.Write("Please Enter Message: ");
                var message = Console.ReadLine();
                var data = Encoding.UTF8.GetBytes(message);
                var result = await producer.Send(data);
            }
        }
    }
}
