using System.IO;

namespace ArcAuthentication.Globals
{
    /// <summary>
    /// What's this? This handles operations related to the modem's IPv4 address storage and retrieval.
    /// </summary>
    public static class AddressFile
    {
        /// <summary>
        /// What's this? This is the file on disk that the program will read/write the modem's IPv4 address from.
        /// </summary>
        public static string AddressFilePath { get; } = @".\modemIPv4.txt";

        /// <summary>
        /// What's this? This will write a new modem IPv4 TXT file containing the default Arcadyan LH1000 gateway address.
        /// </summary>
        /// <returns>True on success</returns>
        public static bool WriteNew()
        {
            try
            {
                //contents to write to the new file
                var newContents = $"/// ENTER ADDRESS BELOW THIS LINE \\\\\\\n{Endpoints.DefaultGatewayAddress}";

                //if it exists, delete it
                if (File.Exists(AddressFilePath))
                    File.Delete(AddressFilePath);

                //write out the default
                File.WriteAllText(AddressFilePath, newContents);

                //report successful
                return true;
            }
            catch
            {
                //ignore
            }

            //default
            return false;
        }

        /// <summary>
        /// What's this? This attempts to read from the modem's file and return the address.
        /// </summary>
        /// <returns>Default IPv4 on failure; TXT contents on success.</returns>
        public static string GetAddress(bool forceNew = false)
        {
            try
            {
                //if the file exists, we can proceed. No point trying to read a file that doesn't exist.
                if (File.Exists(AddressFilePath) && !forceNew)
                {
                    //read it into memory
                    var fileContents = File.ReadAllLines(AddressFilePath);

                    //verify it
                    if (fileContents.Length >= 2)
                        if (!string.IsNullOrWhiteSpace(fileContents[1]) &&
                            !string.IsNullOrWhiteSpace(fileContents[0]))
                            return fileContents[1];
                }

                //if the file doesn't exist (or the value was invalid), we simply create/overwrite it and return the default value below before exiting.
                WriteNew();
            }
            catch
            {
                //nothing
            }

            //default
            return Endpoints.DefaultGatewayAddress;
        }
    }
}