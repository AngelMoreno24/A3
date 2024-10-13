using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace A3
{
    public sealed class CheckNumber : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> Text { get; set; }
        public InArgument<string> SecretNumber { get; set; }


        //define an output argument
        public OutArgument<int> check { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text and SecretNumber input argument
            string guess = context.GetValue(this.Text);

            string secretNumber = context.GetValue(this.SecretNumber);


            //sets up url for REST service with user input
            string URL = "http://localhost:60108/Service1.svc/checkNumber?userNum=" + guess+"&SecretNum="+secretNumber;

            // create a channel
            WebClient channel = new WebClient();

            // return byte array
            byte[] abc = channel.DownloadData(URL);

            // convert to mem stream
            Stream strm = new MemoryStream(abc);
            DataContractSerializer obj = new DataContractSerializer(typeof(string));

            // convent to string
            string randString = obj.ReadObject(strm).ToString();

            //print guess result to console
            Console.WriteLine("Your Guess is "+ randString);

            //changes value of check in the workflow to stop while loop for guessing once guess is correct
            if (randString=="correct")
            {
            context.SetValue(this.check, 1);
            }
        }
    }
}
