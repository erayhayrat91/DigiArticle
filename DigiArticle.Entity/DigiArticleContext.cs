using DigiArticle.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DigiArticle.Entity
{
    public class DigiArticleContext : DbContext
    {
        private readonly string _connectionString = "Server=MONSTERPC;Database=DigiArticleDEVDB;User Id=sa;Password=123456789;MultipleActiveResultSets=True";
        public DigiArticleContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
