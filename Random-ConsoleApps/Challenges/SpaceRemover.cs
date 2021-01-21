using RandomApps;
using System;

internal class SpaceRemover : Executeable {

	#region private fields
	private string _Input;
	#endregion

	#region properties
	public override string Description
		=> "Dieses Programm fügt alle eingegebenen Strings zu einem Wort Zusammen.";
	#endregion

	#region Executeable
	protected override void Execute()
		=> Console.WriteLine( $"\t Die Eingegebenen wörter '{_Input}' \n\t lauten zusammengesetzt: '{ToWord( _Input )}'" );

	protected override void GetParameters() {
		_Input = GetParameter<string>( "Bitte geben Sie einige Wörter ein: " );
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