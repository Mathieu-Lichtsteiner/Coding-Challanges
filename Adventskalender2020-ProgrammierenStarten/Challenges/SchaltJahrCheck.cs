using Adventskalender2020;
using System;

internal class SchaltJahrCheck : IChallenge {

	private DateTime _Date;
	public SchaltJahrCheck( DateTime date )
		=> _Date = date;

	public string Run() {
		var offset = 200;
		var test = 0;
		for( int i = offset + 1; i <= offset + 400; i++ )
			if( IsLeapYear( new DateTime( i, 1, 1 ) ) )
				test++;
		return Equals( test, 97 ) ? "Funktioniert" : "Funktioniert nicht" + $" und das Datum {_Date} " + (IsLeapYear( _Date ) ? "ist " : "ist nicht ") + "in einem Schaltjahr!";
	}
	private bool IsLeapYear( DateTime date )
		=> (Equals( date.Year % 4, 0 ) && Equals( date.Year % 100, 0 ) is false) || Equals( date.Year % 400, 0 );
}