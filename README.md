# functional.pipe

C# implementation of F# pipe

Piping helps you divide complex problem into smaller, simple operation and handle them one by one. Also, with careful use, the code will read much better and more like a natural language.

```csharp
public MoneyTransaction Parse(IList<string> columns)
{
    return new MoneyTransaction(
        columns[0].Pipe(c => DateTime.ParseExact(c, "dd MMM yy", CultureInfo.InvariantCulture)),
        columns[1].Trim(),
        columns[1].Trim().Pipe(FindCategory),
        columns[6]
            .Pipe(c => c.Trim())
            .Pipe(c => _logger.LogInformation($"Input: {c}"))
            .Pipe(c => !string.IsNullOrEmpty(c) ? decimal.Parse(c) : 0),
        0
    );
}
```

