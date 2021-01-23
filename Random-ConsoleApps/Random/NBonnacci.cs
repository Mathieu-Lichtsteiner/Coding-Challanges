using RandomApps;
using System;
using System.Linq;

internal class NBonnacci : Executeable {

	#region Executeable
	public override string Description => "In diesem Programm werden gewünscht viele Zahlen einer Fibonacci Reihe ausgegeben, wobei die erste Zahl (Basis) angegeben werden kann!";
	protected override void Execute() {
		uint s = GetParameter<uint>( "Bitte die Anzahl Schritte eingeben: ",
			(n => n >= 3, "Es müssen mindestens drei Schritte ausgegeben werden! ") );
		uint b = GetParameter<uint>( "Bitte die Basis angeben: ",
			(n => n != 0, "Die Basis wurde auf 0 gesetzt und würde in einer reihe von nullen resultieren!") );

		uint[] itterative = Itterative( s, b );
		uint[] recursive = Recursive( s, b );
		//TODO I could implement a Linq-Oneliner
		Console.WriteLine( $"Die Fibonacci-Reihe mit Basis {b} lautet:\n " +
			$"Itterativ: {string.Join( ", ", itterative )}\n " +
			$"Rekursiv:  {string.Join( ", ", recursive )}" );
	}
	#endregion

	#region private helper methods
	private uint[] Itterative( uint steps, uint @base ) {
		var sequence = new uint[steps];
		sequence[0] = @base;
		sequence[1] = @base;

		for( int i = 2; i < steps; i++ )
			sequence[i] = sequence[i - 1] + sequence[i - 2];

		return sequence;
	}
	private uint[] Recursive( uint steps, uint @base ) {
		if( steps == 2 )
			return new[] { @base, @base };
		var prev = Recursive( steps - 1, @base );
		return prev.Append( prev[steps - 2] + prev[steps - 3] ).ToArray();
	}
	#endregion

}