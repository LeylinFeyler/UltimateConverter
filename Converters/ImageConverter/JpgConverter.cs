using System;
using System.Drawing;
using System.Drawing.Imaging;
using UltimateConverter.Interfaces;
using UltimateConverter.Services;

namespace UltimateConverter.Converters.ImageConverter
{
    internal class JpgConverter : IConverter
    {
        public void Convert(string inputFilePath)
        {
            ExternalToolRunner.RunCommand("mogrify", "-format jpg " + inputFilePath);
            Console.WriteLine($"Converted successfully!");
        }
    }
}