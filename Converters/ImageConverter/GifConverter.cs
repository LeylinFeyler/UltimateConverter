using System;
using System.Drawing;
using System.Drawing.Imaging;
using UltimateConverter.Interfaces;
using UltimateConverter.Services;

namespace UltimateConverter.Converters.ImageConverter
{
    internal class GifConverter : IConverter
    {
        public void Convert(string inputFilePath)
        {
            ExternalToolRunner.RunCommand("mogrify", "-format gif " + inputFilePath);
            Console.WriteLine($"Converted successfully!");
        }
    }
}