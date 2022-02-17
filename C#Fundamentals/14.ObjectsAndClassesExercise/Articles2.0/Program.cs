using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ");
                string title = tokens[0];
                string content = tokens[1];
                string author = tokens[2];

                Article article = new Article(title, content, author);
                articles.Add(article);
            }

            string criteria = Console.ReadLine();

            if (criteria == "title")
            {
                articles.Sort((a1, a2) => a1.Title.CompareTo(a2.Title));
            }
            else if (criteria == "content")
            {
                articles = articles.OrderBy(n => n.Content).ToList();
            }
            else if (criteria == "author")
            {
                articles = articles.OrderBy(n => n.Autor).ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, articles));
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Autor = author;
        }


        public string Title { get; set; }
        public string Content { get; set; }
        public string Autor { get; set; }



        public override string ToString()
        {
            return $"{Title} - {Content}: {Autor}";
        }
    }
    }

