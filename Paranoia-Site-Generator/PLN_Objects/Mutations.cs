namespace Paranoia_Site_Generator
{
    [SqlStatement("SELECT * FROM phpbb_ac_mutations")]
    public class Mutations
    {
        public int MutationId;
        public string MutationName;
        public int MutationSpecial;
    }
}
