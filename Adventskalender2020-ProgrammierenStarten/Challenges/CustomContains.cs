using Adventskalender2020;

internal class CustomContains : IChallenge {

	private string _String;
	private string _Part;
	public CustomContains( string input, string substring ) {
		_String = input;
		_Part = substring;
	}

	public string Run() {
		var contains = Contains( "56uvwxyz", "xyz", out int index );
		return $"{_String} " + (contains ? $"contains {_Part} at index {index}!" : $"does not contain {_Part}");
	}

	private bool Contains( string whole, string part, out int index ) {
		index = 0;
		if( part.Length == 0 )
			return false;
		string container = part;
		for( int i = 0; i < whole.Length; i++ ) {
			if( whole[i] == container[0] ) {
				if( container == part )
					index = i;
				if( container.Length == 1 )
					return true;
				else
					container = container.Substring( 1 );
			}
			else
				container = part;
		}
		return false;
	}

}