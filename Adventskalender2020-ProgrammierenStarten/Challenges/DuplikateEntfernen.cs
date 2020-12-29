using Adventskalender2020;
using System.Collections.Generic;
using System.Linq;

internal class DuplikateEntfernen : IChallenge {

	private List<string> _Param;
	public DuplikateEntfernen( List<string> param )
		=> _Param = param;

	public string Run()
		=> "Alte Liste:\n\t "
		+ _Param.Aggregate( ( ret, curr ) => ret += $",\n\t {curr}" )
		+ "\n\tNeue Liste:\n\t "
		+ RemoveDuplicates( _Param ).Aggregate( ( ret, curr ) => ret += $",\n\t {curr}" );
	public string Run<T>( List<T> unfilteredList )
		=> "Alte Liste:\n\t "
		+ unfilteredList.Aggregate( string.Empty, ( ret, curr ) => ret += $",\n\t {curr}" )
		+ "\n\tNeue Liste:\n\t "
		+ RemoveDuplicates( unfilteredList ).Aggregate( string.Empty, ( ret, curr ) => ret += $",\n\t {curr}" );

	private List<T> RemoveDuplicates<T>( List<T> dirtyList )
		=> dirtyList.Aggregate(
			new List<T>(),
			( newList, oldItem )
			=> newList.Exists( newItem => Equals( newItem, oldItem ) )
			? newList
			: newList.Append( oldItem ).ToList() );

}