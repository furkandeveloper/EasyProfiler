using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryProfiler.Context
{
    /// <summary>
    /// Profiler Identity DbContext.
    /// Use this dbcontext if use identity framework.</summary>
    /// <typeparam name="TUser">
    /// Identity User.
    /// </typeparam>
    /// <typeparam name="TRole">
    /// Identity Role.
    /// </typeparam>
    /// <typeparam name="TKey">
    ///  The type of the primary key for users and roles.
    /// </typeparam>
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

    /// <summary>
    /// Profiler Identity DbContext.
    /// Use this dbcontext if use identity framework.</summary>
    /// <typeparam name="TUser">
    /// Identity User.
    /// </typeparam>
    /// <typeparam name="TRole">
    /// Identity Role.
    /// </typeparam>
    /// <typeparam name="TKey">
    ///  The type of the primary key for users and roles.
    /// </typeparam>
    /// <typeparam name="TUserClaim">
    /// The type of the user claim object.
    /// </typeparam>
    /// <typeparam name="TUserRole">
    /// The type of the user role object.
    /// </typeparam>
    /// <typeparam name="TUserLogin">
    /// The type of the user login object.
    /// </typeparam>
    /// <typeparam name="TRoleClaim">
    /// The type of the user role claim object.
    /// </typeparam>
    /// <typeparam name="TUserToken">
    /// The type of the user token object.
    /// </typeparam>
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
