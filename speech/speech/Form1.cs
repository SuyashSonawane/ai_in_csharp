using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;                                 
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;
using speech;

namespace speech
{
    public partial class Speech : Form
    {
        bool search = false;
        SpeechSynthesizer s = new SpeechSynthesizer();
        public Speech()
        {
            InitializeComponent();          
            SpeechRecognitionEngine reco = new SpeechRecognitionEngine();
            Choices list = new Choices();
            

            s.SpeakAsync(greetrandom());

            list.Add(new string[] { "what is today","hi","open google","open notepad","bye","wiki search","minimize","what is the time","fullscreen","open browser","normal","kill this","search for","dog","apple","cat","open text reader"});

            Grammar gm = new Grammar(new GrammarBuilder(list));

            
            
            try
            {
                reco.RequestRecognizerUpdate();
                reco.LoadGrammar(gm);
                reco.SpeechRecognized += Reco_SpeechRecognized;
                reco.SetInputToDefaultAudioDevice();
                reco.RecognizeAsync(RecognizeMode.Multiple);

                

            }
            catch { }
            
         }

        public string greetrandom()
        {
            string[] greeting = new string[5] { "hi sir", "welcome back", "good to see you again", "greetings sir", "what's the plan today" };
            Random r = new Random();
            return greeting[r.Next(4)];
        }

        private void Reco_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string a = e.Result.Text;

            if (search)
            {
                Process.Start("https://www.google.co.in/search?q=" + a);
                search = false;
            }
            if (a=="search for")
            {
                search = true;
                s.Speak ("tell me what to search for");
            }

            if(a == "open text reader")
            {
                Form textreader = new textreader();
                textreader.Show();
                s.SpeakAsync("opening textreader");
            }
            

            if (search == false)
            {

                switch (a)
                {
                    case ("hi"):
                        s.SpeakAsync("hi");
                        break;


                    case ("open google"):
                        s.Speak("opening google");
                        Process.Start("https://www.google.com");
                        break;

                    case ("open notepad"):
                        s.Speak("opening notepad");
                        Process.Start("notepad.exe");
                        break;

                    case ("bye"):
                        s.Speak("bye sir may you have a good day");
                        this.Close();
                        break;
                    case ("fullscreen"):
                        WindowState = FormWindowState.Maximized;
                        break;

                    case ("minimize"):
                        WindowState = FormWindowState.Minimized;
                        break;

                    case ("normal"):
                        WindowState = FormWindowState.Normal;
                        break;

                    case ("kill this"):
                        SendKeys.Send("%{F4}");
                        break;
                    case ("open browser"):
                        Form browser = new browser();
                        WindowState = FormWindowState.Minimized;
                        browser.Show();
                        break;

                    case ("what is today"):
                        s.Speak("Today is" + DateTime.Now.ToShortDateString());
                        break;

                    case ("what is the time"):
                        s.Speak("it is" + DateTime.Now.ToShortTimeString());
                        break;

                   


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            panel2.Width = 102;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.Width = 10;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Form cmd = new commands();
            s.SpeakAsync("Please enter the new command here");
            cmd.Show();
        }
    }
    
}
