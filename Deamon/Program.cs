using Quartz;
using Quartz.Impl;
using System.Reflection.Metadata;

StdSchedulerFactory factory = new StdSchedulerFactory();
IScheduler scheduler = await factory.GetScheduler();

await scheduler.Start();

// تعریف job
IJobDetail job = JobBuilder.Create<MyJob>()
    .WithIdentity("job1", "group1")
    .Build();

// تعریف تریگر: هر 1 ثانیه اجرا شود
ITrigger trigger = TriggerBuilder.Create()
    .WithIdentity("trigger1", "group1")
    .StartNow()
    .WithSimpleSchedule(x => x
        .WithIntervalInSeconds(1)
        .RepeatForever())
    .Build();

// اجرای job با تریگر
await scheduler.ScheduleJob(job, trigger);

Console.WriteLine("Job started. Press Enter to exit.");
Console.ReadLine();

await scheduler.Shutdown();