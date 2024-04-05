using System;
using System.Management;
using System.Diagnostics;

namespace HomeWork2{
    class HomeWork2{

        static bool isPaintOpen = false;

        static void Main(string[] args){
            Console.WriteLine("This is my second homework.");
            Console.WriteLine("USB Listener started. Press Ctrl+C to exit.");

            while (true)
            {
                if (CheckUsbConnection())
                {
                    if (!isPaintOpen)
                    {
                        LaunchPaint();
                        isPaintOpen = true;
                    }

                    System.Threading.Thread.Sleep(5000);
                }
                else
                {
                    isPaintOpen = false;
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        static bool CheckUsbConnection()
        {
            string query = "SELECT * FROM Win32_PnPEntity WHERE Caption LIKE '%USB%'";

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject device in collection)
                {
                    string deviceName = (string)device["Name"];

                    if (deviceName.Contains("USB Mass Storage") || deviceName.Contains("Flash Drive"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static void LaunchPaint()
        {
            try
            {
                Console.WriteLine("Opening MS Paint...");
                Process.Start("mspaint.exe");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening MS Paint: {ex.Message}");
            }
        }
    }
}
