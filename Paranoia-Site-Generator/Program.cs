using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Paranoia_Site_Generator
{
    class Program
    {
        static void BuildWebsite( string name, Func<string> func)
        {
            var completeHtml = func( );

            var indexLocation = CreateFile( name, completeHtml );

            OpenFile(indexLocation);
        }

        static string GetSolutionPath( )
            => File.ReadAllText("solutionpath.txt").Trim();

        static string CreateFile(string fileName, string completeHtml)
        {
            Directory.CreateDirectory(GetSolutionPath() + "docs/");

            var location = GetSolutionPath() + $"docs/{fileName}.html";

            using (StreamWriter writer = new StreamWriter(location, false))
            {
                writer.Write(completeHtml);
                writer.Dispose();
            }

            return location;
        }

        static void OpenFile(string fileName)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.FileName = fileName;
                p.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static string CreateIndex( )
        {
            var forumList = Factory.Build<Forum>();

            var posts = Factory.Build<Post>().OrderBy(post => post.PostTime);
            var postsLists = posts.GroupBy(post => new { post.TopicId, post.ForumId })
                .Select(group => new
                {
                    group.Key.TopicId,
                    group.Key.ForumId,
                    Posts = group.ToList()
                })
                .ToList();

            foreach (var forum in forumList)
            {
                forum.Topics = postsLists.Where(topic => topic.ForumId == forum.ForumId)
                                          .Select(topic => topic.Posts)
                                          .ToList();
            }

            var categoryList = Factory.Build<Category>().OrderBy(category => category.CatOrder).ToList();

            foreach (var category in categoryList)
            {
                category.Forums = forumList.Where(forum => forum.CatId == category.CatId).OrderBy(forum => forum.ForumOrder).ToList();
            }

            var completeHtml = HtmlGenerator.BuildWithLayout(
                "pln_forums",
                new List<string> { "Topics", "Forum", "Description", "Category", "CategoryOrder" },
                HtmlGenerator.Build(categoryList)
            );

            return completeHtml;
        }

        static string CreateItems()
        {
            var potentialItems = Factory.Build<PotentialItem>();
            var actualItems = Factory.Build<Item>();

            var itemsList = new List<IItem>();
            itemsList.AddRange(potentialItems);
            itemsList.AddRange( actualItems );

            var completeHtml = HtmlGenerator.BuildWithLayout(
                    "items",
                    new List<string> { "Name", "Description", "Cost", "Clearance", "Suggestor" },
                    HtmlGenerator.Build(itemsList)
                );

            return completeHtml;
        }

        static string CreateSecretSocieties()
        {
            var societies = Factory.Build<SecretSociety>().ToList( );

            var completeHtml = HtmlGenerator.BuildWithLayout(
                    "items",
                    new List<string> { "Name", "Special?", "Society Points", "Leader Account", "Alt. Leader Account" },
                    HtmlGenerator.Build(societies)
                );

            return completeHtml;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BuildWebsite("index", CreateIndex);
            BuildWebsite("items", CreateItems);
            BuildWebsite("societies", CreateSecretSocieties);

            //Console.WriteLine(completeHtml);

            //var location = System.IO.Path.GetTempPath() + Path.GetTempFileName() + ".html";
            //var location = Path.GetTempPath() + Guid.NewGuid().ToString() + ".html"; ;
            //var location = System.IO.Path.GetTempPath() + Path.GetTempFileName();
            //var location = Path.GetTempFileName();

            //var location = Path.GetTempPath( ) + "index.html";

            /*
            Directory.CreateDirectory(GetSolutionPath() + "docs/");

            var location = GetSolutionPath() + "docs/index.html";

            using (StreamWriter writer = new StreamWriter(location, false))
            {
                writer.Write(completeHtml);
                writer.Dispose();
            }
            try
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.FileName = location;
                p.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            */
            /*

            Console.WriteLine("Forums:");
            foreach (var category in categoryList )
            {
                Console.WriteLine($"{category.CatId} -  { category.CatTitle }:");

                var forums = category.Forums;

                foreach( var element in forums )
                {
                    Console.WriteLine($"{element.ForumName} - { element.ForumDesc }; topics: { element.ForumTopics }, Forum Id: { element.ForumId }");
                }
            }

            var itemList = Factory.Build<PotentialItem>();

            Console.WriteLine("Items:");
            foreach (var element in itemList)
            {
                Console.WriteLine($"{element.ItemName} - { element.ItemDescription}; cost: { element.ItemCost }, clearance: { element.ItemClearance }");
            }

            var mutantList = Factory.Build<Mutations>();
            Console.WriteLine("Mutations:");
            foreach (var element in mutantList)
            {
                Console.WriteLine($"{element.MutationName} - { element.MutationId} - { element.MutationSpecial }");
            }

            //Use breakpoint here to view all topics
            var posts = Factory.Build<Post>();
            var postsLists = posts.GroupBy( post => new { post.TopicId, post.ForumId } )
                .Select( group => new
                    {
                        group.Key.TopicId,
                        group.Key.ForumId,
                        Posts = group.ToList()
                    } )
                .ToList( );
                */

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
