using System;
using System.Reflection;
using Verse;

namespace PeerPressure
{
	/// <summary>
	/// Log and error reporting utilities.
	/// </summary>
	public static class Report
	{
		/// <summary>
		/// Assembly of the mod.
		/// </summary>
		private static readonly Assembly Reference = typeof(Report).Assembly;

		/// <summary>
		/// Current version of the assembly.
		/// </summary>
		private static readonly Version Version = Reference.GetName().Version;

		/// <summary>
		/// Prefix used in configuration errors and logs.
		/// </summary>
		private static readonly string Prefix = $"[{PeerPressureMod.Name} v{Version}] ";

		/// <summary>
		/// Prepends the identification prefix to some text to be used in a report.
		/// </summary>
		/// <param name="original">Text to be prefixed.</param>
		/// <returns>Text with the prefix.</returns>
		private static string AddPrefix(string original)
		{
			return $"{Prefix}{original}";
		}

		/// <summary>
		/// Shows a line in the log. Usually used only by certain mod options.
		/// </summary>
		/// <param name="message">Message to log.</param>
		public static void Notice(string message)
		{
			Log.Message(AddPrefix(message));
		}

		/// <summary>
		/// Errors are always logged regardless of mod settings.
		/// </summary>
		/// <param name="message">Message to log.</param>
		public static void Error(string message)
		{
			Log.Error(AddPrefix(message));
		}
	}
}