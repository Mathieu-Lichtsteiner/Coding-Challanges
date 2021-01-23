using RandomApps;
using System;
using System.Linq;

//TODO develop this
internal class FunctionPrinter : Executeable {

	#region Executeable
	public override string Description
		=> "Dieses Programm plotet eine Funktion";
	protected override void Execute() {
		char[,] view;
		double a, b, c, m;
		FieldDefinition fieldDef;

		if( GetParameter<bool>( "Möchten Sie einen benutzerdefinierten Plotbereich? (Standard: x = -7...7, y = -7...7 ): " ) ) {
			int xStart = GetParameter<int>( "Startpunkt von x: " );
			int xEnd = GetParameter<int>( "Endpunkt von x: " );
			int yStart = GetParameter<int>( "Startpunkt von y: " );
			int yEnd = GetParameter<int>( "Endpunkt von y: " );
			fieldDef = new FieldDefinition( xStart, xEnd, yStart, yEnd );
		}
		else
			fieldDef = new FieldDefinition( -7, 7, -7, 7 );

		string modus = GetParameter<string>( "Bitte geben Sie den gewünschten Modus ein! [L / Q]: ",
			(str => new[] { "quadratisch", "q", "linear", "l" }.Contains( str?.ToLower() ), "Bitte geben sie einen richtigen Modus ein! [L/Q]: ") ).ToLower();

		switch( modus ) {
			case "quadratisch" or "q":
				Console.WriteLine( "Bitte die nötigen variabeln für y = ax^2+bx+c eingeben!" );
				a = GetParameter<double>( @"Bitte eine gültige Zahl für a eingeben! {n E Q/} a: " );
				b = GetParameter<double>( @"Bitte eine gültige Zahl für b eingeben! {n E Q/} b: " );
				c = GetParameter<double>( @"Bitte eine gültige Zahl für c eingeben! {n E Q/} c: " );

				view = CalculateQuadratic( a, b, c, fieldDef );
				Console.Clear();
				Console.WriteLine( $"y = {a}x^2 + {b}x + {c} :" );
				break;
			case "linear" or "l":
				Console.WriteLine( "Bitte die nötigen variabeln für y = mx+b eingeben!" );
				m = GetParameter<double>( @"Bitte eine gültige Zahl für m eingeben! {n E Q/} m: " );
				b = GetParameter<double>( @"Bitte eine gültige Zahl für b eingeben! {n E Q/} b: " );

				view = CalculateLinear( m, b, fieldDef );
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
	}
	#endregion

	#region Math-Methods
	private char[,] CalculateLinear( double m, double b, FieldDefinition size, char character = '*' ) {
		char[,] view = new char[size.GetWidth(), size.GetHeight()];
		int plottedX, plottedY;
		//y = m*x+b
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
	#endregion

	#region Print-Method
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

	#region FieldDefinition
	private struct FieldDefinition {
		public int XStart { get; init; }
		public int XEnd { get; init; }
		public int SizeX => XEnd - YEnd;
		public int YStart { get; init; }
		public int YEnd { get; init; }
		public int SizeY => YEnd - YStart;
		public FieldDefinition( int xStart, int xEnd, int yStart, int yEnd ) {
			XStart = Math.Min( xStart, xEnd );
			XEnd = Math.Max( xStart, xEnd );
			YStart = Math.Min( yStart, yEnd );
			YEnd = Math.Max( yStart, yEnd );
		}

		// Maybe i dont need those anymore
		public bool IsXOnesided()
			=> (XStart >= 0 && XEnd > 0) || (XStart < 0 && XEnd <= 0);
		public int GetWidth() {
			int width = Math.Abs( XStart ) + Math.Abs( XEnd );
			if( IsXOnesided() )
				width++;
			return width;
		}
		public bool IsYOnesided()
			=> (YStart >= 0 && YEnd > 0) || (YStart < 0 && YEnd <= 0);
		public int GetHeight() {
			int height = Math.Abs( YStart ) + Math.Abs( YEnd );
			if( IsYOnesided() )
				height++;
			return height;
		}
	}
	#endregion

}