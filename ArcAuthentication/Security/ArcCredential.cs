namespace ArcAuthentication.Security
{
    /// <summary>
    /// Automatically hashes and stores said hashes for a username/password combo
    /// </summary>
    public class ArcCredential
    {
        public string Username { get; }
        public string Password { get; }

        public ArcCredential(string un, string pw)
        {
            Username = ArcMd5.ArcadyanMd5(un);
            Password = ArcMd5.ArcadyanMd5(pw);
        }
    }
}