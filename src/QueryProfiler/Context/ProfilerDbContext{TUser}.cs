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
    /// Use this dbcontext if use identity framework.
    /// </summary>
    /// <typeparam name="TUser">
    /// Identity User.
    /// </typeparam>
    public class ProfilerDbContext<TUser> : IdentityDbContext<TUser>
        where TUser : IdentityUser
    {
        public ProfilerDbContext(DbContextOptions options) : base(options)
        {
        }

        public ProfilerDbContext()
        {
        }
    }
}
