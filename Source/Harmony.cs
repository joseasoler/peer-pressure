using System;

namespace PeerPressure
{
	/// <summary>
	/// Handles application of harmony patches.
	/// </summary>
	public static class Harmony
	{
		/// <summary>
		/// Apply harmony patches and mark any potential exceptions as caused by this mod.
		/// </summary>
		public static void Initialize()
		{
			try
			{
				HarmonyLib.Harmony harmonyInstance = new HarmonyLib.Harmony(PeerPressureMod.PackageId);
				harmonyInstance.PatchAll();
			}
			catch (Exception exception)
			{
				Report.Error($"Harmony patching failed:\n{exception}");
			}
		}
	}
}