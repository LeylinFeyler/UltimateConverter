using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using UltimateConverter.Interfaces;
using UltimateConverter.Services;

namespace UltimateConverter.Converters.VideoConverter
{
    internal class WebmConverter : IConverter
    {
        public void Convert(string inputFilePath)
        {
            string[] files = inputFilePath.Split(' ');
            string videoFile = string.Empty;
            foreach (string file in files)
            {
                videoFile = file.Trim(Path.GetExtension(file).ToCharArray());
                ExternalToolRunner.RunCommand("HandBrakeCLI", "--input " + file + " --output " + videoFile + ".webm");
            }
            Console.WriteLine($"Converted successfully!");
        }
    }
}