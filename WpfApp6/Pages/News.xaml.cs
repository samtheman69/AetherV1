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

        // Method to load news data
        private void LoadNews()
        {
            List<NewsItem> newsItems = new List<NewsItem>
            {
                new NewsItem { Title = "New Fortnite Update", Description = "Fortnite v12.41 released with exciting new features and skins!" },
            };

            // Bind the news items to the ListView
            NewsListView.ItemsSource = newsItems;
        }

        // Event handler for refreshing news
        private void RefreshNews_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("News refreshed!");
            LoadNews(); // In a real-world scenario, this would reload or fetch updated news
        }
    }
}
