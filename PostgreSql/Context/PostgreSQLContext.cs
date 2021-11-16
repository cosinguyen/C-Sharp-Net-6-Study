using Microsoft.EntityFrameworkCore;
using PostgreSql.Models;

namespace PostgreSql.Context
{
    internal class PostgreSQLContext : DbContext
    {
        /// <summary>
        /// PostgreSQLContext ConnectionString
        /// </summary>
        private string ConnectionString { get; }
        public PostgreSQLContext(string ConnectionStringProvider)
        { ConnectionString = ConnectionStringProvider; }
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options, string ConnectionStringProvider)
            : base(options)
        { ConnectionString = ConnectionStringProvider; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql(ConnectionString);
        }

        /// DBset
        internal virtual DbSet<GuildModel>? Guilds { get; set; }
        internal virtual DbSet<AuditLogsHistory>? AuditLogsHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            modelBuilder.Entity<GuildModel>(entity =>
            {
                entity.ToTable("Guilds").HasKey(x => x.GuildID);
                entity.Property(e => e.GuildID).HasColumnName("GuildID").HasColumnType("bigint").IsRequired().ValueGeneratedNever();
                entity.Property(e => e.GuildName).HasColumnName("GuildName").HasColumnType("text");
                entity.Property(e => e.CreationDate).HasColumnName("CreationDate").HasColumnType("timestamp with time zone").IsRequired();
                entity.Property(e => e.RecordCreated).HasColumnName("RecordCreated").HasColumnType("timestamp with time zone");
                entity.Property(e => e.RecordUpdated).HasColumnName("RecordUpdated").HasColumnType("timestamp with time zone");
                entity.HasIndex(e => e.GuildID).IsUnique(true);
            });
            modelBuilder.Entity<AuditLogsHistory>(entity =>
            {
                entity.ToTable("AuditLogsHistory").HasKey(x => x.AuditLogID);
                entity.Property(e => e.AuditLogID).HasColumnName("AuditLogID").HasColumnType("bigint").IsRequired().ValueGeneratedNever();
                entity.Property(e => e.GuildID).HasColumnName("GuildID").HasColumnType("bigint").IsRequired();
                entity.Property(e => e.CreationDate).HasColumnName("CreationDate").HasColumnType("timestamp with time zone").IsRequired();
                entity.Property(e => e.ActionType).HasColumnName("ActionType").HasColumnType("text");
                entity.Property(e => e.Reason).HasColumnName("Reason").HasColumnType("text");
                entity.Property(e => e.RecordCreated).HasColumnName("RecordCreated").HasColumnType("timestamp with time zone");
                entity.Property(e => e.RecordUpdated).HasColumnName("RecordUpdated").HasColumnType("timestamp with time zone");
                entity.HasIndex(e => e.AuditLogID).IsUnique(true);
                entity.HasOne(e => e.Guild).WithMany(q => q.AuditLogs).HasForeignKey(p => p.GuildID).OnDelete(DeleteBehavior.Restrict);
            });
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //Kế thừa lại phương thức SaveChangesAsync để ghi sẵn RecordUpdated và RecordCreated
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            if (entries != null)
            {
                DateTime UTCDateTime = DateTime.UtcNow;

                foreach (var entityEntry in entries)
                {
                    ((BaseEntity)entityEntry.Entity).RecordUpdated = UTCDateTime;

                    if (entityEntry.State == EntityState.Added)
                    {
                        ((BaseEntity)entityEntry.Entity).RecordCreated = UTCDateTime;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}