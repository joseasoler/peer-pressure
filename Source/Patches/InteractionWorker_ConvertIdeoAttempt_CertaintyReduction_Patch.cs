using HarmonyLib;
using RimWorld;
using Verse;

namespace PeerPressure.Patches
{
	/// <summary>
	/// Implementation of the "Certainty reduction multiplier by opinion" setting.
	/// </summary>
	[HarmonyPatch(typeof(InteractionWorker_ConvertIdeoAttempt),
		nameof(InteractionWorker_ConvertIdeoAttempt.CertaintyReduction))]
	internal static class InteractionWorker_ConvertIdeoAttempt_CertaintyReduction_Patch
	{
		private static void Postfix(ref float __result, Pawn initiator, Pawn recipient)
		{
			Pawn_RelationsTracker relations = recipient.relations;
			if (relations != null)
			{
				__result *= Multiplier.CertaintyReductionOpinion(relations.OpinionOf(initiator));
			}
		}
	}
}