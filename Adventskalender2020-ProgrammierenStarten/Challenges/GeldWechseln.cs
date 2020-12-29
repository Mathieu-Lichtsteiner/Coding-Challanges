using System.Collections.Generic;
using System.Linq;

namespace Adventskalender2020 {
	internal class GeldWechseln : IChallenge {

		private decimal[] _Münzen = { 5M, 2M, 1M, 0.5M, 0.2M, 0.1M, 0.05M };
		private decimal _Param;
		public GeldWechseln( decimal param )
			=> _Param = param;

		public string Run() {
			var betrag = _Param;
			var ausgabe = new Dictionary<decimal, int>(
				_Münzen.Select( m => new KeyValuePair<decimal, int>( m, 0 ) ) );

			foreach( var münze in _Münzen )
				while( betrag / münze >= 1 ) {
					ausgabe[münze]++;
					betrag -= münze;
				}
			return ausgabe.Aggregate( string.Empty, ( val, münzPaar ) => val += $"{münzPaar.Value}x{münzPaar.Key}," );
		}

	}
}
