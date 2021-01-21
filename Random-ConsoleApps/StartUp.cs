using RandomApps;
using System;
using System.Collections.Generic;

var programList = new List<Executeable>() {
	new ChessPattern(),
	new FunctionPrinter(),
	new EmirpPrimeNumbers(),
	new NBonnacci(),
	new RectanglePrinter(),
	new ShowOperations(),
	new SpaceRemover(),
	new NumberPyramid(),

};

Console.WriteLine( "\n\t--- Programmier-Challenges ---\n" );

programList.ForEach( p => p.Run() );

Console.ReadKey();
