using System;
using Saya.Web.EntityFramework.Entities;

namespace Saya.Web.EntityFramework.Auditing.Entities
{
    /// <summary>
    /// 审计实体 基类
    /// 指定UserID类型
    /// </summary>
    [Serializable]
    public abstract class AuditedEntityWithUserID<TUser> : Entity, IAuditedEntity<TUser>
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
        public virtual TUser CreatorId { get; set; }

        /// <summary>
        /// 最后修改者 用户ID
        /// </summary>
        public virtual TUser LastModifierId { get; set; }
    }

    /// <summary>
    /// 审计实体 基类
    /// 指定UserID类型
    /// </summary>
    /// <typeparam name="TKey">实体主键类型</typeparam>
    /// <typeparam name="TUser">用户ID类型</typeparam>
    public abstract class AuditedEntityWithUserID<TKey, TUser> : Entity<TKey>, IAuditedEntity<TUser>
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
        public virtual TUser CreatorId { get; set; }


        /// <summary>
        /// 最后修改者 用户ID
        /// </summary>
        public virtual TUser LastModifierId { get; set; }

        protected AuditedEntityWithUserID() { }

        protected AuditedEntityWithUserID(TKey id)
            : base(id)
        {

        }
    }
}
