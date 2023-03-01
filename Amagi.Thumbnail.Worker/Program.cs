using Amagi.Thumbnail.BusinessLayer;
using Amagi.Thumbnail.DataLayer.Context;
using Amagi.Thumbnail.Worker;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        AutoMapper.MapperConfiguration mapperConfiguration = new(mc =>
        {
        });
        
        services.AddSingleton(mapperConfiguration.CreateMapper());
        services.AddDbContext<AmagiContext>(options => options.UseSqlServer("Server=localhost;Database=Amagi;Trusted_Connection=True;Encrypt=False;"))
            .AddScoped<AmagiContext>();
        services.AddTransient<IThumbnailService, ThumbnailService>();
        services.AddTransient<Worker>();
        services.AddHostedService<WorkerServiceHost>();
    })
    .Build();

host.Run();
