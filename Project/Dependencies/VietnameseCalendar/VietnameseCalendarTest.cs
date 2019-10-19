using System;
using System.Text;

using NUnit.Framework;

namespace System.Globalization
{
	[TestFixture()]
	public class VietnameseCalendarTest
	{
		private VietnameseCalendar vnCal;

		[SetUp()]
		public void Initialize()
		{
			this.vnCal = new VietnameseCalendar();
		}

		[Test()]
		public void TwoDigitYearMax()
		{
			//Console.WriteLine(DateTime.Today.ToString("yyyyMMddTHHmmssZ"));
			//Console.WriteLine(Guid.NewGuid().ToString("N"));
			//
			Console.WriteLine(":: VietnameseCalendar.GetTwoDigitYearMax(1) = {0}",
				VietnameseCalendar.GetTwoDigitYearMax(1));
			Assert.AreEqual(2029, this.vnCal.TwoDigitYearMax);
		}

		[Test()]
		public void FromDateTime()
		{
			DateTime date = new DateTime(2008, 9, 30); int yyyy, mm, dd;
			this.vnCal.FromDateTime(date, out yyyy, out mm, out dd);
			// DEBUG
			Console.WriteLine("2008/9/30 = '{0}/{1}/{2}'", yyyy, mm, dd);
			//
			Assert.AreEqual("Mậu Tý", this.vnCal.GetYearName(yyyy));
			Assert.AreEqual(9, mm); Assert.AreEqual(2, dd);
			Assert.AreEqual("Nhâm Tuất", this.vnCal.GetMonthName(yyyy, mm));
			Assert.AreEqual("Quý Dậu", this.vnCal.GetDayName(date));
			Assert.AreEqual("Nhâm Tý", this.vnCal.GetHourZeroName(date));
			Assert.AreEqual("Thu phân", this.vnCal.GetMinorSolarTerms(date));
			Assert.AreEqual("Tý (23-1), Dần (3-5), Mão (5-7), Ngọ (11-13), Mùi (13-15), Dậu (17-19)",
				this.vnCal.GetPropitiousHour(date));
		}

		[Test()]
		public void ToDateTime()
		{
			DateTime date = new DateTime(2008, 9, 1, this.vnCal);
			// DEBUG
			Console.WriteLine("Mậu Tý/9/1 = '{0}'", date);
			//
			Assert.AreEqual(2008, date.Year); Assert.AreEqual(9, date.Month); Assert.AreEqual(29, date.Day);
		}

		[Test()]
		public void CheckLeapYear2006()
		{
			// DEBUG
			Console.WriteLine("Year 2006 IsLeap = {0}", this.vnCal.GetLeapMonth(2006, 0));
			DateTime date = new DateTime(2006, 1, 1, this.vnCal);	// tet am lich
			Assert.AreEqual(2006, date.Year); Assert.AreEqual(1, date.Month); Assert.AreEqual(29, date.Day);
			//
			DateTime date2 = date.AddDays(-28);
			Assert.AreEqual("Ất Dậu", this.vnCal.GetYearName(this.vnCal.GetYear(date2)));
			Assert.AreEqual(12, this.vnCal.GetMonth(date2));
			Assert.AreEqual(2, this.vnCal.GetDayOfMonth(date2));

			//
			date = new DateTime(2006, 8, 1, this.vnCal);	// thang nhuan
			Assert.AreEqual("Bính Tuất", this.vnCal.GetYearName(2006)); Assert.AreEqual(2006, date.Year);
			Assert.AreEqual(8, date.Month); Assert.AreEqual(24, date.Day);
			Assert.AreEqual("Bính Thân (nhuận)", this.vnCal.GetMonthName(2006, 8));
			//
			date2 = date.AddDays(-30);
			Assert.AreEqual(7, date2.Month); Assert.AreEqual(7, this.vnCal.GetMonth(date2));
			Assert.AreEqual(25, date2.Day); Assert.AreEqual(1, this.vnCal.GetDayOfMonth(date2));
			//
			Assert.AreEqual("Bính Thân", this.vnCal.GetMonthName(2006, 7));
			Assert.AreEqual("Ất Mão", this.vnCal.GetDayName(date2));
			Assert.AreEqual("Bính Tý", this.vnCal.GetHourZeroName(date2));
			Assert.AreEqual("Đại thử", this.vnCal.GetMinorSolarTerms(date2));
			Assert.AreEqual("Tý (23-1), Dần (3-5), Mão (5-7), Ngọ (11-13), Mùi (13-15), Dậu (17-19)",
				this.vnCal.GetPropitiousHour(date2));

			//
			date2 = new DateTime(2006, 13, 1, this.vnCal);	// cuoi nam luon
			Assert.AreEqual(2007, date2.Year);
			Assert.AreEqual(1, date2.Month); Assert.AreEqual(19, date2.Day);
			//
			Assert.AreEqual("Tân Sửu", this.vnCal.GetMonthName(2006, 13));
			Assert.AreEqual("Quý Sửu", this.vnCal.GetDayName(date2));
			Assert.AreEqual("Tiểu hàn", this.vnCal.GetMinorSolarTerms(date2));
		}

		/// <summary>
		/// Toan bo lich am cua 2 nam tinh tu nam hien tai.
		/// </summary>
		[Test()]
		public void PrintCurrentYear()
		{
			// current solar year
			int yyyy, mm, dd, lm, cy = DateTime.Today.Year;
			DateTime date = new DateTime(cy++, 1, 1);

			// iCalendar
			StringBuilder buff = new StringBuilder();
			buff.AppendLine("BEGIN:VCALENDAR")
				.AppendLine("VERSION:2.0")
				.AppendLine("METHOD:PUBLISH");

			// all months in the current year
			while (date.Year <= cy)
			{
				this.vnCal.FromDateTime(date, out yyyy, out mm, out dd);
				lm = this.vnCal.GetLeapMonth(yyyy, 0);
				// DEBUG
				//Console.WriteLine("Converting {0} to {1}/{2}/{3}", date.ToShortDateString(), yyyy, mm, dd);

				// append to the iCalendar
				CreateEvent(buff, date, 1, false, "Vietnamese Lunar Calendar",
					string.Format("ÂL {0}/{1}{2}", dd,
					((lm > 0 && mm >= lm) ? mm - 1 : mm), ((lm > 0 && lm == mm) ? " nhuận" : "")),
					string.Format("Ngày {0} tháng {1}{2} năm {3}\\nTiết: {4}\\nGiờ HĐ: {5}",
					this.vnCal.GetDayName(date), this.vnCal.GetMonthName(yyyy, mm),
					((lm > 0 && lm == mm) ? " nhuận" : ""), this.vnCal.GetYearName(yyyy),
					this.vnCal.GetMinorSolarTerms(date), this.vnCal.GetPropitiousHour(date)));

				date = date.AddDays(1);	// loop to next year
			}
			buff.AppendLine("END:VCALENDAR");

			// dump
			Console.Write(buff);
		}

		/// <summary>
		/// Cac ngay nghi am lich + duong lich cua VN trong 2 nam.
		/// </summary>
		[Test()]
		public void PrintHolidays()
		{
			// current solar year
			int yyyy, mm, dd, lm, cy = DateTime.Today.Year;
			DateTime date = new DateTime(cy++, 1, 1);

			// iCalendar
			StringBuilder buff = new StringBuilder();
			buff.AppendLine("BEGIN:VCALENDAR")
				.AppendLine("VERSION:2.0")
				.AppendLine("METHOD:PUBLISH");

			bool isLM;
			// all months in the current year
			while (date.Year <= cy)
			{
				this.vnCal.FromDateTime(date, out yyyy, out mm, out dd);
				lm = this.vnCal.GetLeapMonth(yyyy, 0);
				isLM = (lm > 0 && mm == lm); if (lm > 0 && mm >= lm) mm--;
				// DEBUG
				//Console.WriteLine("Converting {0} to {1}/{2}/{3}", date.ToShortDateString(), yyyy, mm, dd);

				// append to the iCalendar
				if (date.Month == 1 && date.Day == 1)	// Tết Dương Lịch
				{
					CreateEvent(buff, date, 1, true, "Vietnam Public Holidays", "Tết dương lịch", "");
				}
				if (mm == 1 && dd == 1 && !isLM)		// Tết Nguyên Đán
				{
					CreateEvent(buff, date.AddDays(-1), 4, true, "Vietnam Public Holidays",
						"Tết Nguyên Đán", "Tết cổ truyền của dân tộc\\nNăm " + this.vnCal.GetYearName(yyyy));
				}
				if (mm == 3 && dd == 10 && !isLM)		// Giỗ tổ Hùng Vương
				{
					CreateEvent(buff, date, 1, true, "Vietnam Public Holidays",
						"Giỗ Tổ Hùng Vương",
						"Đền Hùng, Phú Thọ\\nTưởng nhớ đến công ơn các Vua Hùng đã có công dựng nước.");
				}
				if (date.Month == 4 && date.Day == 30)	// Ngày giải phóng miền Nam
				{
					CreateEvent(buff, date, 1, true, "Vietnam Public Holidays",
						"Ngày giải phóng miền Nam, thống nhất đất nước", "Kết thúc Chiến tranh Việt Nam");
				}
				if (date.Month == 5 && date.Day == 1)	// Quốc tế Lao động
				{
					CreateEvent(buff, date, 1, true, "Vietnam Public Holidays", "Quốc tế Lao động", "");
				}
				if (date.Month == 9 && date.Day == 2)	// Quốc khánh
				{
					CreateEvent(buff, date, 1, true, "Vietnam Public Holidays",
						"Quốc khánh", "Kỉ niệm ngày thành lập nước CHXHCN Việt Nam");
				}
				/*--------------------------------------------------------------------------------------*/
				if (date.Month == 2 && date.Day == 3)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays",
						"Thành lập Đảng Cộng sản Việt Nam", "");
				}
				if (date.Month == 2 && date.Day == 27)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Ngày Thầy thuốc Việt Nam", "");
				}
				if (date.Month == 3 && date.Day == 8)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Quốc tế Phụ nữ", "");
				}
				if (date.Month == 6 && date.Day == 1)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Quốc tế Thiếu nhi", "");
				}
				if (date.Month == 7 && date.Day == 27)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Ngày Thương binh Liệt sĩ", "");
				}
				if (date.Month == 10 && date.Day == 10)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Ngày Giải phóng Thủ đô", "");
				}
				if (date.Month == 10 && date.Day == 20)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Ngày Phụ nữ Việt Nam", "");
				}
				if (date.Month == 11 && date.Day == 20)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Ngày Nhà giáo Việt Nam", "");
				}
				if (date.Month == 12 && date.Day == 22)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays",
						"Ngày thành lập Quân đội Nhân dân Việt Nam", "");
				}
				if (date.Month == 12 && date.Day == 24)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Lễ Giáng Sinh", "");
				}
				/*--------------------------------------------------------------------------------------*/
				if (mm == 1 && dd == 15 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Rằm Tháng Giêng", "");
				}
				if (mm == 4 && dd == 14 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Tết Dân tộc Khmer Nam Bộ", "");
				}
				if (mm == 4 && dd == 15 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Lễ Phật Đản", "");
				}
				if (mm == 5 && dd == 5 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Tết Đoan Ngọ", "");
				}
				if (mm == 7 && dd == 15 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Vu Lan", "");
				}
				if (mm == 8 && dd == 1 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Tết Katê - Dân tộc Chăm", "");
				}
				if (mm == 8 && dd == 15 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Tết Trung Thu", "");
				}
				if (mm == 12 && dd == 23 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Holidays", "Ông Táo chầu trời", "");
				}
				/*--------------------------------------------------------------------------------------*/
				if (mm == 1 && dd == 4 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội đền Hai Bà Trưng", "Mê Linh, Vĩnh Phúc");
				}
				if (mm == 1 && dd == 4 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội Liễu Đôi", "Nam Định");
				}
				if (mm == 1 && dd == 8 && !isLM)
				{
					CreateEvent(buff, date, 2, false, "Vietnam Culture Holidays",
						"Hội Chùa Đậu", "Thường Tín, Hà Tây");
				}
				if (mm == 1 && dd == 5 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội Đống Đa", "Hà Nội, Tây Sơn - Bình Định");
				}
				if (mm == 1 && dd == 6 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội Chùa Hương", "Hà Tây\\nTháng 1 - Tháng 3");
				}
				if (mm == 1 && dd == 10 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội đua Voi", "Buôn Ma Thuột");
				}
				if (mm == 1 && dd == 13 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội Lim", "Bắc Ninh");
				}
				if (mm == 1 && dd == 15 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội Côn Sơn", "Hải Dương");
				}
				if (mm == 1 && dd == 15 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội Xuân Núi Bà", "Tây Ninh");
				}
				if (mm == 3 && dd == 6 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội Chùa Tây Phương", "Thạch Thất - Hà Tây");
				}
				if (mm == 3 && dd == 7 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội Chùa Thầy", "Quốc Oai - Hà Tây");
				}
				if (mm == 3 && dd == 1 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội Đâm Trâu", "Buôn Ma Thuột, Đắk Lắk\\nTháng 3");
				}
				if (mm == 4 && dd == 9 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội Thánh Gióng", "Hà Nội");
				}
				if (mm == 4 && dd == 26 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội Bà Chúa Xứ", "Châu Đốc, An Giang");
				}
				if (mm == 8 && dd == 2 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội Lăng Lê Văn Duyệt", "TP Hồ Chí Minh");
				}
				if (mm == 8 && dd == 9 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội Chọi Trâu Đồ Sơn", "Hải Phòng");
				}
				if (mm == 8 && dd == 16 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội Nghinh Ông", "Tiền Giang - Bến Tre - TP Hồ Chí Minh - Bình Thuận");
				}
				if (mm == 8 && dd == 20 && !isLM)
				{
					CreateEvent(buff, date, 1, false, "Vietnam Culture Holidays",
						"Hội đền Kiếp Bạc", "Hải Dương");
				}

				date = date.AddDays(1);	// loop to next year
			}
			buff.AppendLine("END:VCALENDAR");

			// dump
			Console.Write(buff);
		}
		private static void CreateEvent(StringBuilder buff, DateTime start, int duration,
			bool isPublic, string category, string summary, string description)
		{
			// append to the iCalendar
			buff.AppendLine("BEGIN:VEVENT")
				//.AppendLine("CLASS:PUBLIC")
				.AppendLine("STATUS:CONFIRMED")
				.AppendLine("TRANSP:OPAQUE")
				.Append("UID:").AppendLine(Guid.NewGuid().ToString())
				.Append("DTSTAMP:").AppendLine(DateTime.Now.ToString("yyyyMMddTHHmmssZ"))
				.Append("DTSTART;VALUE=DATE:").AppendLine(start.ToString("yyyyMMdd"))
				.Append("DTEND;VALUE=DATE:").AppendLine(start.AddDays(duration).ToString("yyyyMMdd"));
			//.Append("CREATED:").AppendLine(DateTime.Now.ToString("yyyyMMddTHHmmssZ"));
			if (isPublic)
				buff.AppendLine("RRULE:FREQ=YEARLY;INTERVAL=1");
			buff.Append("CATEGORY:").AppendLine(category)
				.Append("SUMMARY:").AppendLine(summary);
			if (!string.IsNullOrEmpty(description))
				buff.Append("DESCRIPTION:").AppendLine(description);
			buff//.Append("LAST-MODIFIED:").AppendLine(DateTime.Now.ToString("yyyyMMddTHHmmssZ"))
				.AppendLine("END:VEVENT");
		}

		/// <summary>
		/// Danh muc nhac nho cac ngay mung 1 va ngay ram.
		/// </summary>
		[Test()]
		public void PrintAllmostDays()
		{
			// current solar year
			int yyyy, mm, dd, lm, cy = DateTime.Today.Year;
			DateTime date = new DateTime(cy++, 1, 1);

			// iCalendar
			StringBuilder buff = new StringBuilder();
			buff.AppendLine("BEGIN:VCALENDAR")
				.AppendLine("VERSION:2.0")
				.AppendLine("METHOD:PUBLISH");

			// all months in the current year
			while (date.Year <= cy)
			{
				this.vnCal.FromDateTime(date, out yyyy, out mm, out dd);
				lm = this.vnCal.GetLeapMonth(yyyy, 0);
				// DEBUG
				//Console.WriteLine("Converting {0} to {1}/{2}/{3}", date.ToShortDateString(), yyyy, mm, dd);

				if ((dd == 1 || dd == 15) && mm != 1)
				{
					// append to the iCalendar
					CreateEvent(buff, date, 1, false, "Vietnamese Almost Lunar Days",
						string.Format("{0} tháng {1}{2}", (dd == 1 ? "Mùng 1" : "Rằm"),
						((lm > 0 && mm >= lm) ? mm - 1 : mm),
						((lm > 0 && mm == lm) ? " nhuận" : string.Empty)),
						"Năm " + this.vnCal.GetYearName(yyyy));
				}

				date = date.AddDays(1);	// loop to next year
			}
			buff.AppendLine("END:VCALENDAR");

			// dump
			Console.Write(buff);
		}
	}//
}
