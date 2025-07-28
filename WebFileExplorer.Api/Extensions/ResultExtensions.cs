using Microsoft.AspNetCore.Mvc;
using WebFileExplorer.SharedKernel.Api;

namespace WebFileExplorer.Api.Extensions
{
    public static class ResultExtensions
    {
        public static ActionResult ToActionResult<T>(this Result<T> result)
        {
            if (result.IsSuccess)
                return new OkObjectResult(result.Value);

            return new NotFoundObjectResult(result.Error);
        }

        public static ActionResult ToActionResult(this Result result)
        {
            if (result.IsSuccess)
                return new NoContentResult();

            return new NotFoundObjectResult(result.Error);
        }
    }
}
