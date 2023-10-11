using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlertUp.Configuration;

public class DateTimeOffsetConverter : ValueConverter<DateTimeOffset, DateTimeOffset>
{
    public DateTimeOffsetConverter()
        : base(
            d => d.ToUniversalTime(),
            d => d.ToUniversalTime()
        )
    { }
}