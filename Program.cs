using System;
using UltimateConverter.Interfaces;
using UltimateConverter.Factories;

namespace UltimateConverter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: UltimateConverter <-i|-v|-a|-f> <outputFormat> <inputFilePath>");
                return;
            }

            string typeArg = args[0];
            string outputFormat = args[1];
            string inputFilePath = "";
            foreach (string arg in args[2..])
                inputFilePath += "\"" + arg + "\" ";

            IConverterFactory factory;
            switch (typeArg)
            {
                case "-i":
                    factory = new ImageConverterFactory();
                    break;
                case "-v":
                    factory = new VideoConverterFactory();
                    break;
                case "-a":
                   factory = new AudioConverterFactory();
                   break;
                //case "-f":
                //    factory = new FileConverterFactory();
                //    break;
                default:
                    Console.WriteLine("Unknown conversion type. Use -i (image), -v (video), -a (audio), -f (file).");
                    return;
            }

            IConverter converter = factory.CreateConverter(outputFormat);
            if (converter == null)
            {
                Console.WriteLine($"Unsupported output format: {outputFormat}");
                return;
            }

            converter.Convert(inputFilePath);
        }
    }
}
