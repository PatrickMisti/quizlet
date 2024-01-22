using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using quizlet_back.Configuration;
using quizlet_back.ExceptionHandling;
using quizlet_back.Models;
using Serilog;
using Serilog.Core;

namespace quizlet_back.Repository
{
    public class DbDatabase: DbContext
    {
        private readonly string _connectionString = "Host=localhost;Database=Card;Port=5432;Username=app;Password=app;";
        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }

        private static Logger _log = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();

        public DbDatabase(DbContextOptions<DbDatabase> dbContext) : base(dbContext) { }

        public DbDatabase() : this(new DbContextOptionsBuilder<DbDatabase>().Options)
        {
            // todo actual don't know
        }

        public DbDatabase(string? connectionString) : this(new DbContextOptionsBuilder<DbDatabase>().Options)
        {
            if (connectionString == null) return;

            _connectionString = connectionString;
        }

        /// <summary>
        /// Configs Connection with orMapper to Db
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // UseNpgsql is used to connect to post gre Sql
            optionsBuilder
                .UseNpgsql(_connectionString, options => options.EnableRetryOnFailure(2))
                .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Init and Config Entities
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create Config and Init Entities
            Configuration(modelBuilder);
            InitializeTable(modelBuilder);


            base.OnModelCreating(modelBuilder);
        }

        private void Configuration(ModelBuilder builder)
        {
            // Apply all Configurations
            builder.ApplyConfiguration(new BaseConfiguration<Card>());
            builder.ApplyConfiguration(new BaseConfiguration<User>());
        }
        
        private void InitializeTable(ModelBuilder model)
        {
            // Init all Entities
            model.Entity<Card>();
            model.Entity<User>();
        }

        /// <summary>
        /// Create Table if not exist 
        /// </summary>
        public static async Task CreateDatabase(DbContext db)
        {
            _log.Debug("DBContext: Create Database");

            try
            {
                var isCreated = await db.Database.CanConnectAsync();


            }
            catch (Exception ex)
            {
                throw new DatabaseNotConnectedException("Couldn't connect to db:" + ex.Message);
            }

            try
            {
                var showUserLength = await db.Set<User>().CountAsync();

                if (showUserLength > 0)
                {
                    _log.Debug("DBContext: data already exist !");
                    return;
                }

                _log.Debug("DBContext: add default values");
                await AddDefaultData(db);
            }
            catch (Exception e)
            {
                await AddDefaultData(db);
                _log.Error("DBContext throw error {err}", e.Message);
                
            }
            finally
            {
                _log.Debug("DBContext now ready!");
            }
        }

        private static async Task AddDefaultData(DbContext db)
        {
            await db.Database.EnsureCreatedAsync();
            await db.SaveChangesAsync();

            var card = new Card
            {
                EnglishTranslate = "Hello",
                GermanTranslate = "Hallo"
            };

            await db.Set<Card>().AddAsync(card);
            await db.SaveChangesAsync();

            var defaultUser = new User
            {
                Role = Role.Admin,
                Email = "admin@admin.at",
                Password = "admin"
            };

            await db.Set<User>().AddAsync(defaultUser);
            
            await db.SaveChangesAsync();
        }
    }
}
