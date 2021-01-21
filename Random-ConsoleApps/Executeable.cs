using System;
using System.Linq;

namespace RandomApps {
	internal abstract class Executeable {

		#region protected fields
		private char[] _YesAwnsers = { 'y', 'Y', 'j', 'J' };
		#endregion

		#region abstract properties
		public virtual string Description { get; } = "";
		public virtual string Source { get; } = "";
		#endregion

		#region public methods
		public void Run() {
			Console.WriteLine( $"Welcome to {GetType().Name}!" );
			if( string.IsNullOrWhiteSpace( Description ) is false )
				Console.WriteLine( Description );
			if( string.IsNullOrWhiteSpace( Source ) is false )
				Console.WriteLine( $"\t (Source: {Source})" );

			Console.Write( "Would You like to run this program? [y/n]: " );
			while( _YesAwnsers.Contains( Console.ReadKey().KeyChar ) ) {
				Console.WriteLine();
				GetParameters();
				Execute();
				Console.Write( "Would You like to repeat this program? [y/n]: " );
			}
			Console.WriteLine();
		}
		#endregion

		#region abstract methods
		protected abstract void Execute();
		protected virtual void GetParameters() { }
		#endregion

		#region protected methods
		protected T GetParameter<T>( string message, params (Predicate<T?>, string?)[]? conditions ) {
			T? item = default( T );
			Func<T?> input = item switch {
				int => () => int.TryParse( Console.ReadLine(), out int val ) ? (T)(object)val : (T)(object?)null,
				double => () => double.TryParse( Console.ReadLine(), out double val ) ? (T)(object)val : (T)(object?)null,
				char => () => (T)(object)Console.ReadKey().KeyChar,
				_ => () => (T)(object?)Console.ReadLine(),
			};

			// Force an input
			do {
				Console.WriteLine( message );
				item = input();
			} while( item is null );
			Console.WriteLine();

			// check if every specified condition is met
			conditions?.ToList().ForEach( tuple => {
				while( tuple.Item1( item ) is false ) {
					Console.WriteLine( tuple.Item2 );
					item = input();
				}
				Console.WriteLine();
			} );

			return item;
		}

	}
	#endregion

}
