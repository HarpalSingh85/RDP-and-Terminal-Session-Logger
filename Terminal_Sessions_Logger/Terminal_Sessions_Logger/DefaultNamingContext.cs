using System;
using System.DirectoryServices;

namespace Terminal_Sessions_Logger
{
    internal static class DefaultNamingContext
      {
        public static string GetDefaultNamingContext()
        {
            string defaultNamingContext;
            try
            {
                using (DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE"))
                {
                    defaultNamingContext = rootDSE.Properties["defaultNamingContext"].Value.ToString();
                }
                return defaultNamingContext;
            }
            catch(Exception)
            {
                throw;
            }
            
        }
      }
}

    