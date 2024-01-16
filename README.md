# Logger

Official FA .NET logger package

## ⭐ Features

1. Logging: For general logging purpose
2. Notify: For general notify purpose

## ❔ Usage

### Logging (New)

- Inject logger

```csharp
    public static void SetupLogger(IServiceCollection serviceProvider, IConfiguration configuration)
    {
        var consoleLoggerProvider = new ConsoleLoggerProvider();
        // discord
        var discordUrl = configuration.GetValue<string>("AuthSettings:DiscordURI");
        // telegram
        var telegramBotToken = configuration.GetValue<string>("AppSettings:TelegramBotToken");
        var telegramGroupId = configuration.GetValue<string>("AppSettings:TelegramGroupId");

        serviceProvider.AddSingleton<IMyLogger, MyLogger>(s =>
        {
            var list = new List<IMyLoggerProvider>
            {
                consoleLoggerProvider,
            };

            // discord
            if (!string.IsNullOrWhiteSpace(discordUrl))
            {
                list.Add(new DiscordLoggerProvider(discordUrl));
            }

            // telegram
            if (!string.IsNullOrWhiteSpace(telegramBotToken) && !string.IsNullOrWhiteSpace(telegramGroupId))
            {
                list.Add(new TelegramLoggerProvider(telegramBotToken, telegramGroupId));
            }

            return new MyLogger(list);
        });
    }
```

- Use logger

```csharp
//info
await myLogger.LogInfo("This is done");

// error
await myLogger.LogException(ex, $"Date: {date}", ex.StackTrace);

// notification
await myLogger.LogNotification($"Distributor Publisher\nDate: {dateTime} done");
```

### Logging (Old)

1. Discord Logger

```csharp
services.AddHttpClient<IMyLoggerProvider, DiscordMyLoggerProvider>(c =>
{
    c.BaseAddress = new Uri(context.Configuration.GetValue<string>("AuthSettings:DiscordURI"));
});
services.AddSingleton<IMyLogger>(s => new MyLogger(s.GetRequiredService<IMyLoggerProvider>()));
```

## 👍 Contribution

1. Fork it
2. Create your feature branch (git checkout -b my-new-feature)
3. Commit your changes (git commit -m 'Add some feature')
4. Push to the branch (git push origin my-new-feature)
5. Create new Pull Request
