using RandomApps;
using System;

internal class WordPyramid : Executeable {

	#region Executeable
	public override string Description => "Zeigt ein Wort stufenweise an, also von der mitte nach aussen. ";
	public override ChallengeSource? Source => ChallengeSource.CSharpApp;
	protected override void Execute() {
		string word = GetParameter<string>( "Bitte geben Sie ein wort ein: " );
		int half = (word.Length - 1) / 2;

		for( int row = 0; row <= half; row++ ) {
			for( int space = 0; space < half - row; space++ )
				Console.Write( " " );
			for( int chars = half - row; chars <= (word.Length / 2) + row; chars++ )
				Console.Write( word[chars] );
			Console.WriteLine();
		}
	}
	#endregion

}