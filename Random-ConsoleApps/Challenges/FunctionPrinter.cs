using System;
using System.Linq;

internal class FunctionPrinter : IProgram {
	public void Run() {
		double a, b, c, m;
		char[,] view;
		char modus;
		Console.WriteLine(
			"\t Willkommen beim Funktions-Drucker! " +
			"\n\t Dieses Programm plotet eine Funktion" +
			"\n\t entweder kann eine Lineare [L] oder eine Quadratische [Q] Funktion gedruckt werden" +
			"\n" );
		do {
			// den Modus bestimmen lassen
			do {
				Console.Write( "Bitte gebe den gewünschten Modus ein! [L / Q]: " );
				var input = Console.ReadLine().ToUpper().Trim();
				modus = input == string.Empty ? ' ' : input[0];
			} while( (modus == 'Q' || modus == 'L') == false );

			switch( modus ) {
				case 'Q':
					Console.WriteLine( "\t Bitte die nötigen variabeln für y = ax^2+bx+c eingeben!" );
					DoubleInput( out a, "a" );
					DoubleInput( out b, "b" );
					DoubleInput( out c, "c" );

					view = CalculateQuadratic( a, b, c, SizeInput() );
					Console.Clear();

					Console.WriteLine( $"y = {a}x^2 + {b}x + {c} :" );
					break;
				case 'L':
					Console.WriteLine( "\t Bitte die nötigen variabeln für y = mx+b eingeben!" );
					DoubleInput( out m, "m" );
					DoubleInput( out b, "b" );

					view = CalculateLinear( m, b, SizeInput() );
					Console.Clear();

					Console.WriteLine( $"y = {m}x + {b} :" );
					break;
				default:
					view = new char[,] {
						{' ', '|', ' ' },
						{'-', '+', '-' },
						{' ', '|', '-' }
					};
					break;
			}
			PrintView( view );
			Console.Write( "Soll eine neue Funktion geplottet werden? [J / N]: " );
		} while( Ja() );

	}

	#region Math-Methods
	private char[,] CalculateLinear( double m, double b, FieldDefinition size, char character = '*' ) {
		char[,] view = new char[size.GetWidth(), size.GetHeight()];
		int plottedX, plottedY;
		//y = mx+b
		for( int x = size.XStart; x < size.XEnd; x++ ) {
			int y = Runden( m * x + b );

			// wenn y zu gross für den graf ist, y nicht eintragen
			if( y < size.YStart || y > size.YEnd )
				continue;

			plottedX = size.IsXOnesided() ?
				(size.XStart > 0 ? (x + 1) - size.XStart : x + Math.Abs( size.XStart ))
				: x + Math.Abs( size.XStart );

			plottedY = size.IsYOnesided() ?
				(size.XStart > 0 ? (y + 1) - size.YStart : y + Math.Abs( size.YStart ))
				: y + Math.Abs( size.YStart );

			view[plottedX, plottedY] = character;
		}
		return view;
	}
	private char[,] CalculateQuadratic( double a, double b, double c, FieldDefinition size, char character = '*' ) {
		char[,] view = new char[size.GetWidth(), size.GetHeight()];

		return view;
	}
	private int Runden( double input )
		=> (int)Math.Round( input, 0, MidpointRounding.AwayFromZero );
	private void PrintView( char[,] view ) {
		// iterates over all rows (y) in the array, starting from the top
		for( int i = view.GetLength( 0 ) - 1; i >= 0; i-- ) {
			// iterates over all columns (x) of the selected row (i)
			for( int j = 0; j < view.GetLength( 1 ) - 1; j++ ) {

				// sets a char to the value in the view at the specified position
				char printed = view[i, j];
				// if it is empty sets the value to a dash ' ' to print correctly
				if( printed == new char() ) {
					printed = ' ';
				}

				// writes the char to the console
				Console.Write( $"{printed}" );
			}
			// new line after each row in the view is completed
			Console.Write( "\n" );
		}
	}
	#endregion

	#region Input-Methods

	private static void DoubleInput( out double output, string name ) {
		Console.Write( $"{name}: " );
		while( double.TryParse( Console.ReadLine(), out output ) == false ) {
			Console.WriteLine( @"Bitte eine gültige Zahl eingeben! {n E Q/}" );
			Console.Write( $"{name}: " );
		}
	}

	private static void IntInput( out int output, string name ) {
		Console.Write( $"{name}: " );
		while( !int.TryParse( Console.ReadLine(), out output ) ) {
			Console.WriteLine( @"Bitte eine gültige Zahl eingeben! {n E Z/}" );
			Console.Write( $"{name}: " );
		}
	}

	private static bool Ja() {
		string[] jaAntworten = { "ja", "j", "yes", "y", "yeah", "oui", "ouais", "si" };
		return jaAntworten.Contains( Console.ReadLine().ToLower().Trim() );
	}

	private static FieldDefinition SizeInput() {
		Console.Write( "Möchten Sie einen benutzerdefinierten Plotbereich? " +
			"\n[Standard = (-7,-7) bis (7,7)]" +
			"\n[J / N]: " );

		if( Ja() ) {
			int xStart, xEnd, yStart, yEnd;
			Console.WriteLine( "Bitte die gewünschte Grösse für den Plot angeben: " );
			IntInput( out xStart, "Startpunkt von x" );
			IntInput( out xEnd, "Endpunkt von x" );
			IntInput( out yStart, "Startpunkt von y" );
			IntInput( out yEnd, "Endpunkt von y" );

			return new FieldDefinition( xStart, xEnd, yStart, yEnd );
		}
		else {
			return new FieldDefinition( -7, 7, -7, 7 );
		}
	}

	#endregion

	#region FieldDefinition
	private struct FieldDefinition {
		public int XStart { get; set; }
		public int XEnd { get; set; }
		public int YStart { get; set; }
		public int YEnd { get; set; }
		public FieldDefinition( int xStart, int xEnd, int yStart, int yEnd ) {
			XStart = Math.Min( xStart, xEnd );
			XEnd = Math.Max( xStart, xEnd );
			YStart = Math.Min( yStart, yEnd );
			YEnd = Math.Max( yStart, yEnd );
		}
		public bool IsXOnesided()
			=> (XStart > 0 && XEnd > 0) || (XStart < 0 && XEnd < 0);
		public int GetWidth() {
			int width = Math.Abs( XStart ) + Math.Abs( XEnd );
			if( IsXOnesided() )
				width++;
			return width;
		}
		public bool IsYOnesided()
			=> (YStart > 0 && YEnd > 0) || (YStart < 0 && YEnd < 0);
		public int GetHeight() {
			int height = Math.Abs( YStart ) + Math.Abs( YEnd );
			if( IsYOnesided() )
				height++;
			return height;
		}
	}
	#endregion
}