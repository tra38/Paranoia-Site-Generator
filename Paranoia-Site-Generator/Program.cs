using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Paranoia_Site_Generator
{
    class Program
    {
        /*
            //Stories:
            //1) Gather data.
            //2) Populate static site with data.

            //Should the data simply be transformed into txt files? And then
            //I transfer said txt files to a static site generator?
            //Or do I roll my own static site generator?

            //Seems there's too many specific limits, and I need the practice,
            //so I'll generate my own static site generator. Time to look
            //at the pattern book.

            //For now, we should roll our own static site generator.
        */

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var forumList = Factory.Build<Forum>();

            var categoryList = Factory.Build<Category>().OrderBy(category => category.CatOrder).ToList( );

            foreach (var category in categoryList)
            {
                category.Forums = forumList.Where(forum => forum.CatId == category.CatId).OrderBy(forum => forum.ForumOrder).ToList();
            }

            var completeHtml = HtmlGenerator.Build(
                "pln_forums",
                new List<string> { "Forum", "Description", "Category", "CategoryOrder", "Forum Topics" },
                HtmlGenerator.Build( categoryList )
            );

            Console.WriteLine(completeHtml);

            //var location = System.IO.Path.GetTempPath() + Path.GetTempFileName() + ".html";
            var location = Path.GetTempPath() + Guid.NewGuid().ToString() + ".html"; ;
            //var location = System.IO.Path.GetTempPath() + Path.GetTempFileName();
            //var location = Path.GetTempFileName();

            //var location = Path.GetTempPath( ) + "index.html";

            using (StreamWriter writer = new StreamWriter(location, true))
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
                //p.Start("/Applications/Utilities/Terminal.app", $"less { location }");
                //System.Diagnostics.Process.Start("/Applications/Google Chrome.app/Contents/MacOS/'Google Chrome'", location);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
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
