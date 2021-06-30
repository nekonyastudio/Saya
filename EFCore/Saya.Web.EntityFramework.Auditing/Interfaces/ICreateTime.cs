using System;

namespace Saya.Web.EntityFramework.Auditing
{
    /// <summary>
    /// “创建时间”的标准接口
    /// </summary>
    public interface ICreateTime
    {
        DateTimeOffset? CreateTime { get; set; }
    }
}
