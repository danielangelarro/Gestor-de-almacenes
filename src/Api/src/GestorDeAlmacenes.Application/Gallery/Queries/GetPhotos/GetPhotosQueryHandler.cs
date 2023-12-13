using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Gallery;
using MediatR;

namespace GestorDeAlmacenes.Application.Gallery.Query.GetPhotos;

public class GetPhotosQueryHandler : IRequestHandler<GetPhotosQuery, ErrorOr<GalleryResultList>>
{
    private readonly IPhotoRepository _photoRepository;

    public GetPhotosQueryHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    public async Task<ErrorOr<GalleryResultList>> Handle(GetPhotosQuery query, CancellationToken cancellationToken)
    {
        return new GalleryResultList(await _photoRepository.GetPhotos());
    }
}