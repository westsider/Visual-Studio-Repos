﻿using System;
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


namespace NT8_Monitor
{
        /*
         if the data is updated
         X. Last Update = get date from last line lastUpdateOutputLabel
         X. pasre connection, update ui messageOutputLlabel, 
         X. if connected message, update ui connected color greed, red, connectedOutputLabel
         X, last message, messageLabel
         X. git commit
         X. clean up code vars, funcs
         4. send mail
         5. connected since message, onlineSinceOutput

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

        private string dirName = @"C:\Users\MBPtrader\Documents\NT_CSV";
        public string filename = "C:\\Users\\MBPtrader\\Documents\\NT_CSV\\connected.csv";
        List<string> rows = new List<string>();
        public string DirName { get => dirName; set => dirName = value; }
        List<string> myDate = new List<string>();

        public string lastUpdate = "notSet";
        public string message = "notSet";

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
            string found = "Nothing Found";
            if (row.Contains(a)) {
                found = a; }
            if (row.Contains(b)) {
                found = b; }
            return found;
        }
        // parse date
        public void parseRowDate()
        {
            string[] feilds = rows.Last().Split(null);
            lastUpdate = feilds[3] + " " + feilds[4];
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
            connectedOutputLabel.BeginInvoke(new UpdateTextInLabel(SetLabelText), con);
            lastUpdateOutputLabel.BeginInvoke(new UpdateTextInLastUpdate(SetlastUpdateOutputLabel), lastUpdate);
            connectedOutputLabel.BeginInvoke(new UpdateTextInMessage(SetMessageOutputLlabel), message);

            //  TODO: - Send Mail Update
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
        void SetMessageOutputLlabel(string text){
            messageOutputLlabel.Text = text;
        }
    }
}


