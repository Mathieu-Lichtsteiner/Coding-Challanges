using RandomApps;
using System;

internal class ChessPattern : Executeable {

	#region Executeable
	protected override void Execute() {
		int size = GetParameter<int>( "Bitte die Grösse angeben: " );
		char black = GetParameter<char>( "Bitte das erste Symbol angeben: " );
		char white = GetParameter<char>( "Bitte das zweite Symbol angeben: " );
		bool now = false;

		for( int i = 0; i < size; i++ ) {
			if( size % 2 == 0 )
				now = !now;
			for( int j = 0; j < size; j++ ) {
				now = !now;
				Console.Write( (now ? black : white) + " " );
			}
			Console.WriteLine();
		}
	}
	#endregion

}