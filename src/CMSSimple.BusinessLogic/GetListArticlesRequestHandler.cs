using CMSSimple.BusinessLogic.Contracts;
using CMSSimple.StorageServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSSimple.BusinessLogic
{
    public class GetListArticlesRequestHandler
    {
        public GetListArticlesRequestHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        private readonly IArticleService _articleService;

        public async Task<IEnumerable<ArticleForListContract>> Handle(QueryArticlesContract contract)
        {
            Validate(contract);

            var articlesInStorage = await _articleService.GetArticles(contract.FiledToSort, contract.Desc, contract.Offset, contract.Limit);

            var articles = articlesInStorage?.Select(a =>
                new ArticleForListContract
                {
                    Id = a.Id,
                    Title = a.Title,
                    Timestamp = a.Timestamp,
                });

            return articles;
        }

        private void Validate(QueryArticlesContract contract)
        {
            string normalizedFiledToSort = contract.FiledToSort?.ToLowerInvariant();

            if (normalizedFiledToSort != "id"
                && normalizedFiledToSort != "title"
                && normalizedFiledToSort != "body"
                && normalizedFiledToSort != "timestamp")
            {
                throw new ArgumentException("Unknown FieldToSort");
            }

            if (contract.Limit < 0)
            {
                throw new ArgumentException("Limit must be greater than or equal to zero");
            }
            
            if (contract.Offset < 0)
            {
                throw new ArgumentException("Offset must be greater than or equal to zero");
            }
        }
    }
}
