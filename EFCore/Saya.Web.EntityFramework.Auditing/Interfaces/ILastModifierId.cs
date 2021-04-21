using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace Saya.Web.EntityFramework.Auditing
{
    /// <summary>
    /// 最后修改者Id 标准接口 默认用户ID类型为string
    /// </summary>
    public interface ILastModifierId : ILastModifierId<string>
    {
    }


    /// <summary>
    /// 最后修改者Id 标准接口 泛型
    /// </summary>
    /// <typeparam name="TUser">用户ID类型</typeparam>
    public interface ILastModifierId<TUser>
    {
        TUser LastModifierId { get; set; }
    }

}
