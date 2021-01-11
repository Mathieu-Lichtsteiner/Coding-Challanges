using System;

internal class RectanglePrinter : IProgram {

	private int _Height;
	private int _Width;
	private char _Sign;

	public RectanglePrinter( int height, int width, char sign ) {
		_Height = height;
		_Width = width;
		_Sign = sign;
	}

	public void Run() {
		for( int i = 0; i < _Height; i++ )
			for( int j = 0; j < _Width; j++ )
				Console.Write(
					((i == 0 || i == _Height - 1) || (j == 0 || j == _Width - 1)) ?
					(j == _Width - 1 ? _Sign + "\n" : _Sign) : " " );
	}
}