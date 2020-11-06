using CMSSimple.BusinessLogic.Common;
using CMSSimple.BusinessLogic.Contracts;
using CMSSimple.StorageServices.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CMSSimple.BusinessLogic
{
    public class GetArticleRequestHandler
    {
        public GetArticleRequestHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        private readonly IArticleService _articleService;

        public async Task<ArticleContract> Handle(Guid id)
        {
            var articleInStorage = await _articleService.GetArticle(id);

            if (articleInStorage == null)
            {
                throw new HttpResponseException { 
                    Status = (int)HttpStatusCode.NotFound
                };
            }

            return new ArticleContract
            {
                Title = articleInStorage.Title,
                Body = articleInStorage.Body,
                Timestamp = articleInStorage.Timestamp,
            };
        }
    }
}
