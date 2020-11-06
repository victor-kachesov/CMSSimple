using System;
using System.Collections.Generic;
using System.Text;

namespace CMSSimple.BusinessLogic.Contracts
{
    public class ArticleForListContract
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime? Timestamp { get; set; }
    }
}
