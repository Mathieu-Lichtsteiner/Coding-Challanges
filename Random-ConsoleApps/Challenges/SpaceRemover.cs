using System;

internal class SpaceRemover : IProgram {
	public void Run() {
		string input;
		Console.WriteLine( "\t Willkommen beim Wörter-connector! \n\t Dieses Programm fügt alle eingegebenen Strings zu einem Wort Zusammen. \n\t Bitte gebe einige Wörter ein: " );
		do {
			Console.Write( "\t  " );
			input = Console.ReadLine();
			Console.WriteLine( "\t Die Eingegebenen wörter \n\t  '{0}' \n\t lauten zusammengesetzt: \n\t  '{1}', \n\t möchten Sie wiederholen? ", input, ToWord( input ) );

		} while( input.ToLower() != "n" );
	}
	private string ToWord( string input ) {
		string output = null;
		string[] words = input.Split( ' ' );
		foreach( string item in words )
			output += item;
		return output;
	}
}