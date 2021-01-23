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
		Console.WriteLine( $"Die Primfaktoren von {number} sind: {factorList} ! Es ist also {(factors.Count() == 2 ? "eine" : "keine")} Primzahl!" );
	}
	#endregion

	#region private helpermethods

	private IEnumerable<(uint factor, byte amount)> GetPrimeFactors( uint number ) {
		var num = number;
		var factors = new Dictionary<uint, byte> { { 1, 1 } };
		for( uint n = 2; n <= num; n++ )
			while( num % n == 0 ) {
				num /= n;
				if( factors.ContainsKey( n ) ) {
					factors[n]++;
					continue;
				}
				else
					factors.Add( n, 1 );
			}
		if( factors.ContainsKey( number ) is false )
			factors.Add( number, 1 );
		return factors.OrderBy( kvp => kvp.Key ).Select( kvp => (kvp.Key, kvp.Value) );
	}
	#endregion

}