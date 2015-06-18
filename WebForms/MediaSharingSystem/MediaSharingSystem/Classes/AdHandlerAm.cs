using System.DirectoryServices.AccountManagement;

namespace MediaSharingSystem
{
    public class AdHandlerAm
    {
        // Should be replaced with a service account for security reasons!
        //private string _adminname = @"CN=Administrator,CN=Users,DC=INFRA-S86,DC=local";
        private string adminName = @"INFRA-S86\Administrator";
        private string adminPw = "ADAdmin2";
        private string domain = "INFRA-S86.local";
        private string groupsou = "OU=SMEgroups,DC=INFRA-s86,DC=local";
        private string rootou = "DC=INFRA-S86,DC=local";
        private string usersou = "OU=SMEusers,DC=INFRA-S86,DC=local";

        /// <summary>
        ///     Gets the root principal context from the domain
        /// </summary>
        /// <returns>Return the (root) context of the SME server</returns>
        public PrincipalContext GetContext()
        {
            PrincipalContext pContext = new PrincipalContext(ContextType.Domain, domain, rootou,
                ContextOptions.SimpleBind, adminName, adminPw);
            return pContext;
        }

        /// <summary>
        ///     Gets the context for the designated OU
        /// </summary>
        /// <param name="OU">The desired OU location, i.e.: OU=SMEusers,DC=bedrijfs86,DC=com</param>
        /// <returns>Returns requested OU context</returns>
        public PrincipalContext GetContext(string OU)
        {
            PrincipalContext pContext = new PrincipalContext(ContextType.Domain, domain, OU, ContextOptions.SimpleBind,
                adminName, adminPw);
            return pContext;
        }

        public bool AuthenticateUser(string username, string password)
        {
            bool authOK = false;
            PrincipalContext pContext = GetContext();
            authOK = pContext.ValidateCredentials(username, password);
            return authOK;
        }

        /// <summary>
        ///     Creates a new user in the active directory
        /// </summary>
        /// <param name="username">The username for the new user</param>
        /// <param name="password">The password for the new user</param>
        /// <param name="mail">The E-mail for the new user</param>
        public void CreateUser(string username, string password, string mail)
        {
            PrincipalContext pContext = GetContext(usersou);
            UserPrincipal pUser = new UserPrincipal(pContext, username, password, false);
            pUser.EmailAddress = mail;
            pUser.Save();
        }

        /// <summary>
        ///     Enable a user account
        /// </summary>
        /// <param name="username">the username of the account you want to enable</param>
        public void EnableUser(string username)
        {
            PrincipalContext pContext = GetContext();
            UserPrincipal pUser = UserPrincipal.FindByIdentity(pContext, username);
            pUser.Enabled = true;
            pUser.Save();
        }

        /// <summary>
        /// </summary>
        /// <param name="username"></param>
        /// <param name="groupname"></param>
        /// <returns></returns>
        public bool UserInGroup(string username, string groupname)
        {
            PrincipalContext pContext = GetContext();
            UserPrincipal pUser = UserPrincipal.FindByIdentity(pContext, username);
            pContext = GetContext(groupsou);
            GroupPrincipal pGroup = GroupPrincipal.FindByIdentity(pContext, groupname);

            if (pUser != null || pGroup != null)
            {
                return pGroup.Members.Contains(pUser);
            }
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="username"></param>
        /// <param name="groupname"></param>
        public void AddUserToGroup(string username, string groupname)
        {
            PrincipalContext pContext = GetContext();
            UserPrincipal pUser = UserPrincipal.FindByIdentity(pContext, username);
            pContext = GetContext(groupsou);
            GroupPrincipal pGroup = GroupPrincipal.FindByIdentity(pContext, groupname);
            if (pUser != null || pGroup != null)
            {
                if (!pGroup.Members.Contains(pUser))
                {
                    pGroup.Members.Add(pUser);
                    pGroup.Save();
                }
            }
        }

        /// <summary>
        ///     Disable a user account
        /// </summary>
        /// <param name="username">the username of the account you want to disable</param>
        public void DisableUser(string username)
        {
            PrincipalContext pContext = GetContext();
            UserPrincipal pUser = UserPrincipal.FindByIdentity(pContext, username);
            pUser.Enabled = false;
            pUser.Save();
        }

        /// <summary>
        ///     DEBUGGING METHOD Shows a simple messagebox. without having to include windows form reference
        /// </summary>
        /// <param name="message">Message to display</param>
        private void ShowError(string message)
        {
            //System.Windows.Forms.MessageBox.Show(message);
        }
    }
}