using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp6.Pages
{
    public partial class News : Page
    {
        public class NewsItem
        {
            public string? Title { get; set; }
            public string? Description { get; set; }
        }

        public News()
        {
            InitializeComponent();
            LoadNews();
        }

        private void LoadNews()
        {
            List<NewsItem> newsItems = new List<NewsItem>
            {
                new NewsItem { Title = "New Aether Update!", Description = "Fortnite v12.41 released with exciting new features and skins!" },
                new NewsItem { Title = "V-Bucks On Kill", Description = "You Can Now Earn Vbucks On Kill And Win!" },

            };

            NewsListView.ItemsSource = newsItems;
        }

        private void RefreshNews_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("News refreshed!");
            LoadNews();
        }
    }
}
