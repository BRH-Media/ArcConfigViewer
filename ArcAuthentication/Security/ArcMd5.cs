namespace ArcAuthentication.Security
{
    public static class ArcMd5
    {
        public static string ArcadyanMd5(string input)
        {
            return ArcHashHelper.CalculateSha512Hash(ArcHashHelper.CalculateMd5Hash(input));
        }
    }
}