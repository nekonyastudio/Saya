using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Saya.Core.Extensions.Enumerable;

namespace Saya.Domain.Entities
{
    /// <summary>
    /// 通用EFCore实体基类
    /// </summary>
    [Serializable]
    public abstract class Entity : IEntity
    {
        /// <inheritdoc/>
        public override string ToString()
        {
            return $"[ENTITY: {GetType().Name}] Keys = {GetKeys().JoinAsString(", ")}";
        }

        public abstract object[] GetKeys();
    }

    /// <summary>
    /// 实体基类，指定Key
    /// </summary>
    /// <inheritdoc cref="IEntity{TKey}" />
    [Serializable]
    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey Id { get; set; }

        protected Entity() { }

        protected Entity(TKey id)
        {
            this.Id = id;
        }

        public override object[] GetKeys()
        {
            return new object[] { Id };
        }

        public override string ToString()
        {
            return $"[ENTITY: {GetType().Name}] Id = {Id}";
        }

    }
}
