namespace FitDash.Services
{
    public class TimerBackgroundService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new System.Timers.Timer(500);

            timer.Start();

            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            await Task.CompletedTask;
        }

        private void OnTimedEvent(object? sender, System.Timers.ElapsedEventArgs e)
        {

            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }
    }
}
