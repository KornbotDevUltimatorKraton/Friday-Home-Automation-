using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
  // The function of the twilio 

//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
namespace FRIDAY_Neurallace
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //TwilioClient.Init("AC2b129dd7ed0c2822c2bf241d87f452d2", "5eb1f25b6e31f38847591ec1087c16d5");
           // MessageResource.Create(to: new PhoneNumber("+660860113663"), from: new PhoneNumber("+660898"), body: "Hello i'm F.R.I.D.A.Y A.I. your friendly assistance now back online");
        }
    }
}
