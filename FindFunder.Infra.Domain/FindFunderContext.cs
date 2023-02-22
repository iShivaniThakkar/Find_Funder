using FindFunder.Infra.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Infra.Domain
{
    public class FindFunderContext : DbContext
    {
        public FindFunderContext(DbContextOptions<FindFunderContext> options) : base(options) { }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Entrepreneur> Entrepreneurs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<RequestProposal> RequestProposals { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<InvestmentStatistics> InvestmentsStatistics { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
