using RandomApps;
using System;
using System.Text;

internal class IntToHexAndBinary : Executeable {

	#region Executeable
	public override string Description => "Wandelt die eingegeben Zahl in Binär und Hexadecimal um.";
	public override ChallengeSource? Source => ChallengeSource.CSharpApp;
	protected override void Execute() {
		uint number = GetParameter<uint>( "Bitte eine Zahl eingeben: " );
		Console.WriteLine( $"Die Zahl {number} lautet in Binär: {ToBinary( number )} und in Hexadecimal: {ToHexadecimal( number )}" );
	}
	#endregion

	#region private helpermethods
	private string ToBinary( uint number ) {
		StringBuilder output = new StringBuilder();
		while( number > 0 ) {
			output.Insert( 0, (number % 2 == 0) ? '0' : '1' );
			number /= 2;
		}
		return output.ToString();
	}
	//=> ConvertBase( number, 2 );
	private string ToHexadecimal( uint number ) {
		char[] hex = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
		StringBuilder output = new StringBuilder();
		while( number > 0 ) {
			output.Insert( 0, hex[number % 16] );
			number /= 16;
		}
		return output.ToString();
	}
	//=> ConvertBase( number, 16, new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' } );
	private string ConvertBase( uint number, uint newBase, char[]? digitTable = null ) {
		if( newBase > 10 && digitTable is null )
			throw new ArgumentNullException( nameof( digitTable ), "if the base is bigger than 10, you have to define a digitTable" );
		else if( newBase > digitTable?.Length )
			throw new ArgumentException( nameof( digitTable ), "you must provide a char for every digit" );
		else if( digitTable is null )
			digitTable = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

		StringBuilder output = new StringBuilder();
		while( number > 0 ) {
			output.Insert( 0, digitTable[number % newBase] );
			number /= newBase;
		}
		return output.ToString();
	}
	#endregion

}