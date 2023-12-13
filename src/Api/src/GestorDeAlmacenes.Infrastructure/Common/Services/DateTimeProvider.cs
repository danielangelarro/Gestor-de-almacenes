using GestorDeAlmacenes.Application.Common.Interfaces.Services;

namespace GestorDeAlmacenes.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}