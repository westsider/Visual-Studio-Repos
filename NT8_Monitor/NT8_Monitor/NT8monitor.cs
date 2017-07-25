using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Net.Mail;
using System.Net;


namespace NT8_Monitor
{
    /*
     [X] connected since message, onlineSinceOutput
     [X] send trade notification, working,
     [X] bug sends all trades to txt but not showing on console
     [ ] bug sends all trades, limit to today
     [X] remove mail, indicator from ninjatrader
     [ ] compile and upload to server
     [ ] notify if NT crashes or quits
     [ ] push connection, trades to firebase or realm

     MBP Connected      at 7/22/2017 9:08:29 PM SPY
     MBP Disconnected   at 7/22/2017 9:09:03 PM SPY
     MBP Connected      at 7/22/2017 9:09:16 PM SPY

     Last Update = lastUpdateOutputLabel
     Message = messageLabel
     Connection = connectedOutputLabel
     online Since = onlineSinceLabel
    */
    public partial class NT8monitor : Form
    {
        public delegate void UpdateTextInLabel(string message);
        public delegate void UpdateTextInLastUpdate(string message);
        public delegate void UpdateTextInMessage(string message);
        public delegate void UpdateTextInLastOnline(string message);

        private string dirName = @"C:\Users\MBPtrader\Documents\NT_CSV";
        public string filename = "C:\\Users\\MBPtrader\\Documents\\NT_CSV\\connected.csv";
        List<string> rows = new List<string>();
        public string DirName { get => dirName; set => dirName = value; }
        List<string> myDate = new List<string>();

        public string lastUpdate = "notSet";
        public string message = "notSet";
        // for mail
        public string toEmailAddress = "whansen1@mac.com";
        public string toSmsAddress = "3103824522@tmomail.net";
        public string fromEmailAddress = "trader1@tradestrat.net";
        public string fromEmailPass = "Si062fcaa";

        // main function
        public NT8monitor()
        {
            InitializeComponent();
            CreateFileWatcher(dirName);
        }

        // get data from csv file
        public void getData()
        {
            //// Read the file and display it line by line.
            using (TextFieldParser parser = new TextFieldParser(path: filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    // add each line to row array
                    rows.Add(parser.ReadLine());
                }
            }
        }

        // parse connected
        public string parseRowConnection(string row)
        {
            string a = "Connected";
            string b = "Disconnected";
            string c = "Trade";
            string found = "Nothing Found";
            if (row.Contains(a)) {
                found = a; }
            if (row.Contains(b)) {
                found = b; }
            if (row.Contains(c)) {
                found = c; }
            return found;
        }
        // parse date
        public void parseRowDate()
        {
            string[] feilds = rows.Last().Split(null);
            string timeTrim = feilds[4]; // .Substring(feilds[4].Length - 2);
            string myString = timeTrim.Remove(timeTrim.Length - 3); 

            lastUpdate = feilds[3] + " " + myString + " " + feilds[5];
            message = "Connection Status";
        }
        //   File watcher magic
        public void CreateFileWatcher(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.csv";
            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }

        // File has changed, ,getData, Parse Connected, Connected, Parse Date, 
         void OnChanged(object sender, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            getData();
            string con =  parseRowConnection(row: rows.Last());
            parseRowDate();
            // update the labels
            connectedOutputLabel.BeginInvoke(new UpdateTextInLabel(SetLabelText), con);
            lastUpdateOutputLabel.BeginInvoke(new UpdateTextInLastUpdate(SetlastUpdateOutputLabel), lastUpdate);
            connectedOutputLabel.BeginInvoke(new UpdateTextInMessage(SetMessageOutputLabel), message);
            onlineSinceOutput.BeginInvoke(new UpdateTextInLastOnline(SetOnlineSinceLabel), con);

            // Send Mail Update
            string messages = "VPN " + con + " on " + lastUpdate;
            sendTheMail(emailSubject: "VPN "+con, message: messages);
        }
        void SetLabelText(string text)
        {
            connectedOutputLabel.Text = text;
            if (text == "Connected") {
                connectedOutputLabel.BackColor = Color.DodgerBlue; }
            if (text == "Disconnected") {
                connectedOutputLabel.BackColor = Color.Red; } 
        }
        void SetlastUpdateOutputLabel(string text) {
            lastUpdateOutputLabel.Text = text;
        }
        void SetMessageOutputLabel(string text){
            messageOutputLlabel.Text = text;
        }

        void SetOnlineSinceLabel(string text)
        {
            if (text == "Connected")
            {
                onlineSinceOutput.Text = lastUpdate;
            }
        }


        public void sendTheMail(string emailSubject, string message)
        {
            SmtpClient smtp = new SmtpClient(fromEmailAddress);
            smtp.Port = 25;
            smtp.Host = "smtp.stackmail.com";
            smtp.EnableSsl = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPass);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromEmailAddress, "VPN Trade Stats");
            mail.To.Add(toEmailAddress);
            mail.To.Add(toSmsAddress);
            mail.Subject = emailSubject; mail.IsBodyHtml = false; mail.Body = message;
            try
            {
                // smtp.Send(mail);
                Console.WriteLine(message);
                Console.WriteLine("Sent Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ", ex);
            }

        }
    }
}


