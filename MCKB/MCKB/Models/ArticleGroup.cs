using System;
using System.Collections.Generic;

namespace MCKB
{
    public class ArticleGroup : List<Article>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }

        public ArticleGroup(string title, string shortTitle)
        {
            Title = title;
            ShortTitle = shortTitle; 
        }
    }
}
