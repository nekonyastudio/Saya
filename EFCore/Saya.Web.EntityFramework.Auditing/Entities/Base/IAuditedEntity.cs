namespace Saya.Web.EntityFramework.Auditing.Entities
{
    /// <summary>
    /// 审计实体 基础接口 [默认用户ID为string类型]
    /// </summary>
    public interface IAuditedEntity : IAuditedEntity<string>
    {
    }

    /// <summary>
    /// 审计实体 基础接口 泛型
    /// </summary>
    /// <typeparam name="TUser">记录的用户类型</typeparam>
    public interface IAuditedEntity<TUser> : ICreator<TUser>, ICreateTime, ILastModificationTime, ILastModifierId<TUser>
    {
    }
}
