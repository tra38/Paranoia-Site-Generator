using System.Collections.Generic;

namespace Paranoia_Site_Generator
{
    [SqlStatement( "SELECT * FROM phpbb_categories" )]
    public class Category : PLN_Object
    {
        public int CatId;
        public int CatOrder;
        public string CatTitle;

        public List<Forum> Forums;

        public int Id { get => CatId; }
    }
}
