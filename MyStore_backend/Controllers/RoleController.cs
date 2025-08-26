using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore_backend.Constants;
using MyStore_backend.Data;
using MyStore_backend.Models.Dto;
using MyStore_backend.Models.DTO.Role;
using System.Security.Claims;

namespace MyStore_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly MyStoreAuthDBContext _myStoreAuthDBContext;

        public RoleController(RoleManager<IdentityRole> roleManager, MyStoreAuthDBContext myStoreAuthDBContext)
        {
            _roleManager = roleManager;
            _myStoreAuthDBContext = myStoreAuthDBContext;
        }


        //This endpoint is used for fetch a list of all existing roles which has claimType of "Permission"
        //Not the roles user see in UserManagement 
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _roleManager.Roles.ToListAsync(); // Better performance
                var filteredRoles = new List<RoleDto>();

                foreach (var role in roles)
                {
                    var claims = await _roleManager.GetClaimsAsync(role);
                    var permissions = claims
                        .Where(c => c.Type == CustomClaimTypes.permission)
                        .Select(c => c.Value)
                        .ToList();

                    if (permissions.Count > 0)
                    {
                        var roleDto = new RoleDto()
                        {
                            RoleId = role.Id,
                            RoleName = role.Name ?? string.Empty, // Handle potential null
                            Permissions = permissions // Fixed property name
                        };
                        filteredRoles.Add(roleDto);
                    }
                }

                return Ok(new ApiResponseDto<List<RoleDto>>()
                {
                    Data = filteredRoles,
                    Message = "Roles fetched successfully",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseDto<List<RoleDto>>()
                {
                    Data = new List<RoleDto>(),
                    Message = "Failed to fetch roles",
                    Success = false,
                    Errors = new List<string> { ex.Message }
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequestDto createRoleRequestDto)
        {
            var role = new IdentityRole()
            {
                Name = createRoleRequestDto.Name,
            };
            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded) return StatusCode(500, result.Errors);

            var reponse = new ApiResponseDto<IdentityRole>()
            {
                Data = role,
                Message = "Role created successfully",
                Success = true
            };

            return Ok(reponse);

        }

        [HttpPost]
        [Route("AddPermissions/{roleId}")]
        public async Task<IActionResult> AddPermissions([FromRoute] string roleId, [FromBody] AddPermissionsRequestDto addPermissionsRequestDto)
        {

            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null) return BadRequest(new ApiResponseDto()
            {
                Message = "Role not found",
                Success = false
            });

            using var transaction = await _myStoreAuthDBContext.Database.BeginTransactionAsync();

            //Filter out duplicated permissions 
            var claims = await _roleManager.GetClaimsAsync(role);
            var existingPermissions = claims
                .Where(c => c.Type == CustomClaimTypes.permission)
                .Select(c => c.Value)
                .ToList();

            var permissionsToAdd = addPermissionsRequestDto.Permissions
                .Where(p => !existingPermissions.Contains(p))
                .Distinct()
                .ToList();

            foreach (var permission in permissionsToAdd)
            {
                var permissionClaim = new Claim(CustomClaimTypes.permission, permission);
                var result = await _roleManager.AddClaimAsync(role, permissionClaim);
                if (!result.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, new ApiResponseDto()
                    {
                        Message = "Failed to add permissions",
                        Success = false,
                        Errors = result.Errors.Select(e => e.Description).ToList()
                    });
                }
            }

            await transaction.CommitAsync();

            var reponsePayload = new AddPermissionsResponseDto()
            {
                AddedPermissions = permissionsToAdd,
                roleId = role.Id,
                roleName = role.Name ?? string.Empty
            };

            return Ok(new ApiResponseDto<AddPermissionsResponseDto>()
            {
                Data = reponsePayload,
                Message = "Permissions added successfully",
                Success = true
            });




        }

        [HttpPost]
        [Route("ModifyPermissions/{roleId}")]
        public async Task<IActionResult> ModifyPermissions(ModifyPermissionsRequestDto modifyPermissionsRequestDto)
        {
            //This method shall replace the AddPermissions and pretty much be the only one needed for modifying the permissions
            //This maps how the UI shall be implemented, Modify permission Modal when 
        }
    }
}
