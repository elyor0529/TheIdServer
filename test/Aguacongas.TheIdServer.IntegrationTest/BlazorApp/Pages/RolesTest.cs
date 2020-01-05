﻿using Aguacongas.TheIdServer.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Aguacongas.TheIdServer.IntegrationTest.BlazorApp.Pages
{
    [Collection("api collection")]
    public class RolesTest : EntitiesPageTestBase
    {
        public override string Entities => "roles";

        public RolesTest(ApiFixture fixture, ITestOutputHelper testOutputHelper)
            :base(fixture, testOutputHelper)
        {
        }

        protected override Task PopulateList()
        {
            return DbActionAsync<ApplicationDbContext>(context =>
            {
                context.Roles.Add(new IdentityRole
                {
                    Id = GenerateId(),
                    Name = "filtered",
                });

                return context.SaveChangesAsync();
            });
        }
    }
}