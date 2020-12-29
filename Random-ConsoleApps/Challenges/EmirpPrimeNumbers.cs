using System;
using System.Linq;

internal class EmirpPrimeNumbers : IProgram {
	public void Run() {
		string input = null;
		bool prime, emirp;
		Console.WriteLine( "\t Willkommen beim Primzahlen-Checker! \n\t Dieses Programm testet, ob die eingegebene Zahl eine Primzahl ist. \n\t Ausserdem wird der Kehrwert geprüft. \n\t Bitte gebe die zu untersuchende Zahl ein: " );
		do {
			if( int.TryParse( input, out int zahl ) is false )
				Console.WriteLine( "\t Bitte eine positive, ganze Zahl eingeben!" );
			else {
				prime = IsPrime( zahl );
				emirp = IsEmirp( zahl );
				Console.Write( "\n {0}: ist {1} Primzahl und ist umgekehrt {2} Primzahl.| Neue Zahl: ", zahl, prime ? "eine" : "keine", emirp ? "eine" : "keine" );
			}
			input = Console.ReadLine();
		} while( input.ToLower() != "close" );
	}
	private bool IsEmirp( int number )
		=> IsPrime( Mirrored( number ) );
	private bool IsPrime( int number ) {
		for( int i = 2; i <= Math.Sqrt( number ); i++ )
			if( number % i == 0 )
				return false;
		return true;
	}
	private int Mirrored( int number )
		=> ArrayToInt( IntToArray( number ).Reverse().ToArray() );
	private int ArrayToInt( int[] array )
		=> int.Parse( string.Join( "", array ) );
	private int[] IntToArray( int number ) {
		string number_string = number.ToString();
		int[] intArray = new int[number_string.Length];
		for( int i = 0; i < number_string.Length; i++ )
			intArray[i] = int.Parse( string.Format( "{0}", number_string[i] ) );
		return intArray;
	}

}