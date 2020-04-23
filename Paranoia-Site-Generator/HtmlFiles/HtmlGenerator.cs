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
                        $"<th>{forum.ForumName}</th>" +
                        $"<th>{forum.ForumDesc}</th>" +
                        $"<th>{category.CatTitle }</th>" +
                        $"<th>{category.CatOrder}</th>" +
                        $"<th>DummyData</th>" +
                   $"</tr>")
            );

        public static string Build(List<Category> categories)
            => string.Join( "", categories.Select(category => Build(category)) );

        public static string Build( string tableId, List<string> tableColumnNames, string tableRows )
        {
            var tableColumns = string.Join("", tableColumnNames.Select(name => $"<th>{name}</th>") );

            var table = @$"<table id=""{ tableId }"" >" +
                $"<thead><tr>{tableColumns}</tr><tbody>{tableRows}</tbody></table>";

            return Build(table);
        }

        public static string Build( string content )
        {
            string text = File.ReadAllText("HtmlFiles/layout.html");

            var replacedString = text.Replace("<main></main>", content);

            return replacedString;
        }
    }
}
