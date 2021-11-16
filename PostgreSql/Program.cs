using Microsoft.EntityFrameworkCore;
using Multi_Tasking.Modules;
using Npgsql;
using PostgreSql.Context;
using PostgreSql.Models;

Console.WriteLine("ProgreSQL Testing App. Press anykey !!!");
Console.ReadKey();

try
{ TestDatabaseAsync(); }
catch (Exception ex)
{ Console.WriteLine($"Message: {ex.Message}\nInner: {ex.InnerException}"); }

Console.ReadKey();

void TestDatabaseAsync()
{

    //Khởi tạo đối tượng DbContext chứa kết nối đến PostgreSQL
    PostgreSQLContext Database = new(ToPostgresConnectionString());

    //Đảm bảo dữ liệu được xóa sạch để làm mới mỗi lần Test, user phải có quyền xóa Table
    //await DbContext.Database.EnsureDeletedAsync();

    //Đảm bảo rằng Database được tạo ra tương tự như đã thiết lập thông qua Fluent API
    Database.Database.EnsureCreatedAsync();

    //Nếu có 2 Task cùng ghi dữ liệu như nhau xuống PostgreSQL thì Unique sẽ nhảy lỗi nên cần sử dụng Queue chạy
    BasicQueueTask queue = new();

    //Thêm 100 Guild vào bảng Guilds - Lần 1 (Task 1)
    Console.WriteLine("#Start Task 1 on ThreadID " + Environment.CurrentManagedThreadId);
    queue.Run(async () =>
    {
        using PostgreSQLContext DbContext = new(ToPostgresConnectionString());
        for (int i = 100; i >= 1; i--)
        {
            GuildModel? data;
            if (DbContext.Guilds != null)
            {
                data = await DbContext.Guilds.Where(x => x.GuildID == (398887563366105099 + i)).FirstOrDefaultAsync();
                if (data == null)
                {
                    //Thêm vào như thêm đối tượng vào mảng
                    DbContext.Guilds.Add(new GuildModel()
                    {
                        GuildID = (398887563366105099 + i),
                        GuildName = "ABCAAAAAAAAA",
                        CreationDate = DateTime.UtcNow
                    });
                }
            }
        }

        //Lưu xuống Database
        await DbContext.SaveChangesAsync();

        //Thông báo Task 1 hoàn tất việc Save
        Console.WriteLine("Task 1 Save Complete on ThreadID" + Environment.CurrentManagedThreadId);
    });
    Console.WriteLine("#End Task 1 on ThreadID " + Environment.CurrentManagedThreadId);

    Console.WriteLine("#Start Task 2 on ThreadID " + Environment.CurrentManagedThreadId);
    queue.Run(async () =>
    {
        using PostgreSQLContext DbContext = new(ToPostgresConnectionString());
        for (int i = 100; i >= 1; i--)
        {
            GuildModel? data;
            if (DbContext.Guilds != null)
            {
                data = await DbContext.Guilds.Where(x => x.GuildID == (398887563366105099 + i)).FirstOrDefaultAsync();
                if (data == null)
                {
                    //Thêm vào như thêm đối tượng vào mảng
                    DbContext.Guilds.Add(new GuildModel()
                    {
                        GuildID = (398887563366105099 + i),
                        GuildName = "ABCAAAAAAAAA",
                        CreationDate = DateTime.UtcNow
                    });
                }
            }
        }

        //Lưu xuống Database
        await DbContext.SaveChangesAsync();

        //Thông báo Task 1 hoàn tất việc Save
        Console.WriteLine("Task 2 Save Complete on ThreadID" + Environment.CurrentManagedThreadId);
    });
    Console.WriteLine("#End Task 2 on ThreadID " + Environment.CurrentManagedThreadId);
}

string ToPostgresConnectionString()
{
    // Sinh chuỗi ConntectString
    var csb = new NpgsqlConnectionStringBuilder
    {
        Host = "localhost",
        Port = 5434,
        Database = "test",
        Username = "test",
        Password = "123456789",
        SslMode = SslMode.Disable,
        TrustServerCertificate = true
    };
    return csb.ConnectionString;
}