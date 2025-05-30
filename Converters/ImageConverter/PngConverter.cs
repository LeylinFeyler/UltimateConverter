using System;
using System.Drawing;
using System.Drawing.Imaging;
using UltimateConverter.Interfaces;
using UltimateConverter.Services;

namespace UltimateConverter.Converters.ImageConverter
{
    internal class PngConverter : IConverter
    {
        public void Convert(string inputFilePath)
        {
            ExternalToolRunner.RunCommand("mogrify", "-format png " + inputFilePath);
            Console.WriteLine($"Converted successfully!");
        }
    }
}