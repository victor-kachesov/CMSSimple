using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMSSimple.StorageServices.Contracts
{
    public interface IArticleService
    {
        Task<ArticleInStorage> GetArticle(Guid id);
        
        Task<IEnumerable<ArticleInStorage>> GetArticles(string fieldToSort, bool desc, int offset, int limit);
        
        Task AddArticle(Guid id, string title, string body, DateTime timestamp);
        
        Task UpdateArticle(Guid id, string title, string body, DateTime timestamp);
        
        Task DeleteArticle(Guid id, DateTime timestamp);
    }
}
