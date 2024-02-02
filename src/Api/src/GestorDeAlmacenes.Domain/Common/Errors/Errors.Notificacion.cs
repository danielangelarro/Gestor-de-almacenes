using ErrorOr;

namespace GestorDeAlmacenes.Domain.Common.Errors;

public static partial class Errors
{
    public static class Notificacion
    {
        public static Error NotificacionNotFound => Error.NotFound(
            code: "Notificacion.NotFound",
            description: "Notification Not Found."
        );
    }
}