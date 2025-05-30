using UltimateConverter.Interfaces;
using UltimateConverter.Converters.ImageConverter;

namespace UltimateConverter.Factories
{
    internal class ImageConverterFactory : IConverterFactory
    {
        public IConverter CreateConverter(string format)
        {
            return format.ToLower() switch
            {
                "png" => new PngConverter(),
                "jpg" => new JpgConverter(),
                "jpeg" => new JpgConverter(),
                "gif" => new GifConverter(),
                "bmp" => new BmpConverter(),
                "tif" => new TiffConverter(),
                "tiff" => new TiffConverter(),
                "webp" => new WebpConverter(),
                "heic" => new HeicConverter(),
                "heif" => new HeicConverter(),
                _ => throw new NotSupportedException($"Image format '{format}' is not supported.")
            };
        }
    }
}