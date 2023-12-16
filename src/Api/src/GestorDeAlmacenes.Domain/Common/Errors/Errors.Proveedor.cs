using ErrorOr;

namespace GestorDeAlmacenes.Domain.Common.Errors;

public static partial class Errors
{
    public static class Proveedor
    {
        public static Error NotFound => Error.NotFound(
            code: "Proveedor.NotFound",
            description: "El proveedor no existe."
        );
    }
}