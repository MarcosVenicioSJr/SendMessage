using SendMessage.Models.Interfaces;

namespace SendMessage
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISendMessage _sendMessage;

        public Worker(ILogger<Worker> logger, ISendMessage sendMessage)
        {
            _logger = logger;
            _sendMessage = sendMessage;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}