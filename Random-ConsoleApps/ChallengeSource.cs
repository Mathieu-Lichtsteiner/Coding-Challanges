using System.ComponentModel;
using System.Reflection;

namespace RandomApps {
	internal enum ChallengeSource {

		[Description( "Exercises C# App (PlayStore)" )]
		CSharpApp,

	}

	internal static class EnumExtensions {
		internal static string GetDescription( this ChallengeSource value )
			=> value.GetType()?.GetField( value.ToString() )?.GetCustomAttribute( typeof( DescriptionAttribute ), false ) is DescriptionAttribute attribute
			? attribute.Description
			: value.ToString();
	}
}
