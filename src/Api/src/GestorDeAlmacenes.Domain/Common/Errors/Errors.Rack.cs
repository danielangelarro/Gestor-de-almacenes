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
        
        public static Error NotFoundWait => Error.NotFound(
            code: "Rack.NotFoundWait",
            description: "El rack de espera no existe."
        );
    }
}