namespace Paranoia_Site_Generator
{
    [SqlStatement("SELECT * FROM phpbb_posts INNER JOIN phpbb_posts_text ON phpbb_posts.post_id = phpbb_posts_text.post_id ORDER BY post_time;")]
    public class Post : PLN_Object
    {
        public int PostId;
        public int TopicId;
        public int ForumId;
        public int PosterId;
        public int PostTime;
        public string PosterIp;
        public string PostUsername;
        public int EnableBbcode;
        public int EnableHtml;
        public int EnableSmilies;
        public int EnableSig;
        public int PostEditTime;
        public int PostEditCount;
        public int PostScore;
        public string PostText;
        public string PostSubject;

        public int Id { get => PostId; }
    }
}
