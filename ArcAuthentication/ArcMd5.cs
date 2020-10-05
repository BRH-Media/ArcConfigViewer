namespace ArcAuthentication
{
    public static class ArcMd5
    {
        public static string ArcadyanMd5(string input)
        {
            return HashHelper.CalculateSha512Hash(HashHelper.CalculateMd5Hash(input));
        }
    }
}