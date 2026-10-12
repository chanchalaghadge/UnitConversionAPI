namespace UnitConversion.Models;

public sealed record ConversionResponse(
    decimal OriginalValue,
    string FromUnit,
    decimal ConvertedValue,
    string ToUnit
    );