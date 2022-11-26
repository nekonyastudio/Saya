namespace Saya.EntityFramework.Auditing;

/// <summary>
/// 创建者 标准定义 [默认字符串类型 CreatorId ]
/// </summary>
public interface ICreator : ICreator<string> { }

/// <summary>
/// 创建者 标准定义
/// </summary>
public interface ICreator<TUser>
{
    TUser CreatorId { get; set; }
}
