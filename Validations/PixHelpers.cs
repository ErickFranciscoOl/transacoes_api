using System.Text.RegularExpressions;

namespace Transacoes.Validation;

public class PixHelpers
{
    public static string GerarEndToEndId(DateTime hora)
    {
        var randomChars = new Regex("[^a-zA-Z0-9 -]")
            .Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "")
            .Substring(0, 11);
        return $"E{Defaults.MicrocashIspb}{hora:yyyyMMddHHmm}{randomChars}";
    }

    public static string GerarEndToEndIdDevolucao(string ispb, DateTime hora)
    {
        var randomChars = new Regex("[^a-zA-Z0-9 -]")
            .Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "")
            .Substring(0, 11);
        return $"R{ispb}{hora:yyyyMMddHHmm}{randomChars}";
    }
}

public struct Defaults
{
    public const int MicrocashIspb = 45756448;
}