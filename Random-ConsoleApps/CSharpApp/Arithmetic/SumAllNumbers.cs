using RandomApps;
using System;
using System.Collections.Generic;
using System.Linq;

internal class SumAllNumbers : Executeable {

	#region Executeable
	public override string Description => "Es wird die Summe von allen eingegeben Zahlen ausgegeben.";
	public override ChallengeSource? Source => ChallengeSource.CSharpApp;
	protected override void Execute() {
		var numberlist = new List<int>();
		int number;
		do {
			number = GetParameter<int>( "Bitte geben Sie eine Zahl ein: " );
			Console.WriteLine( $"{numberlist.Aggregate( string.Empty, ( str, n ) => str += $"+ {n}" )} = {numberlist.Sum()}" );

		} while( number != 0 );
	}
	#endregion

}