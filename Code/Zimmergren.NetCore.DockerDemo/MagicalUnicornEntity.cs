using Microsoft.WindowsAzure.Storage.Table;

namespace Zimmergren.NetCore.DockerDemo
{
    public class MagicalUnicornEntity : TableEntity
    {
        public string UnicornName { get; set; }
        public bool IsRealUnicorn { get; set; }
    }
}
