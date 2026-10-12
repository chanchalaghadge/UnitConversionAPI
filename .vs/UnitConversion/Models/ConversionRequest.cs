
namespace UnitConversion.Models;

public sealed class ConversionRequest
{
    public decimal Value { get; init; }

    public string FromUnit { get; init; } = string.Empty;

    public string ToUnit { get; init; } = string.Empty;
}
