using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMSSimple.BusinessLogic;
using CMSSimple.BusinessLogic.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMSSimple.WebApi.Controllers
{
    [Route("api/article")]
    [ApiController]
    [Authorize]
    public class ArticleController : ControllerBase
    {
        public ArticleController(AddArticleRequestHandler addArticleRequestHandler,
            UpdateArticleRequestHandler updateArticleRequestHandler,
            DeleteArticleRequestHandler deleteArticleRequestHandler,
            GetArticleRequestHandler getArticleRequestHandler,
            GetListArticlesRequestHandler getListArticlesRequestHandler)
        {
            _addArticleRequestHandler = addArticleRequestHandler;
            _updateArticleRequestHandler = updateArticleRequestHandler;
            _deleteArticleRequestHandler = deleteArticleRequestHandler;
            _getArticleRequestHandler = getArticleRequestHandler;
            _getListArticlesRequestHandler = getListArticlesRequestHandler;
        }

        private readonly AddArticleRequestHandler _addArticleRequestHandler;
        private readonly UpdateArticleRequestHandler _updateArticleRequestHandler;
        private readonly DeleteArticleRequestHandler _deleteArticleRequestHandler;
        private readonly GetArticleRequestHandler _getArticleRequestHandler;
        private readonly GetListArticlesRequestHandler _getListArticlesRequestHandler;

        // GET: api/<ArticleController>
        [HttpGet]
        public async Task<IEnumerable<ArticleForListContract>> GetAsync([FromBody] QueryArticlesContract contract)
        {
            return await _getListArticlesRequestHandler.Handle(contract);
        }

        // GET api/<ArticleController>/5
        [HttpGet("{id}")]
        public async Task<ArticleContract> GetAsync(Guid id)
        {
            return await _getArticleRequestHandler.Handle(id);
        }

        // POST api/<ArticleController>
        [HttpPost]
        public async Task PostAsync([FromBody] AddArticleContract contract)
        {
            await _addArticleRequestHandler.Handle(contract);
        }

        // PUT api/<ArticleController>/{guid}
        [HttpPut("{id}")]
        public async Task PutAsync(Guid id, [FromBody] AddArticleContract contract)
        {
            await _updateArticleRequestHandler.Handle(id, contract);
        }

        // DELETE api/<ArticleController>/{guid}
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _deleteArticleRequestHandler.Handle(id);
        }
    }
}
