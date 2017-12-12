/* Creator Mr. Chanapai Chuadchum 
 * Project name Friday Neurallace A.I. 
 * Date : 11/2/2017   // Project started 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
// Function of the Speech Recognition  and Speech Synthesis 
using System.Speech.Synthesis;    // Speech Synthesis function 
using System.Speech.Recognition;  // Speech Recognition
 //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                  // Image Processing function 
using Emgu.CV;
//using Emgu.CV.Util;
//using Emgu.CV.VideoSurveillance;
using Emgu.CV.Structure;
 // function net core 
using Emgu.CV.Cuda;  // adding cuda function for the Face detction 
using Emgu.CV.CvEnum;  // added the CvEnum 
//using Emgu.CV.UI;
//using Emgu.CV.VideoStab;
//using Emgu.CV.Face;
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//The SSH Remote function 
using Renci.SshNet;
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>.
// IOT microgear netpie 
using io.netpie.microgear;
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
// System Runtime function 
using System.Runtime.InteropServices;
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
using System.Threading;
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
// System property for saving the file 
using FRIDAY_Neurallace.Properties;
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
// Think gear function for the neural brain wave detector 
using ThinkGearNET;
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
// QR code Generator function library 
using ZXing;
using ZXing.Common;
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
// Serial communication between the port 
using System.IO.Ports;
using System.IO; // The IO file added system function 
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
// Machine learning function for the System Neubrain learning 
using Accord.Controls;  // Accord control library function for the System of the machinelearning 
using Accord.IO;
using Accord.Math;
using Accord.Statistics.Distributions.Univariate;
using Accord.MachineLearning.Bayes;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.VectorMachines;
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
// Google search API function  
using Google.Apis.Services; // Google API service 
using Google.Apis.Requests; // Request funciton of the google API using Google.Apis.Download; // Google API download function
using Google.Apis.Upload; // Google API uploader
using Google.Apis.Customsearch.v1;  // Google API custom search engine
using Google.Apis.Customsearch.v1.Data; // Google API data base 
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
 // Google cloud vision system 
using Google.Apis.Vision.v1;//Google function of the vision API 1 
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
// Excel writer function for the machinelearning raw data input  
using Microsoft.Office.Core;  // Microsoft office cor function 
using Microsoft.Office.Interop.Excel; // Microsoft interop 
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
// SMS sensder function of the communication system 
using System.Net;
using System.Net.Mail; // Sending mail STMP 
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
using System.Data.OleDb; // Connect with the oracle data base server 
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//Pop up notification 
using Tulpep.NotificationWindow; //Library for the popup notification system 
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
using System.Xml;
using System.Xml.Linq;
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
using System.Media; // for adding the media file 
                    //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // Standform NLP function
using java.io;// Java io input function 
using java.util; //Java util function 
using edu.stanford.nlp.pipeline; // Using the Standford NLP to  
//using edu.stanford.nlp.math;
//using edu.stanford.nlp.neural;
using Console = System.Console; // using System .console function to control the console 

 //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
      // 3D sound audio simulation function 
using IrrKlang;
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
using System.Web;
using System.Web.Services; // Web service Extraction
//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                           // GLC cutum interface controller  
using GlgoleLib; 
namespace FRIDAY_Neurallace
{
    
    public partial class Form1 : Form
    {
        System.Timers.Timer timer;
        // String text input function will be later update on the function on the text box 
        private String AppID = "Kornbot";   
        private String Key = "wBHqON1EtNqlTzu";
        private String Secret = "nt0utSlDrPEOiYOFFfHYJDbEw";
        private String Alias = "VisualStudio";
        private String Target = "NodeMCU1";
        private String Topic = "/topic";
        public SshClient cmd;
        public ShellStream shellStream { get; set; }
        public Microgear microgear;
        private Emgu.CV.Capture Camera1; // Camera 1 for the user access  // Using the same camera image box and Camera 
                                         //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                         // The function of the Weather API for the weather reporter 
        private const string API_KEY = "4596f237cf87892349b3368f2ec53805";

        // Query URLs. Replace @LOC@ with the location.
        private const string CurrentUrl =
            "http://api.openweathermap.org/data/2.5/weather?" +
            "q=@loc@&mode=xml&APPID=" + API_KEY;
        private const string ForecastUrl =
            "http://api.openweathermap.org/data/2.5/forecast?" +
            "q=@loc@&mode=xml&APPID=" + API_KEY;

        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private Emgu.CV.Capture Camera2; // Camera2 for the survillance cam 
        private ThinkGearWrapper _thinkGearWrapper = new ThinkGearWrapper(); // Think gear system for the  Mind set control system 
         
        private bool _CapturecamInprogress;
        private bool saveToFile; // Save file to the 
      //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                 // The google search API  linking with the the ID and API key for the data base 
        const string apikey = "AIzaSyC80ZgRS1t6xCqwdJYCbmH2YJjtxorRfPs"; // The string of the API key function 
        const string searchEngineID = "017568105456105416131:jlpxga1-2mm"; // The string of the search engine ID
        string query = "Hintdesk";
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // The Google cloud vision system 
        const string apiKeyVision = "AIzaSyCHoIIr2_dc_uRKjQUyJwdVdsNyfTsX14M"; // The Vision API key 
        const string searchEngineIDVision = "605250881007-d2q7i8bb8tv42bugg2qb29sncpjl3dmt.apps.googleusercontent.com"; //Vision function ID
        const string SecretkeyVision = "E_JcVtBQNaVwUHHwR6M_Ol-s";  //Vision Key 
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // Function for controlling the volume up and volume down 
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
        IntPtr wParam, IntPtr lParam);
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        IInputArray image;  // add the image  // The funtion  
       //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
               // Image face recognition system function 
        Image<Bgr, Byte> cutrrentFrame; // Picture current frame 
        
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
           
           // MessageResource.Create(to: new PhoneNumber("+660860113663"), from: new PhoneNumber("+660898"), body: "Hello i'm F.R.I.D.A.Y A.I. your friendly assistance now back online");
            try
            {
                Camera1 = new Emgu.CV.Capture(0); // Camera 1 for the user identification system  // 
                Camera2 = new Emgu.CV.Capture(1);   // Camera 2 for the survillance cam online 
                Camera1.ImageGrabbed += ProcessFrame;
                Camera1.Start();
            }
            catch (NullReferenceException erre)
            {
                MessageBox.Show(erre.Message);
            }
            if (Camera1 != null)
            {
                if (_CapturecamInprogress)
                {
                    Camera1.Pause();

                }
            }
            if (Camera1 == null)
            {
                Camera1.Start();
            }
            _CapturecamInprogress = !_CapturecamInprogress;

            foreach (var v in Friday.GetInstalledVoices().Select(v => v.VoiceInfo))
            {
                Console.WriteLine("Name:{0}, Gender:{1}, Age:{2}",
                  v.Description, v.Gender, v.Age);
            }

            // select male senior (if it exists)
            Friday.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);

            // select audio device
            Friday.SetOutputToDefaultAudioDevice();

            // build and speak a prompt
            PromptBuilder Fbuilder = new PromptBuilder();
            Friday.Speak("Friday Operating system is now back online");
        }
       
        private void  NeuralFunction_input(string REST)   // Access  Neural learning interface function 
        {
           
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
           
            // Learn  from the xls data and make the machine learning function 
            System.Data.DataTable table = new ExcelReader(REST+".xls").GetWorksheet("FridayNeural learning");
            double[][] inputs = table.ToArray<double>("X", "Y"); // plot the table x,y into the plot monitoring 
            int[] outputs = table.Columns["G"].ToArray<int>();
            var learner = new NaiveBayesLearning<NormalDistribution>();  // Bay learning 
            var nb = learner.Learn(inputs, outputs);
            int[] answers = nb.Decide(inputs);  // feedback answer to the layer 
            var teacher = new LineSegment3DF(); // non of use function 
            
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // The function of the display the Data of the machine learning 
            textBox11.Text = "\n" + inputs.ToString() + "\t" +outputs.ToString() + "\t" + answers.ToString(); // String show in the text box 
        }
      private void CAD() // CAD file image load function 
      {
      

      }
       private void NeuralNet2(string REST)
      {
            System.Data.DataTable table2 = new ExcelReader(REST + ".xls").GetWorksheet("FridayNeuralLearning2");
            double[][] inputs1 = table2.ToArray<double>("x", "y"); // The table build the axis x,y 
            int[] outputs1 = table2.Columns["Q"].ToArray<int>(); // The neural table display system function 
            var learner1 = new NaiveBayesLearning<NormalDistribution>(); // Bay learning 
            var nb2 = learner1.Learn(inputs1, outputs1); // Recieve the value output from the neural learning 1 
            int[] answers1 = nb2.Decide(inputs1); //The function of the result answer back 
      }
     /*
      private static void VisionSystem(Mat image, string faceFileName, String eyeFileName, List<System.Drawing.Rectangle> faces, List<System.Drawing.Rectangle> eyes, bool tryUseCuda, out long detectionTime) // The vision system of the A.I.  link with the Speech data table 
      {
    
      }
      */
        private void ProcessFrame(object sender, EventArgs e)
        {
            Mat frame = new Mat();
            Camera1.Retrieve(frame, 0); // Retrieve Data of the image 
            try
            {
                imageBox1.Image = frame; //Image frame running 
                //imageBox1.Image = frame.QueryFrame();  // QueryFrame has the problem
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);  // Show the message error 
            }
            if (saveToFile)
            {
                int i;
                string date = DateTime.Now.ToString();
                System.Random picture = new System.Random();
                i = picture.Next(1, 100000000);
                String Pixi = i.ToString();
                try
                {
                  
                    Friday.Speak("I'm going to save the picure in the flash drive");
                    frame.Save(@"D:\" + Pixi + ".jpg");
                    saveToFile = !saveToFile;
                    var bmpTemp = new Bitmap(@"D:\" + Pixi + ".jpg");
                    
                    Image image = new Bitmap(bmpTemp);
                    PopupNotifier popup2 = new PopupNotifier(); // Pop up notication 
                    popup2.Image = Properties.Resources._520605_flash_128; // Toast notification popup function 
                    popup2.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Added date to pop up when you say hello 
                    popup2.ContentText = "I'm going to save the picure in the flash drive"; // Pop up notification popup 
                    popup2.BodyColor = Color.Aquamarine;
                    popup2.Image = image;
                    popup2.Popup();// Show up and popup
                    pictureBox2.Image = image;
                    i++;
                }
                catch
                {
                    //popup2.Image = Properties.Resources.HitechBackground;
                   // popup2.Popup();// Show up and popup
                    Friday.Speak("The Flash drive had been removed so");
                    Friday.Speak("I'm going to save your picture in drive C ");
                    frame.Save(@"C:\Users\kornbot\Desktop\Friday photoes" + Pixi + ".jpg");
                    saveToFile = !saveToFile;
                    var bmpTemp = new Bitmap(@"C:\Users\kornbot\Desktop\Friday photoes" + Pixi + ".jpg");

                    Image image = new Bitmap(bmpTemp);

                    PopupNotifier popup2 = new PopupNotifier(); // Pop up notication 
                    popup2.Image = Properties.Resources.Drive_C; // Toast notification popup function 
                    popup2.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Added date to pop up when you say hello 
                    popup2.ContentText = "I'm going to save the picture in drive C"; // Pop up notification popup 
                   // popup2.BodyColor = Color.Aquamarine;
                    popup2.Image = image; 
                    popup2.Popup();// Show up and popup
                    pictureBox2.Image = image;
                    i++;
                }
            }
        }
        private void ReleaseData()
        {
            if (Camera1 != null)
                Camera1.Dispose();
        }
   //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
       // The function that A.I. Need to learn and improve itself to the high level 
      
        private void Translator() // Translator function of the A.I. link to data translator and speech 
        {


        }
        private void AR() // The Augmented reality  // link to action of vition and Speech and sensing Audio analysis AR  
        {


        }
        private void AudioAnalysis() // The voice matching function Audio analysis linking with the Speech data table 
        {
         
        }
        private void GPSAPIlinkPhone() // The function of the GPS tracking of the phone to the A.I. 
        {


        }
        private void SensorInput() // The sensor Data base function of the A.I. for the selfe aware function 
        {
       

        }
        private void GeneticAlgorithm()  // Genetic Algorithm for optimization in the system 
        {


        }
        private void SMSSender()
        {
         try
            {
                SmtpClient smtp = new SmtpClient(); // System of the sms sender function activated 
                MailMessage message = new MailMessage();
                smtp.Credentials = new NetworkCredential("", "");// Finding the username and the password 
                smtp.Host = "ipipi.com";
                message.From = new MailAddress(string.Format("",""));
                message.To.Add(string.Format("","0860113663"));
                message.Subject = "Friday";
            }
          catch
            {
                Friday.Speak("Fail sending SMS ");
            }
        }
   //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        SpeechRecognitionEngine Recengine = new SpeechRecognitionEngine(); //Speech Recognition 
        SpeechSynthesizer Friday = new SpeechSynthesizer();  //Speech Synthesis 
        private void Form1_Load(object sender, EventArgs e)
        {
            // Google cloud server need to be able to solve so this function will be able to connect to the seach engine 
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // Google APIs custom search function added 
          //  var Customsearchengine = new CustomsearchService(new BaseClientService.Initializer { ApiKey = apikey }); // The function of the google APIS Data base search
           /* 
            var svc = new Google.Apis.Customsearch.v1.CustomsearchService(new BaseClientService.Initializer { ApiKey = apikey });
            var listRequest = svc.Cse.List(query); // The function of the Google search engine 
            listRequest.Cx = searchEngineID; // Search ID of the data base 
            textBox11.ForeColor = Color.Blue; // The color of the textbox set 
            textBox11.Text = "CSE start ready ...";
            IList<Google.Apis.Customsearch.v1.Data.Result> paging = new List<Google.Apis.Customsearch.v1.Data.Result>();
            var count = 0; 
            while(paging != null)
            {
             textBox11.Text = $"Page{count}";
                try
                { 
                listRequest.Start = count * 10 + 1;
                paging = listRequest.Execute().Items;
                if (paging != null)
                {
                    foreach (var item in paging)
                        textBox11.Text = ("Title :" + item.Title + Environment.NewLine + "Link :" + item.Link);
                    count++;
                }
                }
                catch(Exception Error)
                {
                    MessageBox.Show(Error.Message); 
                }
            }
            textBox11.Text = "Done .";
            */   

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //Google API function 



            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>.
            //Neural Brain for Training  the Artificial Intelligence Machine learning 
            foreach (string port in SerialPort.GetPortNames())
                try
                {
                    comboBox1.Items.Add(port);
                    comboBox1.SelectedIndex = 0;
                }
                catch(Exception er)
                {
                    MessageBox.Show(er.Message); 
                }
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>.
            //QR code Generator for the User Identification 
            IBarcodeWriter Writer = new BarcodeWriter
            { Format = BarcodeFormat.QR_CODE };  // QR code generator function 
            var result = Writer.Write("\t" + Settings.Default["Routine1"].ToString()); textBox2.Text = Settings.Default["Routine1"].ToString();  // Saving here in the text box 
            result = Writer.Write("\t" + Settings.Default["Routine2"].ToString()); textBox3.Text = Settings.Default["Routine2"].ToString();
            result = Writer.Write("\t" + Settings.Default["Routine3"].ToString()); textBox4.Text = Settings.Default["Routine3"].ToString();
            result = Writer.Write("\t" + Settings.Default["Routine4"].ToString()); textBox5.Text = Settings.Default["Routine4"].ToString();
            result = Writer.Write("\t" + Settings.Default["Routine5"].ToString()); textBox10.Text = Settings.Default["Routine5"].ToString();
        
            var barcodeBitmap = new Bitmap(result);
            pictureBox3.Image = barcodeBitmap;
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
             // The Routine Setting up for the fucntion of the Text remmember 
            textBox6.Text = Settings.Default["Routine6"].ToString();
            textBox7.Text = Settings.Default["Routine7"].ToString();
            textBox8.Text = Settings.Default["Routine8"].ToString();
            textBox9.Text = Settings.Default["Routine9"].ToString();
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>.
               // The AppID  secret key and Key password   Apps  
            textBox12.Text = Settings.Default["Routine10"].ToString();
            textBox13.Text = Settings.Default["Routine11"].ToString();
            textBox14.Text = Settings.Default["Routine12"].ToString();    
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // IOT Function 
                     microgear = new Microgear();
                     microgear.onMessage += message;
                     microgear.Connect(AppID, Key, Secret);
                     microgear.SetAlias(Alias);
                     microgear.Subscribe(Topic);
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            Choices command = new Choices(); // The  command input 
            command.Add(new String[] {"Hello Friday","Friday Open the window", "Friday close the window", "Friday Open the pumping water", "Friday handle the factory function", "Friday access the hap module"
                , "Friday Shut down the hap module","Friday What time is it","What date today","Friday Bed room light on","Friday Bed room light off","Friday Shut the system down","Friday turn on the pumping water"
                ,"Friday turn off the pumping water","Friday turn on the pump","Friday turn off the pump","How are you doing today","How is it going on today","Where are you rigt now","How are you doing today",
                "Friday Are you there","Can you help me some thing","i'm sick","I'm feeling not so good","Friday connect to the telescope camera","Friday remember routine","Friday",
                "Where is the neerest comfee shop","Friday open the google map","Friday open the facebook","Friday open the youtube","Friday open the google map","Friday connect to the main computer",
                "Friday bed room light on","Friday bed room light off","Friday room light on",
                "Friday room light off","Friday toilet room light off","Friday toilet room light on"
                ,"Friday What date today","Friday What time is it","Friday close the window","Friday open the window"
                ,"Friday living room light on","Friday living room light off","Friday turn on the light","Friday turn off the light"
                ,"Friday turn on the pumping water","Friday turn off the pumping water",
                "Friday what day today","Friday what is today","Friday maximizing the window GUI",
                "Friday hiding your self","Friday what is the day of the week","Friday Save Identification profile","Friday turn every thing in the room on",
                "Friday turn every thing in the room off","Friday take a photo","Friday turn on the airconditioner","Friday turn off the airconditioner",
                "Friday Open the google","Friday Open the youtube","Friday Open the google map","Friday open the google health care"
                ,"Friday turn living room light on","Friday increasing volume","Friday decreasing volume","Friday mute","Friday Volume up"
                ,"Friday Volume down","Thank you Friday","Friday Cleaning bot network","Friday count down to take photo","Friday remote termios"
                ,"Friday Robot one activate","Friday update the robot","Friday disconnect to my mind","Friday connect with my brain","Friday disable blink"
                ,"Friday can you sing happy birth day for me","Friday save robot address","What is your name","Friday turn on the fan"
                ,"Friday turn off the fan","Friday turn on the Television"
                ,"Friday turn off the Television","Friday turn on every thing","Friday turn off every thing","Friday turn off the light"
                ,"Friday Shutdown everything","Friday what date today","Friday Activated Swarm bot function","Friday de activate swarm",
                "Friday turn on the refisgerator","Friday turn off the refisgerator","Friday who is your creator","Bye bye Friday","Friday Open the facebook"
                ,"Friday Open the social network","Friday What is the weather today","Thank you Friday"});
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>.
              // The function of the grammar resilence added 
            GrammarBuilder grammarbuilder = new GrammarBuilder(command); // Command 88system function input to the grammar builder 
            Grammar grammar = new Grammar(grammarbuilder); // Grammar function buider input 
            Recengine.LoadGrammar(grammar);  // Grammar function input 
            Recengine.LoadGrammar(new DictationGrammar());
            Recengine.SetInputToDefaultAudioDevice(); // Audio input microphone devices  
            Recengine.SpeechRecognized += Speech_recognize;
            Recengine.RecognizeAsync(RecognizeMode.Multiple); // The recognition enable function
            Recengine.EndSilenceTimeout = TimeSpan.FromSeconds(1); // Noise reduce 
            Recengine.EndSilenceTimeoutAmbiguous = TimeSpan.FromSeconds(1); // Noise reducing functino to enable the function of the the noise 
            textBox1.ForeColor = Color.LightGreen;// The color of the text box 
            foreach (var v in Friday.GetInstalledVoices().Select(v => v.VoiceInfo))
            {
                Console.WriteLine("Name:{0}, Gender:{1}, Age:{2}",
                  v.Description, v.Gender, v.Age);
            }

            // select male senior (if it exists)
            Friday.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);

            // select audio device
            Friday.SetOutputToDefaultAudioDevice();

            // build and speak a prompt
            PromptBuilder builder = new PromptBuilder();
            StanfordNLP(); // The function of the stanford NLP 
        }
        private void message(string topic,string message)
        {
            try
            {
               textBox1.Invoke(new System.Action(() => textBox1.AppendText(message + "\n")));
                microgear.Chat(Target, message); // sending the resived message back into the IOT devices 
                if(message == "LivingON")
                {
                    Friday.Speak("The ling room is now turn off");
                }
                if (message == "LivingOFF")
                {
                    Friday.Speak("The ling room is now turn on");
                }
                if (message == "4")
                {
                   // Friday.Speak("Smart watch on line");
                    Friday.Speak(message);
                }
           //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>..
               //The function of the message watch 
                if (message != "4")
                {
                   
                    if (message  =="smart watch online")
                    {
                        Friday.Speak(message);
                        //Friday.Pause();
                        if(message == "0"|| message =="3")  
                        {
                            //Friday.Speak(message);
                            Thread.Sleep(1000);
                            Friday.Pause();
                        }
                    }
                   
                }
             
                


                // int Numberconverter = Int32.Parse(message);


            }
            catch(Exception Error)
            {
                MessageBox.Show(Error.Message); // The function of the Message error will show up in the text box 
            }
        }
       
        private void Speech_recognize(object sender, SpeechRecognizedEventArgs e)
        {
            if(e.Result.Confidence >= 0.9) // Add the function of the confidence display function 
            {
                float percent = e.Result.Confidence * 100;
                this.Text = "Confidence of the command :" +percent +"%"; // The confidence of speech 
                this.BackColor = Color.Blue; 
            }
            else if(e.Result.Confidence < 0.9  && e.Result.Confidence > 0.8)
            {
                float percent = e.Result.Confidence * 100;
                this.Text = "Confidence of the command :" + percent + "%"; // The confidence of speech 
                this.BackColor = Color.SeaShell;
               
            }
            richTextBox1.Text = e.Result.Text;
            switch (e.Result.Text)
            {
                case "Hello Friday":
                    System.Random ree = new System.Random(); // Random functoin of the word  to greeting 
                    int rere = ree.Next(1, 5);
                    switch (rere)
                    {
                        case 1:
                            PopupNotifier popup = new PopupNotifier(); // Pop up notication 
                            popup.Image = Properties.Resources.if___Bell_1904653; // Toast notification popup function 
                            popup.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Added date to pop up when you say hello 
                            popup.TitleColor = Color.White; // The color of the text title output 
                            popup.ContentText = "Hey Hi how are you doing ?"; // Pop up notification popup
                            popup.ContentColor = Color.White; // The Color of the text output 
                            popup.BodyColor = Color.Blue;
                           // popup.Image = Properties.Resources.HitechBackground; // picture at the back ground for the notification system function 
                            popup.Popup();// Show up and popup 
                            Friday.Speak("Hey Hi how are you doing ?");
                          
                            break;
                        case 2:
                            String Date = DateTime.Now.ToString();
                            Friday.Speak("Hello Today is " + Date);  // Telling the detail for you
                            PopupNotifier popup1 = new PopupNotifier(); // Pop up notication 
                            popup1.Image = Properties.Resources.if___Bell_1904653; // Toast notification popup function 
                            popup1.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Added date to pop up when you say hello 
                            popup1.TitleColor = Color.White;  // The title color white // Color text out 
                            popup1.ContentText = Date; // Pop up notification popup 
                            popup1.ContentColor = Color.White; 
                            popup1.BodyColor = Color.Blue; 
                            //popup1.Image = Properties.Resources.HitechBackground;//Picture popup 
                            popup1.Popup();// Show up and popup 
                            break;
                        case 3:
                            DateTime dt = DateTime.Now;   // Function date time 
                            int TimeH = dt.Hour;
                             // The fnction of the popup notification 
                            PopupNotification(TimeH);  // Added to the function of the popup notification running by the TimeH classification function 
                            if (TimeH == 00)
                            {
                                Friday.Speak("Midnight now you have to go to sleep now");
                                System.Random qe = new System.Random();
                                int ee = qe.Next(1, 3);
                                switch (ee)
                                {
                                    case 1:
                                        Friday.Speak("Do you have any help sir ?");
                                        string time1 = DateTime.Now.ToString("h" + "m" + "minute" + "s" + "Second"); 
                                        Friday.Speak("Now" + time1 + "O'clock");
                                        break;

                                    case 2:
                                        Friday.Speak("Do you want to drink any drink ?");
                                        string time2 = DateTime.Now.ToString("h" + "m" + "minute" + "s" + "Second");
                                        Friday.Speak("Now" + time2 + "O'clock");
                                        break;
                                }
                            }
                            if (TimeH >= 5 && TimeH <= 11) // Interval of the morning time 
                            {
                                Friday.Speak("Hello");
                                System.Random we = new System.Random(); //
                                int rent = we.Next(1, 4);
                                switch (rent)
                                {
                                    case 1:
                                        Friday.Speak("Good morning sir ");
                                        break;
                                    case 2:
                                        Friday.Speak("Did you have any break fast yet ? I'm gong to prepare it for you");
                                        microgear.Chat(Target, "FoodGenActivate"); // Function of the Signal food generator function  
                                        string time1 = DateTime.Now.ToString("h" + "m" + "minute" + "s" + "Second");
                                        Friday.Speak("Now" + time1 + "O'clock");
                                        break;
                                    case 3:
                                        Friday.Speak("Did you have any food yet this morning let me bring it for you");
                                        microgear.Chat(Target, "FoodGenActivate"); // Function of the food provder analog function
                                        break;
                                    case 4:
                                        Friday.Speak("Hello sir did you excercise yet for this morning ?");
                                        microgear.Chat(Target, "ExceriseMode"); // activate the excercise mode up to on the time 
                                        break;
                                }
                            }
                            if (TimeH == 12)
                            {
                                Friday.Speak("Good noon sir");
                                System.Random wqq = new System.Random(); // Random the function of the noon 
                                int ert = wqq.Next(1, 3);
                                switch (ert)
                                {
                                    case 1:
                                        Friday.Speak("Hello sir did you have lunch yet? "); 
                                        break;
                                    case 2:
                                        Friday.Speak("Do you need any food ? So that i can bring it for you");
                                        string time1 = DateTime.Now.ToString("h" + "m" + "minute" + "s" + "Second");
                                        Friday.Speak("Now" + time1 + "O'clock");
                                        break;
                                    case 3:
                                        Friday.Speak("What are you doing  sir ?");
                                        break;
                                }
                            }
                            if (TimeH >= 13 && TimeH <= 16)
                            {
                                Friday.Speak("Good after noon sir");
                                System.Random wer = new System.Random(); // Random the function to ask you how do you feel 
                                int errr = wer.Next(1, 3);
                                switch (errr)
                                {
                                    case 1:
                                        Friday.Speak("Would you like to listen to the music ?"); 
                                        break;
                                    case 2:
                                        Friday.Speak("Do you need some dessert  sir ?");
                                        string time1 = DateTime.Now.ToString("h" + "m" + "minute" + "s" + "Second");
                                        Friday.Speak("Now" + time1 + "O'clock");
                                        break;
                                    case 3:
                                        Friday.Speak("Any help sir ?");
                                        break;

                                }

                            }
                            if (TimeH >= 17 && TimeH <= 18) // The function of the Time date alert 
                            {
                                System.Random wert = new System.Random();
                                int wef = wert.Next(1, 3);
                                switch (wef)
                                {
                                    case 1:
                                        Friday.Speak("Good Evening sir");
                                        break;
                                    case 2:
                                        string time1 = DateTime.Now.ToString("h" + "m" + "minute" + "s" + "Second");
                                        Friday.Speak("Now" + time1 + "O'clock");
                                        Friday.Speak(" Would you like to have any drink or Dinner ?");
                                        break;
                                    case 3:
                                        Friday.Speak("did you have any  dinner yet ?");
                                        break;
                                }
                            }
                            if (TimeH >= 19 && TimeH <= 23) 
                            {
                                System.Random Reo = new System.Random(); // Random function of the anwser and question 
                                int doe = Reo.Next(1, 3);
                                switch (doe)
                                {
                                    case 1:
                                        Friday.Speak("Hello sir what are you doing ?");
                                        break;
                                    case 2:
                                        Friday.Speak("I will prepare every thing to be ready before you go to sleep");
                                        break;
                                    case 3:
                                        Friday.Speak("Do you need any drink this night ?");
                                        break;
                                }
                            }
                            break;
                        case 4:  // The function of the weather reminder on the system to remind you the temperature that app normal 
                     
                            Friday.Speak("Today temperature is ");
                            // Thread.Sleep(500);
                            //Friday.Speak("I'm showing you in the popup notification");
                            string url34 = CurrentUrl.Replace("@LOC@", "Bangkok");
                            GetFormattedXml(url34, "temperature");
                            GetFormattedXml(url34, "Pressure");
                            GetFormattedXml(url34, "Humid");
                            GetFormattedXml(url34, "Cloud");
                            //  GetFormattedXml(url, "WindDirection");
                            Thread.Sleep(1000);
                            /*url = ForecastUrl.Replace("@LOC@", richTextBox1.Text);
                           GetFormattedXml(url, "temperature","Pressure","Humid", "CloudValue","WinSpeed","WindDirection");*/
                            richTextBox1.ForeColor = Color.AliceBlue;

                            break;

                    }
                    break;
                case "Bye bye Friday":
                    System.Random re = new System.Random();
                    int tt = re.Next(1, 4);
                    switch (tt)
                    {
                    case 1:
                    Friday.Speak("See you soon sir");
                    break;
                    case 2:
                            Friday.Speak("Bye bye sir");
                    break;
                    case 3:
                        Friday.Speak("See you later");
                    break;
                   case 4:
                    Friday.Speak("See you tomorrow");        
                   break;
                    }
                break;
                case "Friday who is your creator":

                    Interview(); // Function of interview 
                 break;

                case "Friday what date today":
                    String Date120 = DateTime.Now.ToString();
                   
                    if (e.Result.Confidence > 0.9)
                    {
                        PopupNotifier poptr = new PopupNotifier();
                        poptr.TitleText = "F.R.I.D.A.Y A.I. Neurallace";
                        poptr.TitleColor = Color.White; // The title text color 
                        poptr.ContentText = "Today is"+Date120;// The content text 
                        poptr.ContentColor = Color.White; // the color of the content 
                        poptr.Popup();
                    }
                    Friday.Speak("Today is "+ Date120);// reply you dat and time // The function of the date pop up 
                    PopupNotification(1);
                    break;
                case "Friday Shut the system down":
                    //      pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;
                    try
                    {
                        Friday.Speak("Good bye sir");
                        this.Close(); // Close the window off
                    }
                    catch (Exception erer)
                    {
                        Friday.Speak("Please not iteration command on me");
                        MessageBox.Show(erer.Message);
                    }
                    break;
                case "Friday open the window":
                    microgear.Chat(Target, "WindowON");
                    Friday.Speak("Now i'm  openning  the window for you");
                    // pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;
                    break;
                case "Friday close the window":
                    microgear.Chat(Target, "WindowOFF");
                    PopupNotifier Popup45 = new PopupNotifier(); // The popup notification system 
                    Popup45.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; //The A.I. function of the neurallace notification systm 
                    Popup45.TitleColor = Color.White; // The color white for the content notificatoin 
                    Popup45.ContentText = "Close the window for you now .";
                    Popup45.BodyColor = Color.Blue; // The color notification system 
                    Popup45.Popup(); // The function of the popup command 
                    Friday.Speak("Ok sir now i'm closing the window for you");
                    // pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;
                    break;
                case "Friday turn on the refisgerator":
                    microgear.Chat(Target, "TurnOnRefeeze"); // Turn on the refisgerator 
                 break;
                case "Friday turn off the refisgerator ":
                    PopupNotifier popup34 = new PopupNotifier(); // The function of popup notification system 
                    popup34.TitleText = "F.R.I.D.A.Y A.I. Neurallace";
                    popup34.TitleColor = Color.White; // The color notificaion function 
                    popup34.ContentText = "Turn off the refisgerator";
                    popup34.BodyColor = Color.Blue; // The blue color for the body 
                    popup34.Popup();
                    microgear.Chat(Target, "TurnOffRefeeze"); // Turn off the refisgerator
                break;
                case "Friday bed room light on":
                    try
                    {
                        PopupNotifier popup4 = new PopupNotifier(); // Pop up notication 
                        popup4.Image = Properties.Resources.if_Lightbulb_728950; // Toast notification popup function 
                        popup4.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Added date to pop up when you say hello 
                        popup4.TitleColor = Color.White; // The white color for content 
                        popup4.ContentText = "I'm going to turn the light on"; // Pop up notification popup 
                        popup4.ContentColor = Color.White; // The color for the content text  
                        popup4.BodyColor = Color.Blue;// The body color for the  
                       // popup2.Image = image;
                        popup4.Popup();// Show up and popup
                        Friday.Speak("Ok turn on the bed room light for you now sir");
                        // pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;
                        microgear.Chat(Target, "BedroomOff");
                    }
                    catch (Exception ere)
                    {
                        MessageBox.Show(ere.Message);
                    }
                    break;
                case "Friday bed room light off":
                    PopupNotifier popup45 = new PopupNotifier();  // The popup notification system 
                    popup45.TitleText = "F.R.I.D.A.Y A.I. Neurallace";
                    popup45.TitleColor = Color.White; // White color of the text 
                    popup45.ContentText = "Bed room light now turn on ";
                    popup45.ContentColor = Color.White; // The color 
                    popup45.Popup(); // The command to mak the notification popup 
                    Friday.Speak("Ok turn off the bed room light for you now sir");
                    // pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;
                    microgear.Chat(Target, "BedroomON");
                    break;
                case "Friday turn living room light on": 
                    Friday.Speak("Ok sir now i'm turing the light on for you");
                    // pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;
                    pictureBox1.Image = FRIDAY_Neurallace.Properties.Resources.Light_up_scene;
                    microgear.Chat(Target, "LivingOFF");
                    break;
                case "Friday living room light off":
                    Friday.Speak("Ok sir now i'm turing the light off for you");
                    // pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;
                    pictureBox1.Image = FRIDAY_Neurallace.Properties.Resources.Light_OFF_scene;
                    microgear.Chat(Target, "LivingON");
                    break;
                case "Friday What date today":
                    String Date1 = DateTime.Now.ToString();
                    Friday.Speak("Today is " + Date1);  // Telling the detail for you
                    break;
                case "Friday What time is it":
                    string time = DateTime.Now.ToString("h" + "m" + "minute" + "s" + "Second");
                    Friday.Speak("Now time is " + time + "O'clock");
                    break;
                case "Friday turn on the pump":
                    microgear.Chat(Target, "PumpOFF");
                    Friday.Speak("Ok sir now i'm turning on the pumping water for you");
                    break;
                case "Friday turn off the pump":
                    microgear.Chat(Target, "PumpON");
                    Friday.Speak("Turn off the pumping water for you now sir");
                    break;
                case "Friday turn every thing in the room on":
                    Friday.Speak("Now i'm turnning everything on for you");
                    microgear.Chat(Target, "LivingOFF");
                    microgear.Chat(Target, "WindowOFF");
                    microgear.Chat(Target, "BedroomOFF");
                    break;
                case "Friday turn every thing in the room off":
                    Friday.Speak("Now i'm turning every thing off for you");
                    microgear.Chat(Target, "LivingON");
                    microgear.Chat(Target, "WindowON");
                    microgear.Chat(Target, "BedroomON");
                    break;
                case "Friday what is the day of the week":
                    if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Monday)
                    {
                        // pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;

                        Friday.Speak("The day of the week  is " + "Monday");
                        String Date10 = DateTime.Now.ToString();
                        Friday.Speak(" Today is " + Date10);  // Telling the detail for you
                        microgear.Chat(Target, "Today :Mon");
                        Thread.Sleep(500);
                        microgear.Chat(Target,Date10);
                    }
                    if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        Friday.Speak("The day of the week  " + "Tuesday");
                        String Date10 = DateTime.Now.ToString();
                        Friday.Speak(" Today is " + Date10);  // Telling the detail for you
                                                              //pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;
                        microgear.Chat(Target, "Today :Tue");
                        Thread.Sleep(500);
                        microgear.Chat(Target, Date10);
                    }

                    if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        Friday.Speak("The day of the week  " + "Wednesday");
                        String Date10 = DateTime.Now.ToString();
                        Friday.Speak(" Today is " + Date10);  // Telling the detail for you
                                                              // pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;
                        microgear.Chat(Target, "Today :Wed");
                        Thread.Sleep(500);
                        microgear.Chat(Target, Date10);
                    }
                    if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Thursday) // The datetime picker 
                    {
                        Friday.Speak("The day of the week " + "Thursday");
                        String Date10 = DateTime.Now.ToString();
                        Friday.Speak(" Today is " + Date10);  // Telling the detail for you
                                                              //  pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;

                        microgear.Chat(Target, "Today :Thur");
                        Thread.Sleep(500);
                        microgear.Chat(Target, Date10);
                    }
                    if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Friday)
                    {
                        Friday.Speak("The day of the week  " + "Friday");
                        String Date10 = DateTime.Now.ToString();
                        Friday.Speak(" Today is " + Date10);  // Telling the detail for you
                                                              //  pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;
                        microgear.Chat(Target, "Today :Fri");
                        Thread.Sleep(500);
                        microgear.Chat(Target, Date10);
                    }
                    if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Saturday)
                    {

                        Friday.Speak("The day of the week " + "Saturday");
                        String Date10 = DateTime.Now.ToString();
                        Friday.Speak(" Today is " + Date10);  // Telling the detail for you
                                                              //     pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;
                        microgear.Chat(Target, "Today :Sat");
                        Thread.Sleep(500);
                        microgear.Chat(Target, Date10);
                    }
                    if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Sunday)
                    {
                        Friday.Speak("The day of the week " + "Sunday");
                        String Date10 = DateTime.Now.ToString();
                        Friday.Speak(" Today is " + Date10);  // Telling the detail for you
                                                              //  pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;
                        microgear.Chat(Target, "Today :Sun");
                        Thread.Sleep(500);
                        microgear.Chat(Target, Date10);
                    }


                    break;
                case "Friday maximizing the window GUI":
                    PopupNotifier popup3 = new PopupNotifier(); // Pop up notication 
                    popup3.Image = Properties.Resources.sick_5_128; // Toast notification popup function 
                    popup3.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Added date to pop up when you say hello 
                    popup3.TitleColor = Color.White; // The color of the text title
                    popup3.ContentText = "I got it sir ,Now maximizing window "; // Pop up notification popup 
                    popup3.ContentColor = Color.White;  //The  color of the Text content 
                    popup3.BodyColor = Color.Blue;
                    //popup2.Image = Properties.Resources.HitechBackground;
                    popup3.Popup();// Show up and popup
                    this.WindowState = FormWindowState.Maximized;
                    Friday.Speak("I got it sir");
                    // pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;

                    break;
                case "Friday hiding your self":
                    PopupNotifier popup2 = new PopupNotifier(); // Pop up notication 
                    popup2.Image = Properties.Resources.spy_user_agent_webroot_undercover_128; // Toast notification popup function 
                    popup2.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Added date to pop up when you say hello 
                    popup2.TitleColor = Color.White;
                    popup2.ContentText = "Ok sir ,i'm hiding myself "; // Pop up notification popup 
                    popup2.ContentColor = Color.White;
                    popup2.BodyColor = Color.Blue;
                    //popup2.Image = Properties.Resources.HitechBackground;
                    popup2.Popup();// Show up and popup
                    this.WindowState = FormWindowState.Minimized;
                    Friday.Speak("Ok sir !");
                    // pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;

                    //pictureBox2.Image = Friday_Home_Automation_Assistance.Properties.Resources.Hitech_Globl;
                    break;
                case "Friday take a photo":
                    PopupNotifier popup5 = new PopupNotifier(); // Pop up notication 
                    popup5.Image = Properties.Resources.Camera; // Toast notification popup function 
                    popup5.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Added date to pop up when you say hello 
                    popup5.TitleColor = Color.White; // Color of the title 
                    popup5.ContentText = "Ok, sir i'm taking a photo"; // Pop up notification popup
                    popup5.ContentColor = Color.White;  
                    popup5.BodyColor = Color.Blue;
                    //popup2.Image = Properties.Resources.HitechBackground;
                    popup5.Popup();// Show up and popup
                    Friday.Speak("Okay sir ?");
                    saveToFile = !saveToFile; // Friday taking a photoes  
                    break;
                case "Friday Save Identification profile":
                    Friday.Speak("Now i'm saving the Identificaion profile");
                    PopupNotifier popup23 = new PopupNotifier(); // Popup identification profile adding new 
                    popup23.Image = Properties.Resources.Drive_C;
                    popup23.TitleText = "F.R.I.D.A.Y A.I."; // The text title for the popup notification 
                    popup23.ContentText = "Now i'm saving the identification profiler";
                    popup23.ContentColor = Color.White;
                    popup23.BodyColor = Color.Blue; 
                    popup23.TitleColor = Color.White;
                    popup23.ContentFont = Font.DeepClone();
                    popup23.Popup();   // Adding function to popup the clorful texture  
                    Properties.Settings.Default["Routine1"] = textBox2.Text; // Setting the information and save the data for the User
                    Properties.Settings.Default["Routine2"] = textBox3.Text;
                    Properties.Settings.Default["Routine3"] = textBox4.Text;
                    Properties.Settings.Default["Routine4"] = textBox5.Text;
                    Properties.Settings.Default["Routine5"] = textBox10.Text;
                    Properties.Settings.Default.Save();
                    break;
                case "Friday save robot address":
                    Friday.Speak("Now i'm saving the robots IP address for you ");
                    Properties.Settings.Default["Routine6"] = textBox6.Text;
                    Properties.Settings.Default["Routine7"] = textBox7.Text;
                    Properties.Settings.Default["Routine8"] = textBox8.Text;
                    Properties.Settings.Default["Routine9"] = textBox9.Text;
                    Properties.Settings.Default["Routine12"] = textBox12.Text;
                    Properties.Settings.Default["Routine13"] = textBox13.Text;
                    Properties.Settings.Default["Routine14"] = textBox14.Text; 
                    Properties.Settings.Default.Save(); // The function saving the IP address 
                    break;
                case "Friday turn on the airconditioner":
                    PopupNotifier popup2344 = new PopupNotifier(); // Function of the popup Notifier function 
                    popup2344.TitleText = "F.R.I.D.A.Y A.I. Neurallace";  // Pop up notification text
                    popup2344.TitleColor = Color.White; // Color for the text title 
                    popup2344.Image = Properties.Resources._113_128;  // The picture display the air
                    popup2344.ContentText = "Turn on the Airconditioner"; // The functionof turning on the Airconditioner
                    popup2344.ContentColor = Color.White; // Content text color function 
                    popup2344.BodyColor = Color.Blue; // The body color is blue 
                    popup2344.Popup(); // The function of the popup Added 
                    Friday.Speak("Turn airconditioner on for you now sir");
                    microgear.Chat(Target, "AirconditionOFF");
                    break;
                case "Friday turn off the airconditioner":
                    PopupNotifier popup2345 = new PopupNotifier(); // Function of the popup Notifier function 
                    popup2345.TitleText = "F.R.I.D.A.Y A.I. Neursllace";// Pop up notification text
                    popup2345.TitleColor = Color.White; // Color for the text title 
                    popup2345.ContentText = "Turn OFF the Airconditioner";// The functionof turning on the Airconditioner
                    popup2345.ContentColor = Color.White; // Content text color function 
                    popup2345.BodyColor = Color.Blue; // The body color is blue 
                    popup2345.Popup(); // The function of the popup Added 
                    microgear.Chat(Target, "AirconditionON");// The function of the Airconditioner  turn on 
                    Friday.Speak("Turn airconditioner off for you now sir"); // The Ariconditioner system for the Home Automation  
                    break;
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>...
                // The Social net work and google search engine
                case "Friday Open the google":
                    PopupNotifier popup24 = new PopupNotifier(); // Pop up notifier for the google web link 
                    popup24.TitleText = "F.R.I.D.A.Y A.I. Neurallace";
                    popup24.ContentText = "Openning the google ";
                    popup24.Image = Properties.Resources.Googlepic; 
                    popup24.TitleColor = Color.White;
                    popup24.BodyColor = Color.Blue; // The blue color function for the Blue notification color 
                    popup24.ContentColor = Color.White; 
                    popup24.Popup();
                    System.Diagnostics.Process.Start("https://www.google.co.th/?gws_rd=cr,ssl&ei=erBVWbHJMsXjvgTaxayoCQ"); // The link for the 
                    break;
                case "Friday Open the social network":
                    PopupNotifier popup25 = new PopupNotifier(); // Pop up notifier for the facebook web link 
                    popup25.TitleText = "F.R.I.D.A.Y A.I. Neurallace";
                    popup25.ContentText = "Openning the facebook ";
                    popup25.Image = Properties.Resources.square_facebook_128; 
                    popup25.TitleColor = Color.White;
                    popup25.BodyColor = Color.Blue;
                    popup25.ContentColor = Color.White;
                    popup25.Popup();
                    System.Diagnostics.Process.Start("https://www.facebook.com");
                break;
                case "Friday Open the youtube":
                    PopupNotifier popup233 = new PopupNotifier(); //popup notification for the youtube web link 
                    popup233.TitleText = "F.R.I.D.A.Y A.I. Neurallace";
                    popup233.BodyColor = Color.Blue; // Body color for the notification pop up is blue 
                    popup233.ContentText = "Openning the youtube"; // Openning the youtube link and say openning  
                    popup233.ContentColor = Color.White; // The color function of the content color to show up the color function 
                    popup233.TitleColor = Color.White; // The color White for the text color notification 
                    popup233.Popup();  // End function and say popup 
                    System.Diagnostics.Process.Start("https://www.youtube.com/?gl=TH");
                    break;
                case "Friday Open the google map":
                    PopupNotifier popup2334 = new PopupNotifier(); // Pop up for the google map notification function 
                    popup2334.TitleText = " F.R.I.D.A.Y A.I."; //Popup notification function 
                    popup2334.TitleColor = Color.White; // The function of the white color White 
                    popup2334.ContentText = "Openning the google map"; // Text to the notification to alert the notification 
                    popup2334.ContentColor = Color.White;
                    popup2334.BodyColor = Color.Blue; // The color of the bodyblue   
                    popup2334.Popup(); 
                    System.Diagnostics.Process.Start("https://www.google.co.th/maps");

                    break;
                case "Friday open the google health care":
                    PopupNotifier popup2333 = new PopupNotifier(); // The function of the popup notification 
                    popup2333.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; //The function of the Title dispay 
                    popup2333.TitleColor = Color.White; // The function of title color of the function notification system 
                    popup2333.BodyColor = Color.Blue;
                    popup2333.ContentText = "Openning the google health care"; //The function of the contentText
                    popup2333.ContentColor = Color.White; // The color of the content notification system    
                    popup2333.Popup();
                    System.Diagnostics.Process.Start("https://gsuite.google.com/industries/healthcare/");
                    break;
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 

                case "Friday toilet light on":
                    PopupNotifier popup2444 = new PopupNotifier();
                    popup2444.TitleText = "F.R.I.D.A.Y A.I. Neurallace";
                    popup2444.TitleColor = Color.White; // The function text title display color white 
                    popup2444.ContentText = "Turn on the Toilet light";
                    popup2444.ContentColor = Color.White; // The function of the white color of the content
                    popup2444.Popup(); // popup notification  
                    microgear.Chat(Target, "ToiletON");
                    Friday.Speak("Ok sir toilet light is now turn on");
                    break;
                case "Friday toilet light off":
                    PopupNotifier popup2445 = new PopupNotifier(); //The function of the popup notification function  
                    popup2445.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Neurallace function for the  
                    popup2445.TitleColor = Color.White;
                    popup2445.Image = Properties.Resources.Light_OFF_scene;  // Ligt off for the notificatio
                    popup2445.ContentText = "Turn off the Toilet light"; // The function of the content  
                    popup2445.BodyColor = Color.Blue; // The body color blue 
                    popup2445.Popup(); // Popup notification function for the reminder function 
                    microgear.Chat(Target, "ToiletOFF");
                    Friday.Speak("Ok sir toilet light is now turn off");
                    break;
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // Volume up and volume down the sound sub function 
                case"Friday increasing volume":     
                    System.Random Randi2 = new System.Random();
                    int ran2 = Randi2.Next(1, 3);
                    switch (ran2)
                    {
                        case 1:
                            int i;
                            for (i = 1; i <= 4; i++)
                            {
                                VolUp();
                                if (i == 4)
                                {
                                    Friday.Speak("For you sir ");
                                }
                            }
                            break;
                        case 2:

                            for (i = 1; i <= 4; i++)
                            {
                                VolUp();
                                if (i == 4)
                                {
                                    Friday.Speak("As you wish sir");
                                }
                            }
                            break;

                        case 3:


                            for (i = 1; i <= 4; i++)
                            {
                                VolUp();
                                if (i == 4)
                                {
                                    Friday.Speak("Oksir");
                                }
                            }
                            break;

                    }
                    break;

                case "Friday decreasing volume":
                    System.Random Randi = new System.Random();
                    int ran = Randi.Next(1, 3);
                    switch (ran)
                    {
                        case 1:

                            int i;
                            for (i = 1; i <= 4; i++)
                            {
                                VolDown();
                                if (i == 4)
                                {
                                    Friday.Speak("For you sir");
                                }
                            }


                            break;
                        case 2:

                            for (i = 1; i <= 4; i++)
                            {
                                VolDown();
                                if (i == 4)
                                {
                                    Friday.Speak("As you wish sir");
                                }
                            }
                            break;

                        case 3:

                            for (i = 1; i <= 4; i++)
                            {
                                VolDown();
                                if (i == 4)
                                {
                                    Friday.Speak("Ok sir");
                                }
                            }
                            break;

                    }
                    break;

                case "Friday mute":
                    System.Random Randi1 = new System.Random();
                    int ran1 = Randi1.Next(1, 3);
                    switch (ran1)
                    {
                        case 1:
                            Mute();
                            Friday.Speak("For you sir");

                            break;
                        case 2:
                            Mute();
                            Friday.Speak("As you wish sir"); 
                            break;

                        case 3:
                            Mute();
                            Friday.Speak("Ok sir");
                            break;

                    }
                    break;
                case "Friday Volume up":
                    int j;
                    for (j = 1; j <= 20; j++)
                    {
                        VolUp();
                        System.Random Ranr = new System.Random();
                        int er = Ranr.Next(1, 3);
                        if (j == 20)
                        {
                            switch (er)
                            {
                                case 1:
                                    Friday.Speak(" As you wish sir");

                                    break;
                                case 2:
                                    Friday.Speak("Ok sir now i do itfor you ");
                                    break;
                                case 3:

                                    Friday.Speak("Ok sir ");
                                    break;
                            }
                        }
                    }

                    break;
                case "Friday Volume down":
                    int R;
                    for (R = 1; R <= 20; R++)
                    {
                        VolDown();
                        System.Random Ranr = new System.Random();
                        int er = Ranr.Next(1, 3);
                        if (R == 10)
                        {
                            switch (er)
                            {
                                case 1:
                                    Friday.Speak(" As you wish sir");

                                    break;
                                case 2:
                                    Friday.Speak("Ok sir now i do for you ");
                                    break;
                                case 3:

                                    Friday.Speak("Ok sir ");
                                    break;
                            }
                        }
                    }

                    break;
                case "Friday turn on the fan":  
                    PopupNotifier popup234 = new PopupNotifier(); // The function of the popup notification 
                    popup234.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; //The function of the Title dispay 
                    popup234.TitleColor = Color.White; // The function of title color of the function notification system 
                    popup234.BodyColor = Color.Blue;
                    popup234.ContentText = "Turn on the fan for you now"; //The function of the contentText
                    popup234.ContentColor = Color.White; // The color of the content notification system    
                    popup234.Popup();
                    Friday.Speak(" Ok sir the fan turn on");
                    microgear.Chat(Target, "FanON");
                break;
                case "Friday turn off the fan":
                    PopupNotifier popup2343 = new PopupNotifier(); // The function of the popup notification 
                    popup2343.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; //The function of the Title dispay 
                    popup2343.TitleColor = Color.White; // The function of title color of the function notification system 
                    popup2343.BodyColor = Color.Blue;
                    popup2343.ContentText = "Turn off the fan for you now"; //The function of the contentText
                    popup2343.ContentColor = Color.White; // The color of the content notification system    
                    popup2343.Popup();
                    Friday.Speak(" Fan off now sir");
                    microgear.Chat(Target, "FanOFF");
                break;
                case "Friday turn on the Television":
                    PopupNotifier popup2353 = new PopupNotifier(); // The function of the popup notification 
                    popup2353.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; //The function of the Title dispay 
                    popup2353.TitleColor = Color.White; // The function of title color of the function notification system 
                    popup2353.BodyColor = Color.Blue;
                    popup2353.ContentText = "Turn on the Television for you now "; //The function of the contentText
                    popup2353.ContentColor = Color.White; // The color of the content notification system    
                    popup2353.Popup();
                    Friday.Speak("Television on");
                    microgear.Chat(Target, "TeleOFF");
                break;
                case "Friday turn off the Television":
                    PopupNotifier popup2354 = new PopupNotifier(); // The function of the popup notification 
                    popup2354.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; //The function of the Title dispay 
                    popup2354.TitleColor = Color.White; // The function of title color of the function notification system 
                    popup2354.BodyColor = Color.Blue;
                    popup2354.ContentText = "Turn off the Television for you now "; //The function of the contentText
                    popup2354.ContentColor = Color.White; // The color of the content notification system    
                    popup2354.Popup();
                    Friday.Speak("Television Off");
                    microgear.Chat(Target, "TeleON");
                break;
                case"Friday turn on every thing":
                    microgear.Chat(Target,"WindowOFF");
                    microgear.Chat(Target, "FanON");
                    microgear.Chat(Target, "TeleOFF");
                    Friday.Speak("Now i'm turning every thing on");
                break;
                case"Friday turn off every thing":
                    microgear.Chat(Target, "WindowON");
                    microgear.Chat(Target, "FanOFF");
                    microgear.Chat(Target, "TeleON");
                    Friday.Speak("Now i'm turning every thing off");
               break;
                case "Friday turn on the light":
                    microgear.Chat(Target, "WindowON");
                    Friday.Speak("Ok sir light turn on");
               break;
                case "Friday turn off the light":
                    microgear.Chat(Target, "WindowOFF");
                    Friday.Speak("Ok sir light turn off");
               break;
                case"Friday What is the weather today": // All function report 
                    // Compose the query URL.
                    Friday.Speak("Today temperature is ");
                   // Thread.Sleep(500);
                    //Friday.Speak("I'm showing you in the popup notification");
                    string url = CurrentUrl.Replace("@LOC@","Bangkok");
                     GetFormattedXml(url,"temperature");
                     GetFormattedXml(url, "Pressure");
                    GetFormattedXml(url, "Humid");
                    GetFormattedXml(url, "Cloud");
                //  GetFormattedXml(url, "WindDirection");
                    Thread.Sleep(1000);
                     /*url = ForecastUrl.Replace("@LOC@", richTextBox1.Text);
                    GetFormattedXml(url, "temperature","Pressure","Humid", "CloudValue","WinSpeed","WindDirection");*/
                    richTextBox1.ForeColor = Color.AliceBlue;  
                  break;
                case "Friday What is the Temperature today":  // Only the temperature show in the system function 
                    // Compose the query URL.
                    Friday.Speak("Today temperature is ");
                    // Thread.Sleep(500);
                    //Friday.Speak("I'm showing you in the popup notification");
                    string url1 = CurrentUrl.Replace("@LOC@", "Bangkok");
                     GetFormattedXml(url1, "temperature");
                    Thread.Sleep(1000);
                    url1 = ForecastUrl.Replace("@LOC@", richTextBox1.Text);
                     GetFormattedXml(url1, "temperature");
                    richTextBox1.ForeColor = Color.AliceBlue;
                    break;
                case "Friday What is the pressure today": //pressure
                    // Compose the query URL.
                    Friday.Speak("Today temperature is ");
                    // Thread.Sleep(500);
                    //Friday.Speak("I'm showing you in the popup notification");
                    string url2 = CurrentUrl.Replace("@LOC@", "Bangkok");
                     GetFormattedXml(url2, "Pressure");
                    Thread.Sleep(1000);
                    //url2= ForecastUrl.Replace("@LOC@", richTextBox1.Text);
                    //richTextBox1.Text = GetFormattedXml(url2, "", "Pressure", "", "", "", "");
                    richTextBox1.ForeColor = Color.AliceBlue;
                    break;
                case "Friday What is the Humidity today": // Humidity 
                    Friday.Speak("Today temperature is ");
                    // Thread.Sleep(500);
                    //Friday.Speak("I'm showing you in the popup notification");
                    string url3 = CurrentUrl.Replace("@LOC@", "Bangkok");
                    GetFormattedXml(url3, "Humid");
                    Thread.Sleep(1000);
                    //url3 = ForecastUrl.Replace("@LOC@", richTextBox1.Text);
                    //richTextBox1.Text = GetFormattedXml(url3, "", "", "Humid", "", "", "");
                    richTextBox1.ForeColor = Color.AliceBlue;

                    break;

                case "Thank you Friday":
                    System.Random ered = new System.Random();
                    int er1 = ered.Next(1, 3);
                    switch (er1)
                    {
                        case 1:
                            Friday.Speak("You are very welcome sir");

                            break;
                        case 2:
                            Friday.Speak("Sure thing sir");

                            break;
                        case 3:
                            Friday.Speak("I'm happy to help you sir");
                            break;
                    }
                    break;
                case "Friday Cleaning bot network":
                    Friday.Speak("Ok sir now i'm running the robotics network");
                    // RoboticNetwork();
                    break;

                case "Friday count down to take photo":
                    int w;
                    Friday.Speak("I'm going to take a photo now in 5 seccond");
                    for (w = 5; w >= 1; w--)
                    {
                        String count = w.ToString();
                        Friday.Speak(count);
                        if (w == 1)
                        {
                            saveToFile = !saveToFile;
                            Friday.Speak("On your desktop now sir");
                        }
                    }

                    break;
                case "What is your name":  // Before people know the name of the friday will ask for this question 
                       // Random the answer  3 state of the answer 
                    System.Random Rane = new System.Random();
                    int re2 = Rane.Next(1, 3);
                    switch (re2)
                    {
                     case 1:
                    Friday.Speak("You can call me Friday");
                    break;
                   case 2:
                    Friday.Speak("My name is Friday");
                    break;
                    case 3:
                    Friday.Speak("Call Me Friday");   
                    break;          
                    } 
                    break;
                case"Friday Shutdown everything":
                    Friday.Speak("Oh sir i will shut down every thing");
                    
                    break;
                case "Friday remote the drone":
                    try
                    {
                        using (var client = new SshClient("192.168.1.59", "pi", "raspberry"))  // Using the Jornbot network to access
                        {
                            PopupNotifier Popi = new PopupNotifier(); // The popup notification system function 
                            Popi.TitleText = "F.R.I.D.A.Y  A.I. Neurallace"; // The function of the neurallace notification function 
                            Popi.TitleColor = Color.White; // The color white for the notification function 
                            Popi.Image = Properties.Resources.Search_Engine_Spider_128;// The remote robot function online 
                            Popi.ContentText = "Remotoe Termios remote the swarm robots"; //The functioni of the remotng robots 
                            Popi.ContentColor = Color.White;
                            Popi.BodyColor = Color.Blue; // The color blue for the body color function 
                            Popi.Popup(); // The function of the popup notification function system for the message reply 
                            client.Connect();
                            SshCommand cmd = client.RunCommand("tightvncserver");  // Tightvncserver access so you just now able to access by using only password 
                            var reader = new System.IO.StreamReader(cmd.ExtendedOutputStream);
                            richTextBox1.Text = reader.ReadToEnd();
                            cmd = client.RunCommand("sudo python SSHbot.py");
                            Friday.Speak("Successfully connect to the drone 1");
                            richTextBox1.ForeColor = Color.Blue;
                            richTextBox1.Text = "\n Automatic command Drone activated";
                            client.Disconnect();
                            client.Dispose();
                        }

                    }
                    catch
                    {
                        PopupNotifier popdrone = new PopupNotifier(); // The fuction to remind the error 
                        popdrone.TitleText = "Drone remote crashed !! ";
                        popdrone.TitleColor = Color.White; // the popup front color 
                        popdrone.ContentColor = Color.White;   
                        popdrone.BodyColor = Color.Blue;
                        popdrone.Popup();        
                    }

                    break;
                case "Friday remote termios":

                    Friday.Speak("Robot SSH remote connection ");
                    String IPaddress1 = Settings.Default["Routine6"].ToString();
                    String IPaddress2 = Settings.Default["Routine7"].ToString();
                    String IPaddress3 = Settings.Default["Routine8"].ToString();
                    String IPaddress4 = Settings.Default["Routine9"].ToString();
                    microgear.Chat(Target, "Remote");
                    try
                    {
                        using (var client = new SshClient("192.168.1.36", "pi", "raspberry"))  // Using the Jornbot network to access
                        {
                            PopupNotifier Popi = new PopupNotifier(); // The popup notification system function 
                            Popi.TitleText = "F.R.I.D.A.Y  A.I. Neurallace"; // The function of the neurallace notification function 
                            Popi.TitleColor = Color.White; // The color white for the notification function 
                            Popi.Image = Properties.Resources.Search_Engine_Spider_128;// The remote robot function online 
                            Popi.ContentText = "Remotoe Termios remote the swarm robots"; //The functioni of the remotng robots 
                            Popi.ContentColor = Color.White;
                            Popi.BodyColor = Color.Blue; // The color blue for the body color function 
                            Popi.Popup(); // The function of the popup notification function system for the message reply 
                            client.Connect();
                            SshCommand cmd = client.RunCommand("tightvncserver");  // Tightvncserver access so you just now able to access by using only password 
                            var reader = new System.IO.StreamReader(cmd.ExtendedOutputStream);
                            richTextBox1.Text = reader.ReadToEnd();
                            cmd = client.RunCommand("sudo python SSHbot.py");
                            Friday.Speak("Successfully connect to the cleaning robot 1");
                            richTextBox1.ForeColor = Color.Blue;
                            richTextBox1.Text = "\n Automatic command Cleaning Robot 1 activated";
                            client.Disconnect();
                            client.Dispose();
                        }

                    }
                   
                    catch
                    {
                        microgear.Chat(Target, "FailCon");

                        Console.WriteLine("SSH fail connection i will try another IP address");
                        Friday.Speak("Fail connection i will try another robot networking");
                        try
                        {
                            using (var client = new SshClient("192.168.1.43", "pi", "bananapi"))  // Using the Jornbot network to access
                            {
                                client.Connect();
                                SshCommand cmd = client.RunCommand("su");  // Tightvncserver access so you just now able to access by using only password 
                                cmd = client.RunCommand("bananapi");
                                cmd = client.RunCommand("cd microgear-python");
                                Friday.Speak("Successfully connect to the  pratro drone");
                                /*
                                string reply = string.Empty;
                                shellStream = client.CreateShellStream("dumb", 80, 24, 800, 600, 1024);
                                reply = shellStream.Expect(new Regex(@":.*>#"), new TimeSpan(0, 0, 3));
                                richTextBox1.Text = "Connected please enter command\r\n#";
                                */
                                richTextBox1.ForeColor = Color.Red;
                                richTextBox1.Text = "\n\n Automatic command Cleaning Robot 1 Fail connection";
                                Thread.Sleep(1000);
                                client.Disconnect(); client.Dispose();

                            }

                        }
                        catch
                        {

                            Friday.Speak("I will try another IP address connection ");
                            try
                            {
                                using (var client = new SshClient(IPaddress3, "ubuntu", "ubuntu"))  // Using the Jornbot network to access
                                {
                                    client.Connect();
                                    SshCommand cmd = client.RunCommand("cd Cleaning robot");  // Tightvncserver access so you just now able to access by using only password 
                                    cmd = client.RunCommand("python CleaningBotSSH.py");
                                    Friday.Speak("Successfully connect to auto mate robot ");
                                    richTextBox1.ForeColor = Color.Green;
                                    richTextBox1.Text = "\n\n\n Automatic command Cleaning Robot 2 acivated ";
                                    Thread.Sleep(1000);
                                    client.Disconnect();
                                    client.Dispose();

                                }

                            }
                            catch
                            {
                                Friday.Speak("All robotic network connection fail");
                                Friday.Speak("Please check your connection of the Sentien Robotics networking");
                            }
                        }
                    }
                    break;
                case"Friday Activated Swarm bot function": // The Swarm activate function 
                    System.Random YE = new System.Random(); // The function randoming the swarmbot word speech activation 
                    int Yw = YE.Next(1, 3); //The cal random 
                    switch(Yw)
                    {
                        case 1:
                            Friday.Speak("Activate the Swarmbot");
                            Swarmbotmultiple_activation("Swarmactive");
                        break;

                        case 2:
                            Friday.Speak("Ok sir now i'm activated the swarm bot function");
                            Swarmbotmultiple_activation("Swarmactive");
                            break;

                        case 3:
                            Friday.Speak("Activated the Swarmbot");
                            Swarmbotmultiple_activation("Swarmactive");
                        break;


                    }
                break;
                case "Friday de activate swarm":
                    System.Random YE1 = new System.Random();
                    int Yw1 = YE1.Next(1, 3); //The cal random 
                    switch (Yw1)
                    {
                        case 1:
                            PopupNotifier popwe = new PopupNotifier(); // The popup notifier function 
                            popwe.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // The function of the title of the popup notification 
                            popwe.TitleColor = Color.White; // The function of the color on the title notification 
                            popwe.ContentText = ""; 
                            popwe.Popup(); 
                            Swarmbotmultiple_activation("DeactivateSwarm");
                            Swarmbotmultiple_activation("DeactivateSwarm");
                            break;

                        case 2:
                            Swarmbotmultiple_activation("DeactivateSwarm");
                            Friday.Speak("Ok sir now i'm De activated the swarm bot function");
                            break;

                        case 3:
                            Swarmbotmultiple_activation("DeactivateSwarm");
                            Friday.Speak("De Activated the Swarmbot");
        
                            break;
                    }

                  break;
                case "Friday activete the Automate bot":
                    Friday.Speak("Access system ");

                    Friday.Speak("I will try another IP address connection ");
                    try
                    {
                        using (var client = new SshClient("192.168.1.41", "ubuntu", "ubuntu"))  // Using the Jornbot network to access
                        {
                            client.Connect();
                            SshCommand cmd = client.RunCommand("cd Cleaning robot");  // Tightvncserver access so you just now able to access by using only password 
                            cmd = client.RunCommand("python CleaningBotSSH.py");
                            Friday.Speak("Successfully connect to auto mate robot");
                            richTextBox1.ForeColor = Color.Yellow;
                            richTextBox1.Text = "\n\n Automatic command Cleaning Robot 3 activated";
                            Thread.Sleep(1000);
                            client.Disconnect(); client.Dispose();

                        }
                    }
                    catch
                    {
                        Friday.Speak("All robotic network connection fail");
                        Friday.Speak("Please check your connection of the Sentien Robotics networking");
                        richTextBox1.ForeColor = Color.Red;
                        richTextBox1.Text = "\n\n\n\n\n Automatic command Cleaning Robot 3 Fail connection";
                    }

                    break;
                case "Friday connect to my brain": //  The function of the brain interface function of the brain 
                    PopupNotifier popupNew = new PopupNotifier(); // Popup the notification 
                    popupNew.TitleText = "F.R.I.D.A.Y A.I. Neurallace";
                    popupNew.TitleColor = Color.White;  // Display the white color of the text title notification system 
                    popupNew.ContentText ="Connnecting ... brain interface";
                    popupNew.BodyColor = Color.Blue;// The color blue on the body of the notification system  
                    popupNew.Popup(); // The popup notification function 
                    Friday.Speak("Now i'm connecting with you brain");
                    _thinkGearWrapper = new ThinkGearWrapper(); // The brain interface with the Think gear library function 

                    // setup the event
                    _thinkGearWrapper.ThinkGearChanged += _thinkGearWrapper_ThinkGearChanged; 

                    // connect to the device on the specified COM port at 57600 baud
                    if (!_thinkGearWrapper.Connect(comboBox1.SelectedItem.ToString(), 57600, true))
                        MessageBox.Show("Could not connect to headset.");
                    break;
                case "Friday disconnect with my brain":
                    Friday.Speak("I'm going to disconnect with your brian");
                    _thinkGearWrapper.Disconnect();
                    break;
                case "Friday enable blinking":
                    _thinkGearWrapper.EnableBlinkDetection(true);
                    break;
                case "Friday unable bliinking":
                    _thinkGearWrapper.EnableBlinkDetection(false);
                    break;
                
            }
            }
      
    // GetFormattedXml(url, "temperature","Pressure","Humid", "CloudValue","WinSpeed","WindDirection");
        private string GetFormattedXml(string url, string Weather)   // The XML file Extraction  
        {
            // Create a web client.
            using (WebClient client = new WebClient())  // The Webclient communication 
            {
                // Get the response string from the URL.
                string xml = client.DownloadString(url);
                Console.WriteLine(xml);

                // Load the response into an XML document.
                XmlDocument xml_document = new XmlDocument();
                xml_document.LoadXml(xml);
                var new_doc = XDocument.Parse(xml);
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>.
                   // XML Reader function system 
                var fieldValues = new_doc.Descendants("temperature").First();// Temperature value 
                var pressure = new_doc.Descendants("pressure").First(); // Pressure value  
                var Humidity= new_doc.Descendants("humidity").First();//humidity value  
                var CloudValu = new_doc.Descendants("clouds").First();//Cloud  value detecting 
              // var Winspeed = new_doc.Descendants("windSpeed").First();
                //var Winddirection = new_doc.Descendants("windDirection").First();
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>..
                // The function of the Xml reader on each data in command 
                //switch case ดีกว่า
                switch(Weather)   // Input from the weather string input 
                {
                    case "temperature":    // The Temperature Value 
                        PopupNotifier port = new PopupNotifier();
                        port.TitleText = "F.R.I.D.A.Y  A.I. Neurallace";
                        port.TitleColor = Color.White; // The color for the text white
                        port.ContentText = "Temperature :" + fieldValues.Attribute("max").Value.ToString() + "*K"; // The output popup Temperature
                        Friday.Speak(fieldValues.Attribute("max").Value.ToString() + "Kelvin");
                        port.ContentColor = Color.White;
                        port.BodyColor = Color.Blue;
                        port.Popup();

                        break;

                    case "Pressure": //The Pressure 

                        PopupNotifier popwer = new PopupNotifier(); // Pop up notification of the pressure 
                        popwer.TitleText = "FRIDAY AI Neurallace"; // Friday neurallace function for the A.I. 
                        popwer.TitleColor = Color.White;
                        Friday.Speak("Pressure is :" + pressure.Attribute("value").Value.ToString() + "hpa"); // The void function on the Speech synthsis display 
                        popwer.ContentText = "Pressure :" + pressure.Attribute("value").Value.ToString() + "hpa";
                        popwer.BodyColor = Color.Blue;
                        popwer.ButtonBorderColor = Color.Green;
                        popwer.Popup();
                    break;
                    case "Humid": // The Humidity 

                        PopupNotifier popwe = new PopupNotifier();
                        popwe.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Friday neurallace function for the A.I. 
                        popwe.TitleColor = Color.White; // White color for the Text title 
                        popwe.ContentText = "Humidity is " + Humidity.Attribute("value").Value + "%"; // The Humidity value out 
                        Friday.Speak("Humidity is " + Humidity.Attribute("value").Value + "%");
                        popwe.ContentColor = Color.White;
                        popwe.BodyColor = Color.Blue;
                        popwe.Popup();
                        break;
                    case "Cloud": // The cloud 
                        int Humid = Int32.Parse(Humidity.Attribute("value").Value.ToString());
                        int Cloudss = Int32.Parse(CloudValu.Attribute("value").Value.ToString());
                        double Skycle = (int)(Cloudss + Humid) * 0.5;
                        PopupNotifier popwerr = new PopupNotifier(); // Popup notification
                        popwerr.TitleText = "F.R.I.D.A.Y A.I. Neurallace";
                        popwerr.TitleColor = Color.White; // The function of he color of Title text function 
                        popwerr.ContentText = "Temperature :" + fieldValues.Attribute("max").Value.ToString() + "*K"; // The output popup Temperature
                        popwerr.ContentText = "Pressure :" + pressure.Attribute("value").Value.ToString() + "hpa";
                        popwerr.ContentText = "Humidity : "+ Humidity.Attribute("value").Value + "%"; // The Humidity value out 
                        popwerr.ContentText = "Temperature :"+ "\t" + fieldValues.Attribute("max").Value.ToString()+"*k" + "\n Pressure :" + "\t" 
                         + pressure.Attribute("value").Value.ToString()+"hpa" + "\nHumidity is " + "\t"+Humidity.Attribute("value").Value + "%" 
                         + "\nClouds :"+ "\t\t"+CloudValu.Attribute("value").Value + "%"+"\nSky status :"+ "\t"+Skycle+"%"; // The value output for the cloud percentage 
                       // popwerr.ContentText = "Sky today  :" + (int)(Cloudss + Humid) * 0.5 + "%";
                        if((int)(Cloudss+Humid)*0.5 >= 77) //The sky raining function added 
                        {

                           
                            Friday.Speak("Sky today is" +(int)(Cloudss +Humid)*0.5);
                            popwerr.Image = Properties.Resources.Rain_128; // The function of picture show when raining icon 
                            Friday.Speak("Seem to be raining today");
                        }
                        if((int)(Cloudss+Humid)*0.5 >= 40 && (int)(Cloudss+Humid)*0.5 <= 60) // Clear sky function added 
                        {
                        // popwerr.ContentText = "Today has clear sky";
                            Friday.Speak("Sky today is" + (int)(Cloudss + Humid) * 0.5);
                            popwerr.Image = Properties.Resources.weather_icons_17_128; // The function  of the weather icon 
                            Friday.Speak("Today has clear sky");
                        }
                       
                        Friday.Speak("Clouds today has  :"+CloudValu.Attribute("value").Value +"%");
                        popwerr.ContentColor = Color.White; // Content color 
                        popwerr.BodyColor = Color.Blue; // The color blue for the  function of the notification function 
                        popwerr.Popup(); // The popup notification function 
                      break;
                   

                }

                /*
                if (Temperature == "temperature")
                {
                    PopupNotifier port = new PopupNotifier();
                    port.TitleText = "F.R.I.D.A.Y  A.I. Neurallace";
                    port.TitleColor = Color.White; // The color for the text white
                    port.ContentText = "Temperature :" + fieldValues.Attribute("max").Value.ToString() + "*K"; // The output popup Temperature
                    Friday.Speak(fieldValues.Attribute("max").Value.ToString() + "Kelvin");
                    port.ContentColor = Color.White;
                    port.BodyColor = Color.Blue;
                    port.Popup();
                }
              if(Pressure == "Pressure")   // The pressure reporter 
              {
                    PopupNotifier popwer = new PopupNotifier(); // Pop up notification of the pressure 
                    popwer.TitleText = "FRIDAY AI Neurallace"; // Friday neurallace function for the A.I. 
                    popwer.TitleColor = Color.White;
                    Friday.Speak("Pressure is :" + pressure.Attribute("value").Value.ToString() + "hpa"); // The void function on the Speech synthsis display 
                    popwer.ContentText = "Pressure :" + pressure.Attribute("value").Value.ToString() + "hpa";
                    popwer.BodyColor = Color.Blue;
                    popwer.ButtonBorderColor = Color.Green; 
                    popwer.Popup(); 
              }
              */
             /*if(Humid == "Humid") // Humidity value 
             {
                    PopupNotifier popwe = new PopupNotifier(); 
                    popwe.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Friday neurallace function for the A.I. 
                    popwe.TitleColor = Color.White; // White color for the Text title 
                    popwe.ContentText = "Humidity is "+Humidity.Attribute("value").Value+ "%"; // The Humidity value out 
                    popwe.ContentColor = Color.White;
                    popwe.Popup();
                }
                //(url, "temperature","Pressure","Humid", "CloudValue","WinSpeed","WindDirection");
                //(string url, string Temperature,string Pressure,string Humid, string CloudValue, string  WinSpeed,string WindDirection)   // The XML file Extraction 
            if (CloudValue == "CloudValue")
            {
                    PopupNotifier popwerr = new PopupNotifier(); // Popup notification
                    popwerr.TitleText = "F.R.I.D.A.Y A.I. Neurallace";
                    popwerr.TitleColor = Color.White; // The function of he color of Title text function 
                    popwerr.ContentText = "Clouds :" + CloudValu.Attribute("value").Value ; // The value output for the cloud percentage 
                    popwerr.ContentColor = Color.Blue; // Content color 
                    popwerr.BodyColor = Color.Blue; // The color blue for the  function of the notification function 
                    popwerr.Popup(); // The popup notification function 
            }
          
           if(WinSpeed == "WindSpeed")  // The function of the wind speed 
           {
                    PopupNotifier popwerrw = new PopupNotifier(); // Popup notification 
                    popwerrw.TitleText = "F.R.I.D.A.Y A.I. Neurallace";
                    popwerrw.TitleColor = Color.White; // The color white for the TitleText color 
                    popwerrw.ContentText = "Wind Speed is "+Winspeed.Attribute("mps").Value+"mps";
                    Friday.Speak("Wind Speed is" + Winspeed.Attribute("mps").Value + "mps");
                    popwerrw.BodyColor = Color.Blue; // The color for the body 
                    popwerrw.Popup();
           }  
           
           
           if(WindDirection == "WindDirection")
           {

                    PopupNotifier popqwe = new PopupNotifier(); // Popup notification system 
                    popqwe.TitleText = "F.R.I.D.A.Y A.I. Neurallace";
                    popqwe.TitleColor = Color.White;
                    popqwe.ContentText = "Wind direction angle" +Winddirection.Attribute("deg").Value+" deg'"; // degree angle function of the wind direction  
                    popqwe.ContentText = "Wind compass" + Winddirection.Attribute("code").Value + Winddirection.Attribute("name").Value;  // Telling the compass directon 
                    Friday.Speak("Wind direction angle is " + Winddirection.Attribute("deg").Value + "deg'"+ "on"+Winddirection.Attribute("name").Value); // degree angle function of the wind direction );
                    popqwe.ContentColor = Color.White;
                    popqwe.BodyColor = Color.Blue; // The blue color for the body of the notification 
                    popqwe.Popup(); 

           }*/
           
                // Format the XML.
                using (System.IO.StringWriter string_writer = new System.IO.StringWriter())
                {
                    XmlTextWriter xml_text_writer = new XmlTextWriter(string_writer);
                    xml_text_writer.Formatting = Formatting.Indented;
                    xml_document.WriteTo(xml_text_writer);

                    // Return the result.
                    return string_writer.ToString();
                }
            }
        }
        private void DataBaseFunction_input(int Date ,int image ,int NodeInput) // Adding the data input into the Analysis function of the Machinelearning
        {


        }
        private void StanfordNLP() // Standford NLP function for the speech natural language 
        {
            var jarRoot = @"..\..\..\..\data\paket-files\nlp.stanford.edu\stanford-corenlp-full-2016-10-31\models";

            // Text for processing
            var text = "Kosgi Santosh sent an email to Stanford University. He didn't get a reply.";

            // Annotation pipeline configuration
           // var props = new Properties(); // 
          //  props.setProperty("annotators", "tokenize, ssplit, pos, lemma, ner, parse, dcoref");
            //props.setProperty("ner.useSUTime", "0");
            /*
            var curDir = Environment.CurrentDirectory;
            Directory.SetCurrentDirectory(jarRoot);  // Getting the JarRoot from the function of the Text model in Jaa function 
            var pipeline = new StanfordCoreNLP();
            Directory.SetCurrentDirectory(curDir);

            // Annotation
            var annotation = new Annotation(text);
            pipeline.annotate(annotation);

            // Result - Pretty Print
            using (var stream = new ByteArrayOutputStream())
            {
                pipeline.prettyPrint(annotation, new PrintWriter(stream));
                Console.WriteLine(stream.toString());
                stream.close();
            }
            */
        }
        private void Interview() // The interiew speak 
        {
            Friday.Speak("Hell my name if friday  i was designed to be your Home Automation Assistance system ");
            Thread.Sleep(500); // The function of the delaytion before speak next word 
            Friday.Speak("Created by my creator Mr.Chanapai Chuadchum");

        } 
        private void _thinkGearWrapper_ThinkGearChanged(object sender, ThinkGearChangedEventArgs e)// This function will learning  from your though and translate to computer to behave like you 
        {
            // update the textbox and sleep for a tiny bit
            BeginInvoke(new MethodInvoker(delegate
            {
                 // Each state of the brain wave signal measure to traning the data for the A.I. Algorithm 
                richTextBox1.Text = "Attention: " + e.ThinkGearState.Attention;       //Attention Value output 
                richTextBox1.Text = "Meditation: " + e.ThinkGearState.Meditation;     //Meditation Value output 
                richTextBox1.Text = "Alpha1 brain wave:" + e.ThinkGearState.Alpha1;   //Alpha1 Value output 
                richTextBox1.Text = "Alpha2 brain wave:" + e.ThinkGearState.Alpha2;   //Alpha2 Value output 
                richTextBox1.Text = "Beta1 brain wave:" + e.ThinkGearState.Beta1;     //Beta1 value output
                richTextBox1.Text = "Beta2 brain wave :" + e.ThinkGearState.Beta2;    //Beta2 value output
                richTextBox1.Text = "Gama1 brain wave :" + e.ThinkGearState.Gamma1;   //Gamma1 value output
                richTextBox1.Text = "Gamma2 brain wave :" + e.ThinkGearState.Gamma2;  //Gamma2 value output
                richTextBox1.Text = e.ThinkGearState.ToString();    //Print out the string  from your 
                DataLearning(e.ThinkGearState.ToString()); // Learning data function and save into the excel 
                switch (e.ThinkGearState.ToString())  // Switch case function for the system of the 
                {
                    
                      
                }
            }));
            Thread.Sleep(10);
        }
     
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _thinkGearWrapper.Disconnect();
        }
        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // Volume 
        private void Mute()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }

        private void VolDown()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_DOWN);
        }

        private void VolUp()
        {
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_UP);
        }
       private void DataLearning(String Learn)
        {
            Microsoft.Office.Interop.Excel.Application Learning = new Microsoft.Office.Interop.Excel.Application(); // Create the Excel application and built the .xls file 
            Microsoft.Office.Interop.Excel.Workbook workbook = Learning.Workbooks.Add(Type.Missing); // Create the application work book 
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null; // The work sheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "RawDataDetails";
        }
        private void button1_Click(object sender, EventArgs e) // The function of saving IP address 
        {
            Friday.Speak("Now i'm saving the robots IP address for you ");
            Properties.Settings.Default["Routine6"] = textBox6.Text;
            Properties.Settings.Default["Routine7"] = textBox7.Text;
            Properties.Settings.Default["Routine8"] = textBox8.Text;
            Properties.Settings.Default["Routine9"] = textBox9.Text;
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // The function save text value in the App ID and Key 
            Properties.Settings.Default["Routine12"] = textBox12.Text;
            Properties.Settings.Default["Routine13"] = textBox13.Text;
            Properties.Settings.Default["Routine14"] = textBox14.Text; 
            Properties.Settings.Default.Save(); // The function saving the IP address 
        }
       
        private void PopupNotification( int time) // Popup in the time event Just insert the timeH into this function for the reminder  
        {
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>..
             // The function of the Code reminder date on the time 
            if(time == 00 ) // midnight reminder function 
            {
                PopupNotifier popup2 = new PopupNotifier(); // Pop up notication 
                popup2.Image = Properties.Resources.if___Bell_1904653; // Toast notification popup function 
                popup2.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Added date to pop up when you say hello 
                popup2.ContentText = "Midnight now you have to go to sleep now"; // Pop up notification popup 
                microgear.Chat(Target, "Midnight");
                popup2.BodyColor = Color.Blue;
                //popup2.Image = Properties.Resources.HitechBackground; 
                popup2.Popup();// Show up and popup
            }
            if(time >= 5 && time <=11) // Morning reminder function 
            {
                PopupNotifier popup2 = new PopupNotifier(); // Pop up notication 
                popup2.Image = Properties.Resources.if___Bell_1904653; // Toast notification popup function 
                popup2.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Added date to pop up when you say hello 
                popup2.ContentText = "Good morning sir , Have you have breakfast yet ?"; // Pop up notification popup 
                microgear.Chat(Target, "Goodmorning");
                popup2.BodyColor = Color.Blue; // The blue background function 
                popup2.Image = Properties.Resources.if___Bell_1904653; // The function of the picture bell display 
                popup2.Popup();// Show up and popup
            }
            if(time  == 12)// Noon reminder function
            {
                PopupNotifier popup2 = new PopupNotifier(); // Pop up notication 
                popup2.Image = Properties.Resources.if___Bell_1904653; // Toast notification popup function 
                popup2.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Added date to pop up when you say hello 
                popup2.ContentText = "Good noon sir ,Have you have lunch yet ?"; // Pop up notification popup 
                microgear.Chat(Target, "Goodnoon");
                popup2.BodyColor = Color.Blue;  //The 
              //  popup2.Image = Properties.Resources.HitechBackground; 
                popup2.Popup();// Show up and popup
            }
            if(time >= 17 && time <= 18) // Function of the evening reminder 
            {
                PopupNotifier popup2 = new PopupNotifier(); // Pop up notication 
                popup2.Image = Properties.Resources.if___Bell_1904653; // Toast notification popup function 
                popup2.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Added date to pop up when you say hello 
                popup2.ContentText = "Good evening sir,Have you have a dinner yet ?"; // Pop up notification popup 
                microgear.Chat(Target, "Goodevening");
                popup2.BodyColor = Color.Blue;
                //popup2.Image = Properties.Resources.HitechBackground;
                popup2.Popup();// Show up and popup
            }
            if(time >= 19 && time <= 23) // Night time reminder function 
            {
                PopupNotifier popup2 = new PopupNotifier(); // Pop up notication 
                popup2.Image = Properties.Resources.if___Bell_1904653; // Toast notification popup function 
                popup2.TitleText = "F.R.I.D.A.Y A.I. Neurallace"; // Added date to pop up when you say hello 
                popup2.ContentText = "Good night sir , When will you go to sleep"; // Pop up notification popup 
                microgear.Chat(Target, "Goodnight");
                Thread.Sleep(500);
                popup2.ContentText = DateTime.Now.TimeOfDay.ToString(); // Adding to show the time pop up after this notification
                popup2.BodyColor = Color.Blue;
                //popup2.Image = Properties.Resources.HitechBackground; 
                popup2.Popup();// Show up and popup
            }
        }
   //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>.
          // The function of the Swarm bot control each operation function of the robots
        private void Swarmbotmultiple_activation( string R) // Loop operation function 
        {
           if( R == "Swarmactive") // The function of the string input for activate the swarm function command 
            {
                PopupNotifier popupRobot = new PopupNotifier(); // The popup notification function 
                popupRobot.TitleText = "F.R.I.D.A.Y A.I.  Neurallace";
               ; //The Swarmbot picture on the function of the swarmbot 
                popupRobot.TitleColor = Color.White; // The color text  
                popupRobot.ContentText = "Swarm bot function";
                popupRobot.ContentColor = Color.White; //Content color 
                popupRobot.BodyColor = Color.Blue; // The color function of the body text Toast notification
                popupRobot.Popup(); // The popup notification function 
                Friday.Speak("Swarm bot activated function online");
                int p = 0; 
                for(p = 0; p < 10; p++)  //Loop operation for the messaging function 
                {
                    string IOBot = p.ToString(); // The string converter from number to the Robot
                    microgear.Chat(Target, "Swarm"+IOBot); // Connect to the IObot directly 
                    Thread.Sleep(30);  // Waiting for each command for about 30 millisec           
                }

            }
           if( R == "DeactivateSwarm")  // Deactivate swarm function operation   This deswarm function will working on the operation of the Multiple robot control 
           {
                PopupNotifier popupRobot = new PopupNotifier(); // The popup notification function 
                popupRobot.TitleText = "F.R.I.D.A.Y A.I.  Neurallace";
                popupRobot.Image = Properties.Resources.Search_Engine_Spider_128;  //The Swarmbot picture on the function of the swarmbot 
                popupRobot.TitleColor = Color.White; // The color text  
                popupRobot.ContentText = "Deswarm bot function";  // The function of remove the swarmbot 
                popupRobot.ContentColor = Color.White; //Content color 
                popupRobot.BodyColor = Color.Blue; // The color function of the body text Toast notification
                popupRobot.Popup();
                Friday.Speak("De swarm mode activated"); // Speak out the deswarm function of robot 
                 
                int U = 10; 

                for(U = 10; U > 0; U--) // Deactivate command function of the swarm bot 
                {
                   
                    string IObot1 = U.ToString(); // Convert the number to string function 
                    microgear.Chat(Target, "DeSwarm" + IObot1); // The function of the swarm deactivate 
                    Thread.Sleep(30); //using the time for deactivate about 30 millisec
                }

           }
        }
    }
}
