using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CheckNumber
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //checks if the guess is correct
        public string checkNumber(int userNum, int SecretNum)
        {
            if (userNum == SecretNum)
                return "correct";
            else
                if (userNum > SecretNum)
                return "too big";
            else return "too small";
        }
    }
}
