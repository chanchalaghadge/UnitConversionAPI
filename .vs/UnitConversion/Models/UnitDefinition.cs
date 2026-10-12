namespace UnitConversion.Models;

public sealed record UnitDefinition(
    string Symbol,
    string Category,
    decimal FactorToBase,
    decimal OffsetToBase = 0);