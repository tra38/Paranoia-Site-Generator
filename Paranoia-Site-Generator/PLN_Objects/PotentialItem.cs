namespace Paranoia_Site_Generator
{
    [SqlStatement("SELECT * FROM phpbb_ac_potitems")]
    public class PotentialItem : PLN_Object
    {
        public int PotitemId;
        public string PotitemName;
        public int PotitemCost;
        public int PotitemClearance;
        public int PotitemDecay;
        public string PotitemDescription;
        public int PotitemUser;
        public int PotitemStatus;

        public int ItemId => PotitemId;
        public string ItemName => PotitemName;
        public int ItemCost => PotitemCost;
        public int ItemClearance => PotitemClearance;
        public int ItemDecay => PotitemDecay;
        public string ItemDescription => PotitemDescription;

        public int Id { get => ItemId; }
    }
}
