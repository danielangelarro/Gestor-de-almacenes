using ErrorOr;

namespace GestorDeAlmacenes.Domain.Common.Errors;

public static partial class Errors
{
    public static class Entrada
    {
        public static Error NotFound => Error.NotFound(
            code: "Entrada.NotFound",
            description: "El entrada no existe."
        );
    }
}