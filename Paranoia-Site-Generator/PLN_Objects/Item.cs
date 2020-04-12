namespace Paranoia_Site_Generator.PLN_Objects
{
    [SqlStatement("SELECT * FROM phpbb_ac_items")]
    public class Item
    {
        public int ItemId;
        public string ItemName;
        public int ItemCost;
        public int ItemClearance;
        public int ItemDecay;
        public int ItemAction;
        public string ItemDescription;
    }
}
