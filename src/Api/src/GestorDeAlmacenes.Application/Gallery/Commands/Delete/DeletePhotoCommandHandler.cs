using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Gallery;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace GestorDeAlmacenes.Application.Gallery.Commands.Delete;

public class DeletePhotoCommandsHandler : IRequestHandler<DeletePhotoCommands, ErrorOr<GalleryResult>>
{
    private readonly IPhotoRepository _photoRepository;

    public DeletePhotoCommandsHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    public async Task<ErrorOr<GalleryResult>> Handle(DeletePhotoCommands command, CancellationToken cancellationToken)
    {
        if (await _photoRepository.GetPhotoById(command.FileId) is not Photo photo)
        {
            return Errors.File.FileNotFound;
        }

        _photoRepository.Delete(photo);
        
        return new GalleryResult(photo);
    }
}