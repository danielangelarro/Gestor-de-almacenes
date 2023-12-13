using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Gallery;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;

namespace GestorDeAlmacenes.Application.Gallery.Query.Download;

public class DownloadPhotoQueryHandler : IRequestHandler<DownloadPhotoQuery, ErrorOr<GalleryResult>>
{
    private readonly IPhotoRepository _photoRepository;

    public DownloadPhotoQueryHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    public async Task<ErrorOr<GalleryResult>> Handle(DownloadPhotoQuery query, CancellationToken cancellationToken)
    {
        if (await _photoRepository.GetPhotoById(query.FileId) is not Photo photo)
        {
            return Errors.File.FileNotFound;
        }

        return new GalleryResult(photo);
    }
}