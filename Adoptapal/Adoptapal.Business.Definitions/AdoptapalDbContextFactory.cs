/*
 * File: AdoptapalDbContextFactory.cs
 * Namespace: Adoptapal.Business.Definitions
 * 
 * Description:
 * This file contains the implementation of the DbContext factory used for creating instances
 * of the AdoptapalDbContext during design time, typically for migrations and scaffolding.
 * 
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Adoptapal.Business.Definitions
{
    /// <summary>
    /// Factory class for creating instances of AdoptapalDbContext during design time.
    /// </summary>
    public class AdoptapalDbContextFactory : IDesignTimeDbContextFactory<AdoptapalDbContext>
    {
        /// <summary>
        /// Creates a new instance of AdoptapalDbContext for design time.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        /// <returns>A new instance of AdoptapalDbContext.</returns>
        public AdoptapalDbContext CreateDbContext(string[] args)
        {
            // Configure DbContext options
            var optionsBuilder = new DbContextOptionsBuilder<AdoptapalDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Adoptapal;Trusted_Connection=True;MultipleActiveResultSets=true");
            optionsBuilder.EnableSensitiveDataLogging();

            // Create and return a new instance of the AdoptapalDbContext
            return new AdoptapalDbContext(optionsBuilder.Options);
        }
    }
}
