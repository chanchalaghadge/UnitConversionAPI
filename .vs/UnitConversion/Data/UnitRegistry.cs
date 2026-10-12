using UnitConversion.Models;

namespace UnitConversion.Data;

public static class UnitRegistry
{
    public static readonly IReadOnlyDictionary<string, UnitDefinition>
        Units = new Dictionary<string, UnitDefinition>(
            StringComparer.OrdinalIgnoreCase)
        {
            // Length: base unit = meter
            ["m"] = new("m", "length", 1m),
            ["km"] = new("km", "length", 1000m),
            ["cm"] = new("cm", "length", 0.01m),
            ["mm"] = new("mm", "length", 0.001m),
            ["ft"] = new("ft", "length", 0.3048m),
            ["in"] = new("in", "length", 0.0254m),
            ["mi"] = new("mi", "length", 1609.344m),

            // Mass: base unit = kilogram
            ["kg"] = new("kg", "mass", 1m),
            ["g"] = new("g", "mass", 0.001m),
            ["mg"] = new("mg", "mass", 0.000001m),
            ["lb"] = new("lb", "mass", 0.45359237m),
            ["oz"] = new("oz", "mass", 0.028349523125m),

            // Temperature: base unit = Kelvin
            // Kelvin = Celsius + 273.15
            ["c"] = new("C", "temperature", 1m, 273.15m),

            // Kelvin = Fahrenheit * 5/9 + 255.372222...
            ["f"] = new("F", "temperature",
                5m / 9m, 273.15m - 32m * 5m / 9m),

            ["k"] = new("K", "temperature", 1m)
        };
}