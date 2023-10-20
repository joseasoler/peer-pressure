using HarmonyLib;
using RimWorld;
using Verse;

namespace PeerPressure.Patches
{
	/// <summary>
	/// Convert ability tooltip data.
	/// </summary>
	[HarmonyPatch(typeof(CompAbilityEffect_Convert),
		nameof(CompAbilityEffect_Convert.ExtraLabelMouseAttachment))]
	internal static class CompAbilityEffect_Convert_ExtraLabelMouseAttachment_Patch
	{
		private static void Postfix(ref string __result, CompAbilityEffect_Convert __instance, LocalTargetInfo target)
		{
			Pawn recipient = target.Pawn;
			Pawn_RelationsTracker relations = recipient?.relations;

			if (relations == null || !__instance.Valid(target, false))
			{
				return;
			}

			Pawn initiator = __instance.parent.pawn;

			float multiplier = Multiplier.CertaintyReductionOpinion(relations.OpinionOf(initiator));
			if (multiplier > 0.0F)
			{
				__result += "\n -  " + "SP_OpinionOf".Translate(recipient.Named("PAWN1"), initiator.Named("PAWN2"),
					multiplier.ToStringPercent());
			}
		}
	}
}