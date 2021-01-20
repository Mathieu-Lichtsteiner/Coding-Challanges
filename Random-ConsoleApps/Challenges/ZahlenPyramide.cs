using RandomApps;
using System;

internal class ZahlenPyramide : Executeable {

	#region private fields
	private int _Input = 0;
	#endregion

	#region Executeable
	protected override void Execute() {
		Console.Write( "\n" );
		for( int stufen = 0; stufen <= _Input; ++stufen ) {
			int tester = 0;
			for( int leer = _Input - stufen; leer >= 0; --leer ) {
				if( _Input >= 10 ) {
					if( _Input % 10 >= 0 && tester - 1 <= ((_Input % 10) + ((_Input / 10) - 1) * 10) ) {
						Console.Write( "  " );
						tester++;
					}
					else if( _Input % 10 == 0 && tester - 1 <= _Input - 10 ) {
						Console.Write( "  " );
						tester++;
					}
					else
						Console.Write( " " );
				}
				else
					Console.Write( " " );
			}
			for( int zahl = -stufen; zahl <= stufen; ++zahl )
				Console.Write( Math.Abs( zahl ) );
			Console.Write( "\n" );
		}
		Console.Write( "\n" );
	}
	protected override void GetParameters() {

		Console.Write( "Bitte geben sie die Anzahl Stufen ein: " );
		while( int.TryParse( Console.ReadLine(), out _Input ) is false || _Input > 63 ) {
			if( _Input > 63 )
				Console.WriteLine( "Achtung zu grosse Zahl! (max.63)" );
			Console.Write( "Bitte eine Zahl eingeben!: " );
		}
	}
	#endregion

}