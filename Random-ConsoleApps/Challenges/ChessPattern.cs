using RandomApps;
using System;

internal class ChessPattern : Executeable {

	#region private fields
	private char _Black;
	private char _White;
	private int _Size;
	#endregion

	#region Executeable
	protected override void Execute() {
		char now = _Black;
		for( int i = 0; i < _Size; i++ ) {
			now = now == _Black ? _Black : _White;
			for( int j = 0; j < _Size; j++ ) {
				now = now == _Black ? _White : _Black;
				Console.Write( now + " " );
			}
			Console.WriteLine();
		}
	}
	protected override void GetParameters() {
		_Size = GetParameter<int>( "Bitte die Grösse angeben: " );
		_Black = GetParameter<char>( "Bitte das erste Symbol angeben: " );
		_White = GetParameter<char>( "Bitte das zweite Symbol angeben: " );
	}
	#endregion
}