using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace ADOPM3_09_12.Models
{
    public class Source
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class Article
    {
        public Source Source { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }
    }
    [XmlRoot("NewsApiData", Namespace = "http://mynamespace/test/")] //This line needed only for the SampleData
    public class NewsApiData
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<Article> Articles { get; set; }
    }
}
