<<<<<<< HEAD
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ChainedFunctions
{
    public class NotifySubscribers
    {
        [FunctionName("NotifySubscribers")]
        [StorageAccount("StorageConnectionString")]
        public async Task Run(
            [BlobTrigger("heartbeat/{name}")] Stream uploadedBlob,
            [ServiceBus("HeartbeatCreated", Connection = "ServiceBusConnectionString")] IAsyncCollector<dynamic> messages,
            string name, ILogger log
        )
        {
            log.LogInformation($"New heartbeat blob uploaded:{name}");

            var message = new HeartbeatCreatedMessage
            {
                BlobName = name
            };
            await messages.AddAsync(message);

            log.LogInformation("Published heartbeat message");
        }
   }
=======
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ChainedFunctions
{
    public class NotifySubscribers
    {
        [FunctionName("NotifySubscribers")]
        [StorageAccount("StorageConnectionString")]
        public async Task Run(
            [BlobTrigger("heartbeat/{name}")] Stream uploadedBlob,
            [ServiceBus("HeartbeatCreated", Connection = "ServiceBusConnectionString")] IAsyncCollector<dynamic> messages,
            string name, ILogger log
        )
        {
            log.LogInformation($"New heartbeat blob uploaded:{name}");

            var message = new HeartbeatCreatedMessage
            {
                BlobName = name
            };
            await messages.AddAsync(message);

            log.LogInformation("Published heartbeat message");
        }
   }
>>>>>>> 73c2f177cb8c2f3c0b0ddcd0e8d6369c9410134f
}