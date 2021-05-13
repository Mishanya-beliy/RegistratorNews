using System;
using System.Collections.Generic;

namespace RegistratorNews
{
    static class NewsManager
    {
        private static readonly Dictionary<int, News> News = new Dictionary<int, News>();
        private static int idNews = 0;
        static int Add(DateTime publishDate, Categories category, string summary, FullName journalistName)
        {
            News.Add(idNews, new(publishDate, category, summary, journalistName));
            return idNews++;
        }
        static bool Remove(int id)
        {
            return News.Remove(id);
        }
        static void EditNews(int id, string newSummary)
        {
            if (News.TryGetValue(id, out var news))
                news.Summary = newSummary;
        }
        static void EditJournalist(int id,FullName newJournalistName)
        {
            if (News.TryGetValue(id, out var news))
                news.JournalistName = newJournalistName;
        }

        static List<News> GetRange(DateTime start, DateTime finish)
        {
            List<News> response = new List<News>();

            foreach (var news in News.Values)
                if (news.PublishDate >= start && news.PublishDate <= finish)
                    response.Add(news);

            return response;
        }
    }
    class News
    {
        internal DateTime PublishDate { get; }
        internal Categories Category { get; }
        internal string Summary { get; set; }
        internal FullName JournalistName { get; set; }

        internal News(DateTime publishDate, Categories category, string summary, FullName journalistName)
        {
            PublishDate = publishDate;
            Category = category;
            Summary = summary;
            JournalistName = journalistName;
        }
    }
    struct FullName
    {
        public string name;
        public string surname;
        public string patronymic;
    }

    enum Categories
    {
        Culture,
        Sport,
        Science
    }
}
