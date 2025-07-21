using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VigilanceClearance.Application.DTOs.Model;
using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Infrastructure.Infrastructure.Identity;

namespace VigilanceClearance.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public AuthService(UserManager<ApplicationUser> um, RoleManager<IdentityRole> rm, IConfiguration cfg)
        {
            _userManager = um;
            _roleManager = rm;
            _config = cfg;
        }

        public async Task<List<UserWithRolesDto>> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            var userWithRolesList = new List<UserWithRolesDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                // Exclude users with "Admin" role
                if (!roles.Contains("Admin"))
                {
                    userWithRolesList.Add(new UserWithRolesDto
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        Email = user.Email,
                        Roles = roles.ToList()
                    });
                }
            }

            return userWithRolesList;

        }


        public async Task<string> RegisterAsync(string email, string pwd, string role)
        {
            var u = new ApplicationUser { Email = email, UserName = email };
            var r = await _userManager.CreateAsync(u, pwd);
            if (!r.Succeeded) return string.Join(";", r.Errors.Select(e => e.Description));

            if (await _roleManager.RoleExistsAsync(role))
                await _userManager.AddToRoleAsync(u, role);
            return "User registered";
        }

        public async Task<string> LoginAsync(string email, string pwd)
        {
            var u = await _userManager.FindByEmailAsync(email);
            if (u == null || !await _userManager.CheckPasswordAsync(u, pwd)) return null;

            var roles = await _userManager.GetRolesAsync(u);
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, u.UserName!),            
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<string> CreateRoleAsync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return "Role name cannot be empty.";

            if (await _roleManager.RoleExistsAsync(roleName))
                return $"Role '{roleName}' already exists.";

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            return result.Succeeded ? $"Role '{roleName}' created successfully."
                                    : string.Join(";", result.Errors.Select(e => e.Description));
        }

        public async Task<List<string>> GetRoleAsync()
        {
            return await Task.FromResult(_roleManager.Roles.Select(r => r.Name).ToList());
        }

        public async Task<string> AssignRoleToUserAsync(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return $"User with email '{email}' not found.";

            if (!await _roleManager.RoleExistsAsync(roleName))
                return $"Role '{roleName}' does not exist.";

            if (await _userManager.IsInRoleAsync(user, roleName))
                return $"User '{email}' is already in role '{roleName}'.";

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded ? $"Role '{roleName}' assigned to user '{email}'."
                                    : string.Join(";", result.Errors.Select(e => e.Description));
        }

    }

}
