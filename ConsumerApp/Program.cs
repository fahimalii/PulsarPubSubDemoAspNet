using DotPulsar;
using System;
using System.Buffers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = PulsarClient.Builder().Build();
            
            /*
             * If Multiple Consumer process have same "subscriptionName", only one of them will get message
             * Can use Guid.NewGuid().ToString() to ensure each consumer process have unique subscriptionName
             */

            var consumerOptions = new ConsumerOptions(subscriptionName: "DemoSub", topic: "persistent://public/default/mytopic");
            var consumer = client.CreateConsumer(consumerOptions);

            await foreach (var message in consumer.Messages())
            {
                Console.WriteLine($"Received: {Encoding.UTF8.GetString(message.Data.ToArray())}");
                //await consumer.Acknowledge(message);
            }

            //var readerOptions = new ReaderOptions(MessageId.Latest, "persistent://public/default/mytopic");
            //var reader = client.CreateReader(readerOptions);

            //await foreach (var message2 in reader.Messages())
            //{
            //    Console.WriteLine($"Reader Received: {Encoding.UTF8.GetString(message2.Data.ToArray())}");
            //}
        }
    }
}
