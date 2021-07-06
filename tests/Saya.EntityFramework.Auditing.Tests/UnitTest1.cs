using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Saya.EntityFramework.Auditing.Tests.Data;

namespace Saya.EntityFramework.Auditing.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var options = CreateDbContextOptions("meowDb");
            var context = new MeowDbContext(options);

            //添加数据
            context.Cats.Add(new Entities.Cat
            {
                Name = "巧克力",
                CreatorId = 1001 //需要指定创建者ID
            });
            context.Cats.Add(new Entities.Cat
            {
                Name = "香草",
                CreatorId = 1001 //需要指定创建者ID
            });
            await context.SaveChangesAsync();

            //修改
            var cat_2 = await context.Cats.FirstAsync(neko => neko.Name.Equals("香草"));
            cat_2.Name = "バニラ";
            cat_2.LastModifierId = 1002;//指定修改者ID
            await context.SaveChangesAsync();

            //打印数据
            var allCat = await context.Cats.ToListAsync();
            foreach (var item in allCat)
            {
                TestContext.WriteLine($"Cat: {item.Name} - ID:{item.Id}, 创建者: {item.CreatorId} , 修改者：{item.LastModifierId}");
            }

            //打印 审计结果
            foreach (var item in await context.AuditRecords.ToListAsync())
            {
                TestContext.WriteLine($"审计信息 -- 表 {item.TableName} 于 {item.UpdateTime} 由 {item.UpdateBy} 修改,修改类型:{item.OperationType}，主键:{item.KeyValues}, 初始值:{item.OriginalValues ?? "*空"}, 修改后:{item.NewValues ?? "*空"}");
            }
        }

        public static DbContextOptions<MeowDbContext> CreateDbContextOptions(string databaseName)
        {
            var serviceProvider = new ServiceCollection().
                AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<MeowDbContext>();
            builder.UseInMemoryDatabase(databaseName)
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}