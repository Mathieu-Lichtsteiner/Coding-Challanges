using Adventskalender2020;
using System.Collections.Generic;
using System.Linq;

internal class PlaindromCheck : IChallenge {
	private string _Wort;
	public PlaindromCheck( string wort )
		=> _Wort = wort.ToLower();

	public string Run() {
		var p = IsPalindrome( _Wort );
		var ret = $"Wort \"{_Wort}\" " + (p ? "ist ein " : "ist kein ") + "Palindrom";
		if( p is false && AlmostPalindrome( _Wort ).Count == 2 )
			ret += $", aber wenn {AlmostPalindrome( _Wort )[0]} ersetzt wird, stimmt es";
		return ret;
	}
	private bool IsPalindrome( string wort )
		=> Equals( wort, Inverse( wort ) );

	// Rxliefpfeilyr gibt true zurück, BUGG!!
	private List<(char, char)> AlmostPalindrome( string wort ) {
		var diffs = new List<(char, char)>();
		var inv = Inverse( wort );
		for( int i = 0; i < wort.Length; i++ )
			if( wort[i] != inv[i] )
				diffs.Add( (wort[i], inv[i]) );
		return diffs;
	}
	private string Inverse( string wort )
		=> wort.Aggregate( string.Empty, ( ret, val ) => ret = val + ret );
}