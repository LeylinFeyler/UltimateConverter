namespace UltimateConverter.Interfaces
{
    internal interface IConverterFactory
    {
        IConverter CreateConverter(string format);
    }
}