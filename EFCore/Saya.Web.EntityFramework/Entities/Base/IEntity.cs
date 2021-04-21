namespace Saya.Web.EntityFramework.Entities
{
    /// <summary>
    /// 定义一个实体. 
    /// 它的主键可能不是"Id"，也有可能是复合主键
    /// 使用 <see cref="IEntity{TKey}"/> 可以定义一个"Id"主键并更好的与框架功能结合
    /// </summary>
    public interface IEntity
    {
        object[] GetKeys();
    }


    /// <summary>
    /// 定义一个拥有单独主键"Id"的实体
    /// </summary>
    /// <typeparam name="TKey">实体的主键类型</typeparam>
    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; }
    }

}
