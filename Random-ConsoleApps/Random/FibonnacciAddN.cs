using RandomApps;
using System;

internal class FibonnacciAddN : Executeable {

	#region Executeable
	public override string Description => "Gibt eine Fibonacci-Reihe aus, bei der eine definierte Anzahl von Elementen aufsummiert werden.";
	protected override void Execute() {
		uint a = GetParameter<uint>( "Bitte die Anzahl Stellen, die Summiert werden, eingeben: " );
		uint s = GetParameter<uint>( "Bitte die Anzahl Schritte eingeben: ",
			(n => n >= a, $"Es müssen mehr Schritte ausgegeben werden, als aufsummiert werden ({a})! ") );
		uint b = GetParameter<uint>( "Bitte die Basis angeben: ",
			(n => n != 0, "Die Basis wurde auf 0 gesetzt und würde in einer reihe von nullen resultieren!") );

		uint[] itterative = Itterative( s, b, a );
		uint[] recursive = Recursive( s, b, a );
		//TODO I could implement a Linq-Oneliner
		Console.WriteLine( $"Die Fibonacci-Reihe mit Basis {b} und {a} aufsummierten Elementen lautet:\n " +
			$"Itterativ: {string.Join( ", ", itterative )}\n " +
			$"Rekursiv:  {string.Join( ", ", recursive )}" );
	}
	#endregion

	#region private helper methods
	private uint[] Itterative( uint steps, uint @base, uint amount ) {
		var sequence = new uint[steps];

		for( int b = 0; b < amount; b++ )
			sequence[b] = @base;

		for( uint step = amount; step < steps; step++ ) {
			uint temp = 0;
			for( int n = 1; n <= amount; n++ )
				temp += sequence[step - n];
			sequence[step] = temp;
		}

		return sequence;
	}
	private uint[] Recursive( uint steps, uint @base, uint amount ) {
		uint[] sequence;

		if( steps == amount ) {
			sequence = new uint[steps];
			for( int b = 0; b < amount; b++ )
				sequence[b] = @base;
		}
		else {
			var sequenceR = Recursive( steps - 1, @base, amount );
			uint temp = 0;
			for( int n = 1; n <= amount; n++ )
				temp += sequenceR[(steps - 1) - n];
			sequence = new uint[steps];
			sequenceR.CopyTo( sequence, 0 );
			sequence[steps - 1] = temp;
		}
		return sequence;
	}
	#endregion

}