using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MCKB
{
    public partial class ArticlePage : ContentPage
    {
        public ArticlePage()
        {
            InitializeComponent();

            articleListView.ItemsSource = new List<Article>{
                new Article { Title = "STM32F1", Description = "Description Text with some more lines to see how this looks like in the list", Articletext = "Article text"},
                new Article { Title = "STM32F3", Description = "Description Text", Articletext = "Article text"},
                new Article { Title = "STM32F4", Description = "Description Text", Articletext = "Article text"}
            };
        }
    }
}
