using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Wireless_Audit_Test_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openCSV = new OpenFileDialog();
            openCSV.Filter = "CSV File (*.csv) | *.csv";
            openCSV.ShowDialog();

            splitApFromClient(openCSV.FileName);
        }

        private void splitApFromClient(string fileName)
        {
            using (var reader = new System.IO.StreamReader(@fileName))
            {
                List<string> listAP = new List<string>();
                List<string> listClient = new List<string>();
                
                // Read First Blank Line
                var line = reader.ReadLine();

                // Get AP Header Line
                line = reader.ReadLine();

                while (line != "")
                { 
                    listAP.Add(line);
                    line = reader.ReadLine();
                }

                // Get Client Header Line
                line = reader.ReadLine();

                while (line != "")
                {
                    listClient.Add(line);
                    line = reader.ReadLine();
                }

                DataTable apView = Deconstruct_CSV.deconstructInformation(listAP, 15, ",");
                DataTable clientView = Deconstruct_CSV.deconstructInformation(listClient, 7, ",");

                this.gridControl1.DataSource = apView;
                this.gridControl2.DataSource = clientView;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OUI.obtainOUI();
        }
    }
}
