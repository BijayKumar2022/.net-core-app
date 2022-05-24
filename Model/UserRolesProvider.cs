using System;  
using System.Linq;  
using System.Web.Security;  
   
namespace MvcRoleBasedAuthentication_Demo.Models  
{  
    public class UserRoleProvider : RoleProvider  
    {  
        public override string ApplicationName  
        {  
            get  
            {  
                throw new NotImplementedException();  
            }  
   
            set  
            {  
                throw new NotImplementedException();  
            }  
        }  
   
        public override void AddUsersToRoles(string[] first_names, string[] Roles)  
        {  
            throw new NotImplementedException();  
        }  
   
        public override void CreateRole(string Roles)  
        {  
            throw new NotImplementedException();  
        }  
   
        public override bool DeleteRole(string Roles, bool throwOnPopulatedRole)  
        {  
            throw new NotImplementedException();  
        }  
   
        public override string[] FindUsersInRole(string Roles, string first_nameToMatch)  
        {  
            throw new NotImplementedException();  
        }  
   
        public override string[] GetAllRoles()  
        {  
            throw new NotImplementedException();  
        }  
   
        public override string[] GetRolesForUser(string first_name)  
        {  
            using (EmployeeContext _Context=new EmployeeContext())  
            {  
                var userRoles = (from user in _Context.Users  
                                 join roleMapping in _Context.UserRoleMappings  
                                 on user.Id equals roleMapping.UserId  
                                 join role in _Context.Roles  
                                 on roleMapping.RoleId equals role.Id  
                                 where user.first_name == first_name  
                                 select role.Role).ToArray();  
                return userRoles;  
            }               
        }  
   
        public override string[] GetUsersInRole(string Roles)  
        {  
            throw new NotImplementedException();  
        }  
   
        public override bool IsUserInRole(string first_name, string Roles)  
        {  
            throw new NotImplementedException();  
        }  
   
        public override void RemoveUsersFromRoles(string[] first_names, string[] Roless)  
        {  
            throw new NotImplementedException();  
        }  
   
        public override bool RoleExists(string Roles)  
        {  
            throw new NotImplementedException();  
        }  
    }  
}  