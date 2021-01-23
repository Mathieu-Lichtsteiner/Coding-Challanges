using RandomApps;
using System;
using System.Linq;

internal class DescribeCharacter : Executeable {

	#region Executeable
	public override string Description => "Bestimmt die Art eines Zeichens.";
	public override ChallengeSource? Source => ChallengeSource.CSharpApp;
	protected override void Execute() {
		char character = GetParameter<char>( "Bitte geben Sie ein Zeichen ein: " );
		char[] vokalen = new[] { 'a', 'e', 'i', 'o', 'u' };
		char[] konsonanten = new[] { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };
		char[] zahlen = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
		char[] sonderzeichen = new[] { '.', ',', ':', ';', '-', '+', '*', '/', '\\', '@', '!', '?', '\'', '^', '~', ' ', '#' };
		char zeichen = character.ToString().ToLower()[0];
		string typ =
			(character != zeichen) ? ("ein grosser " + (vokalen.Contains( zeichen ) ? "Vokal" : konsonanten.Contains( zeichen ) ? "Konsonant" : "Buchstabe")) :
			vokalen.Contains( character ) ? "ein kleiner Vokal" : konsonanten.Contains( character ) ? "ein kleiner Konsonant" :
			zahlen.Contains( character ) ? "eine Zahl" :
			sonderzeichen.Contains( character ) ? "ein Sonderzeichen" :
			"etwas anderes";
		Console.WriteLine( $"Das Zeichen '{character}' ist {typ}!" );
	}
	#endregion

}