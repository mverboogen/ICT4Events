using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;

namespace AD_playground
{
	public class AdHandlerAm
	{
		private string _domain = "INFRA-S86.local";
		private string _usersou = "OU=SMEusers,DC=INFRA-S86,DC=local";
		private string _groupsou = "OU=SMEgroups,DC=INFRA-s86,DC=local";
		private string _rootou = "DC=INFRA-S86,DC=local";
    	
		// Should be replaced with a service account for security reasons!
		//private string _adminname = @"CN=Administrator,CN=Users,DC=INFRA-S86,DC=local";
		private string _adminname = @"INFRA-S86\Administrator";
		//private string _adminname = @"INFRA-S86\SMEservice";
		private string _adminpw = "password";
    	
		/// <summary>
		/// Creates a new instance of ADHandler
		/// </summary>
		public AdHandlerAm()
		{
    		
		}
    	
		/// <summary>
		/// Gets the context of the root from the domain
		/// </summary>
		/// <returns>Return the (root) context of the SME server</returns>
		public PrincipalContext GetContext()
		{
            PrincipalContext pContext = new PrincipalContext(ContextType.Domain, _domain, _rootou, ContextOptions.SimpleBind, _adminname, _adminpw);
			return pContext;
		}
    	
		/// <summary>
		/// Gets the context for the designated OU
		/// </summary>
		/// <param name="OU">The desired OU location, i.e.: OU=SMEusers,DC=bedrijfs86,DC=com</param>
		/// <returns>Returns requested OU context</returns>
		public PrincipalContext GetContext(string OU)
		{
			PrincipalContext pContext = new PrincipalContext(ContextType.Domain, _domain, OU, ContextOptions.SimpleBind, _adminname, _adminpw);
			return pContext;
		}
    	
        /// <summary>
        /// Authenticates an user against the active directory
        /// </summary>
        /// <param name="username">the username of the user you want to authenticate</param>
        /// <param name="password">the password of the user you want to authenticate</param>
        /// <returns>true if authentication good / false if authentication failed</returns>
		public bool AuthenticateUser(string username, string password)
		{
			bool authOK = false;
			PrincipalContext pContext = GetContext();
			authOK = pContext.ValidateCredentials(username, password);
			return authOK;
		}
    	
		/// <summary>
		/// Creates a new user in the active directory
		/// </summary>
		/// <param name="username">The username for the new user</param>
		/// <param name="password">The password for the new user</param>
		/// <param name="mail">The E-mail for the new user</param>
		public void CreateUser(string username, string password, string mail)
		{
			PrincipalContext pContext = GetContext(_usersou);
			
			UserPrincipal fUser = UserPrincipal.FindByIdentity(GetContext(), username);
			if(fUser == null)
			{
			UserPrincipal pUser = new UserPrincipal(pContext, username, password, false);
			pUser.EmailAddress = mail;
			pUser.Save();
			}
		}
    	
		/// <summary>
		/// Sets account state to enabled
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
        /// Checks wether or not a user is in a group
        /// </summary>
        /// <param name="username">the username of the user</param>
        /// <param name="groupname">the name of the group</param>
        /// <returns>true if user is in group, false if user is not in group</returns>
		public bool UserInGroup(string username, string groupname)
		{
			try
			{
			PrincipalContext pContext = GetContext();
			UserPrincipal pUser = UserPrincipal.FindByIdentity(pContext, username);
			pContext = GetContext(_groupsou);
			GroupPrincipal pGroup = GroupPrincipal.FindByIdentity(pContext, groupname);
			
			if (pUser != null || pGroup != null) 
			{
				return pGroup.Members.Contains(pUser);
			}
			}
			catch(Exception e)
			{
				
			}
			return false;
		}

		/// <summary>
		/// Adds an user to a group
		/// </summary>
		/// <param name="username">The username of the user you want to add to a group</param>
		/// <param name="groupname">The name of the group you want to add the user to</param>
		/// <returns>true if successful / false if unsuccessful</returns>
		public bool AddUserToGroup(string username, string groupname)
		{
			PrincipalContext pContext = GetContext();
			UserPrincipal pUser = UserPrincipal.FindByIdentity(pContext, username);
			pContext = GetContext(_groupsou);
			GroupPrincipal pGroup = GroupPrincipal.FindByIdentity(pContext,groupname);
			if (pUser != null || pGroup != null) 
			{
				if (!pGroup.Members.Contains(pUser))
				{
					pGroup.Members.Add(pUser);
					pGroup.Save();
				    return true;
				}
			}
		    return false;
		}
    	
		/// <summary>
		/// Sets account state to disabled.
		/// </summary>
		/// <param name="username">the username of the account you want to disable</param>
		public void DisableUser(string username)
		{
			PrincipalContext pContext = GetContext();
			UserPrincipal pUser = UserPrincipal.FindByIdentity(pContext, username);
			pUser.Enabled = false;
			pUser.Save();
		}

	}
}
