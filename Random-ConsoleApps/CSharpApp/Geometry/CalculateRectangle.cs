using RandomApps;
using System;

internal class CalculateRectangle : Executeable {

	#region Executeable
	public override string Description
		=> "Berechnet die Fläche, Umfang und Diagonale von einem Rechteck.";
	public override ChallengeSource? Source
		=> ChallengeSource.CSharpApp;
	protected override void Execute() {
		double width = GetParameter<double>( "Bitte die Breite eingeben: " );
		double height = GetParameter<double>( "Bitte die Höhe eingeben: " );
		Console.WriteLine( $"Das Rechteck mit Höhe {height} und Breite {width} hat folgende eigenschaften: " +
			$"\n Fläche = {height * width}" +
			$"\n Umfang = {2 * height + 2 * width}" +
			$"\n Diagonale = {Math.Sqrt( (height * height) + (width * width) )}" );
	}
	#endregion

}