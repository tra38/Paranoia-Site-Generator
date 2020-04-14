namespace Paranoia_Site_Generator
{
    [SqlStatement("SELECT * FROM phpbb_ac_mutations")]
    public class Mutations : PLN_Object
    {
        public int MutationId;
        public string MutationName;
        public int MutationSpecial;

        public int Id { get => MutationId; }
    }
}
