using System;

internal class ZahlenPyramide : IProgram {
	public void Run() {
		Console.WriteLine( "Willkommen bei der Zahlenpyramide" );
		Console.Write( "Bitte bestätige mit Y/N: " );
		string wiederholen = Console.ReadLine().ToUpper();
		bool anyway = false;
		int stufen = 0;
		while( wiederholen == "Y" || anyway ) {
			if( anyway is false ) {
				Console.Write( "Bitte geben sie die Anzahl Stufen ein: " );
				do
					Console.Write( "Bitte eine Zahl eingeben!: " );
				while( int.TryParse( Console.ReadLine(), out stufen ) is false );
				Zahlenpyramide( stufen );
			}
			else {
				Zahlenpyramide( stufen );
				anyway = false;
			}
			Console.Write( "Eine neue Pyramide generieren? Y/N: " );
			string help = Console.ReadLine();
			anyway = Int32.TryParse( help, out stufen );
			if( !anyway )
				wiederholen = help.ToUpper();
		}
	}

	private void Zahlenpyramide( int input ) {
		if( input > 63 ) {
			Console.WriteLine( "Achtung zu grosse Zahl! (max.63)" );
			return;
		}
		Console.Write( "\n" );
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
}