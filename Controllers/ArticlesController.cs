using MediatR;
using Microsoft.AspNetCore.Mvc;
using ArticlesAppProject.Application.Handlers.Articles.Queries.GetAll;
using ArticlesAppProject.Application.Handlers.Articles.Queries.Helper;

namespace ArticlesAppProject.Controllers;

public class ArticlesController : Controller
{
    private readonly ILogger<ArticlesController> _logger;
    private readonly IMediator _mediator;

    public ArticlesController(ILogger<ArticlesController> logger, IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("Articles")]
    public async Task<IActionResult> Index(Categories filterBy, SortBy sortBy, int pageSize = 10, int pageNumber = 1)
    {
        ViewData["FilterBy"] = filterBy;
        ViewData["SortBy"] = sortBy;
        ViewData["PageSize"] = pageSize;
        ViewData["PageNumber"] = pageNumber;
        ViewData["Categories"] = filterBy;
        var articles = await _mediator.Send(GetArticlesQuery.Create(pageSize, pageNumber, sortBy, filterBy));
        return View(articles);
    }
}