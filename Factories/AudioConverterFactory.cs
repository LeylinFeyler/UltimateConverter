using UltimateConverter.Interfaces;
using UltimateConverter.Converters.AudioConverter;

namespace UltimateConverter.Factories
{
    internal class AudioConverterFactory : IConverterFactory
    {
        public IConverter CreateConverter(string format)
        {
            return format.ToLower() switch
            {
                "mp3" => new Mp3Converter(),
                "wav" => new WavConverter(),
                "flac" => new FlacConverter(),
                "aac" => new AacConverter(),
                "ogg" => new OggConverter(),
                _ => throw new NotSupportedException($"Audio format '{format}' is not supported.")
            };
        }
    }
}