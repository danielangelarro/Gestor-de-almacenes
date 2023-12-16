using ErrorOr;

namespace GestorDeAlmacenes.Domain.Common.Errors;

public static partial class Errors
{
    public static class Casillero
    {
        public static Error NotFound => Error.NotFound(
            code: "Casillero.NotFound",
            description: "El casillero no existe."
        );
    }
}