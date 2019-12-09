﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC
{
    /// <summary>
    /// Представляє собою клас для логування.
    /// </summary>
    public class Logger<T> : ILogger<T>
    {
        private readonly ILogger _logger;

        public Logger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        /// <summary>
        /// Метод для логування.
        /// </summary>
        /// <typeparam name="TState">Стан</typeparam>
        /// <param name="logLevel">Рівень логування</param>
        /// <param name="eventId">Айді події</param>
        /// <param name="state">Стан</param>
        /// <param name="exception">Виключення</param>
        /// <param name="formatter">Форматер</param>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string Formatter(TState innserState, Exception innerException)
            {
                // additional logic goes here, in my case that was extracting additional information from custom exceptions
                var message = formatter(innserState, innerException) ?? string.Empty;
                return message + " custom logger";
            }

            _logger.Log(logLevel, eventId, state, exception, Formatter);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _logger.IsEnabled(logLevel);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return _logger.BeginScope(state);
        }
    }
}
