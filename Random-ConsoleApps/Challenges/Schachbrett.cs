using System;

internal class Schachbrett : IProgram {
	public void Run() {
		int size;
		do {
			Console.Write( "Bitte die Grösse angeben: " );
		}
		while( int.TryParse( Console.ReadLine(), out size ) );
		Console.Write( "Bitte das erste Symbol angeben: " );
		var x = Console.ReadKey( false ).KeyChar;
		Console.Write( "Bitte das zweite Symbol angeben: " );
		var y = Console.ReadKey( false ).KeyChar;
		Print( size, x, y );
	}
	private void Print( int anzahl = 8, char black = 'X', char white = 'O' ) {
		char start = black;
		for( int i = 0; i < anzahl; i++ ) {
			start = start == black ? white : black;
			for( int j = 0; j < anzahl; j++ ) {
				start = start == black ? white : black;
				Console.Write( start + " " );
			}
			Console.WriteLine();
		}
	}
}