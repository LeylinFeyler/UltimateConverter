using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using UltimateConverter.Interfaces;
using UltimateConverter.Services;

namespace UltimateConverter.Converters.VideoConverter
{
    internal class Mp4Converter : IConverter
    {
        public void Convert(string inputFilePath)
        {
            string[] files = inputFilePath.Split(' ');
            string videoFile = string.Empty;
            foreach (string file in files)
            {
                videoFile = file.Trim(Path.GetExtension(file).ToCharArray());
                ExternalToolRunner.RunCommand("ffmpeg", "-i " + file + " " + videoFile + ".mp4");
            }
            Console.WriteLine($"Converted successfully!");
        }
    }
}