using ErrorOr;

namespace GestorDeAlmacenes.Domain.Common.Errors;

public static partial class Errors
{
    public static class Cliente
    {
        public static Error NotFound => Error.NotFound(
            code: "Cliente.NotFound",
            description: "El cliente no existe."
        );
    }
}