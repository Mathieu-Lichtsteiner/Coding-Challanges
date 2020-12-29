using Adventskalender2020;
using System;
using System.Collections.Generic;

var challengelist = new List<IChallenge>() {
	new IntToBinary(100),
	new BinaryToInt("1100100"),
	new GeldWechseln(24.95M),
	new DuplikateEntfernen( new List<string>{ "Peter", "Toni", "Peter", "Peter", "Toni", "Alfred", "Manfred" } ),
	new GrössterGemeinsamerTeiler(150, 125),
	new PlaindromCheck("Rxliefpfeiler"),
	new KlammerCheck("(2+5))*10+10"),
	new SchaltJahrCheck(DateTime.Now),
	new JaggedArrayMaximum(new int[][] { new int[]{ 1 , 12,15,36,2,5}, new int[]{ 5,12,96,4,7,5,12}, new int[]{ 10,12,12,56,1,12},} ),
	new CustomContains("abcdefaölkjdfaölkdfsjgasdf", "kdfsjga"),
};

Console.WriteLine( "Programmier-Challenges von Programmieren-Starten.de" );

challengelist.ForEach( challenge => {
	Console.WriteLine( $"{challenge.GetType().Name}:" );
	Console.WriteLine( $"\t{challenge.Run()}" );
} );
Console.ReadKey();
