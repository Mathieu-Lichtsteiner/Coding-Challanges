using System;
using System.Collections.Generic;

var programList = new List<IProgram>() {
	new ZahlenPyramide(),
	new Schachbrett(),
	new ShowOperations(),
	new SpaceRemover(),
	new NBonnacci(),
	new FunctionPrinter(),
	new EmirpPrimeNumbers(),
	new RectanglePrinter(4,6, '*'),

};

Console.WriteLine( "Programmier-Challenges" );

foreach( var program in programList )
	program.Run();

Console.ReadKey();
