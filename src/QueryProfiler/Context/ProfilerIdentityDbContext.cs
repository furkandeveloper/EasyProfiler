using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryProfiler.Context
{
    public class ProfilerIdentityDbContext<TUser> : IdentityDbContext<TUser>
        where TUser : IdentityUser
    {
        public ProfilerIdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        public ProfilerIdentityDbContext()
        {
        }
    }

    public class ProfilerIdentityDbContext<TUser, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        public ProfilerIdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        public ProfilerIdentityDbContext()
        {
        }
    }

    public class ProfilerIdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken> : IdentityUserContext<TUser, TKey, TUserClaim, TUserLogin, TUserToken>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TUserLogin : IdentityUserLogin<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
        where TUserToken : IdentityUserToken<TKey>
    {
        public ProfilerIdentityDbContext()
        {
        }

        public ProfilerIdentityDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
