using System;
using System.Collections.Generic;
using System.Linq;
using Serilog.Context;
using Serilog.Events;
using Serilog.Parsing;

/*
public class LoggingContextAwareException : Exception
{
    public List<string> ThrownScope { get; } = new List<string>();

    public LoggingContextAwareException(Exception e, string message)
        : base(message, e)
    {
        var contextEnricher = LogContext.Clone();
        var logEvent = new LogEvent(DateTimeOffset.Now, LogEventLevel.Debug, null, new MessageTemplate(new List<MessageTemplateToken>()), new List<LogEventProperty>());
        contextEnricher.Enrich(logEvent, new PropertyFactory());
        if (logEvent.Properties["Scope"] is SequenceValue p)
            ThrownScope = p.Elements
                .Select( el => el is ScalarValue s ? s.Value.ToString() : el.ToString())
                .AsList();
    }
}
*/