using Adventskalender2020;

internal class GrössterGemeinsamerTeiler : IChallenge {

	private int _A;
	private int _B;
	public GrössterGemeinsamerTeiler( int a, int b ) {
		_A = a;
		_B = b;
	}

	public string Run()
		=> $"A = {_A}, B = {_B}, ggT = {GetEuklidisch( _A, _B )}";


	private int GetEuklidisch( int a, int b ) {
		var min = a < b ? a : b;
		var max = a > b ? a : b;
		return
			min == 0
			? max
			: GetEuklidisch( min, max % min );
	}

	private int GetGGT( int a, int b ) {
		var ggT = 1;
		for( int t = 1; t <= (a < b ? a : b); t++ )
			if( a % t == 0 && b % t == 0 )
				ggT = t;
		return ggT;
	}
}