using System;
using System.Collections.Generic;
using System.Text;

namespace CMSSimple.BusinessLogic.Contracts
{
    public class QueryArticlesContract
    {
        public string FiledToSort { get; set; }

        public bool Desc { get; set; }

        public int Limit { get; set; }

        public int Offset { get; set; }
    }
}
