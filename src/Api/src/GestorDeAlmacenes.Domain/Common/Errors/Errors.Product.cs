using ErrorOr;

namespace GestorDeAlmacenes.Domain.Common.Errors;

public static partial class Errors
{
    public static class Producto
    {
        public static Error NotFound => Error.NotFound(
            code: "Producto.NotFound",
            description: "El producto no existe."
        );
    }
}