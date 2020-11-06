using CMSSimple.StorageServices;
using CMSSimple.StorageServices.Common;
using CMSSimple.StorageServices.Contracts;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CMSSimple.IntegrationTest
{
    [Collection(nameof(ArticleServiceTestCollection))]
    public class AddArticleTest : IDisposable
    {
        public AddArticleTest()
        {
            string connectionString = "server=localhost,21433;Initial Catalog=cms;User ID=sa;Password=@Passw0rd;";

            _dbMapper = new DbMapper(connectionString);
            _articleService = new ArticleService(connectionString);
        }

        private readonly DbMapper _dbMapper;
        private readonly IArticleService _articleService;


        [Fact]
        public async Task AddArticle_InsertDataToTable()
        {
            // Arrange
            Guid id = new Guid("16ef4cad-0bd1-4193-88f7-af3bf5b47dc0");
            string title = "title1";
            string body = "body1";

            // Act
            await _articleService.AddArticle(id, title, body, DateTime.UtcNow);

            // Assert
            var article = await _dbMapper.QuerySingleOrDefaultAsync<ArticleInStorage>("select * from articles where id=@id",
                new
                {
                    id = id,
                });

            Assert.Equal(id, article.Id);
            Assert.Equal(title, article.Title);
            Assert.Equal(body, article.Body);
        }

        public void Dispose()
        {
            _dbMapper.ExecuteAsync("truncate table articles;");
        }
    }
}
