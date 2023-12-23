# Logger

Official FA .NET logger package

## ⭐ Features

1. Logging: For general logging purpose
2. Notify: For general notify purpose

## ❔ Usage

### Logging

1. Discord Logger

```csharp
services.AddHttpClient<IMyLoggerProvider, DiscordMyLoggerProvider>(c =>
{
    c.BaseAddress = new Uri(context.Configuration.GetValue<string>("AuthSettings:DiscordURI"));
});
services.AddSingleton<IMyLogger>(s => new MyLogger(s.GetRequiredService<IMyLoggerProvider>()));
```

### Notifier

1. Telegram Provider

```csharp
serviceProvider.AddSingleton<IMyNotifier, MyNotifier>(s =>
    new MyNotifier(new TelegramNotifyProvider(
        botToken: configuration.GetValue<string>("AppSettings:TelegramBotToken"),
        groupId: configuration.GetValue<string>("AppSettings:TelegramGroupId"))));
```

## 👍 Contribution

1. Fork it
2. Create your feature branch (git checkout -b my-new-feature)
3. Commit your changes (git commit -m 'Add some feature')
4. Push to the branch (git push origin my-new-feature)
5. Create new Pull Request
