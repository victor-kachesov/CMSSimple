using CMSSimple.BusinessLogic.Contracts;
using CMSSimple.StorageServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMSSimple.BusinessLogic
{
    public class UpdateArticleRequestHandler
    {
        public UpdateArticleRequestHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        private readonly IArticleService _articleService;

        public async Task Handle(Guid id, AddArticleContract contract)
        {
            await _articleService.UpdateArticle(id, contract.Title, contract.Body, DateTime.UtcNow);
        }
    }
}
