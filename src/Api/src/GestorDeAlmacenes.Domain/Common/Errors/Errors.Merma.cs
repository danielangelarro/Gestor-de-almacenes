using ErrorOr;

namespace GestorDeAlmacenes.Domain.Common.Errors;

public static partial class Errors
{
    public static class Merma
    {
        public static Error NotFound => Error.NotFound(
            code: "Merma.NotFound",
            description: "El merma no existe."
        );
    }
}