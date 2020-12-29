using System;
using System.Collections.Generic;

var programList = new List<IProgram>() {
	new Schachbrett(),
	new ShowOperations(),
	new SpaceRemover(),
	new ZahlenPyramide(),
	new NBonnacci(),
	new FunctionPrinter(),
	new EmirpPrimeNumbers(),

};

Console.WriteLine( "Programmier-Challenges von Programmieren-Starten.de" );

programList.ForEach( program => {
	Console.WriteLine( $"{program.GetType().Name}:" );
	program.Run();
} );

Console.ReadKey();
