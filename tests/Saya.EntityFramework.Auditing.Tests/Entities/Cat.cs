using System;
using System.ComponentModel.DataAnnotations;
using Saya.EntityFramework.Auditing.Entities;

namespace Saya.EntityFramework.Auditing.Tests.Entities
{
    /// <summary>
    /// 测试用实体
    /// </summary>
    public class Cat : AuditedEntityWithUserID<Guid, int>
    {
        [Required]
        public string Name { get; set; }

    }
}
