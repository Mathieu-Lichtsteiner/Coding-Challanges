using RandomApps;
using System;

internal class RectanglePrinter : Executeable {

	#region Executeable
	public override string Description => "Zeichnet ein hohles Rechteck mit einer definierten Höhe, Breite und zeichen!";
	public override ChallengeSource? Source => ChallengeSource.CSharpApp;
	protected override void Execute() {
		int width = GetParameter<int>( "Bitte die Länge angeben: " );
		int height = GetParameter<int>( "Bitte die Höhe angeben: " );
		char sign = GetParameter<char>( "Bitte ein Symbol eingeben: " );

		for( int i = 0; i < height; i++ )
			for( int j = 0; j < width; j++ )
				Console.Write(
					((i == 0 || i == height - 1) || (j == 0 || j == width - 1)) ?
					(j == width - 1 ? sign + "\n" : sign) : " " );
	}
	#endregion

}