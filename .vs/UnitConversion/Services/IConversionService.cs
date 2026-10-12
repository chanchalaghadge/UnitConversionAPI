
using UnitConversion.Models;

namespace UnitConversion.Services;

public interface IConversionService
{
    ConversionResponse Convert(ConversionRequest request);

    IEnumerable<UnitDefinition> GetUnits();
}