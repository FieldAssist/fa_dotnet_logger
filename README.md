# Logger

Official FA .NET logger package

## ⭐ Features

1. Logging: For general logging purpose
2. Notify: For general notify purpose

## ❔ Usage

### Logging (New)

// TODO

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
