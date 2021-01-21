using RandomApps;
using System;
using System.Linq;

internal class EmirpPrimeNumbers : Executeable {

	#region Executeable
	public override string Description
		=> "Dieses Programm testet, ob die eingegebene Zahl eine Primzahl ist. Ausserdem wird der Kehrwert auch darauf geprüft.";
	protected override void Execute() {
		int number = GetParameter<int>( "Bitte eine positive, ganze Zahl eingeben!" );
		int mirrored = int.Parse( number.ToString().ToArray().Reverse().Aggregate( string.Empty, ( str, c ) => str += c ) );

		Console.Write( $"\n {number}: ist {(IsPrime( number ) ? "eine" : "keine")} Primzahl " +
			$"und umgekehrt ({mirrored}) ist {(IsPrime( mirrored ) ? "eine" : "keine")} Primzahl." );
	}
	#endregion

	#region private helpermethods
	private bool IsPrime( int number ) {
		for( int i = 2; i <= Math.Sqrt( number ); i++ )
			if( number % i == 0 )
				return false;
		return true;
	}
	#endregion

}