namespace Paranoia_Site_Generator
{
    [SqlStatement("SELECT * FROM phpbb_ac_items")]
    public class Item : PLN_Object
    {
        public int ItemId;
        public string ItemName;
        public int ItemCost;
        public int ItemClearance;
        public int ItemDecay;
        public int ItemAction;
        public string ItemDescription;

        public int Id { get => ItemId; }
    }
}
