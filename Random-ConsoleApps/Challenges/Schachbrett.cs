using System;

internal class Schachbrett : IProgram {
	public void Run() {
		int size;
		do
			Console.Write( "Bitte die Grösse angeben: " );
		while( int.TryParse( Console.ReadLine(), out size ) is false );
		Console.Write( "Bitte das erste Symbol angeben: " );
		var x = Console.ReadKey( false ).KeyChar;
		Console.WriteLine();
		Console.Write( "Bitte das zweite Symbol angeben: " );
		var y = Console.ReadKey( false ).KeyChar;
		Console.WriteLine();
		Print( size, x, y );
	}
	private void Print( int anzahl = 8, char black = 'X', char white = 'O' ) {
		char now = black;
		for( int i = 0; i < anzahl; i++ ) {
			now = now == black ? black : white;
			for( int j = 0; j < anzahl; j++ ) {
				now = now == black ? white : black;
				Console.Write( now + " " );
			}
			Console.WriteLine();
		}
	}
}