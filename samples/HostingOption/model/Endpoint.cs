using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingOption
{
    public class Endpoint
    {
        public string Host { set; get; }

        public int Port { set; get; }

        public override string ToString()
        {
            return $"{Host}:{Port}";
        }
    }
}
