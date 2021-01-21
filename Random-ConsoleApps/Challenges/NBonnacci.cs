using RandomApps;
using System;
using System.Linq;

// In this Program i want to show the Fibonnacci Sequences, but define how many elements get added up
internal class NBonnacci : Executeable {

	#region private fields
	private int[] _NBonnacci;
	private int _Basis;
	private int _Steps;
	#endregion

	#region Executeable
	public override string Description
		=> "In diesem Programm werden gewünscht viele Zahlen einer Fibonacci Reihe mit n basis ausgegeben!";
	protected override void Execute() {

		_Basis = GetParameter<int>( "Bitte die Basis angeben: ",
			(n => n != 0, "Die Basis wurde auf 0 gesetzt und würde in einer reihe von nullen resultieren!") );

		_Steps = GetParameter<int>( "Bitte die Anzahl Schritte eingeben: " );

		string methodChar = GetParameter<string>(
			"Bitte die Methode Rekursiv oder Itterativ wählen: [i/r/e] ",
			(str => new[] { "itterativ", "i", "rekursiv", "r", "erweitert", "e" }.Contains( str?.ToLower() ), "Bitte eine richtige Methode anwählen! [i/r/e] ") );
		Action method = methodChar.ToLower() switch {
			"itterativ" or "i" => Itterativ,
			"rekursiv" or "r" => Rekursiv,
			"erweitert" or "e" => Erweitert,
		};

		_NBonnacci = new int[_Steps];
		_NBonnacci[0] = _Basis;
		_NBonnacci[1] = _Basis;
		method?.Invoke();
		string ausgabe = string.Concat( string.Format( $"{_Basis - 1}*0" ), string.Join( ", ", _NBonnacci ).Substring( 3 * (_Basis - 1) - 2 ) );
		Console.WriteLine( $"\n Die Fibonacci-Reihe mit Basis {_Basis} lautet: \n\t {ausgabe} \n" );

	}
	#endregion

	#region N-Bonnacci Methoden
	private void Itterativ() {
		// Array füllen mit jedem Schritt
		for( int i = 0; i < _Steps; i++ ) {
			int temp = 0;
			// nullen hinzufügen
			if( i < _Basis - 1 )
				_NBonnacci[i] = 0;
			// erste 1 hinzufügen
			else if( i == _Basis - 1 )
				_NBonnacci[i] = 1;
			// zahlen summieren
			else {
				// für alle Zahlen, die basis zurück und addieren
				for( int j = 1; j <= _Basis; j++ )
					temp += _NBonnacci[i - j];
				_NBonnacci[i] = temp;
			}
		}
	}
	private void Rekursiv()
		=> Rekursiv( 0, 0, 1 );
	private void Rekursiv( int index, int temp, int subindex ) {
		// 0 einfügen, solange die Reihe noch nicht begonnen wurde
		if( index < _Basis - 1 )
			_NBonnacci[index] = 0;
		// erste 1 einfügen, bei index der Basis (nullbasiert)
		else if( index == _Basis - 1 )
			_NBonnacci[index] = 1;
		// summierung ausführen
		else {
			if( subindex <= _Basis ) {
				temp += _NBonnacci[index - subindex];
				subindex++;
			}
			else {
				_NBonnacci[index] = temp;
				temp = 0;
			}
		}
		if( temp == 0 ) {
			index++;
			subindex = 1;
		}
		if( index < _Steps )
			Rekursiv( index, temp, subindex );
	}

	private void Erweitert()
		=> Erweitert( 0 );
	private void Erweitert( int temp ) {
		_NBonnacci[_Basis - 1] = 1;
		_NBonnacci[_Basis] = 1;
		_NBonnacci[_Basis + 1] = 2;
		_NBonnacci[_Basis + 2] = 4;
		_NBonnacci[_Basis + 3] = 7;
		if( Array.IndexOf( _NBonnacci, 0, _Basis ) > 2 * _Basis )
			temp += (temp >= _NBonnacci[Array.IndexOf( _NBonnacci, 0, _Basis ) - _Basis]) ? (Array.Find( _NBonnacci, item => item > temp )) : (_NBonnacci[Array.IndexOf( _NBonnacci, 0, _Basis ) - _Basis]);
		// wenn temp grösser als der vorherige Index, dann wird der Index aktualisiert
		if( temp > _NBonnacci[Array.IndexOf( _NBonnacci, 0, _Basis ) - 1] ) {
			_NBonnacci[Array.IndexOf( _NBonnacci, 0, _Basis )] = temp;
			temp = 0;
		}
		// Solange noch nicht alle schritte vollständig sind wiederholen
		if( _NBonnacci[_Steps - 1] == 0 )
			Erweitert( temp );
	}
	#endregion

}