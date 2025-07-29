using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebFileExplorer.Api.Extensions;
using WebFileExplorer.Application.Features.Folders;
using WebFileExplorer.Application.Features.Folders.Create;
using WebFileExplorer.Application.Features.Folders.Delete;
using WebFileExplorer.Application.Features.Folders.Get;
using WebFileExplorer.Application.Features.Folders.GetById;
using WebFileExplorer.Application.Features.Folders.GetChildren;
using WebFileExplorer.Application.Features.Folders.GetPath;
using WebFileExplorer.Application.Features.Folders.GetRoot;
using WebFileExplorer.Application.Features.Folders.GetTree;
using WebFileExplorer.Application.Features.Folders.Move;
using WebFileExplorer.Application.Features.Folders.Rename;
using WebFileExplorer.Application.Features.Folders.Update;

namespace WebFileExplorer.Api.Controllers.Folders;

[Route("api/[controller]")]
[Authorize]
public class FoldersController(IMediator mediator) : Controller
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<FolderResponse>>> Get([FromQuery] GetFoldersQuery query, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(query, cancellationToken);
        return result.ToActionResult();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FolderResponse>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetFolderByIdQuery(id), cancellationToken);
        return result.ToActionResult();
    }

    [HttpGet("tree")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<FolderTreeResponse>>> GetTree([FromQuery] GetFolderTreeQuery query, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(query, cancellationToken);
        return result.ToActionResult();
    }

    [HttpGet("{id}/children")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<FolderResponse>>> GetChildren(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetFolderChildrenQuery(id), cancellationToken);
        return result.ToActionResult();
    }

    [HttpGet("root")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<FolderResponse>>> GetRootFolders(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetRootFoldersQuery(), cancellationToken);
        return result.ToActionResult();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FolderResponse>> Create([FromBody] CreateFolderCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        if (result.IsFailure)
            return result.ToActionResult();

        return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FolderResponse>> Update(Guid id, [FromBody] UpdateFolderCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
            return BadRequest("Id mismatch between route and body");

        var result = await mediator.Send(command, cancellationToken);
        return result.ToActionResult();
    }

    [HttpPatch("{id}/rename")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FolderResponse>> Rename(Guid id, [FromBody] RenameFolderCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
            return BadRequest("Id mismatch between route and body");

        var result = await mediator.Send(command, cancellationToken);
        return result.ToActionResult();
    }

    [HttpPatch("{id}/move")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FolderResponse>> Move(Guid id, [FromBody] MoveFolderCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
            return BadRequest("Id mismatch between route and body");

        var result = await mediator.Send(command, cancellationToken);
        return result.ToActionResult();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new DeleteFolderCommand(id), cancellationToken);
        return result.ToActionResult();
    }

    [HttpGet("{id}/path")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FolderPathResponse>> GetPath(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetFolderPathQuery(id), cancellationToken);
        return result.ToActionResult();
    }
}