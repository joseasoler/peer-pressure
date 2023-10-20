using UnityEngine;
using Verse;

namespace PeerPressure
{
	/// <summary>
	/// Implementation of the mod settings window.
	/// </summary>
	public static class SettingsWindow
	{
		/// <summary>
		/// Name of the mod in the settings list.
		/// </summary>
		/// <returns>Name of the mod in the settings list.</returns>
		public static string SettingsCategory()
		{
			return PeerPressureMod.Name;
		}

		/// <summary>
		/// Contents of the mod settings window.
		/// </summary>
		/// <param name="inRect">Available area for drawing the settings.</param>
		public static void DoWindowContents(Rect inRect)
		{
			const int maxOpinion = 100; // See Pawn_RelationsTracker.OpinionOf.

			// Initiate window listing.
			Listing_Standard listing = new Listing_Standard();
			listing.Begin(inRect);

			// Certainty reduction multiplier by opinion.
			AddMultiplierSetting(listing,
				label: "SP_CertaintyReductionOpinionMultiplierLabel",
				descr: "SP_CertaintyReductionOpinionMultiplierDescr",
				descrValue: Multiplier.CertaintyReductionOpinion(maxOpinion),
				multiplier: ref Settings.Values.CertaintyReductionOpinionMultiplier);

			// >Conversion attempt chance multiplier by opinion.
			AddMultiplierSetting(listing,
				label: "SP_ConversionAttemptChanceMultiplierLabel",
				descr: "SP_ConversionAttemptChanceMultiplierDescr",
				descrValue: Multiplier.ConversionAttemptChance(maxOpinion),
				multiplier: ref Settings.Values.ConversionAttemptChanceMultiplier);

			// Reset settings button.
			Rect buttonsRect = listing.GetRect(GenUI.ListSpacing);
			float buttonWidth = buttonsRect.width / 5.0F;
			Rect resetRect = new Rect(buttonsRect.width - buttonWidth, buttonsRect.y, buttonWidth, buttonsRect.height);
			if (Widgets.ButtonText(resetRect, "SP_ResetSettingsLabel".Translate()))
			{
				Settings.Reset();
			}
			TooltipHandler.TipRegion(resetRect, "SP_ResetSettingsHover".Translate());

			listing.End();
		}

		private static void AddMultiplierSetting(Listing_Standard listing, string label, string descr, float descrValue,
			ref float multiplier)
		{
			const float minRawMultiplier = 0.0F;
			const float maxRawMultiplier = 9.0F;

			Text.Font = GameFont.Small;
			listing.Label(label.Translate());
			listing.Gap(GenUI.GapTiny);

			Text.Font = GameFont.Tiny;
			string initialDescription = descr.Translate(descrValue.ToStringPercent());
			string postfix = "SP_PostfixDescr".Translate();
			listing.Label($"{initialDescription} {postfix}");
			listing.Gap(GenUI.GapSmall);

			Rect labelRect = listing.GetRect(GenUI.GapWide);
			Text.Anchor = TextAnchor.MiddleCenter;
			Text.Font = GameFont.Tiny;
			GUI.color = Color.grey;
			Widgets.Label(labelRect, "SP_SliderMultiplierDescr".Translate(descrValue.ToString("0.##")));
			GUI.color = Color.white;
			Text.Anchor = TextAnchor.UpperLeft;
			Text.Font = GameFont.Small;

			Rect sliderRect = listing.GetRect(GenUI.GapWide);
			multiplier = Widgets.HorizontalSlider_NewTemp(sliderRect, multiplier, minRawMultiplier, maxRawMultiplier);

			listing.Gap(GenUI.Gap);
		}
	}
}