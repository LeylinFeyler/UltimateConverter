using System;
using System.Drawing;
using System.Drawing.Imaging;
using UltimateConverter.Interfaces;
using UltimateConverter.Services;

namespace UltimateConverter.Converters.ImageConverter
{
    internal class WebpConverter : IConverter
    {
        public void Convert(string inputFilePath)
        {
            ExternalToolRunner.RunCommand("mogrify", "-format webp " + inputFilePath);
            Console.WriteLine($"Converted successfully!");
        }
    }
}