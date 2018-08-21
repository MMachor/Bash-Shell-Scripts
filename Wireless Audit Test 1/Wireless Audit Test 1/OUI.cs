using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Linq;

namespace Wireless_Audit_Test_1
{
    class OUI
    {
        public static void obtainOUI()
        {
        
            if (verifyInternet())
            {
                WebClient obtainOUI = new WebClient();
                obtainOUI.DownloadFile("http://standards-oui.ieee.org/oui.txt", @"\Test.txt");
            }

            readAndParseOUI();

        }

        public static void readAndParseOUI()
        {
            int numOfLines = File.ReadAllLines(@"\Test.txt").Length;
            int skipCount = 4;

            while (skipCount < numOfLines)
            {
                var lines = File
                .ReadLines(@"\Test.txt")
                .Skip(skipCount)
                .Take(5);



                skipCount += 6;
            };
            
        }

        private static bool verifyInternet()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
