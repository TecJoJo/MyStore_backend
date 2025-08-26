
# User management

## Feature overview
As a user with permission to visit the user management site, 
I am able to browse List of Users
I am able to modify the role of the user
A "Configure Role" modal is used for modify the role of the user

Those users can be sorted and grouped based on the role
The user can be searched 


# Role management

As a user with permission to visit the role management site,
I am able to read, create, remove and update roles
I can see a list of existing roles
I can remove the role from the list 
I can create new role 
I can modify the permissions to the role via a "Configure Permissions" modal

# Configure Permissions modal
Permisson modle shows a list of all permissions as checkbox with the permissions associated to the role ticked 

## Tehcknical Overview
endpoint "modifyRolePermissions" accets a list of permissions which will override the existing permissions of the role
No add /remove permission endpoint is needed



## Add permissions directly to user (Optional)
In user management site,the user can select "customized role" which can add directly permissions 

## RBAC Technical Overview

1. Permission Claims Management via userManager
Use Identity's AspNetUserClaims table to store user permissions as claims with ClaimType = "permission" and ClaimValue = "products.create". No custom models needed.

2.Store permissions inside the existing AspNetUserClaims table as claims with ClaimType = "permission" and ClaimValue = "products.create". No custom models needed.
3.Store the realation between roles and permissions in the **exiting** AspNetRoleClaims
4 how to retreive the permissions of a role:
```csharp
public async Task<List<string>> GetRolePermissionsAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null) return new List<string>();

            var roleClaims = await _roleManager.GetClaimsAsync(role);
            return roleClaims
                .Where(c => c.Type == CustomClaimTypes.permission)
                .Select(c => c.Value)
                .ToList();
        }
```
Create PermissionService using UserManager.AddClaimAsync() and RemoveClaimAsync() for dynamic permission assignment. Protect with [Authorize(Policy = "AdminOnly")].
Benefits
•	No database calls during authorization (claims in JWT)
•	Dynamic permissions via Identity's claim management
•	Admin bypass for elevated access
•	Granular control per specific action
This approach leverages Identity's existing infrastructure while providing enterprise-grade authorization flexibility.
5. JWT Token Enhancement
Update TokenRepository.createJwtToken() to include user's permission claims from UserManager.GetClaimsAsync(). All permissions embed directly into JWT payload for stateless authorization.
6. Authorization Policies
Define policies in Program.cs using RequireAssertion():

```
options.AddPolicy("Products.Create", policy =>
    policy.RequireAssertion(context =>
        context.User.HasClaim("admin", "true") || 
        context.User.HasClaim("permission", "products.create")));
```
7. Controller Protection
~~Apply policies to endpoints: [Authorize(Policy = "Products.Create")]~~


8. Constants folder

```
MyStore_backend/
├── Constants/                 
│   ├── ClaimTypes.cs   
│   ├── Permissions.cs
│   └── Policies.cs
```

9. ClaimsPrincipal Extension(optional)
```
using System.Security.Claims;

public static class ClaimsPrincipalExtensions
{
    private const string Permission = "permission";
    private const string Admin = "admin";
    
    public static bool HasPermission(this ClaimsPrincipal principal, string permission)
    {
        return principal.HasClaim(Permission, permission);
    }
    
    public static bool IsAdmin(this ClaimsPrincipal principal)
    {
        return principal.HasClaim(Admin, "true");
    }
}
```





