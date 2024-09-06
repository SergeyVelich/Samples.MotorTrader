using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Samples.MT.Common.Api.Ardalis;

public static class MvcOptionsExtensions
{
    public static MvcOptions ConfigureArdalis(this MvcOptions mvcOptions)
    {
        mvcOptions.AddResultConvention(resultStatusMap => resultStatusMap
            .AddDefaultMap()
            .For(ResultStatus.Ok, HttpStatusCode.OK, resultStatusOptions => resultStatusOptions
                .For("POST", HttpStatusCode.Created)
                .For("DELETE", HttpStatusCode.NoContent))
            .For(ResultStatus.Error, HttpStatusCode.InternalServerError));

        return mvcOptions;
    }
}