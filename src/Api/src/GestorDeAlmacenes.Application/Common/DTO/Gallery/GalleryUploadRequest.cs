using GestorDeAlmacenes.Application.Entities;
using Microsoft.AspNetCore.Http;

namespace GestorDeAlmacenes.Application.DTO.Gallery;

public record GalleryUploadRequest(
    IFormFile File,
    string FileName,
    string FileDescription,
    User User
);