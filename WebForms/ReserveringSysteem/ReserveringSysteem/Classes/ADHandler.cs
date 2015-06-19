using System.Diagnostics;
using System.DirectoryServices;

namespace ReserveringSysteem
{
    public class ADHandler
    {
        private readonly string ldapuserDn = "INFRA-S86.local/OU=SMEusers,DC=INFRA-S86,DC=local";
        //// Fields
        private string domain;
        //// Constructor
        /// <summary>
        /// </summary>
        /// <param name="domain"></param>
        /// <summary>
        ///     Authenticate against Active Directory. Checks against enabled users
        ///     http://www.codeproject.com/Articles/18102/Howto-Almost-Everything-In-Active-Directory-via-C#35
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Authenticate(string userName, string password)
        {
            bool authentic = false;
            try
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain, userName, password);
                object nativeObject = entry.NativeObject;
                authentic = true;
            }
            catch (DirectoryServicesCOMException)
            {
            }
            return authentic;
        }

        /// <summary>
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public string CreateUserAccount(string userName, string userPassword)
        {
            string oGUID = string.Empty;
            try
            {
                string connectionPrefix = "LDAP://" + ldapuserDn;
                DirectoryEntry dirEntry = new DirectoryEntry(connectionPrefix);
                DirectoryEntry newUser = dirEntry.Children.Add("CN=" + userName, "user");
                newUser.Properties["samAccountName"].Value = userName;

                newUser.CommitChanges();
                oGUID = newUser.Guid.ToString();
                newUser.Invoke("SetPassword", userPassword);
                newUser.CommitChanges();
                dirEntry.Close();
                newUser.Close();
            }
            catch (DirectoryServicesCOMException E)
            {
                ShowError(E.Message);
            }
            return oGUID;
        }

        /// <summary>
        /// </summary>
        /// <param name="userCn">The username as in the SMEusers OU</param>
        /// <param name="groupCn">Can be either "SMEadmin" or "SMEuser"</param>
        public bool AddToGroup(string userCn, string groupCn)
        {
            bool ok = false;
            try
            {
                DirectoryEntry dirEntry =
                    new DirectoryEntry("LDAP://INFRA-S86.local/CN=" + groupCn + ",OU=SMEgroups,DC=INFRA-S86,DC=local");
                dirEntry.Properties["member"].Add("CN=" + userCn + ",OU=SMEusers,DC=INFRA-S86,DC=local");
                dirEntry.CommitChanges();
                dirEntry.Close();
                ok = true;
            }
            catch (DirectoryServicesCOMException E)
            {
                ShowError(E.Message);
            }
            return ok;
        }

        public bool RemoveUserFromGroup(string userCn, string groupCn)
        {
            bool ok = false;
            try
            {
                DirectoryEntry dirEntry =
                    new DirectoryEntry("LDAP://INFRA-S86.local/CN=" + groupCn + ",OU=SMEgroups,DC=INFRA-S86,DC=local");
                dirEntry.Properties["member"].Remove("CN=" + userCn + ",OU=SMEusers,DC=INFRA-S86,DC=local");
                dirEntry.CommitChanges();
                dirEntry.Close();
                ok = true;
            }
            catch (DirectoryServicesCOMException E)
            {
                ShowError(E.Message);
            }
            return ok;
        }

        /// <summary>
        ///     http://www.codeproject.com/Articles/18102/Howto-Almost-Everything-In-Active-Directory-via-C#43
        /// </summary>
        /// <param name="username"></param>
        public bool Enable(string username)
        {
            bool ok = false;
            try
            {
                DirectoryEntry user =
                    new DirectoryEntry("LDAP://INFRA-S86.local/CN=" + username + ",OU=SMEusers,DC=INFRA-S86,DC=local");
                int val = (int) user.Properties["userAccountControl"].Value;
                user.Properties["userAccountControl"].Value = val & ~0x2;
                //ADS_UF_NORMAL_ACCOUNT;

                user.CommitChanges();
                user.Close();
                ok = true;
            }
            catch (DirectoryServicesCOMException E)
            {
                ShowError(E.Message);
            }
            return ok;
        }

        public bool Disable(string username)
        {
            bool ok = false;
            try
            {
                DirectoryEntry user =
                    new DirectoryEntry("LDAP://INFRA-S86.local/CN=" + username + ",OU=SMEusers,DC=INFRA-S86,DC=local");
                int val = (int) user.Properties["userAccountControl"].Value;
                user.Properties["userAccountControl"].Value = val | 0x2;
                //ADS_UF_ACCOUNTDISABLE;

                user.CommitChanges();
                user.Close();
                ok = true;
            }
            catch (DirectoryServicesCOMException E)
            {
                ShowError(E.Message);
            }
            return ok;
        }

        private void ShowError(string message)
        {
            Debug.WriteLine(message);
        }
    }
}