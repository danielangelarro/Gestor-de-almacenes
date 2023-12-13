using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Gallery;
using GestorDeAlmacenes.Application.Entities;
using MediatR;

namespace GestorDeAlmacenes.Application.Gallery.Query.GetPhotoUser;

public class GetByUserPhotoQueryHandler : IRequestHandler<GetByUserPhotoQuery, ErrorOr<GalleryResultList>>
{
    private readonly IPhotoRepository _photoRepository;

    public GetByUserPhotoQueryHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    public async Task<ErrorOr<GalleryResultList>> Handle(GetByUserPhotoQuery query, CancellationToken cancellationToken)
    {
        List<Photo>? photos = await _photoRepository.GetPhotosByUser(query.UserId);

        return new GalleryResultList(photos);
    }
}