using CQRS.AppCore.Entities.Article;
using CQRS.Infrastructure.Commands.ArticleCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Web.Controllers
{
    public class CreateController : Controller
    {
        private readonly IMediator _mediator;

        public CreateController(IMediator mediator)
        {
            _mediator = mediator;
        }        

        [HttpPost]
        [ProducesResponseType(typeof(Article), StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Article(
            CreateArticleCommand model)
        {
            Article resultEntity = await _mediator.Send(model);    

            return CreatedAtAction(nameof(Article), resultEntity);
        }

    }
}
