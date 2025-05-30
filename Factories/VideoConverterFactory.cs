using UltimateConverter.Interfaces;
using UltimateConverter.Converters.VideoConverter;

namespace UltimateConverter.Factories
{
    internal class VideoConverterFactory : IConverterFactory
    {
        public IConverter CreateConverter(string format)
        {
            return format.ToLower() switch
            {
                "mp4" => new Mp4Converter(),
                "mkv" => new MkvConverter(),
                "avi" => new AviConverter(),
                "mov" => new MovConverter(),
                "wmv" => new WmvConverter(),
                "flv" => new FlvConverter(),
                "webm" => new WebmConverter(),
                "mpeg" => new MpegConverter(),
                "mpg" => new MpegConverter(),
                _ => throw new NotSupportedException($"Video format '{format}' is not supported.")
            };
        }
    }
}