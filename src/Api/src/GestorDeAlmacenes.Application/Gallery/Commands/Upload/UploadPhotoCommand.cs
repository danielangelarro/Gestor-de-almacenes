using GestorDeAlmacenes.Application.DTO.Gallery;
using GestorDeAlmacenes.Application.Entities;
using Microsoft.AspNetCore.Http;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Gallery.Commands.Upload;

public record UploadPhotoCommands(
    IFormFile file,
    string FileName,
    string FileDescription,
    User Auth
) : IRequest<ErrorOr<GalleryResult>>;