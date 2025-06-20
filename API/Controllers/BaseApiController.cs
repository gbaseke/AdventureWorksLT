using System;
using API.RequestHelpers;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    protected async Task<ActionResult> CreatePagedResult<T, TResult>(IGenericRepository<T> repo, 
        ISpecification<T> spec, 
        Func<T, TResult> toDto, 
        int pageIndex = 1, 
        int pageSize = 6) where T : class
    {
        var items = await repo.ListAsync(spec);
        var count = await repo.CountAsync(spec);
        
        var dtos = items.Select(toDto).ToList();
        
        var pagination = new Pagination<TResult>(
            pageIndex, 
            pageSize, 
            count, 
            dtos
        );
        
        return Ok(pagination);
    }
}
