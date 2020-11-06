using CMSSimple.BusinessLogic.Contracts;
using CMSSimple.StorageServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMSSimple.BusinessLogic
{
    public class AddArticleRequestHandler
    {
        public AddArticleRequestHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        private readonly IArticleService _articleService;

        public async Task Handle(AddArticleContract contract)
        {
            await _articleService.AddArticle(Guid.NewGuid(), contract.Title, contract.Body, DateTime.UtcNow);
        }
    }
}
