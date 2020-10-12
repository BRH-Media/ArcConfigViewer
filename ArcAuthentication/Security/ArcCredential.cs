namespace ArcAuthentication.Security
{
    /// <summary>
    /// Automatically hashes and stores said hashes for a username/password combo
    /// </summary>
    public class ArcCredential
    {
        public string Username { get; }
        public string Password { get; }

        public ArcCredential(string un, string pw, bool hash = true)
        {
            Username = hash
                ? ArcMd5.ArcadyanMd5(un)
                : un;
            Password = hash
                ? ArcMd5.ArcadyanMd5(pw)
                : pw;
        }
    }
}