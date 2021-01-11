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
	new RectanglePrinter(4,6, '*'),

};

Console.WriteLine( "Programmier-Challenges von Programmieren-Starten.de" );

programList.ForEach( program => {
	Console.Write( $"--- {program.GetType().Name}: --- \n -> Run? [y/n]: " );
	char re = Console.ReadKey().KeyChar;
	Console.WriteLine();
	if( re == 'y' )
		program.Run();
} );

Console.ReadKey();
