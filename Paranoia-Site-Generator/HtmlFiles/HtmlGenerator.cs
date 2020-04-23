using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Paranoia_Site_Generator
{
    public static class HtmlGenerator
    {
        public static string Build(Category category)
        => string.Join(
                "",
                category.Forums.Select(forum =>
                         $"<tr>" +
                                $"<th class='details-control'>{ Modal(Build(forum), forum.ForumName)}</th>" +
                                $"<th>{forum.ForumName}</th>" +
                                $"<th>{forum.ForumDesc}</th>" +
                                $"<th>{category.CatTitle }</th>" +
                                $"<th>{category.CatOrder}</th>" +
                           $"</tr>"
                )
            );

        public static string Build(Forum forum)
        {
            var body = string.Join("",forum.Topics.Select(topic => $"<tr><td class='details-control'>{ Modal(Build(topic), topic.TopicId( ))}</th><td>{topic.TopicName( )}<td></tr>"));
            return BuildTable($"forum_{forum.ForumId}", new List<string> { "View Topic", "Title" }, body);
        }

        public static string Modal( string content, string checkboxName )
        {
            var modalTemplate = File.ReadAllText("HtmlFiles/css-modal.html");
            return modalTemplate.Replace("{{checkbox}}", checkboxName).Replace("<main></main>", content);
        }

        public static string Build(List<Category> categories)
            => string.Join( "", categories.Select(category => Build(category)) );

        public static string Build(List<Post> topic)
        {
            var body = string.Join("", topic.Select(post => $"<tr><td>{post.PosterId}</td><td>{post.PostText}<td></tr>"));
            return BuildTable($"topic_{topic.First().PostId}", new List<string> { "Poster Id", "Post Content" }, body );
        }

        public static string BuildWithLayout( string tableId, List<string> tableColumnNames, string tableRows )
        {
            return BuildWithLayout(BuildTable( tableId, tableColumnNames, tableRows ));
        }

        public static string BuildTable( string tableId, List<string> tableColumnNames, string tableRows )
        {
            var tableColumns = string.Join("", tableColumnNames.Select(name => $"<th>{name}</th>"));

            var table = @$"<table id=""{ tableId }"" >" +
                $"<thead><tr>{tableColumns}</tr><tbody>{tableRows}</tbody></table>";

            return table;
        }

        public static string BuildWithLayout( string content )
        {
            string text = File.ReadAllText("HtmlFiles/layout.html");

            var replacedString = text.Replace("<main></main>", content);

            return replacedString;
        }
    }
}
