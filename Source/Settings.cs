using Verse;

namespace PeerPressure
{
	/// <summary>
	/// Contains data for all settings values. The default values of this object are the initial default settings for the mod.
	/// </summary>
	public class SettingValues
	{
		/// <summary>
		/// Multiplier applied to certainty reduction when the convertee has an opinion of the proselytizer with a value of
		/// 100. Values between opinion 0 and 100 are scaled linearly.
		/// </summary>
		public float CertaintyReductionOpinionMultiplier = 1.0F;

		/// <summary>
		/// Multiplier applied to conversion attempt chance when the proselytizer has an opinion of the convertee with a
		/// value of 100. Values between opinion 0 and 100 are scaled linearly.
		/// </summary>
		public float ConversionAttemptChanceMultiplier = 0.5F;
	}

	/// <summary>
	/// Allows the rest of the mod to access a SettingValues instance. Handles resetting, save and load.
	/// </summary>
	public class Settings : ModSettings
	{
		/// <summary>
		/// Single instance of the setting values of this mod. Uses static for performance reasons.
		/// </summary>
		public static SettingValues Values = new();

		/// <summary>
		/// Set all settings to their default values.
		/// </summary>
		public static void Reset()
		{
			Values = new SettingValues();
		}

		/// <summary>
		/// Save and load preferences.
		/// </summary>
		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look(ref Values.CertaintyReductionOpinionMultiplier, "CertaintyReductionOpinionMultiplier");
			Scribe_Values.Look(ref Values.ConversionAttemptChanceMultiplier, "ConversionAttemptChanceMultiplier");
		}
	}
}