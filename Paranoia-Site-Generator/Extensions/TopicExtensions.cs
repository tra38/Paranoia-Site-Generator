using System.Collections.Generic;
using System.Linq;

namespace Paranoia_Site_Generator
{
    public static class TopicExtensions
    {
        //https://www.dotnetperls.com/first-sentence
        public static string FirstSentence( this string content )
        {
            for (int i = 0; i < content.Length; i++)
            {
                switch (content[i])
                {
                    case '.':
                        if (i < (content.Length - 1) &&
                            char.IsWhiteSpace(content[i + 1]))
                        {
                            goto case '!';
                        }
                        break;
                    case '?':
                    case '!':
                        return content.Substring(0, i + 1);
                }
            }
            return content;
        }

        public static string TopicName(this List<Post> topic)
        {
            var firstPostSubject = topic.Find(post => !string.IsNullOrEmpty(post.PostSubject))?.PostSubject;

            if (firstPostSubject != null)
                return firstPostSubject;
            else
                return topic.First().PostText.FirstSentence();
        }

        public static string TopicId(this List<Post> topic)
            => topic.First().TopicId.ToString();
    }
}
