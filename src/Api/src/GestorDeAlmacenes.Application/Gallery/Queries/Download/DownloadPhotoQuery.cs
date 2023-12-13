using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Gallery;
using MediatR;

namespace GestorDeAlmacenes.Application.Gallery.Query.Download;

public record DownloadPhotoQuery(
    Guid FileId
) : IRequest<ErrorOr<GalleryResult>>;