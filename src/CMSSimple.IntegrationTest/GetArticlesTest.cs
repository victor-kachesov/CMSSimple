using CMSSimple.StorageServices;
using CMSSimple.StorageServices.Common;
using CMSSimple.StorageServices.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CMSSimple.IntegrationTest
{
    [Collection(nameof(ArticleServiceTestCollection))]
    public class GetArticlesTest : IDisposable
    {
        public GetArticlesTest()
        {
            string connectionString = "server=localhost,21433;Initial Catalog=cms;User ID=sa;Password=@Passw0rd;";

            _dbMapper = new DbMapper(connectionString);
            _articleService = new ArticleService(connectionString);
        }

        private readonly DbMapper _dbMapper;
        private readonly IArticleService _articleService;


        [Fact]
        public async Task GetArticles_ReturnCorrectData()
        {
            // Arrange
            int totalCount = 10;
            for (int i = 0; i < totalCount; i++)
            {
                await _dbMapper.ExecuteAsync("insert into articles(id, title, body, [timestamp]) values(@id, @title, @body, @timestamp)",
                    new {
                        id = Guid.NewGuid(),
                        title = "title" + i,
                        body = "body" + i,
                        timestamp = DateTime.UtcNow,
                    });
            }

            // Act
            var articles = await _articleService.GetArticles("timestamp", false, 5, 10);

            // Assert
            Assert.NotNull(articles);
            Assert.Equal(5, articles.Count());
        }

        public void Dispose()
        {
            _dbMapper.ExecuteAsync("truncate table articles;");
        }
    }
}
