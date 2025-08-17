// See https://aka.ms/new-console-template for more information
using Logging.Framework;

Console.WriteLine("Hello, World!");

bool isDone = false;

InternalLogger logger = new InternalLogger();

while(true)
{
    await Task.Run(()  =>
    {
        for (int i = 0; i < 1000; i++)
        {
            Thread.Sleep(1000);
            logger.LogMessage(LogType.Info, "TestTaskManagerWorker", $"I Am Cool and this is loop {i} of 1000.");
        }

        isDone = true;
    }).ConfigureAwait(true);

    if (isDone)
    {
        break;
    }
}