using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Gallery;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Gallery.Commands.Update;

public class UpdatePhotoCommandsHandler : IRequestHandler<UpdatePhotoCommands, ErrorOr<GalleryResult>>
{
    private readonly IPhotoRepository _photoRepository;

    public UpdatePhotoCommandsHandler(IPhotoRepository photoRepository)
    {
        _photoRepository = photoRepository;
    }

    public async Task<ErrorOr<GalleryResult>> Handle(UpdatePhotoCommands command, CancellationToken cancellationToken)
    {
        if (await _photoRepository.GetPhotoById(command.FileId) is not Photo photo)
        {
            return Errors.File.FileNotFound;
        }

        photo.FileName = command.FileName;
        photo.FileDescription = command.FileDescription;
        
        _photoRepository.Put(photo);
        
        return new GalleryResult(photo);
    }
}