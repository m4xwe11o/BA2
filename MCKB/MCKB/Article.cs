using System;
namespace MCKB
{
    public class Article
    {
        public string ArticleName { get; set; }
        public Article()
        {
        }

    }

    ObservableCollection<Article> articles = new ObservableCollection<Article>();
    public ArticleListPage()
    {
        //defined in XAML to follow
        ArticleView.ItemsSource = articles;
    }
    public ArticleListPage()
    {
        articles.Add(new Article { ArticleName = "Rob Finnerty" });
        articles.Add(new Article { ArticleName = "Bill Wrestler" });
        articles.Add(new Article { ArticleName = "Dr. Geri-Beth Hooper" });
    }
}
