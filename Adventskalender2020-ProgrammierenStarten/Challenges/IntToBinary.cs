namespace Adventskalender2020 {
	internal class IntToBinary : IChallenge {

		private int _Param;
		public IntToBinary( int param )
			=> _Param = param;

		public string Run()
			=> Convert( _Param ).TrimStart( '0' );
		private string Convert( int param )
			=> param > 0 ? (Convert( param / 2 ) + param % 2) : "0";

	}
}
