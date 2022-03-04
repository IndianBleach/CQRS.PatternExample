using CQRS.AppCore.Entities.Article;
using CQRS.Infrastructure.DataContext;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Commands.ArticleCommands
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Article>
    {
        private ApplicationContext _dbContext;

        public CreateArticleCommandHandler(ApplicationContext ctx)
        {
            _dbContext = ctx;
        }

        public async Task<Article> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            Article createArticle = new(request.Name, request.Description);

            await _dbContext.Articles.AddAsync(createArticle);
            await _dbContext.SaveChangesAsync();

            return createArticle;
        }
    }

    public class CreateArticleCommand : IRequest<Article>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateArticleCommand()
        {
        }

        public CreateArticleCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
