using System;
using System.Linq;

namespace RandomApps {
	internal abstract class Executeable : IProgram {

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
		protected abstract void GetParameters();
		protected abstract void Execute();
		#endregion


	}
}
