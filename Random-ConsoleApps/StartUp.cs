using RandomApps;
using System;
using System.Collections.Generic;

var programList = new List<Executeable>() {
	new ChessPattern(),
	new EmirpPrimeNumbers(),
	new RectanglePrinter(),
	new ShowOperations(),
	new SpaceRemover(),
	new NumberPyramid(),

	new FunctionPrinter(),
	new NBonnacci(),
	new Fibonnacci(),
};

Console.WriteLine( "\n\t--- Programmier-Challenges ---\n" );

programList.ForEach( p => p.Run() );

Console.ReadKey();
