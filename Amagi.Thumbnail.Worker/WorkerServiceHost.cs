namespace Amagi.Thumbnail.Worker;

public class WorkerServiceHost : BackgroundService
{
    private readonly int _taskDelay = 5000;
    private readonly IServiceProvider _services;

    public WorkerServiceHost(IServiceProvider services)
    {
        _services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _services.CreateScope();
        var worker = scope.ServiceProvider.GetService<Worker>();
        if (worker != null)
        {
            while (true)
            {
                try
                {
                    await worker.ProcessData(stoppingToken);
                }
                catch (Exception ex)
                {
                    //do something
                }

                if (stoppingToken.IsCancellationRequested)
                    break;

                await Task.Delay(_taskDelay, stoppingToken);
            }
        }
    }
}