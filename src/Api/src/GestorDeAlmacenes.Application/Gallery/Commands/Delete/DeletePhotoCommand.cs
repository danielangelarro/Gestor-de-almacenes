using GestorDeAlmacenes.Application.DTO.Gallery;
using ErrorOr;
using MediatR;

namespace GestorDeAlmacenes.Application.Gallery.Commands.Delete;

public record DeletePhotoCommands(
    Guid FileId
) : IRequest<ErrorOr<GalleryResult>>;