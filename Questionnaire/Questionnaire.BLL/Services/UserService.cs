﻿using Questionnaire.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Services
{
    public class UserService : IUserService
    {
        private const string DEFAULT_ROLE = "user";

        //private IAccountWorker worker { get; set; }

        //public UserService(IAccountWorker worker)
        //{
        //    this.worker = worker;
        //}

        //public IEnumerable<UserDTO> GetAllUsers()
        //{
        //    List<ApplicationUser> users = worker.UserManager.Users.ToList();

        //    return Mapper.Map<IEnumerable<UserDTO>>(users);
        //}

        //public async Task<string> GetUserRole(string userId)
        //{
        //    IList<string> roles = await worker.UserManager.GetRolesAsync(userId);
        //    string roleName = roles.FirstOrDefault();

        //    return roleName;
        //}

        //public async Task ChangeUserRole(ChangeRoleDTO changeRoleDTO)
        //{
        //    if (!string.IsNullOrEmpty(changeRoleDTO.OldRole))
        //        await worker.UserManager.RemoveFromRoleAsync(changeRoleDTO.UserId, changeRoleDTO.OldRole);

        //    if (!string.IsNullOrEmpty(changeRoleDTO.Role))
        //        await worker.UserManager.AddToRoleAsync(changeRoleDTO.UserId, changeRoleDTO.Role);

        //    await worker.SaveAsync();
        //}

        //public async Task DeleteUser(string userId)
        //{
        //    if (string.IsNullOrEmpty(userId))
        //        throw new ArgumentNullException();

        //    var user = await worker.UserManager.FindByIdAsync(userId);
        //    var userRoles = await worker.UserManager.GetRolesAsync(userId);

        //    if (userRoles.Count() > 0)
        //        foreach (var role in userRoles)
        //            await worker.UserManager.RemoveFromRoleAsync(userId, role);

        //    await worker.UserManager.DeleteAsync(user);
        //    await worker.SaveAsync();
        //}
    }
}
