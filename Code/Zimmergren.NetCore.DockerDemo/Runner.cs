using System;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Zimmergren.NetCore.DockerDemo
{
    public class Runner
    {
        public static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    var storageAccount = CloudStorageAccount.Parse("TODO: Enter your connection string here");
                    var tableClient = storageAccount.CreateCloudTableClient();
                    var table = tableClient.GetTableReference("unicorns");
                    table.CreateIfNotExistsAsync().Wait();

                    Console.WriteLine("Creating new unicorn...");
                    var id = Guid.NewGuid().ToString("N");

                    var unicorn = new MagicalUnicornEntity
                    {
                        RowKey = id,
                        PartitionKey = "unicorns",
                        IsRealUnicorn = true,
                        UnicornName = $"Mr Unicorn {id}"
                    };

                    var insertOperation = TableOperation.Insert(unicorn);
                    table.ExecuteAsync(insertOperation).Wait();

                    // For the sake of the demo, we'll just back off for half a second before shooting in next message to the table.
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(-1);
            }
        }
    }
}
