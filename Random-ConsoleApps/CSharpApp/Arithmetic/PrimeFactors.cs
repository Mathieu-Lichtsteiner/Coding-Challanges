using RandomApps;
using System;
using System.Collections.Generic;
using System.Linq;

internal class PrimeFactors : Executeable {

	#region Executeable
	public override string Description => "Gibt alle Primfaktoren einer Zahl aus oder bestimmt ob es eine Primzahl ist. ";
	public override ChallengeSource? Source => ChallengeSource.CSharpApp;
	protected override void Execute() {
		uint number = GetParameter<uint>( "Bitte eine Zahl eingeben: " );
		var factors = GetPrimeFactors( number );
		var exponentNotation = factors.Select( pair => (pair.amount > 1 ? $"{pair.factor}^{pair.amount}" : $"{pair.factor}") );
		var factorList = string.Join( ", ", exponentNotation );
		Console.WriteLine( $"Die Primfaktoren von {number} sind: {factorList} !" );
	}
	#endregion

	#region private helpermethods

	private List<(uint factor, byte amount)> GetPrimeFactors( uint number ) {
		return new List<(uint, byte)>();
	}
	#endregion
}