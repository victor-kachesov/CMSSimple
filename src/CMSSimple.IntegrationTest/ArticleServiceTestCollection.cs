using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CMSSimple.IntegrationTest
{
    [CollectionDefinition(nameof(ArticleServiceTestCollection), DisableParallelization = true)]
    public class ArticleServiceTestCollection
    {
    }
}
