using RandomApps;
using System;

internal class Fibonnacci : Executeable {

	#region Executeable
	public override string Description => "Gibt eine variable anzahl von stellen der Fibonnacci-Sequenz aus.";
	protected override void Execute() {
		uint amount = GetParameter<uint>( "Wieviele Zahlen sollen ausgegeben werden? ",
			(n => n >= 3, "Es müssen mindestens 3 Zahlen ausgegeben werden! ") );

		uint[] sequence = new uint[amount];
		sequence[0] = 1;
		sequence[1] = 1;

		for( int i = 2; i < amount; i++ )
			sequence[i] = sequence[i - 1] + sequence[i - 2];

		Console.WriteLine( string.Join( ", ", sequence ) );
	}
	#endregion

}