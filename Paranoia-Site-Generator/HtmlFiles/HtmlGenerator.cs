using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Paranoia_Site_Generator
{
    public static class HtmlGenerator
    {
        public static string Build(List<IItem> items)
            => string.Join(
                "",
                items.Select(item =>
                    $"<tr>" +
                        $"<td>{item.ItemName( )}</td>" +
                        $"<td>{HttpUtility.HtmlEncode( item.ItemDescription( ) )}</td>" +
                        $"<td>{item.ItemCost( )} Credits</td>" +
                        $"<td>{item.ItemClearance( )}</td>" +
                        $"<td>{item.ItemSuggestor( )}</td>" +
                    $"</tr>"
                )
              );

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
            return BuildTable($"forum", new List<string> { "View Topic", "Title" }, body);
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
            var body = string.Join("", topic.Select(post => $"<tr><td>{post.PosterId.Username( )}</td><td class='post__text'>{post.PostText}<td></tr>"));
            return BuildTable($"topic", new List<string> { "Poster Name/Id", "Post Content" }, body );
        }

        public static string BuildWithLayout( string tableClass, List<string> tableColumnNames, string tableRows )
        {
            return BuildWithLayout(BuildTable( tableClass, tableColumnNames, tableRows ));
        }

        public static string BuildTable( string tableClass, List<string> tableColumnNames, string tableRows )
        {
            var tableColumns = string.Join("", tableColumnNames.Select(name => $"<th>{name}</th>"));

            var table = @$"<table class=""{ tableClass }"" >" +
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
