using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HostService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(WCF1.Service1));
            if (host != null)
            {
                host.Open();
                Console.WriteLine("Service Started....");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
