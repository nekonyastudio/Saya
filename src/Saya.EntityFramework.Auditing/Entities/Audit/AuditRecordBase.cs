using System;
using System.ComponentModel.DataAnnotations;
using Saya.Domain.Entities;
using Saya.EntityFramework.Auditing.Audits;

namespace Saya.EntityFramework.Auditing.Entities.Audit
{
    /// <summary>
    /// 通用审计记录 基类实体
    /// （这玩意是用来存储审计记录本身的实体，不是用来让实体拥有审计功能的基类）
    /// </summary>
    [Serializable]
    public abstract class AuditRecordBase<TUser> : Entity<Guid> //TUserID指定写进审计记录的User的类型，通常应该是User的ID, 后面的Entity<Guid> 表示我们审计记录本身的ID是GUID类型的
    {
        /// <summary>
        /// 该条审计记录来针对哪个表
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 该条记录的产生时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTimeOffset UpdateTime { get; set; }

        /// <summary>
        /// 被修改的记录的主键
        /// </summary>
        public string KeyValues { get; set; }

        /// <summary>
        /// 被修改的记录 在修改之前的值
        /// </summary>
        public string OriginalValues { get; set; }

        /// <summary>
        /// 被修改的记录 在修改后的值
        /// </summary>
        public string NewValues { get; set; }

        public DataOperationType OperationType { get; set; }

        public TUser UpdateBy { get; set; }
    }
}
