using System;
using Microsoft.Extensions.Logging;
using System.IO;

namespace entityF3
{
    class MyLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) //CreateLogger: создает и возвращает объект логгера
        {
            return new MyLogger();
        }

        public void Dispose() { }    //управляет освобождение ресурсов

        private class MyLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId,
                    TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                File.AppendAllText("log.txt", formatter(state, exception));
                Console.WriteLine(formatter(state, exception));
            }
        }
}
