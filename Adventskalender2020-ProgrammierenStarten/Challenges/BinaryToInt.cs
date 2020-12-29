using System;

namespace Adventskalender2020 {
	internal class BinaryToInt : IChallenge {

		private string _Param;
		public BinaryToInt( string param )
			=> _Param = param;

		public string Run()
			=> Convert( _Param ).ToString();
		//1100100
		private int Convert( string param )
			=> (int)(param[0] == '1' ? Math.Pow( 2, (param.Length - 1) ) : 0)
			+ (int)(param.Length > 1 ? Convert( param.Substring( 1 ) ) : 0);

	}
}
