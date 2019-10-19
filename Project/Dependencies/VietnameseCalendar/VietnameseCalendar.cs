using System;
using System.Text;
using System.Runtime.InteropServices;

using Microsoft.Win32;

/**
 * Copyright 2004 Ho Ngoc Duc [http://come.to/duc]. All Rights Reserved.<p>
 * Permission to use, copy, modify, and redistribute this software and its
 * documentation for personal, non-commercial use is hereby granted provided that
 * this copyright notice appears in all copies.
 */
namespace System.Globalization
{
	/// <summary>
	/// Represents time in divisions, such as months, days, and years. Years are calculated using the
	/// Vietnamese calendar, while days and months are calculated using the lunisolar calendar.
	/// </summary>
	[Serializable()]
	public class VietnameseCalendar : Calendar
	{
		#region "constants"
		// TODO: must use Environment.GetResourceString()
		private static readonly Resources.ResourceManager resource =
			new Resources.ResourceManager("mscorlib", Reflection.Assembly.GetAssembly(typeof(int)));

		// TODO: translate to English
		/*
		 * Moi nam duong lich se duoc ma hoa voi 3 bytes (24 bits).
		 * - 7 bits cao: so ngay tinh tu 1/1 duong lich den 1/1 am lich.
		 * - 1 bit ke tiep: la 0 thi thang nhuan gom 29 ngay, la 1 thi 30 ngay.
		 * - 12 bits tiep theo: moi bit the hien so ngay trong thang, tuong tu bit thu 8.
		 * - 4 bits thap: neu khac 0 thi nam am lich do se chu'a tha'ng nhuan
		 *   & 4 bit do the hien gia tri cua tha'ng nhuan.
		 * Bang sau chua 400 ma-nam gom cac nam tu 1800 -> 2199.
		 */
		private static readonly int[] yearsCode = new int[] {
		// The ky 19 (1800-1899)
		0x30baa3, 0x56ab50, 0x422ba0, 0x2cab61, 0x52a370, 0x3c51e8, 0x60d160, 0x4ae4b0, 0x376926, 0x58daa0,
		0x445b50, 0x3116d2, 0x562ae0, 0x3ea2e0, 0x28e2d2, 0x4ec950, 0x38d556, 0x5cb520, 0x46b690, 0x325da4,
		0x5855d0, 0x4225d0, 0x2ca5b3, 0x52a2b0, 0x3da8b7, 0x60a950, 0x4ab4a0, 0x35b2a5, 0x5aad50, 0x4455b0,
		0x302b74, 0x562570, 0x4052f9, 0x6452b0, 0x4e6950, 0x386d56, 0x5e5aa0, 0x46ab50, 0x3256d4, 0x584ae0,
		0x42a570, 0x2d4553, 0x50d2a0, 0x3be8a7, 0x60d550, 0x4a5aa0, 0x34ada5, 0x5a95d0, 0x464ae0, 0x2eaab4,
		0x54a4d0, 0x3ed2b8, 0x64b290, 0x4cb550, 0x385757, 0x5e2da0, 0x4895d0, 0x324d75, 0x5849b0, 0x42a4b0,
		0x2da4b3, 0x506a90, 0x3aad98, 0x606b50, 0x4c2b60, 0x359365, 0x5a9370, 0x464970, 0x306964, 0x52e4a0,
		0x3cea6a, 0x62da90, 0x4e5ad0, 0x392ad6, 0x5e2ae0, 0x4892e0, 0x32cad5, 0x56c950, 0x40d4a0, 0x2bd4a3,
		0x50b690, 0x3a57a7, 0x6055b0, 0x4c25d0, 0x3695b5, 0x5a92b0, 0x44a950, 0x2ed954, 0x54b4a0, 0x3cb550,
		0x286b52, 0x4e55b0, 0x3a2776, 0x5e2570, 0x4852b0, 0x32aaa5, 0x56e950, 0x406aa0, 0x2abaa3, 0x50ab50,
		// The ky 20 (1900-1999)
		0x3c4bd8, 0x624ae0, 0x4ca570, 0x3854d5, 0x5cd260, 0x44d950, 0x315554, 0x5656a0, 0x409ad0, 0x2a55d2,
		0x504ae0, 0x3aa5b6, 0x60a4d0, 0x48d250, 0x33d255, 0x58b540, 0x42d6a0, 0x2cada2, 0x5295b0, 0x3f4977,
		0x644970, 0x4ca4b0, 0x36b4b5, 0x5c6a50, 0x466d50, 0x312b54, 0x562b60, 0x409570, 0x2c52f2, 0x504970,
		0x3a6566, 0x5ed4a0, 0x48ea50, 0x336a95, 0x585ad0, 0x442b60, 0x2f86e3, 0x5292e0, 0x3dc8d7, 0x62c950,
		0x4cd4a0, 0x35d8a6, 0x5ab550, 0x4656a0, 0x31a5b4, 0x5625d0, 0x4092d0, 0x2ad2b2, 0x50a950, 0x38b557,
		0x5e6ca0, 0x48b550, 0x355355, 0x584da0, 0x42a5b0, 0x2f4573, 0x5452b0, 0x3ca9a8, 0x60e950, 0x4c6aa0,
		0x36aea6, 0x5aab50, 0x464b60, 0x30aae4, 0x56a570, 0x405260, 0x28f263, 0x4ed940, 0x38db47, 0x5cd6a0,
		0x4896d0, 0x344dd5, 0x5a4ad0, 0x42a4d0, 0x2cd4b4, 0x52b250, 0x3cd558, 0x60b540, 0x4ab5a0, 0x3755a6,
		0x5c95b0, 0x4649b0, 0x30a974, 0x56a4b0, 0x40aa50, 0x29aa52, 0x4e6d20, 0x39ad47, 0x5eab60, 0x489370,
		0x344af5, 0x5a4970, 0x4464b0, 0x2c74a3, 0x50ea50, 0x3d6a58, 0x6256a0, 0x4aaad0, 0x3696d5, 0x5c92e0,
		// The ky 21 (2000-2099)
		0x46c960, 0x2ed954, 0x54d4a0, 0x3eda50, 0x2a7552, 0x4e56a0, 0x38a7a7, 0x5ea5d0, 0x4a92b0, 0x32aab5,
		0x58a950, 0x42b4a0, 0x2cbaa4, 0x50ad50, 0x3c55d9, 0x624ba0, 0x4ca5b0, 0x375176, 0x5c5270, 0x466930,
		0x307934, 0x546aa0, 0x3ead50, 0x2a5b52, 0x504b60, 0x38a6e6, 0x5ea4e0, 0x48d260, 0x32ea65, 0x56d520,
		0x40daa0, 0x2d56a3, 0x5256d0, 0x3c4afb, 0x6249d0, 0x4ca4d0, 0x37d0b6, 0x5ab250, 0x44b520, 0x2edd25,
		0x54b5a0, 0x3e55d0, 0x2a55b2, 0x5049b0, 0x3aa577, 0x5ea4b0, 0x48aa50, 0x33b255, 0x586d20, 0x40ad60,
		0x2d4b63, 0x525370, 0x3e49e8, 0x60c970, 0x4c54b0, 0x3768a6, 0x5ada50, 0x445aa0, 0x2fa6a4, 0x54aad0,
		0x4052e0, 0x28d2e3, 0x4ec950, 0x38d557, 0x5ed4a0, 0x46d950, 0x325d55, 0x5856a0, 0x42a6d0, 0x2c55d4,
		0x5252b0, 0x3ca9b8, 0x62a930, 0x4ab490, 0x34b6a6, 0x5aad50, 0x4655a0, 0x2eab64, 0x54a570, 0x4052b0,
		0x2ab173, 0x4e6930, 0x386b37, 0x5e6aa0, 0x48ad50, 0x332ad5, 0x582b60, 0x42a570, 0x2e52e4, 0x50d160,
		0x3ae958, 0x60d520, 0x4ada90, 0x355aa6, 0x5a56d0, 0x462ae0, 0x30a9d4, 0x54a2d0, 0x3ed150, 0x28e952,
		// The ky 22 (2100-2199)
		0x4eb520, 0x38d727, 0x5eada0, 0x4a55b0, 0x362db5, 0x5a45b0, 0x44a2b0, 0x2eb2b4, 0x54a950, 0x3cb559,
		0x626b20, 0x4cad50, 0x385766, 0x5c5370, 0x484570, 0x326574, 0x5852b0, 0x406950, 0x2a7953, 0x505aa0,
		0x3baaa7, 0x5ea6d0, 0x4a4ae0, 0x35a2e5, 0x5aa550, 0x42d2a0, 0x2de2a4, 0x52d550, 0x3e5abb, 0x6256a0,
		0x4c96d0, 0x3949b6, 0x5e4ab0, 0x46a8d0, 0x30d4b5, 0x56b290, 0x40b550, 0x2a6d52, 0x504da0, 0x3b9567,
		0x609570, 0x4a49b0, 0x34a975, 0x5a64b0, 0x446a90, 0x2cba94, 0x526b50, 0x3e2b60, 0x28ab61, 0x4c9570,
		0x384ae6, 0x5cd160, 0x46e4a0, 0x2eed25, 0x54da90, 0x405b50, 0x2c36d3, 0x502ae0, 0x3a93d7, 0x6092d0,
		0x4ac950, 0x32d556, 0x58b4a0, 0x42b690, 0x2e5d94, 0x5255b0, 0x3e25fa, 0x6425b0, 0x4e92b0, 0x36aab6,
		0x5c6950, 0x4674a0, 0x31b2a5, 0x54ad50, 0x4055a0, 0x2aab73, 0x522570, 0x3a5377, 0x6052b0, 0x4a6950,
		0x346d56, 0x585aa0, 0x42ab50, 0x2e56d4, 0x544ae0, 0x3ca570, 0x2864d2, 0x4cd260, 0x36eaa6, 0x5ad550,
		0x465aa0, 0x30ada5, 0x5695d0, 0x404ad0, 0x2aa9b3, 0x50a4d0, 0x3ad2b7, 0x5eb250, 0x48b540, 0x33d556
		};
		#endregion

		#region "string tables"
		private static readonly string[] selestialStems = new string[] {
			"Giáp", "Ất", "Bính", "Đinh", "Mậu", "Kỷ", "Canh", "Tân", "Nhâm", "Quý"
		};
		private static readonly string[] terrestrialBranches = new string[] {
			"Tý", "Sửu", "Dần", "Mão", "Thìn", "Tỵ", "Ngọ", "Mùi", "Thân", "Dậu", "Tuất", "Hợi"
		};
		private static readonly string[] propitiousHour = new string[] {
			"110100101100", "001101001011", "110011010010", "101100110100", "001011001101", "010010110011"
		};
		private static readonly string[] minorSolarTerms = new string[] {
			"Xuân phân", "Thanh minh", "Cốc vũ", "Lập hạ", "Tiểu mãn", "Mang chủng", "Hạ chí", "Tiểu thử",
			"Đại thử", "Lập thu", "Xử thử", "Bạch lộ", "Thu phân", "Hàn lộ", "Sương giáng", "Lập đông",
			"Tiểu tuyết", "Đại tuyết", "Đông chí", "Tiểu hàn", "Đại hàn", "Lập xuân", "Vũ Thủy", "Kinh trập"
		};
		#endregion

		#region "properties"
		/// <summary>
		/// Gets a value indicating whether the current calendar is solar-based, lunar-based,
		/// or a combination of both.
		/// </summary>
		/// <returns>This property always returns the <see cref="CalendarAlgorithmType.LunisolarCalendar"/>
		/// value.</returns>
		public override CalendarAlgorithmType AlgorithmType
		{
			get { return CalendarAlgorithmType.LunisolarCalendar; }
		}

		/// <summary>
		/// Specifies the era that corresponds to the current VietnameseCalendar object.
		/// </summary>
		public const int VietnameseEra = 1;

		/// <summary>
		/// Gets the eras that correspond to the range of dates and times supported by the current
		/// VietnameseCalendar object.
		/// </summary>
		/// <returns>An array of 32-bit signed integers that specify the relevant eras. The return value
		/// for a VietnameseCalendar object is always an array containing one element equal to
		/// the <see cref="VietnameseEra/> value.</returns>
		[ComVisible(false)]
		public override int[] Eras
		{
			get { return new int[] { VietnameseEra }; }
		}

		private static readonly DateTime minDate = new DateTime(1800, 1, 25, 0, 0, 0);	// Tet am lich 1800
		/// <summary>
		/// Gets the minimum date and time supported by the VietnameseCalendar class.</summary>
		/// <returns>A <see cref="DateTime"/> object that represents January 25, 1800
		/// in the Gregorian calendar, which is equivalent to the constructor
		/// DateTime(1800, 1, 25).</returns>
		[ComVisible(false)]
		public override DateTime MinSupportedDateTime
		{
			get { return minDate; }
		}

		private static readonly DateTime maxDate = new DateTime(2199, 12, 31, 23, 59, 59);
		/// <summary>
		/// Gets the maximum date and time supported by the VietnameseCalendar class.</summary>
		/// <returns>A <see cref="DateTime"/> object that represents the last moment on December 31, 2199
		/// in the Gregorian calendar, which is approximately equal to the constructor
		/// DateTime(2199, 12, 31).</returns>
		[ComVisible(false)]
		public override DateTime MaxSupportedDateTime
		{
			get { return maxDate; }
		}

		/// <summary>
		/// Gets or sets the last year of a 100-year range that can be represented by a 2-digit year.
		/// </summary>
		/// <returns>The last year of a 100-year range that can be represented by a 2-digit year.</returns>
		/// <exception cref="ArgumentOutOfRangeException">The value in a set operation is less than 99
		/// or greater than the maximum supported year in the current calendar.</exception>
		/// <exception cref="InvalidOperationException">The current VietnameseCalendar object is read-only.
		/// </exception>
		public override int TwoDigitYearMax
		{
			get
			{
				if (base.TwoDigitYearMax < 0)
				{
					// Call Win32 ::GetCalendarInfo() to retrieve CAL_ITWODIGITYEARMAX value
					base.TwoDigitYearMax = GetSystemTwoDigitYearSetting(
						1/*CAL_GREGORIAN - Gregorian (localized)*/, this.GetYear(maxDate));
				}
				return base.TwoDigitYearMax;
			}
			set
			{
				this.VerifyWritable();
				if ((value < MinCalendarYear) || (value > MaxCalendarYear))
				{
					throw new ArgumentOutOfRangeException("value", string.Format(CultureInfo.CurrentCulture,
						resource.GetString("ArgumentOutOfRange_Range"), MinCalendarYear, MaxCalendarYear));
				}
				base.TwoDigitYearMax = value;
			}
		}

		internal int MinCalendarYear { get { return minDate.Year; } }
		internal int MaxCalendarYear { get { return maxDate.Year; } }
		#endregion

		#region "native methods"
		/// <summary>
		/// Retrieves information about a calendar for a locale specified by identifier.
		/// </summary>
		/// <param name="localeId">Locale identifier that specifies the locale for which to retrieve
		/// calendar information.</param>
		/// <param name="calendarId">Calendar identifier.</param>
		/// <param name="calendarType">Type of information to retrieve.</param>
		/// <param name="data">Pointer to a buffer in which this function retrieves the requested data
		/// as a string. If <c>CAL_RETURN_NUMBER</c> is specified in <paramref name="calendarType"/>,
		/// this parameter must be set to a <c>null</c> pointer.</param>
		/// <param name="dataSize">Size, in characters, of the <paramref name="data"/> buffer.
		/// The application can set this parameter to 0 to return the required size for the calendar data
		/// buffer. In this case, the <paramref name="data"/> parameter is not used.
		/// If <c>CAL_RETURN_NUMBER</c> is specified for <paramref name="calendarType"/>,
		/// the value of <paramref name="dataSize"/> must be <c>0</c>.</param>
		/// <param name="value">Pointer to a variable that receives the requested data as a number.
		/// If <c>CAL_RETURN_NUMBER</c> is not specified in <paramref name="calendarType"/>,
		/// then <paramref name="value"/> must be <c>null</c>.</param>
		/// <returns>
		/// <p>The number of characters retrieved in the <paramref name="data"/> buffer,
		/// with <paramref name="dataSize"/> set to a nonzero value, if successful.<br/>
		/// If the function succeeds, <paramref name="dataSize"/> is set to 0, and <c>CAL_RETURN_NUMBER</c>
		/// is not specified, the return value is the size of the buffer required to hold the
		/// calendar information.<br/>
		/// If the function succeeds, <paramref name="dataSize"/> is set 0, and <c>CAL_RETURN_NUMBER</c>
		/// is specified, the return value is the size of the value retrieved in <paramref name="value"/>,
		/// that is, 2 for the Unicode version of the function or 4 for the ANSI version.</p>
		/// <p>This function returns 0 if it does not succeed.</p>
		/// </returns>
		[DllImport("Kernel32.dll", EntryPoint = "GetCalendarInfo")]
		internal static extern int GetCalendarInfo(int/*LCID*/ localeId,
			int/*CALID*/ calendarId, int/*CALTYPE*/ calendarType,
			StringBuilder/*LPSTR*/ data, int dataSize, ref int/*LPDWORD*/ value);

		internal static int GetTwoDigitYearMax(int calendarId)
		{
			try
			{
				int num = 0, ret = GetCalendarInfo(0x042a/*vi-VN*/, calendarId,
					0x20000030/*CAL_RETURN_NUMBER | CAL_ITWODIGITYEARMAX*/, null, 0, ref num);
				if (ret < 1)
				{
					Console.WriteLine(@"Native function Kernel32.GetCalendarInfo() returns 0.
						Call GetLastError() to get extended error information.
						GetLastError() can return one of the following error codes:
							* ERROR_INSUFFICIENT_BUFFER
							* ERROR_INVALID_FLAGS
							* ERROR_INVALID_PARAMETER");
					return -1;
				}
				return num;
			}
			catch (Exception e)
			{
				Console.WriteLine("Native function Kernel32.GetCalendarInfo() calling exception: {0}", e);
			}
			return int.MinValue;
		}
		#endregion

		#region "internal methods"
		internal static int GetSystemTwoDigitYearSetting(int calendarId, int defaultYearValue)
		{
			int num = GetTwoDigitYearMax(calendarId);
			if (num < 0)
			{
				RegistryKey key = null;
				try
				{
					key = Registry.CurrentUser.OpenSubKey(
						@"Control Panel\International\Calendars\TwoDigitYearMax", false);
				}
				catch (ObjectDisposedException) { }
				catch (ArgumentException) { }
				if (key != null)
				{
					try
					{
						object obj = key.GetValue(calendarId.ToString(CultureInfo.InvariantCulture));
						if (obj != null)
						{
							try { num = int.Parse(obj.ToString(), CultureInfo.InvariantCulture); }
							catch (ArgumentException) { }
							catch (FormatException) { }
							catch (OverflowException) { }
						}
					}
					finally { key.Close(); }
				}
				if (num < 0) num = defaultYearValue;
			}
			return num;
		}

		internal void VerifyWritable()
		{
			if (this.IsReadOnly)
			{
				throw new InvalidOperationException(resource.GetString("InvalidOperation_ReadOnly"));
			}
		}
		internal void CheckTicksRange(long ticks)
		{
			if ((ticks < MinSupportedDateTime.Ticks) || (ticks > MaxSupportedDateTime.Ticks))
			{
				throw new ArgumentOutOfRangeException("time", string.Format(CultureInfo.InvariantCulture,
					resource.GetString("ArgumentOutOfRange_CalendarRange"),
					this.MinSupportedDateTime, this.MaxSupportedDateTime));
			}
		}
		internal void CheckEraRange(int era)
		{
			if (era != 0 && era != VietnameseEra)
			{
				throw new ArgumentOutOfRangeException("era",
					resource.GetString("ArgumentOutOfRange_InvalidEraValue"));
			}
		}
		internal void CheckYearRange(int year)
		{
			if ((year < this.MinCalendarYear) || (year > this.MaxCalendarYear))
			{
				throw new ArgumentOutOfRangeException("year", string.Format(CultureInfo.CurrentCulture,
					resource.GetString("ArgumentOutOfRange_Range"), MinCalendarYear, MaxCalendarYear));
			}
		}
		internal void CheckMonthRange(int month, int leapMonth)
		{
			if ((month < 1) || (month > 13) || ((month == 13) && (leapMonth == 0)))
			{
				throw new ArgumentOutOfRangeException("month",
					resource.GetString("ArgumentOutOfRange_Month"));
			}
		}
		#endregion

		#region "helper methods"
		private static int GetYearCode(int year)
		{
			return yearsCode[year - 1800];
		}
		/// <summary>
		/// Returns a lunar date that represents the Lunar New Year's Day in the specified solar year.
		/// </summary>
		private static DateTime GetLunarNewYear(int year)
		{
			DateTime date = new DateTime(year, 1, 1, 0, 0, 0);		// New Year's Day
			return date.AddDays(GetYearCode(year) >> 17);	// offset of Tet (Lunar New Year's Day)
		}
		/// <summary>
		/// Returns number of days in specified month of the year.
		/// </summary>
		/// <param name="month">An integer from 1 through 13 that represents the month.</param>
		private static int GetMonthLength(int year, int month, int leapMonth)
		{
			if (leapMonth > 0)
			{
				if (month == leapMonth) month = 0;
				else if (month > leapMonth) month--;
			}
			return (((GetYearCode(year) >> (16 - month)) & 0x1) == 0 ? 29 : 30);
		}
		#endregion

		#region "override abstract methods"
		/// <summary>
		/// Retrieves the era that corresponds to the specified <see cref="DateTime"/> object.
		/// </summary>
		/// <returns>An integer that represents the era in the time parameter.</returns>
		/// <param name="time">The <see cref="DateTime"/> object to read.</param>
		/// <exception cref="ArgumentOutOfRangeException">time is less than
		/// <see cref="MinSupportedDateTime"/> or greater than <see cref="MaxSupportedDateTime"/>.
		/// </exception>
		[ComVisible(false)]
		public override int GetEra(DateTime time)
		{
			this.CheckTicksRange(time.Ticks);
			return VietnameseEra;
		}

		/// <summary>
		/// Returns the year in the specified date.
		/// </summary>
		/// <param name="time">The <see cref="DateTime"/> object to read.</param>
		/// <exception cref="ArgumentOutOfRangeException">time is less than
		/// <see cref="MinSupportedDateTime"/> or greater than <see cref="MaxSupportedDateTime"/>.
		/// </exception>
		/// <returns>An integer that represents the year in the specified <see cref="DateTime"/>
		/// object.</returns>
		public override int GetYear(DateTime time)
		{
			// DEBUG
			Console.WriteLine("VietnameseCalendar.GetYear(), >> time = '{0}'", time);

			this.CheckTicksRange(time.Ticks);
			DateTime date = GetLunarNewYear(time.Year);
			return (time < date ? time.Year - 1 : time.Year);
		}

		/// <summary>
		/// Returns the month in the specified date.
		/// </summary>
		/// <returns>An integer from 1 to 13 that represents the month specified in the time parameter,
		/// </returns>
		/// <param name="time">The <see cref="DateTime"/> object to read.</param>
		public override int GetMonth(DateTime time)
		{
			// DEBUG
			Console.WriteLine("VietnameseCalendar.GetMonth(), >> time = '{0}'", time);

			int year = this.GetYear(time);
			DateTime date = GetLunarNewYear(year);
			int leapMonth = this.GetLeapMonth(year, 0), month = 1;
			while (date < time)
				date = date.AddDays(GetMonthLength(year, month++, leapMonth));
			month = (date > time ? month - 1 : month);

			// DEBUG
			Console.WriteLine("VietnameseCalendar.GetMonth(), << month = {0}", month);
			return month;
		}

		/// <summary>
		/// Calculates the day of the month in the specified date.
		/// </summary>
		/// <returns>An integer from 1 through 30 that represents the day of the month
		/// specified in the time parameter.</returns>
		/// <param name="time">The <see cref="DateTime"/> object to read. </param>
		public override int GetDayOfMonth(DateTime time)
		{
			// DEBUG
			Console.WriteLine("VietnameseCalendar.GetDayOfMonth(), >> time = '{0}'", time);

			int year = this.GetYear(time);
			DateTime date = GetLunarNewYear(year), date2 = date;
			int leapMonth = this.GetLeapMonth(year, 0), month = 1;
			while (date < time)
			{
				if (date < time) date2 = date;
				date = date.AddDays(GetMonthLength(year, month++, leapMonth));
			}
			return (date > time ? (time - date2).Days + 1 : 1);
		}

		/// <summary>
		/// Calculates the day of the week in the specified date.
		/// </summary>
		/// <returns>One of the <see cref="DayOfWeek"/> values that represents the day of the week
		/// specified in the time parameter.</returns>
		/// <param name="time">The <see cref="DateTime"/> object to read.</param>
		/// <exception cref="ArgumentOutOfRangeException">time is less than
		/// <see cref="MinSupportedDateTime"/> or greater than <see cref="MaxSupportedDateTime"/>.
		/// </exception>
		public override DayOfWeek GetDayOfWeek(DateTime time)
		{
			this.CheckTicksRange(time.Ticks);
			return (DayOfWeek)(((int)Math.Round((double)time.Ticks / 864000000000 + 1)) % 7);
		}

		/// <summary>
		/// Calculates the day of the year in the specified date.
		/// </summary>
		/// <returns>An integer from 1 through 354 in a common year, or 1 through 384 in a leap year,
		/// that represents the day of the year specified in the time parameter.</returns>
		/// <param name="time">The <see cref="DateTime"/> object to read.</param>
		public override int GetDayOfYear(DateTime time)
		{
			// DEBUG
			Console.WriteLine("VietnameseCalendar.GetDayOfYear(), >> time = '{0}'", time);

			int year = this.GetYear(time);
			DateTime date = GetLunarNewYear(year);
			return (time - date).Days + 1;
		}

		/// <summary>
		/// Determines whether the specified year in the specified era is a leap year.
		/// </summary>
		/// <returns>true if the specified year is a leap year; otherwise, false.</returns>
		/// <param name="era">An integer that represents the era.</param>
		/// <param name="year">An integer that represents the year.</param>
		/// <exception cref="ArgumentOutOfRangeException">year or era is outside the range supported
		/// by this calendar.</exception>
		public override bool IsLeapYear(int year, int era)
		{
			return (this.GetLeapMonth(year, era) > 0);
		}

		/// <summary>
		/// Determines whether the specified month in the specified year and era is a leap month.
		/// </summary>
		/// <returns>true if the month parameter is a leap month; otherwise, false.</returns>
		/// <param name="era">An integer that represents the era.</param>
		/// <param name="month">An integer from 1 through 13 that represents the month.</param>
		/// <param name="year">An integer that represents the year.</param>
		/// <exception cref="ArgumentOutOfRangeException">year, month, or era is outside the range
		/// supported by this calendar.</exception>
		public override bool IsLeapMonth(int year, int month, int era)
		{
			int leapMonth = this.GetLeapMonth(year, era);
			this.CheckMonthRange(month, leapMonth);
			return ((leapMonth > 0) && (month == leapMonth));
		}

		/// <summary>
		/// Determines whether the specified date in the specified era is a leap day.
		/// </summary>
		/// <returns>true if the specified day is a leap day; otherwise, false.</returns>
		/// <param name="era">An integer that represents the era.</param>
		/// <param name="month">An integer from 1 through 13 that represents the month.</param>
		/// <param name="day">An integer from 1 through 30 that represents the day.</param>
		/// <param name="year">An integer that represents the year.</param>
		/// <exception cref="ArgumentOutOfRangeException">year, month, day, or era is outside
		/// the range supported by this calendar.</exception>
		public override bool IsLeapDay(int year, int month, int day, int era)
		{
			bool ret = this.IsLeapMonth(year, month, era);
			int daysInMonth = GetMonthLength(year, month, this.GetLeapMonth(year, era));
			if ((day < 1) || (day > daysInMonth))
			{
				throw new ArgumentOutOfRangeException("day", string.Format(CultureInfo.CurrentCulture,
					resource.GetString("ArgumentOutOfRange_Day"), daysInMonth, month));
			}
			return ret;
		}

		/// <summary>
		/// Calculates the number of months in the specified year and era.
		/// </summary>
		/// <returns>The number of months in the specified year in the specified era.
		/// The return value is 12 months in a common year or 13 months in a leap year.</returns>
		/// <param name="era">An integer that represents the era.</param>
		/// <param name="year">An integer that represents the year.</param>
		/// <exception cref="ArgumentOutOfRangeException">year or era is outside the range supported
		/// by this calendar.</exception>
		public override int GetMonthsInYear(int year, int era)
		{
			return this.IsLeapYear(year, era) ? 13 : 12;
		}

		/// <summary>
		/// Calculates the number of days in the specified month of the specified year and era.
		/// </summary>
		/// <returns>The number of days in the specified month of the specified year and era.</returns>
		/// <param name="era">An integer that represents the era.</param>
		/// <param name="month">An integer from 1 through 12 in a common year,
		/// or 1 through 13 in a leap year, that represents the month.</param>
		/// <param name="year">An integer that represents the year.</param>
		/// <exception cref="ArgumentOutOfRangeException">year, month, or era is outside the range
		/// supported by this calendar.</exception>
		public override int GetDaysInMonth(int year, int month, int era)
		{
			int leapMonth = this.GetLeapMonth(year, era);
			this.CheckMonthRange(month, leapMonth);
			return GetMonthLength(year, month, leapMonth);
		}

		/// <summary>
		/// Calculates the number of days in the specified year and era.
		/// </summary>
		/// <returns>The number of days in the specified year and era.</returns>
		/// <param name="era">An integer that represents the era.</param>
		/// <param name="year">An integer that represents the year.</param>
		/// <exception cref="ArgumentOutOfRangeException">year or era is outside the range supported
		/// by this calendar.</exception>
		public override int GetDaysInYear(int year, int era)
		{
			int leapMonth = this.GetLeapMonth(year, era), count = 0;
			for (int month = 1, len = (leapMonth > 0 ? 13 : 12); month <= len; month++)
				count += GetMonthLength(year, month, leapMonth);
			return count;
		}

		/// <summary>
		/// Calculates the date that is the specified number of months away from the specified date.
		/// </summary>
		/// <returns>A new <see cref="DateTime"/> object that results from adding the specified
		/// number of months to the time parameter.</returns>
		/// <param name="months">The number of months to add.</param>
		/// <param name="time">The <see cref="DateTime"/> object to add months to.</param>
		/// <exception cref="ArgumentOutOfRangeException">months is less than -120000 or greater than 120000.
		/// -or- time is less than <see cref="MinSupportedDateTime"/> or greater than
		/// <see cref="MaxSupportedDateTime"/>.</exception>
		/// <exception cref="ArgumentException">The result is outside the supported range of a
		/// <see cref="DateTime"/> object.</exception>
		public override DateTime AddMonths(DateTime time, int months)
		{
			// DEBUG
			Console.WriteLine("VietnameseCalendar.AddMonths(), >> time = '{0}', months = {1}", time, months);
			return time.AddMonths(months);

			/*
			int year = time.Year, month = time.Month, day = time.Day;
			// TODO: this.FromDateTime(time, out year, out month, out day);
			int leapMonth = this.GetLeapMonth(year, 0);

			// adds months
			int inc; month += months;
			while (month < 1 || month > 13 || (month == 13 && leapMonth == 0))
			{
				inc = ((month < 1) ? -1 : 1);
				// re-calculates the lunar year
				leapMonth = this.GetLeapMonth((year = year + inc), 0);
				month += ((leapMonth > 0) ? 13 : 12) * (-inc);
			}

			// TODO: decrease the lunar day when overload
			int daysInMonth = GetMonthLength(year, month, leapMonth);
			if (day > daysInMonth) day = daysInMonth;

			return new DateTime(year, month, day, time.Hour, time.Minute,
				time.Second, time.Millisecond, this);
			*/
		}

		/// <summary>
		/// Calculates the date that is the specified number of years away from the specified date.
		/// </summary>
		/// <returns>A new <see cref="DateTime"/> object that results from adding the specified number
		/// of years to the time parameter.</returns>
		/// <param name="time">The <see cref="DateTime"/> object to add years to.</param>
		/// <param name="years">The number of years to add.</param>
		/// <exception cref="ArgumentOutOfRangeException">time is less than
		/// <see cref="MinSupportedDateTime"/> or greater than <see cref="MaxSupportedDateTime"/>.
		/// </exception>
		/// <exception cref="ArgumentException">The result is outside the supported range of a
		/// <see cref="DateTime"/> object.</exception>
		public override DateTime AddYears(DateTime time, int years)
		{
			// DEBUG
			Console.WriteLine("VietnameseCalendar.AddYears(), >> time = '{0}', years = {1}", time, years);
			return time.AddYears(years);

			/*
			int year = time.Year + years, month = time.Month, day = time.Day;
			// TODO: re-calculates the lunar month
			int leapMonth = this.GetLeapMonth(year, 0);
			if (month > 12 && leapMonth == 0) month = 12;

			// TODO: decrease the lunar day when overload
			int daysInMonth = GetMonthLength(year, month, leapMonth);
			if (day > daysInMonth) day = daysInMonth;

			return new DateTime(year, month, day, time.Hour, time.Minute,
				time.Second, time.Millisecond, this);
			*/
		}

		/// <summary>
		/// Returns a <see cref="DateTime"/> object that is set to the specified date, time, and era.
		/// </summary>
		/// <returns>A <see cref="DateTime"/> object that is set to the specified date, time, and era.
		/// </returns>
		/// <param name="era">An integer that represents the era.</param>
		/// <param name="month">An integer from 1 through 13 that represents the month.</param>
		/// <param name="millisecond">An integer from 0 through 999 that represents the millisecond.</param>
		/// <param name="day">An integer from 1 through 30 that represents the day.</param>
		/// <param name="minute">An integer from 0 through 59 that represents the minute.</param>
		/// <param name="year">An integer that represents the year.</param>
		/// <param name="hour">An integer from 0 through 23 that represents the hour.</param>
		/// <param name="second">An integer from 0 through 59 that represents the second.</param>
		/// <exception cref="ArgumentOutOfRangeException">year, month, day, hour, minute, second,
		/// millisecond, or era is outside the range supported by this calendar.</exception>
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute,
			int second, int millisecond, int era)
		{
			// DEBUG
			Console.WriteLine("VietnameseCalendar.ToDateTime(), >> year = {0}, month = {1}, day = {2}"
				+ ", hour = {3}, minute = {4}, second = {5}, millisecond = {6}, era = {7}",
				year, month, day, hour, minute, second, millisecond, era);

			// validate parameters
			int leapMonth = this.GetLeapMonth(year, era);
			this.CheckMonthRange(month, leapMonth);
			int days = GetMonthLength(year, month, leapMonth);
			if ((day < 1) || (day > days))
			{
				throw new ArgumentOutOfRangeException("day", string.Format(CultureInfo.CurrentCulture,
					resource.GetString("ArgumentOutOfRange_Day"), days, month));
			}
			// Lunar New Year's Day
			DateTime time = GetLunarNewYear(year);

			days = day;	// count number of days from the Lunar New Year's Day to the specified lunar-date
			while (--month > 0) days += GetMonthLength(year, month, leapMonth);

			// DEBUG
			//Console.WriteLine("VietnameseCalendar.ToDateTime(), time.Hour = {0}", time.Hour);
			return time.AddDays(days - 1)	// appends time to the object
				.AddHours(hour).AddMinutes(minute).AddSeconds(second).AddMilliseconds(millisecond);
		}
		#endregion

		#region "public methods"
		/// <summary>
		/// Calculates the leap month for the specified year and era.
		/// </summary>
		/// <returns>A positive integer from 1 through 13 that indicates the leap month in the
		/// specified year and era.
		/// -or-
		/// Zero if this calendar does not support a leap month, or if the year and era parameters
		/// do not specify a leap year.</returns>
		/// <param name="era">An integer that represents the era.</param>
		/// <param name="year">An integer that represents the year.</param>
		/// <exception cref="ArgumentOutOfRangeException">year or era is outside the range supported
		/// by this calendar.</exception>
		public override int GetLeapMonth(int year, int era)
		{
			this.CheckEraRange(era);
			this.CheckYearRange(year);
			int leapMonth = GetYearCode(year) & 0xf;
			return (leapMonth > 0) ? (leapMonth + 1) : 0;
		}

		/// <summary>
		/// Converts the specified two-digit year to a four-digit year.
		/// </summary>
		/// <returns>An integer that contains the four-digit representation of the year parameter.</returns>
		/// <param name="year">A two-digit integer that represents the year to convert.</param>
		/// <exception cref="ArgumentOutOfRangeException">year is outside the range supported
		/// by this calendar.</exception>
		public override int ToFourDigitYear(int year)
		{
			year = base.ToFourDigitYear(year);
			this.CheckYearRange(year);
			return year;
		}

		/// <summary>
		/// Calculates the lunar-date for the specified solar-date.
		/// </summary>
		/// <param name="time">Solar date to convert.</param>
		/// <param name="year">Output lunar-year.</param>
		/// <param name="month">Output lunar-month of the year.</param>
		/// <param name="day">Output lunar-day of the month.</param>
		/// <exception cref="ArgumentOutOfRangeException">time is outside the range supported
		/// by this calendar.</exception>
		public virtual void FromDateTime(DateTime time, out int year, out int month, out int day)
		{
			this.CheckTicksRange(time.Ticks);
			// calculates the lunar-year
			DateTime date = GetLunarNewYear(time.Year);
			if (time < date) date = GetLunarNewYear(time.Year - 1);
			year = date.Year;	// lunar-year
			// gets the year's leap month (if it has)
			int leapMonth = GetYearCode(year) & 0xf;
			if (leapMonth > 0) leapMonth++;

			DateTime date2 = date; month = day = 1;
			// scans the floor month nearest with the solar-day
			while (date < time)
			{
				if (date < time) date2 = date;
				date = date.AddDays(GetMonthLength(year, month++, leapMonth));
			}
			if (date > time)
			{
				month--;		// lunar-month
				day += (time - date2).Days;
			}
			// TODO: exception!
		}

		/// <summary>
		/// Returns the number of days since 1/1/4713 BC noon.
		/// </summary>
		public static double JulianDayNumber(DateTime time)
		{
			double a = Math.Floor((14.0D - time.Month) / 12);
			double y = time.Year + 4800 - a;
			double m = time.Month + 12 * a - 3;
			return time.Day + Math.Floor((153 * m + 2) / 5) + 365 * y + Math.Floor(y / 4)
				- Math.Floor(y / 100) + Math.Floor(y / 400) - 32045 + (time.Hour - 12) / 24
				+ time.Minute / 1440 + time.Second / 86400 + time.Millisecond / 86400000;
		}

		/// <summary>
		/// Compute the longitude of the sun at any time.
		/// Algorithm from: "Astronomical Algorithms" by Jean Meeus, 1998.
		/// </summary>
		public static double SunLongitude(DateTime time)
		{
			double jdn = JulianDayNumber(time) + 0.5 - 7 /* Vietnam TimeZone */ / 24.0;

			// Time in Julian centuries from 2000-01-01 12:00:00 GMT
			double t = (jdn - 2451545.0) / 36525;
			double t2 = t * t;
			double dr = Math.PI / 180;	// degree to radian
			// mean anomaly, degree
			double m = 357.52910 + 35999.05030 * t - 0.0001559 * t2 - 0.00000048 * t * t2;
			double l0 = 280.46645 + 36000.76983 * t + 0.0003032 * t2; // mean longitude, degree
			double dl = (1.914600 - 0.004817 * t - 0.000014 * t2) * Math.Sin(dr * m);
			dl = dl + (0.019993 - 0.000101 * t) * Math.Sin(dr * 2 * m)
				+ 0.000290 * Math.Sin(dr * 3 * m);
			double theta = l0 + dl;	// true longitude, degree
			// obtain apparent longitude by correcting for nutation and aberration
			double omega = 125.04 - 1934.136 * t;
			double lambda = theta - 0.00569 - 0.00478 * Math.Sin(omega * dr);
			// Convert to radians
			lambda = lambda * dr;
			// Normalize to (0, 2*PI)
			return lambda - Math.PI * 2 * (Math.Floor(lambda / (Math.PI * 2)));
		}

		/// <summary>
		/// Returns a string that represents the Minor Solar Terms of the specified date.
		/// </summary>
		/// <remarks>
		/// Compute the sun segment at start (00:00) of the day with the given integral
		/// Julian day number. The time zone if the time difference between local time and UTC: 7.0
		/// for UTC+7:00. The function returns a number between 0 and 23.
		/// From the day after March equinox and the 1st major term after March equinox, 0 is returned.
		/// After that, return 1, 2, 3 ...
		/// </remarks>
		public virtual string GetMinorSolarTerms(DateTime date)
		{
			this.CheckTicksRange(date.Ticks);
			return minorSolarTerms[(int)Math.Floor(SunLongitude(date) / Math.PI * 12)];
		}

		/// <summary>
		/// Returns the lunar year's name as a pairs of selestial stems and terrestrial branches.
		/// </summary>
		/// <param name="year">The lunar year to spelling.</param>
		/// <returns>The lunar year's name as a pairs of selestial stems and terrestrial branches.</returns>
		/// <exception cref="ArgumentOutOfRangeException">year is outside the range supported
		/// by this calendar.</exception>
		public virtual string GetYearName(int year)
		{
			this.CheckYearRange(year);
			return selestialStems[(year + 6) % 10] + " " + terrestrialBranches[(year + 8) % 12];
		}

		/// <summary>
		/// Returns the lunar day's name as a pairs of selestial stems and terrestrial branches.
		/// </summary>
		/// <param name="date">The solar date.</param>
		/// <exception cref="ArgumentOutOfRangeException">date is outside the range supported
		/// by this calendar.</exception>
		public virtual string GetDayName(DateTime date)
		{
			this.CheckTicksRange(date.Ticks);
			int jd = (int)Math.Floor(JulianDayNumber(date));
			return selestialStems[(jd + 9) % 10] + " " + terrestrialBranches[(jd + 1) % 12];
		}

		/// <summary>
		/// Returns the lunar month's name as a pairs of selestial stems and terrestrial branches.
		/// </summary>
		/// <param name="year">The lunar year.</param>
		/// <param name="month">The lunar month (from 1 to 13).</param>
		/// <exception cref="ArgumentOutOfRangeException">date is outside the range supported
		/// by this calendar.</exception>
		public virtual string GetMonthName(int year, int month)
		{
			int leapMonth = this.GetLeapMonth(year, 0);
			this.CheckMonthRange(month, leapMonth);
			int i = ((leapMonth > 0 && month >= leapMonth) ? -1 : 0);
			return selestialStems[(year * 12 + month + i + 3) % 10] + " "
				+ terrestrialBranches[(month + i + 1) % 12]
				+ ((leapMonth > 0 && month == leapMonth) ? " (nhu\u1EADn)" : string.Empty);
		}

		public virtual string GetPropitiousHour(DateTime date)
		{
			int jdn = (int)Math.Floor(JulianDayNumber(date));
			int chiOfDay = (jdn + 1) % 12, count = 0;
			// same values for Ty' (1) and Ngo. (6), for Suu and Mui etc.
			string gioHD = propitiousHour[chiOfDay % 6];
			StringBuilder ret = new StringBuilder();
			for (int i = 0; i < 12; i++)
			{
				if (gioHD[i] != '0')
				{
					ret.Append(terrestrialBranches[i]).Append(" (")
						.Append((i * 2 + 23) % 24).Append('-').Append((i * 2 + 1) % 24).Append(')');
					if (count++ < 5) ret.Append(", "); //if (count == 3) ret.AppendLine();
				}
			}
			return ret.ToString();
		}

		/// <summary>
		/// Can cua gio Chinh Ty (00:00) cua ngay voi JDN nay.
		/// </summary>
		public virtual string GetHourZeroName(DateTime time)
		{
			int jdn = (int)Math.Floor(JulianDayNumber(time));
			return selestialStems[(jdn - 1) * 2 % 10] + " " + terrestrialBranches[0];
		}
		#endregion
	}
}
