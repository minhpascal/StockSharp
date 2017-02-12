﻿#region S# License
/******************************************************************************************
NOTICE!!!  This program and source code is owned and licensed by
StockSharp, LLC, www.stocksharp.com
Viewing or use of this code requires your acceptance of the license
agreement found at https://github.com/StockSharp/StockSharp/blob/master/LICENSE
Removal of this comment is a violation of the license agreement.

Project: StockSharp.Quik.Lua.QuikPublic
File: LuaFixTransactionMessageAdapter.cs
Created: 2015, 11, 11, 2:32 PM

Copyright 2010 by StockSharp, LLC
*******************************************************************************************/
#endregion S# License
namespace StockSharp.Quik.Lua
{
	using System.Security;

	using Ecng.Common;
	using Ecng.ComponentModel;
	using Ecng.Localization;

	using StockSharp.Fix;
	using StockSharp.Fix.Dialects;
	using StockSharp.Localization;
	using StockSharp.Messages;

	/// <summary>
	/// Адаптер сообщений для Quik LUA FIX.
	/// </summary>
	[Icon("Quik_logo.png")]
	[DisplayNameLoc("Quik LUA. Transactions")]
	[Doc("769f74c8-6f8e-4312-a867-3dc6e8482636.htm")]
	[TargetPlatform(Languages.Russian)]
	[CategoryLoc(LocalizedStrings.RussiaKey)]
	public class LuaFixTransactionMessageAdapter : FixMessageAdapter
	{
		/// <summary>
		/// Создать <see cref="LuaFixTransactionMessageAdapter"/>.
		/// </summary>
		/// <param name="transactionIdGenerator">Генератор идентификаторов транзакций.</param>
		public LuaFixTransactionMessageAdapter(IdGenerator transactionIdGenerator)
			: base(transactionIdGenerator)
		{
			this.RemoveMarketDataSupport();

			Login = "quik";
			Password = "quik".To<SecureString>();
			Address = QuikTrader.DefaultLuaAddress;
			TargetCompId = "StockSharpTS";
			SenderCompId = "quik";
			//ExchangeBoard = ExchangeBoard.Forts;
			RequestAllPortfolios = true;
		}

		/// <summary>
		/// Создать для заявки типа <see cref="OrderTypes.Conditional"/> условие, которое поддерживается подключением.
		/// </summary>
		/// <returns>Условие для заявки. Если подключение не поддерживает заявки типа <see cref="OrderTypes.Conditional"/>, то будет возвращено <see langword="null"/>.</returns>
		public override OrderCondition CreateOrderCondition()
		{
			return new QuikOrderCondition();
		}

		/// <summary>
		/// Create FIX protocol dialect.
		/// </summary>
		/// <param name="dialect">The FIX dialect.</param>
		/// <returns>The dialect.</returns>
		protected override IFixDialect CreateDialect(FixDialects dialect)
		{
			return new LuaDialect(CreateOrderCondition);
		}
	}
}