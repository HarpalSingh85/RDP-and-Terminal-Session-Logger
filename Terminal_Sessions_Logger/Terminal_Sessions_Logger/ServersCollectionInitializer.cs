using System;
using System.Collections.Generic;
using System.DirectoryServices;

namespace Terminal_Sessions_Logger
{
    internal class ServersCollectionInitializer
    {                   
      
        public List<string> GetCitrixServers()
        {
            try
            {
                var results = new List<string>();
                DirectoryEntry entry = new DirectoryEntry("LDAP://" + DefaultNamingContext.GetDefaultNamingContext());
                DirectorySearcher searcher = new DirectorySearcher(entry);
                searcher.Filter = ("(&(objectclass=computer)(objectcategory=computer)(|(samaccountname=*WTS*)(samaccountname=*XEN*)))");
                foreach (SearchResult result in searcher.FindAll())
                {
                    //ColServers.Add(result.GetDirectoryEntry().Name.ToString());
                    results.Add(result.GetDirectoryEntry().Name.ToString());
                }

                return results;
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
    