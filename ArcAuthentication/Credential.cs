namespace ArcAuthentication
{
    public class Credential
    {
        public string Username { get; }
        public string Password { get; }

        public Credential(string un, string pw)
        {
            Username = un;
            Password = pw;
        }
    }
}