using ErrorOr;

namespace GestorDeAlmacenes.Domain.Common.Errors;

public static partial class Errors
{
    public static class Salida
    {
        public static Error NotFound => Error.NotFound(
            code: "Salida.NotFound",
            description: "El salida no existe."
        );
    }
}