using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGen.Domain
{
    public class GeneticData
    {
        public byte[] RawData { get; set; } = Array.Empty<byte>();
        public string G25Coordinates { get; set; } = string.Empty;
    }
}
