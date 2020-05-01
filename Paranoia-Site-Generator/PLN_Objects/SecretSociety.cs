namespace Paranoia_Site_Generator
{
    [SqlStatement("SELECT * FROM phpbb_ac_secsocs")]
    public class SecretSociety : PLN_Object
    {
        public int SecsocId;
        public string SecsocName;
        public int SecsocSpecial;
        public int SecsocPoints;
        public int LeaderId;
        public int AltLeaderId;
        public int Id => SecsocId;
    }
}
