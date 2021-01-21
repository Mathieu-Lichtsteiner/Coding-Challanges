using RandomApps;
using System;

internal class RectanglePrinter : Executeable {

	#region private fields
	private int _Height;
	private int _Width;
	private char _Sign;
	#endregion

	#region Executeable
	protected override void Execute() {
		for( int i = 0; i < _Height; i++ )
			for( int j = 0; j < _Width; j++ )
				Console.Write(
					((i == 0 || i == _Height - 1) || (j == 0 || j == _Width - 1)) ?
					(j == _Width - 1 ? _Sign + "\n" : _Sign) : " " );
	}
	protected override void GetParameters() {
		_Width = GetParameter<int>( "Bitte die Länge angeben: " );
		_Height = GetParameter<int>( "Bitte die Höhe angeben: " );
		_Sign = GetParameter<char>( "Bitte ein Symbol eingeben: " );
	}
	#endregion

}