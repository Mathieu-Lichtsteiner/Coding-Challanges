using RandomApps;
using System;

internal class NumberPyramid : Executeable {

	#region Executeable
	protected override void Execute() {
		int input = GetParameter<int>( "Bitte geben sie die Anzahl Stufen ein: ", (n => n > 63, "Achtung zu grosse Zahl! (max.63)") );

		for( int stufen = 0; stufen <= input; ++stufen ) {
			int tester = 0;
			for( int leer = input - stufen; leer >= 0; --leer ) {
				if( input >= 10 ) {
					if( input % 10 >= 0 && tester - 1 <= ((input % 10) + ((input / 10) - 1) * 10) ) {
						Console.Write( "  " );
						tester++;
					}
					else if( input % 10 == 0 && tester - 1 <= input - 10 ) {
						Console.Write( "  " );
						tester++;
					}
					else
						Console.Write( " " );
				}
				else
					Console.Write( " " );
			}
			for( int zahl = -stufen; zahl <= stufen; ++zahl )
				Console.Write( Math.Abs( zahl ) );
			Console.Write( "\n" );
		}
		Console.Write( "\n" );
	}
	#endregion

}