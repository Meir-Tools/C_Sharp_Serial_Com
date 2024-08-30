using System;
using System.Threading;
using System.IO.Ports; // https://www.nuget.org/packages/System.IO.Ports/
using Microsoft.Win32;
using System.Diagnostics;
using System.ComponentModel;

namespace _20240820_serial_com_test
{
    internal class Program
    {
        static bool _continue; 
        static SerialPort _serialPort;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // Other info : https://www.c-sharpcorner.com/UploadFile/eclipsed4utoo/communicating-with-serial-port-in-C-Sharp/
            _serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            _serialPort.WriteTimeout = 500;
            _serialPort.Open();

            Console.ReadLine();
        }
        static void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);
            string data = _serialPort.ReadLine();

            Console.WriteLine("result: " + data);

        }

    }
}
