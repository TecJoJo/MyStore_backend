# Permission&role based acces control (RBAC)

Role-Permission Authorization Flow Implementation Brief
## Overview
Implement fine-grained RBAC using ASP.NET Core Identity's built-in claims system for permission-based authorization with admin role bypass.
Implementation Steps
1. Permission Claims Storage
Use Identity's AspNetUserClaims table to store user permissions as claims with ClaimType = "permission" and ClaimValue = "products.create". No custom models needed.
2. JWT Token Enhancement
Update TokenRepository.createJwtToken() to include user's permission claims from UserManager.GetClaimsAsync(). All permissions embed directly into JWT payload for stateless authorization.
3. Authorization Policies
Define policies in Program.cs using RequireAssertion():

```
options.AddPolicy("Products.Create", policy =>
    policy.RequireAssertion(context =>
        context.User.HasClaim("admin", "true") || 
        context.User.HasClaim("permission", "products.create")));
```
4. Controller Protection
Apply policies to endpoints: [Authorize(Policy = "Products.Create")]
5. Permission Management
Create PermissionService using UserManager.AddClaimAsync() and RemoveClaimAsync() for dynamic permission assignment. Protect with [Authorize(Policy = "AdminOnly")].
Benefits
•	No database calls during authorization (claims in JWT)
•	Dynamic permissions via Identity's claim management
•	Admin bypass for elevated access
•	Granular control per specific action
This approach leverages Identity's existing infrastructure while providing enterprise-grade authorization flexibility.
