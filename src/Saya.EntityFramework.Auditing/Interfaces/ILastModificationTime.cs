using System;

namespace Saya.EntityFramework.Auditing;

/// <summary>
/// 最后修改时间 标准接口
/// </summary>
public interface ILastModificationTime
{
    DateTimeOffset? LastModificationTime { get; set; }
}
