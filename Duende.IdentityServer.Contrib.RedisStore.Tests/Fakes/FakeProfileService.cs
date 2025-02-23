﻿using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Duende.IdentityServer.Contrib.RedisStore.Tests.Cache
{
    public class FakeProfileService : IProfileService
    {
        public IEnumerable<Claim> Claims = new List<Claim>();

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.IssuedClaims = Claims.ToList();
            return Task.CompletedTask;
        }

        public Action<IsActiveContext> IsActive;

        public Task IsActiveAsync(IsActiveContext context)
        {
            IsActive?.Invoke(context);
            return Task.CompletedTask;
        }
    }
}
