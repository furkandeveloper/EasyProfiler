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
    internal class ProfilerDbContext<TUser> : IdentityDbContext<TUser>
        where TUser : IdentityUser
    {
        internal ProfilerDbContext(DbContextOptions options) : base(options)
        {
        }

        internal ProfilerDbContext()
        {
        }
    }
}
