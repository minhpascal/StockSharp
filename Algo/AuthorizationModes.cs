#region S# License
/******************************************************************************************
NOTICE!!!  This program and source code is owned and licensed by
StockSharp, LLC, www.stocksharp.com
Viewing or use of this code requires your acceptance of the license
agreement found at https://github.com/StockSharp/StockSharp/blob/master/LICENSE
Removal of this comment is a violation of the license agreement.

Project: StockSharp.Algo.Algo
File: AuthorizationModes.cs
Created: 2015, 11, 11, 2:32 PM

Copyright 2010 by StockSharp, LLC
*******************************************************************************************/
#endregion S# License
namespace StockSharp.Algo
{
	using Ecng.ComponentModel;

	using StockSharp.Localization;

	/// <summary>
	/// Types of authorization.
	/// </summary>
	public enum AuthorizationModes
	{
		/// <summary>
		/// Anonymous.
		/// </summary>
		[EnumDisplayNameLoc(LocalizedStrings.AnonymousKey)]
		Anonymous,

		/// <summary>
		/// Windows authorization.
		/// </summary>
		[EnumDisplayName("Windows")]
		Windows,

		/// <summary>
		/// Custom.
		/// </summary>
		[EnumDisplayNameLoc(LocalizedStrings.CustomKey)]
		Custom,

		/// <summary>
		/// StockSharp.
		/// </summary>
		[EnumDisplayName("StockSharp")]
		Community
	}
}