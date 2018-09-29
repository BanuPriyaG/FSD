using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string SayHello(string name)
        {
            if (DateTime.Now.Hour < 12)
            {
                return "Good Morning " + name;
            }
            else if (DateTime.Now.Hour < 17)
            {
                return "Good Afternoon " + name ;
            }
            else
            {
                return "Good Evening " + name;
            }
        }

        public string TodayProgram(string name)
        {            
            if(DateTime.Now.Day == 7)
                return "Happy weekend";
            else
                return "Enjoy Working day";
        }
    }
}
