#if NET6_0_OR_GREATER
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;

namespace Bunit.TestDoubles;

/// <summary>
/// Default implementation of an IErrorBoundaryLogger (needed for ErrorBoundary component).
/// It delegates the implementation of LogErrorAsync to an instance created from ILoggerFactory.
/// </summary>
internal class BunitErrorBoundaryLogger : IErrorBoundaryLogger
{
	private static readonly Action<ILogger, string, Exception> ExceptionCaughtByErrorBoundary = LoggerMessage.Define<string>(
		LogLevel.Warning,
		100,
		"Unhandled exception rendering component: {Message}");

	private readonly ILogger logger;

	/// <summary>
	/// Initializes the instance of the <see cref="BunitErrorBoundaryLogger"/> class.
	/// </summary>
	public BunitErrorBoundaryLogger(ILoggerFactory loggerFactory)
	{
		logger = loggerFactory.CreateLogger<BunitErrorBoundaryLogger>();
	}

	/// <summary>
	/// Logs the supplied <paramref name="exception"/>.
	/// </summary>
	public ValueTask LogErrorAsync(Exception exception)
	{
		ExceptionCaughtByErrorBoundary(logger, exception.Message, exception);
		return ValueTask.CompletedTask;
	}
}
#endif
