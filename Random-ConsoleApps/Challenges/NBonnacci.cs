﻿using System;
using System.Linq;

internal class NBonnacci : IProgram {

	private int[] _NBonnacci;
	private int _Basis;
	private int _Steps;
	private bool _Parse1 = false;
	private bool _Parse2 = false;
	private bool _Parseable;

	public void Run() {
		Console.WriteLine( " Willkommen bei der N-Bonacci sequenz. \n In diesem Programm werden gewünscht viele Zahlen einer Fibonacci Reihe mit n basis ausgegeben!" );
		do {
			// Basis und schritte als Input verwerten
			do {
				if( _Parse1 )
					Console.Write( "\t Basis: {0} ", _Basis );
				else {
					Console.Write( "\t Bitte die Basis angeben: " );
					_Parse1 = int.TryParse( Console.ReadLine(), out _Basis );
				}
				if( _Parse2 )
					Console.Write( "\t Schritte: {0} ", _Steps );
				else {
					Console.Write( "\t Anzahl Schritte: " );
					_Parse2 = int.TryParse( Console.ReadLine(), out _Steps );
				}
				_Parseable = _Parse1 && _Parse2;
				if( !_Parseable )
					Console.WriteLine( "Bitte nur ganze Zahlen eingeben!" );
			} while( !_Parseable );
			// wenn 0- oder 1-bonacci, return 0-Array
			if( _Basis == 0 || _Basis == 1 ) {
				_NBonnacci = Array.Empty<int>();
				Console.WriteLine( "\n Die Basis wurde auf {0} gesetzt und würde in einer {1}er reihe von {0}en resultieren! \n", _Basis, _Steps );
			}
			// Wenn die Basis grösser als die Anzahl schritte ausgewählt wurde.
			else if( _Basis >= _Steps )
				Console.WriteLine( "\n Die Basis wurde grösser als die anzahl Schritte gesetzt. Das ersultat ist {0}*0", _Steps );
			// Wenn eine korrekte basis gewählt wurde, kann die Methode ausgewählt werden und wird dann in einem String ausgegeben
			else {
				_NBonnacci = new int[_Steps];
				Console.Write( "\t Bitte die Methode Rekursiv oder Itterativ wählen: " );
				Methode();
				string Ausgabe = string.Concat( string.Format( "{0}*0", _Basis - 1 ), string.Join( ", ", _NBonnacci ).Substring( 3 * (_Basis - 1) - 2 ) );
				Console.WriteLine( "\n Die Fibonacci-Reihe mit Basis {0} lautet: \n\t {1} \n", _Basis, Ausgabe );
			}
			_Parse1 = false;
			_Parse2 = false;
		} while( Weiter() );
	}
	private bool Weiter() {
		Console.Write( " - Wenn eine weitere Reihe ausgegeben werden soll bitte bestätigen: " );
		string eingabe = Console.ReadLine();
		if( _Parse1 = int.TryParse( eingabe, out _Basis ) )
			return true;
		return new string[] { "y", "yes", "j", "ja", "weiter", "wiederholen", "repeat" }.Contains( eingabe.ToLower() );
	}
	private void Methode() {
		string input = Console.ReadLine();
		switch( input.ToLower() ) {
			case "itterativ":
			case "i":
				Itterativ();
				return;
			case "rekursiv":
			case "r":
				Rekursiv();
				return;
			case "erweitert":
			case "e":
				Erweitert();
				return;
			default:
				Console.Write( "Bitte eine der Methoden Rekursiv [R] oder Itterativ [I] auswählen: " );
				Methode();
				return;
		}
	}
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
	private void Rekursiv( int index = 0, int temp = 0, int subindex = 1 ) {
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
	private void Erweitert( int temp = 0 ) {
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
}