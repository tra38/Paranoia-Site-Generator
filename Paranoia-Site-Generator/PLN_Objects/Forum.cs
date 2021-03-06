﻿using System.Collections.Generic;

namespace Paranoia_Site_Generator
{
    [SqlStatement("SELECT * FROM phpbb_forums" )]
    public class Forum : PLN_Object
    {
        public int ForumId;
        public int CatId;
        public string ForumName;
        public string ForumDesc;
        public int ForumStats;
        public int ForumOrder;
        public int ForumPosts;
        public int ForumTopics;
        public int ForumLastPostId;
        public int PruneNext;
        public bool PruneEnable;
        public int AuthView;
        public int AuthRead;
        public int AuthPost;
        public int AuthReply;
        public int AuthEdit;
        public int AuthDelete;
        public int AuthSticky;
        public int AuthAnnounce;
        public int AuthVote;
        public int AuthPollCreate;
        public int AuthAttachments;
        public List<List<Post>> Topics;

        public int Id { get => ForumId; }
    }
}
