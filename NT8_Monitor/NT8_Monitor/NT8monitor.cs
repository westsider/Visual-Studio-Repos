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
     [X] toggle send sms, send mail, both - not working buggy from UI
     [X] compile and upload to server
     [ ] testing from server 7/25/2017 4:30PM
     [ ] notify if NT crashes or quits
    */
    public struct DeviceData
    {
        public string dirName { get; set; }
        public string filename { get; set; }
        public string machine { get; set; }

    }
    public struct UpdateData
    {
        public string fileDate { get; set; }
        public string lastUpdate { get; set; }
        public string message { get; set; }
    }

    public partial class NT8monitor : Form
    {
        private DeviceData deviceData = new DeviceData {};
        private UpdateData updateData = new UpdateData { };
        public delegate void UpdateTextInLabel(string message);
        public delegate void UpdateTextInLastUpdate(string message);
        public delegate void UpdateTextInMessage(string message);
        public delegate void UpdateTextInLastOnline(string message);
        List<string> rows = new List<string>();
        // for mail
        public string toEmailAddress = "whansen1@mac.com";
        public string toSmsAddress = "3103824522@tmomail.net";
        public string fromEmailAddress = "trader1@tradestrat.net";
        public string fromEmailPass = "Si062fcaa";

        // main function
        public NT8monitor()
        {
            InitializeComponent();
            initializeMachine(sys: 1); // 0 = MBP 1 = VPN

            try
            {
                CreateFileWatcher( deviceData.dirName );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.ToString(),"File Import Error" );
                Console.WriteLine("Error ", ex);
            }
            
        }

        public void initializeMachine(int sys)
        { 
            if ( sys == 0 )
            {
                deviceData.machine = "MBP";
                deviceData.dirName = @"C:\Users\MBPtrader\Documents\NT_CSV\";
                deviceData.filename = @"C:\Users\MBPtrader\Documents\NT_CSV\connected.csv";
            } else
            {
                deviceData.machine = "VPN";
                deviceData.dirName = @"C:\Users\Administrator\Documents\";
                deviceData.filename = @"C:\Users\Administrator\Documents\connected.csv";
            }
        }

        // get data from csv file
        public void getData()
        {
            //// Read the file and display it line by line.
            using (TextFieldParser parser = new TextFieldParser(path: deviceData.filename))
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
            updateData.lastUpdate = feilds[3] + " " + myString + " " + feilds[5];
            updateData.message = "Connection Status";
            updateData.fileDate = feilds[3]; // to eliminate mail of proir trades
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
            //Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            getData();
            string con =  parseRowConnection(row: rows.Last());
            parseRowDate();
            // update the labels
            connectedOutputLabel.BeginInvoke(new UpdateTextInLabel(SetLabelText), con);
            lastUpdateOutputLabel.BeginInvoke(new UpdateTextInLastUpdate(SetlastUpdateOutputLabel), updateData.lastUpdate);
            connectedOutputLabel.BeginInvoke(new UpdateTextInMessage(SetMessageOutputLabel), updateData.message);
            onlineSinceOutput.BeginInvoke(new UpdateTextInLastOnline(SetOnlineSinceLabel), con);

            // Send Mail Update of records with dodays date
            string messages = deviceData.machine + " " + con + " on " + updateData.lastUpdate;
            if (DateTime.Today.ToShortDateString()  == updateData.fileDate)
            {
                sendTheMail(emailSubject: deviceData.machine + " " + con, message: messages);
            }
            
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
                onlineSinceOutput.Text = updateData.lastUpdate;
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
           // mail.To.Add(toEmailAddress);
            mail.To.Add(toSmsAddress);
            mail.Subject = emailSubject; mail.IsBodyHtml = true; mail.Body = message; // html true allows sms to get same from address
            try
            {
                smtp.Send(mail);
                //Console.WriteLine("Message if: "+DateTime.Today.ToShortDateString() + " != " + fileDate);
                //Console.WriteLine(message);
                //Console.WriteLine("Sent Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Mail Error" );
                //Console.WriteLine("Error ", ex);
            }
        }
    }
}


