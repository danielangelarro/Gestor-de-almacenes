using GestorDeAlmacenes.Application.DTO.Gallery;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Infrastructure.Repositories;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Common.Interfaces.Repository;
using GestorDeAlmacenes.Application.Gallery.Query.GetPhotos;
using GestorDeAlmacenes.Application.Gallery.Query.Download;
using GestorDeAlmacenes.Application.Gallery.Query.GetPhotoUser;
using GestorDeAlmacenes.Application.Gallery.Commands.Upload;
using GestorDeAlmacenes.Application.Gallery.Commands.Update;
using GestorDeAlmacenes.Application.Gallery.Commands.Delete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using MediatR;
using ErrorOr;


namespace GestorDeAlmacenes.API.Controllers;

[Authorize]
[Route("fotos")]
public class GestorDeAlmacenesController : ApiController
{
    private readonly ISender _mediator;

    public GestorDeAlmacenesController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetPhotos()
    {
        var query = new GetPhotosQuery();

        ErrorOr<GalleryResultList> galleryResultList = await _mediator.Send(query);
        
        return galleryResultList.Match(
            result => Ok(galleryResultList),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPhotoById(Guid id)
    {
        var query = new DownloadPhotoQuery(id);

        ErrorOr<GalleryResult> galleryResult = await _mediator.Send(query);
        
        return galleryResult.Match(
            result => Ok(galleryResult),
            errors => Problem(errors)
        );
    }
    
    [HttpGet("download/{id}")]
    public async Task<IActionResult> DownloadPhoto(Guid id)
    {
        var query = new DownloadPhotoQuery(id);

        ErrorOr<GalleryResult> galleryResult = await _mediator.Send(query);
        
        return galleryResult.Match(
            result => Ok(File(result.photo.Contenido, "image/jpeg")),
            errors => Problem(errors)
        );
    }
    
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetPhotosByUser(Guid userId)
    {
        var query = new GetByUserPhotoQuery(userId);

        ErrorOr<GalleryResultList> galleryResultList = await _mediator.Send(query);
        
        return galleryResultList.Match(
            result => Ok(galleryResultList),
            errors => Problem(errors)
        );
    }
    
    [HttpPost]
    public async Task<IActionResult> UploadPhoto(GalleryUploadRequest request)
    {
        var query = new UploadPhotoCommands(
            request.File,
            request.FileName,
            request.FileDescription,
            request.User
        );

        ErrorOr<GalleryResult> galleryResult = await _mediator.Send(query);
        
        return galleryResult.Match(
            result => Ok(galleryResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdatePhoto(GalleryUpdateRequest request)
    {
        var query = new UpdatePhotoCommands(
            request.FileId,
            request.FileName,
            request.FileDescription
        );

        ErrorOr<GalleryResult> galleryResult = await _mediator.Send(query);
        
        return galleryResult.Match(
            result => Ok(galleryResult),
            errors => Problem(errors)
        );
    }
    
    [HttpDelete("{fileId}")]
    public async Task<IActionResult> DeletePhoto(Guid fileId)
    {
        var query = new DeletePhotoCommands(fileId);

        ErrorOr<GalleryResult> galleryResult = await _mediator.Send(query);
        
        return galleryResult.Match(
            result => Ok(),
            errors => Problem(errors)
        );
    }
}