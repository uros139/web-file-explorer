using Microsoft.AspNetCore.Mvc;
using MediatR;
using WebFileExplorer.Application.Features.Files;
using WebFileExplorer.Application.Features.Files.Upload;
using WebFileExplorer.Api.Extensions;
using WebFileExplorer.Application.Features.Files.GetContent;
using WebFileExplorer.Application.Features.Files.GetByFolder;
using WebFileExplorer.Application.Features.Files.GetById;
using WebFileExplorer.Application.Features.Files.GetThumbnail;
using WebFileExplorer.Application.Features.Files.Rename;
using WebFileExplorer.Application.Features.Files.Move;
using WebFileExplorer.Application.Features.Files.Delete;
using WebFileExplorer.Application.Features.Files.Update;
using WebFileExplorer.Application.Features.Files.Get;

namespace WebFileExplorer.Api.Controllers.Files;

[Route("api/[controller]")]
public class FilesController(IMediator mediator) : Controller
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<FileResponse>>> Get([FromQuery] GetFilesQuery query, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(query, cancellationToken);
        return result.ToActionResult();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FileResponse>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetFileByIdQuery(id), cancellationToken);
        return result.ToActionResult();
    }

    [HttpGet("folder/{folderId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<FileResponse>>> GetByFolderId(Guid folderId, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetFilesByFolderIdQuery(folderId), cancellationToken);
        return result.ToActionResult();
    }

    [HttpGet("{id}/content")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetFileContent(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetFileContentQuery(id), cancellationToken);
        if (result.IsFailure)
            return result.ToActionResult();

        var fileContent = result.Value;
        return File(fileContent.Data ?? [], fileContent.ContentType, fileContent.FileName);
    }

    [HttpGet("{id}/thumbnail")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetFileThumbnail(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetFileThumbnailQuery(id), cancellationToken);
        if (result.IsFailure)
            return result.ToActionResult();

        var thumbnail = result.Value;
        return File(thumbnail.Data, thumbnail.ContentType);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FileResponse>> Upload([FromForm] UploadFileCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return result.ToActionResult();

        return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FileResponse>> Update([FromBody] UpdateFileCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return result.ToActionResult();
    }

    [HttpPatch("rename")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FileResponse>> Rename([FromBody] RenameFileCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return result.ToActionResult();
    }

    [HttpPatch("move")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FileResponse>> Move([FromBody] MoveFileCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return result.ToActionResult();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteFileCommand(id), cancellationToken);
        return NoContent();
    }
}