using RandomApps;
using System;
using System.Collections.Generic;

var programList = new List<Executeable>() {


	new Fibonnacci(),
	new FunctionPrinter(),
	new NBonnacci(),

	new CalculateRectangle(),
	new ChessPattern(),
	new DescribeCharacter(),
	new EmirpPrimeNumbers(),
	new IntToHexAndBinary(),
	new NumberPyramid(),
	new PrimeFactors(),
	new RectanglePrinter(),
	new ShowOperations(),
	new SpaceRemover(),
	new SumAllNumbers(),
	new TrianglePrinter(),
	new WordPyramid(),
};

Console.WriteLine( "\n\t--- Programmier-Challenges ---" );
programList.ForEach( p => p.Run() );
Console.ReadKey();
