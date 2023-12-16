using ErrorOr;

namespace GestorDeAlmacenes.Domain.Common.Errors;

public static partial class Errors
{
    public static class Rack
    {
        public static Error NotFound => Error.NotFound(
            code: "Rack.NotFound",
            description: "El rack no existe."
        );
    }
}