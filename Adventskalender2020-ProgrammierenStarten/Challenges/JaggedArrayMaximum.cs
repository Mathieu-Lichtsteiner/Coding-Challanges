using Adventskalender2020;
using System.Linq;

internal class JaggedArrayMaximum : IChallenge {

	private int[][] _JA;
	public JaggedArrayMaximum( int[][] jA )
		=> _JA = jA;

	public string Run()
		=> MaxInJaggedArray( _JA ).Aggregate( string.Empty, ( str, val ) => (str == "" ? "" : str + ",") + val );
	private int[] MaxInJaggedArray( int[][] jA )
		=> jA.Select( a => a.Max() ).ToArray();
}