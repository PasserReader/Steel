using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private Process progressTest;
        ProcessStartInfo start;

        public Form1()
        {
            start = new ProcessStartInfo();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\LiYun\Desktop\NNetwork\PythonApp\CsharpeTest.py";
            //string filePath = @"C:\Users\LiYun\AppData\Local\Programs\Python\Python38\python.exe";
            RunPython(filePath, 3, 4);
        }


        void RunPython(string path, int a, int b)
        {
            string sArguments = "/C python PythonApp.py";
            //sArguments += " " + a.ToString() + " " + b.ToString() + " -u";

            start.FileName = @"cmd.exe";
            start.Arguments = sArguments;
            start.UseShellExecute = true;
            start.RedirectStandardOutput = true;
            start.RedirectStandardInput = false;
            start.RedirectStandardError = false;
            start.CreateNoWindow = true;

            progressTest = Process.Start(start);

            string output = progressTest.StandardOutput.ReadToEnd();
            textBox1.Text = output;
            //progressTest.WaitForExit();
            //progressTest.Close();
        }


    }
}
