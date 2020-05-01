namespace Paranoia_Site_Generator
{
    public interface IItem
    {
        int ItemId( );
        string ItemName( );
        int ItemCost( );
        public int ItemClearance( );
        public int ItemDecay( );
        public int ItemAction( );
        public string ItemDescription( );
        public string ItemSuggestor();
    }
}
