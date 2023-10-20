namespace PeerPressure
{
	/// <summary>
	/// Utility class for calculating the certainty reduction multiplied caused by opinion.
	/// </summary>
	public static class Multiplier
	{
		private static float Calculate(int opinion, float rawMultiplier)
		{
			return opinion switch
			{
				// Scale linearly between the chosen raw multiplier at opinion 100, and 1x at opinion 0.
				> 0 => 1F + 0.01F * opinion * rawMultiplier,
				// At opinion 0 or less, there is no change. 
				<= 0 => 1F
			};
		}

		/// <summary>
		/// Positive opinions multiply certainty reduction. At 0, there is no change. At 100, it is the value chosen
		/// in the settings by the player. Intermediate multiplier values are scaled linearly with opinion.
		/// </summary>
		/// <param name="opinion">Current opinion of the proselytizer held by the convertee.</param>
		/// <returns>Final certainty reduction opinion multiplier.</returns>
		public static float CertaintyReductionOpinion(int opinion)
		{
			return Calculate(opinion, Settings.Values.CertaintyReductionOpinionMultiplier);
		}

		/// <summary>
		/// Positive opinions multiply conversion attempt chances. At 0, there is no change. At 100, it is the value chosen
		/// in the settings by the player. Intermediate multiplier values are scaled linearly with opinion.
		/// </summary>
		/// <param name="opinion">Current opinion of the proselytizer held by the convertee.</param>
		/// <returns>Final certainty reduction opinion multiplier.</returns>
		public static float ConversionAttemptChance(int opinion)
		{
			return Calculate(opinion, Settings.Values.ConversionAttemptChanceMultiplier);
		}
	}
}