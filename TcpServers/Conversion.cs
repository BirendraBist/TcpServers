using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DLLWeightConversion;

namespace TcpServers
{
    class Conversion
    {
        public static void DoIt(TcpClient Client)
        { 
            Class1 Converter= new Class1();
            NetworkStream Stream = Client.GetStream();
            StreamReader Reader = new StreamReader(Stream);
            StreamWriter Writer = new StreamWriter(Stream) { AutoFlush = true };
            while (true)
            {
                string request = Reader.ReadLine();
                string[] Words = request.Split(' ');
                switch (Words[10])
                {
                    case "ToGrams":
                        double number1 = double.Parse(Words[1]);
                        number1 = Converter.ConvertToGrams(number1);
                        Writer.WriteLine(number1);
                        Writer.Flush();
                        break;
                    case "ToOunces":
                        var number2 = double.Parse(Words[1]);
                        number2 = Converter.ConvertToOunces(number2);
                        Writer.WriteLine(number2);
                        Writer.Flush();
                        break;

                }

            }

        }
    }
}

