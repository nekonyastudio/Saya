using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Saya.EntityFramework.Auditing.Entities.Audit;
using Saya.EntityFramework.Auditing.Tests.Entities;

namespace Saya.EntityFramework.Auditing.Tests.Data;

public class MeowDbContext : DbContext
{
    public MeowDbContext(DbContextOptions<MeowDbContext> options) : base(options)
    {

    }

    public DbSet<Cat> Cats { get; set; } //普通路过的一般数据集

    /// <summary>
    /// 审计记录数据集
    /// </summary>
    public DbSet<AuditRecord<int>> AuditRecords { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        //自动审计功能
        var auditEntries = this.OnBeforeSaveChanges<int>(this.AuditRecords);
        var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        await this.OnAfterSaveChanges<int>(this.AuditRecords, auditEntries);
        return result;
    }

}
