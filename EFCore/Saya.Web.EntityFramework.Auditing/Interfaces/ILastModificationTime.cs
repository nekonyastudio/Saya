using System;

namespace Saya.Web.EntityFramework.Auditing
{
    /// <summary>
    /// 最后修改时间 标准接口
    /// </summary>
    public interface ILastModificationTime
    {
        DateTimeOffset? LastModificationTime { get; set; }
    }
}
