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
    public class ProfilerDbContext<TUser, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
    {
        public ProfilerDbContext(DbContextOptions options) : base(options)
        {
        }

        public ProfilerDbContext()
        {
        }
    }
}
