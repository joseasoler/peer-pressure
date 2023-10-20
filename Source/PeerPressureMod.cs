using UnityEngine;
using Verse;

namespace PeerPressure
{
	/// <summary>
	/// Main class of the mod. Handles initialization order.
	/// </summary>
	public class PeerPressureMod : Mod
	{
		public const string PackageId = "joseasoler.peerpressure";
		public const string Name = "Peer Pressure";

		/// <summary>
		/// Handles the initialization of every component of this mod.
		/// </summary>
		/// <param name="content">Content pack data of this mod.</param>
		public PeerPressureMod(ModContentPack content) : base(content)
		{
			Harmony.Initialize();
			GetSettings<Settings>();
			Report.Notice("Mod initialized.");
		}

		/// <summary>
		/// Name of the mod in the mod settings list.
		/// </summary>
		/// <returns>Name of the mod in the settings list.</returns>
		public override string SettingsCategory()
		{
			return SettingsWindow.SettingsCategory();
		}

		/// <summary>
		/// Contents of the mod settings window.
		/// </summary>
		/// <param name="inRect">Available area for drawing the settings.</param>
		public override void DoSettingsWindowContents(Rect inRect)
		{
			SettingsWindow.DoWindowContents(inRect);
			base.DoSettingsWindowContents(inRect);
		}
	}
}