﻿using EtecFilmes.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtecFilmes.Data
{
    public class ContextoSeed
    {
        public static async Task SeedRolesAsync(UserManager<Usuario> userManager,
                        RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Perfis.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Perfis.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Perfis.Moderador.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Perfis.Visitante.ToString()));
        }
        public static async Task SeedSuperAdminAsync(UserManager<Usuario> userManager,
                        RoleManager<IdentityRole> roleManager)
        {
            // Seed Default User
            var defaultUser = new Usuario
            {
                UserName = "Gallo",
                Email = "gallojunior@gmail.com",
                Nome = "Jose Antonio Gallo Junior",
                DataNascimento = DateTime.Parse("05/08/1981"),
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {

                    await userManager.CreateAsync(defaultUser, "@Etec123");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Perfis.Visitante.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Perfis.Moderador.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Perfis.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Perfis.SuperAdmin.ToString());
                }
            }
        }
    }
}
