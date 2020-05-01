namespace Paranoia_Site_Generator
{
    [SqlStatement("SELECT * FROM phpbb_ac_items")]
    public class Item : PLN_Object, IItem
    {
        public int ItemId;
        public string ItemName;
        public int ItemCost;
        public int ItemClearance;
        public int ItemDecay;
        public int ItemAction;
        public string ItemDescription;

        public int Id { get => ItemId; }

        int IItem.ItemId() => ItemId;

        string IItem.ItemName() => ItemName;

        int IItem.ItemCost() => ItemCost;

        int IItem.ItemClearance() => ItemClearance;

        int IItem.ItemDecay() => ItemDecay;

        int IItem.ItemAction() => ItemAction;

        string IItem.ItemDescription() => ItemDescription;

        public string ItemSuggestor() => "Implemented in the IC Forum Game";
    }
}
