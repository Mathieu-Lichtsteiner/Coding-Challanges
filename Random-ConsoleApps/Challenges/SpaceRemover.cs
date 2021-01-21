using RandomApps;
using System;

internal class SpaceRemover : Executeable {

	#region Executeable
	public override string Description
		=> "Dieses Programm fügt alle eingegebenen Strings zu einem Wort Zusammen.";
	protected override void Execute() {
		string input = GetParameter<string>( "Bitte geben Sie einige Wörter ein: " );
		string connected = ToWord( input );

		Console.WriteLine( $"\t Die Eingegebenen wörter '{input}' \n\t lauten zusammengesetzt: '{connected}'" );
	}
	#endregion

	#region private helpermethods
	private string ToWord( string input ) {
		while( input.Contains( ' ' ) ) {
			string[] words = input.Split( ' ' );
			input = "";
			foreach( string item in words )
				input += item;
		}
		return input;
	}
	#endregion

}