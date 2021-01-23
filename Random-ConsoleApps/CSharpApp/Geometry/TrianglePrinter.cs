using RandomApps;
using System;

internal class TrianglePrinter : Executeable {

	#region Executeable
	public override string Description
		=> "Zeigt ein Dreieck mit einem definierten Symbol und Dicke.";
	public override ChallengeSource? Source
		=> ChallengeSource.CSharpApp;
	protected override void Execute() {
		char sign = GetParameter<char>( "Bitte geben Sie das Symbol ein: " );
		int size = GetParameter<int>( "Bitte geben Sie die Grösse ein: " );
		bool side = GetParameter<bool>( "Soll das Dreieck nach rechts ausgereichtet sein?: " );

		if( side ) {
			for( int height = size; height > 0; height-- ) {
				for( int offset = 0; offset < size - height; offset++ )
					Console.Write( "  " );
				for( int width = 0; width < height; width++ )
					Console.Write( $"{sign} " );
				Console.WriteLine();
			}
		}
		else {
			for( int height = size; height > 0; height-- ) {
				for( int width = 0; width < height; width++ )
					Console.Write( $"{sign} " );
				Console.WriteLine();
			}
		}

	}
	#endregion
}