using ErrorOr;

namespace GestorDeAlmacenes.Domain.Common.Errors;

public static partial class Errors
{
    public static class Ubicacion
    {
        public static Error NotFound => Error.NotFound(
            code: "Rack.NotFound",
            description: "La ubicación solicitada no existe."
        );
    }
}