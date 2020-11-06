using CMSSimple.BusinessLogic.Contracts;
using CMSSimple.StorageServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMSSimple.BusinessLogic
{
    public class DeleteArticleRequestHandler
    {
        public DeleteArticleRequestHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        private readonly IArticleService _articleService;

        public async Task Handle(Guid id)
        {
            await _articleService.DeleteArticle(id, DateTime.UtcNow);
        }
    }
}
