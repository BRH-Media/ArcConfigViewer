using ArcAuthentication.Globals;
using ArcAuthentication.Net;
using ArcProcessor;
using ArcWaitWindow;
using System;

namespace ArcAuthentication.Security
{
    public static class ArcModem
    {
        public static void IsArcadyanModem(object sender, ArcWaitWindowEventArgs e)
        {
            if (e.Arguments.Count == 1)
            {
                var silent = (bool)e.Arguments[0];
                e.Result = IsArcadyanModem(false, silent);
            }
        }

        public static bool IsArcadyanModem(bool waitWindow = true, bool silent = false)
        {
            try
            {
                if (waitWindow)
                    return (bool)ArcWaitWindow.ArcWaitWindow.Show(IsArcadyanModem, @"Verifying modem...", silent);

                //download login page
                var loginPage = ResourceGrab.GrabString(Endpoints.LoginHtm);

                //verify if it contains the correct string
                var validModem = loginPage.Contains(Global.VerificationString);

                //return result
                return validModem || Global.InitToken != null;
            }
            catch (Exception ex)
            {
                if (!silent)
                    UiMessages.Error($"An error occurred whilst trying to verify your modem:\n\n{ex}");
            }

            //default
            return false;
        }
    }
}