using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Saya.Web.EntityFramework.Auditing.Entities;

namespace Saya.Web.EntityFramework.Auditing
{
    /// <summary>
    /// Audit Entry
    /// 我也不知道怎么翻译，审计入口？
    /// 这个玩意是实现自动审计功能用的内部类，Entry乍一眼挺像Entity的，别搞混了哦
    /// </summary>
    public class AuditEntry : AuditEntry<string>
    {
        public AuditEntry(EntityEntry entry) : base(entry)
        {
            Entry = entry;
        }

        public new AuditRecord ToAudit()
        {
            var audit = new AuditRecord
            {
                TableName = TableName,
                UpdateTime = DateTimeOffset.UtcNow,
                KeyValues = JsonSerializer.Serialize(KeyValues),
                OriginalValues = OriginalValues.Count == 0 ? null : JsonSerializer.Serialize(OriginalValues),
                NewValues = NewValues.Count == 0 ? null : JsonSerializer.Serialize(NewValues),

                OperationType = this.OperationType,
                UpdateBy = this.Modifier
            };
            return audit;
        }
    }

    /// <summary>
    /// Audit Entry
    /// 我也不知道怎么翻译，审计入口？
    /// 这个玩意是实现自动审计功能用的内部类，Entry乍一眼挺像Entity的，别搞混了哦
    /// </summary>
    /// <typeparam name="TUser">指定User的类型</typeparam>
    public class AuditEntry<TUser>
    {
        public EntityEntry Entry { get; protected set; }
        public string TableName { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OriginalValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();

        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

        /// <summary>
        /// 数据操作类型
        /// </summary>
        public DataOperationType OperationType { get; set; } = DataOperationType.Unknow;

        /// <summary>
        /// 修改者ID
        /// </summary>
        public TUser Modifier { get; set; }

        public bool HasTemporaryProperties => TemporaryProperties.Any();


        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }

        public AuditRecord<TUser> ToAudit()
        {
            var audit = new AuditRecord<TUser>();
            audit.TableName = TableName;
            audit.UpdateTime = DateTimeOffset.UtcNow;
            audit.KeyValues = JsonSerializer.Serialize(KeyValues);
            audit.OriginalValues = OriginalValues.Count == 0 ? null : JsonSerializer.Serialize(OriginalValues);
            audit.NewValues = NewValues.Count == 0 ? null : JsonSerializer.Serialize(NewValues);

            audit.OperationType = this.OperationType;
            audit.UpdateBy = this.Modifier;

            return audit;
        }
    }
}
