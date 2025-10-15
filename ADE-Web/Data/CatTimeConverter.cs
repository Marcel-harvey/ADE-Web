using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

public class CatTimeConverter : ValueConverter<DateTime, DateTime>
{
    private static readonly TimeZoneInfo CatZone =
        TimeZoneInfo.FindSystemTimeZoneById("South Africa Standard Time");

    public CatTimeConverter()
        : base(
            v => ToUtcFromCat(v),
            v => TimeZoneInfo.ConvertTimeFromUtc(v, CatZone)
        )
    { }

    private static DateTime ToUtcFromCat(DateTime v)
    {
        // If already UTC, just return
        if (v.Kind == DateTimeKind.Utc)
            return v;

        // If Local or Unspecified, assume it's CAT local time
        DateTime catLocal = DateTime.SpecifyKind(v, DateTimeKind.Unspecified);
        return TimeZoneInfo.ConvertTimeToUtc(catLocal, CatZone);
    }
}
