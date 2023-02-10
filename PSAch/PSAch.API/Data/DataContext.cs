using Microsoft.EntityFrameworkCore;
using PSAch.API.DTOs;
using PSAch.Core;

namespace PSAch.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Game> Games { get;set; }

        public DbSet<Achievement> Achievements { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Audit> AuditLogs { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual async Task<int> SaveChangesAsync(string userId = "default")
        {
            await OnBeforeSaveChanges(userId);
            var result = await base.SaveChangesAsync();
            return result;
        }

        /// <summary>
        /// Перед сохранением изменений добавить соответствующие изменения в таблицу логов
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private async Task OnBeforeSaveChanges(string userId)
        {
            // сканируем сущность на наличие каких либо изменений
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged) continue;

                var auditEntry = new AuditEntry(entry)
                {
                    //получаем название таблицы
                    TableName = entry.Entity.GetType().Name,
                    UserId = userId
                };
                auditEntries.Add(auditEntry);
                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;
                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.AuditType = AuditType.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }
            foreach (var auditEntry in auditEntries)
            {
                AuditLogs.Add(auditEntry.ToAudit());
            }
        }
    }
}
