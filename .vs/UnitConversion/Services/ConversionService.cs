using UnitConversion.Data;
using UnitConversion.Models;
using UnitConversion.Services;

using UnitConversion.Data;
using UnitConversion.Models;

namespace UnitConversion.Api.Services;

public sealed class ConversionService : IConversionService
{
    public ConversionResponse Convert(ConversionRequest request)
    {
        var from = GetUnit(request.FromUnit);
        var to = GetUnit(request.ToUnit);

        if (!string.Equals(
                from.Category, to.Category,
                StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException(
                "Source and target units must belong to the same category.");
        }

        // Convert the input into the category's base unit.
        decimal baseValue =
            request.Value * from.FactorToBase + from.OffsetToBase;

        // Convert from the base unit into the requested target unit.
        decimal result =
            (baseValue - to.OffsetToBase) / to.FactorToBase;

        return new ConversionResponse(
            request.Value,
            from.Symbol,
            decimal.Round(result, 6),
            to.Symbol);
    }

    public IEnumerable<UnitDefinition> GetUnits()
    {
        return UnitRegistry.Units.Values
            .OrderBy(unit => unit.Category)
            .ThenBy(unit => unit.Symbol);
    }

    private static UnitDefinition GetUnit(string symbol)
    {
        if (string.IsNullOrWhiteSpace(symbol))
        {
            throw new ArgumentException(
                "Unit cannot be empty.");
        }

        if (!UnitRegistry.Units.TryGetValue(
                symbol.Trim(), out var unit))
        {
            throw new KeyNotFoundException(
                $"Unsupported unit: '{symbol}'.");
        }

        return unit;
    }
}
