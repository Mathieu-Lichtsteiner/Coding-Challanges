using System;
using System.Linq;

internal class ShowOperations : IProgram {
	public void Run() {
		int num1, num2;
		Console.WriteLine( "Willkommen bei dem Programm, dass alle möglichen operationen mit 2 Zahlen durchführt! \nBitte geben sie zwei Zahlen ein!" );
		do {
			Console.Write( "Nummer 1: " );
			while( !int.TryParse( Console.ReadLine(), out num1 ) || num1 == 0 ) {
				Gültig();
			}
			Console.Write( "Nummer 2: " );
			while( !int.TryParse( Console.ReadLine(), out num2 ) || num2 == 0 ) {
				Gültig();
			}

			Outputs( num1, num2 );
			Console.Write( "Soll der Kehrwert berechnet werden? [j / n]: " );
			if( Ja() ) {
				Outputs( num2, num1 );
			}

			Console.Write( "Wollen sie neue Zahlen eingeben? [j / n]: " );
		} while( Ja() );
	}

	private void Outputs( int num1, int num2 ) {
		Console.WriteLine( "Summe:		{0} + {1} = {2}", num1, num2, num1 + num2 );
		Console.WriteLine( "Differenz:	{0} - {1} = {2}", num1, num2, num1 - num2 );
		Console.WriteLine( "Produkt:	{0} * {1} = {2}", num1, num2, num1 * num2 );
		Console.WriteLine( "Quotient:	{0} / {1} = {2}", num1, num2, (double)num1 / num2 );
		Console.WriteLine( "Rest:		{0} / {1} = {2}", num1, num2, num1 & num2 );
		Console.WriteLine( "Exponent:	{0} ^ {1} = {2}", num1, num2, Math.Pow( num1, num2 ) );
		Console.WriteLine( "Wurzel:		{0} ^ 1/{1} = {2}", num1, num2, (double)Math.Pow( num1, 1.0 / num2 ) );
	}

	private void Gültig() {
		Console.WriteLine( "Bitte eine gültige Zahl eingeben! {n E Z/, n != 0}" );
	}

	private bool Ja() =>
		(new string[] { "ja", "j", "yes", "y", "yeah", "oui", "ouais", "si" }).Contains( Console.ReadLine().ToLower() );

}