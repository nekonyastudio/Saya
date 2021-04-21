using System;
using Saya.Web.EntityFramework.Auditing.Entities.Audit;

namespace Saya.Web.EntityFramework.Auditing.Entities
{
    /// <summary>
    /// 通用审计记录 实体
    /// （这玩意是用来存储审计记录本身的实体，不是用来让实体拥有审计功能的基类）
    /// </summary>
    [Serializable]
    public class AuditRecord : AuditRecord<string>
    {
        /// <summary>
        /// 获取自己的泛型对象
        /// </summary>
        /// <returns></returns>
        public virtual AuditRecord<string> GetGenericEntity()
        {
            return this;
        }
    }

    [Serializable]
    public class AuditRecord<TUser> : AuditRecordBase<TUser>
    {

    }
}
