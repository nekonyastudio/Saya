using System;
using Saya.Web.EntityFramework.Entities;

namespace Saya.Web.EntityFramework.Auditing.Entities
{
    /// <summary>
    /// 审计实体 基类
    /// UserID默认为string
    /// </summary>
    [Serializable]
    public abstract class AuditedEntity : Entity, IAuditedEntity
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 创建者 用户ID
        /// </summary>
        public virtual string CreatorId { get; set; }


        /// <summary>
        /// 最后修改者 用户ID
        /// </summary>
        public virtual string LastModifierId { get; set; }

    }

    /// <summary>
    /// 审计实体 基类
    /// UserID默认为string
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    public class AuditedEntity<TKey> : Entity<TKey>, IAuditedEntity
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 创建者 用户ID
        /// </summary>
        public virtual string CreatorId { get; set; }


        /// <summary>
        /// 最后修改者 用户ID
        /// </summary>
        public virtual string LastModifierId { get; set; }

        protected AuditedEntity()
        {

        }

        protected AuditedEntity(TKey id)
            : base(id)
        {

        }
    }
}
