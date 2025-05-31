using System;
using UltimateConverter.Interfaces;
using UltimateConverter.Factories;

namespace UltimateConverter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0 || args.Contains("help"))
            {
                PrintHelp();
                return;
            }


            if (args.Length < 3 && !args.Contains("--help"))
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
        
        private static void PrintHelp()
        {
            Console.WriteLine("Ultimate Converter (uconvert) - Універсальна утиліта для конвертації файлів.");
            Console.WriteLine();
            Console.WriteLine("Синтаксис:");
            Console.WriteLine("  uconvert <-i|-v|-a> <формат> <шлях_до_файлу>");
            Console.WriteLine();
            Console.WriteLine("Типи конвертації:");
            Console.WriteLine("  -i     зображення (image)");
            Console.WriteLine("  -v     відео (video)");
            Console.WriteLine("  -a     аудіо (audio)");
            Console.WriteLine();
            Console.WriteLine("Підтримувані формати:");
            Console.WriteLine("  Зображення:");
            Console.WriteLine("    png, jpg, jpeg, gif, bmp, tif (tiff), webp, heic (heif)");
            Console.WriteLine();
            Console.WriteLine("  Відео:");
            Console.WriteLine("    mp4, mkv, avi, mov, wmv, flv, webm, mpeg, mpg");
            Console.WriteLine();
            Console.WriteLine("  Аудіо:");
            Console.WriteLine("    mp3, wav, flac, aac, ogg");
            Console.WriteLine();
            Console.WriteLine("Опції:");
            Console.WriteLine("  help  показати це повідомлення про довідку");
            Console.WriteLine();
            Console.WriteLine("Приклад:");
            Console.WriteLine("  uconvert -i png \"My Photo.jpg\"");
            Console.WriteLine("  uconvert -v webm \"Funny Video.mov\"");
            Console.WriteLine();
            Console.WriteLine("Примітка:");
            Console.WriteLine("  Якщо у назві файлу є пробіли — використовуйте лапки (\"\").");
            Console.WriteLine();
            Console.WriteLine("GitHub: https://github.com/LeylinFeyler/UltimateConverter");
        }
    }
}
