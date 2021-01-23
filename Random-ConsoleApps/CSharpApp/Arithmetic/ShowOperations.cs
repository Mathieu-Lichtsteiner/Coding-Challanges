using RandomApps;
using System;

internal class ShowOperations : Executeable {

	#region Executeable
	public override string Description => "Dieses Programm führt diverse Operationen mit 2 Zahlen durch!";
	public override ChallengeSource? Source => ChallengeSource.CSharpApp;
	protected override void Execute() {
		int number1 = GetParameter<int>( "Bitte die erste Zahl eingeben: ", (n => Equals( n, 0 ), "Bitte eine gültige Zahl eingeben! {n E Z/, n != 0}") );
		int number2 = GetParameter<int>( "Bitte die zweite Zahl eingeben: ", (n => Equals( n, 0 ), "Bitte eine gültige Zahl eingeben! {n E Z/, n != 0}") );

		Console.WriteLine( $"Summe:		{number1} + {number2} = {number1 + number2}" );
		Console.WriteLine( $"Differenz:	{number1} - {number2} = {number1 - number2}" );
		Console.WriteLine( $"Produkt:		{number1} * {number2} = {number1 * number2}" );
		Console.WriteLine( $"Quotient:		{number1} / {number2} = {(double)number1 / number2}" );
		Console.WriteLine( $"Rest:			{number1} / {number2} = {number1 & number2}" );
		Console.WriteLine( $"Exponent:		{number1} ^ {number2} = {Math.Pow( number1, number2 )}" );
		Console.WriteLine( $"Wurzel:		{number1} ^ 1/{number2} = {(double)Math.Pow( number1, 1.0 / number2 )}" );
	}
	#endregion

}