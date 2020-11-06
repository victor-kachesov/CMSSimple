using CMSSimple.StorageServices.Common;
using CMSSimple.StorageServices.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CMSSimple.StorageServices
{
    public class ArticleService : IArticleService
    {
        public ArticleService(string connectionString)
        {
            _dbMapper = new DbMapper(connectionString);
        }

        private readonly DbMapper _dbMapper;

        public Task<ArticleInStorage> GetArticle(Guid id)
        {
            return _dbMapper.QuerySingleOrDefaultAsync<ArticleInStorage>("select id, title, body, timestamp from articles where id=@id and ISNULL(deleted, 0) <> 1",
                new
                {
                    id = id,
                });
        }

        public Task<IEnumerable<ArticleInStorage>> GetArticles(string fieldToSort, bool asc, int offset, int limit)
        {
            string sortClause = asc ? "asc" : "desc";
            
            string query = $"select id, title, timestamp from articles where ISNULL(deleted, 0) <> 1 order by {fieldToSort} {sortClause} offset @offset rows fetch next @limit rows only";

            return _dbMapper.QueryMultipleAsync<ArticleInStorage>(query,
                new { 
                    offset = offset,
                    limit = limit,
                });
        }

        public Task AddArticle(Guid id, string title, string body, DateTime timestamp)
        {
            return _dbMapper.ExecuteOrThrowAsync("insert into articles(id, title, body, [timestamp]) values (@id, @title, @body, @timestamp)", 
                new { 
                    id = id,
                    title = title,
                    body = body,
                    timestamp = timestamp,
                });
        }

        public Task UpdateArticle(Guid id, string title, string body, DateTime timestamp)
        {
            return _dbMapper.ExecuteOrThrowAsync("update articles set title = @title, body = @body, [timestamp] = @timestamp where id = @id",
                new
                {
                    id = id,
                    title = title,
                    body = body,
                    timestamp = timestamp,
                });
        }

        public Task DeleteArticle(Guid id, DateTime timestamp)
        {
            return _dbMapper.ExecuteOrThrowAsync("update articles set deleted = 1, [timestamp] = @timestamp where id = @id",
                new
                {
                    id = id,
                    timestamp = timestamp,
                });
        }
    }
}
