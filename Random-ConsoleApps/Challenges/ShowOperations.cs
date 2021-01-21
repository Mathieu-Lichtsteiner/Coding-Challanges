using RandomApps;
using System;

internal class ShowOperations : Executeable {

	#region private fields
	private int _Number1;
	private int _Number2;
	#endregion

	#region Executeable
	public override string Description
		=> "Dieses Programm führt diverse Operationen mit 2 Zahlen durch!";
	protected override void Execute() {
		Console.WriteLine( $"Summe:		{_Number1} + {_Number2} = {_Number1 + _Number2}" );
		Console.WriteLine( $"Differenz:	{_Number1} - {_Number2} = {_Number1 - _Number2}" );
		Console.WriteLine( $"Produkt:		{_Number1} * {_Number2} = {_Number1 * _Number2}" );
		Console.WriteLine( $"Quotient:		{_Number1} / {_Number2} = {(double)_Number1 / _Number2}" );
		Console.WriteLine( $"Rest:			{_Number1} / {_Number2} = {_Number1 & _Number2}" );
		Console.WriteLine( $"Exponent:		{_Number1} ^ {_Number2} = {Math.Pow( _Number1, _Number2 )}" );
		Console.WriteLine( $"Wurzel:		{_Number1} ^ 1/{_Number2} = {(double)Math.Pow( _Number1, 1.0 / _Number2 )}" );
	}
	protected override void GetParameters() {
		_Number1 = GetParameter<int>( "Bitte die erste Zahl eingeben: ", (n => Equals( n, 0 ), "Bitte eine gültige Zahl eingeben! {n E Z/, n != 0}") );
		_Number2 = GetParameter<int>( "Bitte die zweite Zahl eingeben: ", (n => Equals( n, 0 ), "Bitte eine gültige Zahl eingeben! {n E Z/, n != 0}") );
	}
	#endregion

}