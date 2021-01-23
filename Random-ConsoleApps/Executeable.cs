using System;
using System.Linq;

namespace RandomApps {
	internal abstract class Executeable {

		#region protected fields
		private char[] _YesAwnsers = { 'y', 'Y', 'j', 'J' };
		#endregion

		#region abstract properties
		public virtual string Description { get; } = "";
		public virtual ChallengeSource? Source { get; } = null;
		#endregion

		#region public methods
		public void Run() {
			Console.WriteLine( $"\n Programm: {GetType().Name}!" );
			if( string.IsNullOrWhiteSpace( Description ) is false )
				Console.WriteLine( " " + Description );
			if( Source is ChallengeSource src )
				Console.WriteLine( $" (Source: {src.GetDescription()})" );

			Console.Write( "Would You like to run this program? [y/n]: " );
			while( _YesAwnsers.Contains( Console.ReadKey().KeyChar ) ) {
				Console.WriteLine();
				Execute();
				Console.Write( "Would You like to repeat this program? [y/n]: " );
			}
			Console.WriteLine();
		}
		#endregion

		#region abstract methods
		protected abstract void Execute();
		#endregion

		#region protected methods
		protected T GetParameter<T>( string message, params (Predicate<T?> condition, string? message)[]? conditions ) {
			T? item = default( T );
			Func<T?> input = item switch {
				bool => () => (T)(object)_YesAwnsers.Contains( Console.ReadKey().KeyChar ),
				int => () => int.TryParse( Console.ReadLine(), out int val ) ? (T)(object)val : (T)(object?)null,
				uint => () => uint.TryParse( Console.ReadLine(), out uint val ) ? (T)(object)val : (T)(object?)null,
				double => () => double.TryParse( Console.ReadLine(), out double val ) ? (T)(object)val : (T)(object?)null,
				char => () => {
					var c = Console.ReadKey().KeyChar;
					Console.WriteLine();
					return (T)(object)c;
				}
				,
				_ => () => (T)(object?)Console.ReadLine(),
			};

			// Force an input
			do {
				Console.Write( message.EndsWith( ' ' ) ? message : (message += " ") );
				item = input();
			} while( item is null );

			// check if every specified condition is met
			conditions?.ToList().ForEach( tuple => {
				while( tuple.condition( item ) is false ) {
					Console.Write( tuple.message ?? message );
					item = input();
				}
			} );

			return item;
		}

	}
	#endregion

}
