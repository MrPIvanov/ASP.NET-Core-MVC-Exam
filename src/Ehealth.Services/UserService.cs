using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ehealth.Data;
using Ehealth.Models;
using Ehealth.Services.Contracts;
using Ehealth.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ehealth.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly EhealthDbContext context;
        private readonly UserManager<User> userManager;

        public UserService(IMapper mapper, EhealthDbContext context, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<List<AllUsersIfnoViewModel>> GetAllAdminsByName()
        {
            var adminRole = await this.context.Roles.FirstOrDefaultAsync(r => r.NormalizedName == "ADMIN");

            var adminRoleId = adminRole.Id;

            var allAdminIds = await this.context.UserRoles.Where(ur => ur.RoleId == adminRoleId).Select(ur => ur.UserId).ToListAsync();

            var allAdmins = this.context.Users.Where(u => allAdminIds.Contains(u.Id));

            var mappedUsers = await mapper.ProjectTo<AllUsersIfnoViewModel>(allAdmins).OrderBy(u => u.Username).ToListAsync();

            return mappedUsers;
        }

        public async Task<List<AllUsersIfnoViewModel>> GetAllUsersByName()
        {
            var userRole = await this.context.Roles.FirstOrDefaultAsync(r => r.NormalizedName == "USER");

            var userRoleId = userRole.Id;

            var allUserIds = await this.context.UserRoles.Where(ur => ur.RoleId == userRoleId).Select(ur => ur.UserId).ToListAsync();

            var allUsers = this.context.Users.Where(u => allUserIds.Contains(u.Id));

            var mappedUsers = await mapper.ProjectTo<AllUsersIfnoViewModel>(allUsers).OrderBy(u => u.Username).ToListAsync();

            return mappedUsers;
        }

        public async Task PromoteUserToAdmin(string id)
        {
            var currentUser = await this.context.Users.FirstOrDefaultAsync(u => u.Id == id);

            await this.userManager.AddToRoleAsync(currentUser, "Admin");

            await this.userManager.RemoveFromRoleAsync(currentUser, "User");
        }

        public async Task DemoteAdminToUser(string id)
        {
            var currentAdmin = await this.context.Users.FirstOrDefaultAsync(u => u.Id == id);

            await this.userManager.AddToRoleAsync(currentAdmin, "User");

            await this.userManager.RemoveFromRoleAsync(currentAdmin, "Admin");
        }
    }
}
