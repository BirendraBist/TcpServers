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
        public static void DoIt(TcpClient client)
        { 
            Class1 converter = new Class1();
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
            while (true)
            {
                string request = reader.ReadLine();
                string[] words = request.Split(' ');
                switch (words[10])
                {
                    case "ToGrams":
                        double number1 = double.Parse(words[1]);
                        number1 = converter.ConvertToGrams(number1);
                        writer.WriteLine(number1);
                        writer.Flush();
                        break;
                    case "ToOunces":
                        var number2 = double.Parse(words[1]);
                        number2 = converter.ConvertToOunces(number2);
                        writer.WriteLine(number2);
                        writer.Flush();
                        break;

                }

            }

        }
    }
}

