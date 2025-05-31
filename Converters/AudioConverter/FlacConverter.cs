using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using UltimateConverter.Interfaces;
using UltimateConverter.Services;

namespace UltimateConverter.Converters.AudioConverter
{
    internal class FlacConverter : IConverter
    {
        public void Convert(string inputFilePath)
        {
            string[] files = inputFilePath.Split(' ');
            string audioFile = string.Empty;
            foreach (string file in files)
            {
                audioFile = file.Trim(Path.GetExtension(file).ToCharArray());
                ExternalToolRunner.RunCommand("ffmpeg", "-i " + file + " " + audioFile + ".flac");
            }
            Console.WriteLine($"Converted successfully!");
        }
    }
}