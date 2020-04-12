namespace Paranoia_Site_Generator
{
    [SqlStatement("SELECT * FROM phpbb_ac_potitems")]
    public class PotentialItem
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
    }
}
