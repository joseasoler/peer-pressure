using HarmonyLib;
using RimWorld;
using Verse;

namespace PeerPressure.Patches
{
	/// <summary>
	/// Implementation of the "Conversion attempt chance multiplier by opinion" setting.
	/// </summary>
	[HarmonyPatch(typeof(InteractionWorker_ConvertIdeoAttempt), "ConversionSelectionFactor")]
	public class InteractionWorker_ConvertIdeoAttempt_ConversionSelectionFactor_Patch
	{
		private static void Postfix(ref float __result, Pawn initiator, Pawn recipient)
		{
			Pawn_RelationsTracker relations = recipient.relations;
			if (relations != null)
			{
				__result *= Multiplier.ConversionAttemptChance(relations.OpinionOf(initiator));
			}
		}
	}
}