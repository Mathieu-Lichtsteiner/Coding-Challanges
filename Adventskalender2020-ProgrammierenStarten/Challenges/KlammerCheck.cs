using Adventskalender2020;
using System;

internal class KlammerCheck : IChallenge {

	private string _Ausdruck;
	public KlammerCheck( string ausdruck )
		=> _Ausdruck = ausdruck;

	public string Run()
		=> CheckKlammerpare( _Ausdruck );
	private string CheckKlammerpare( string ausdruck ) {
		var ret = $"der Ausdruck { ausdruck} ";
		int aktuell = 0;
		foreach( char c in ausdruck )
			aktuell += Equals( c, ')' ) ? -1 : Equals( c, '(' ) ? 1 : 0;
		if( Equals( aktuell, 0 ) )
			return ret + "hat die richtige anzahl Klammerpaare!";
		return ret + $"hat {Math.Abs( aktuell )} " + (aktuell > 0 ? "öffnende \'(\'" : "schliessende \')\'") + " Klammer" + (Math.Abs( aktuell ) > 1 ? "n " : " ") + "zuviel";
	}
}