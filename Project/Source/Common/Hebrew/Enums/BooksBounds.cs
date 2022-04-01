/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2022 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2012-10 </created>
/// <edited> 2022-03 </edited>
namespace Ordisoftware.Hebrew;

[SuppressMessage("Performance", "U2U1004:Public value types should implement equality", Justification = "N/A")]
[StructLayout(LayoutKind.Auto)]
public readonly struct BookBound
{
  public int Min { get; }
  public int Max { get; }
  public BookBound(int min, int max)
  {
    Min = min;
    Max = max;
  }
}

static class BooksBounds
{
  static public readonly BookBound Torah = Create<TorahBook>();
  static public readonly BookBound Neviim = Create<NeviimBook>();
  static public readonly BookBound Ketouvim = Create<KetouvimBook>();
  static private BookBound Create<T>() where T : struct, Enum
    => new(EnumHelper.Min<T>() + 1, EnumHelper.Max<T>() + 1);

  static public readonly NullSafeDictionary<Language, NullSafeOfStringDictionary<TanakBook>> Transcriptions = new()
  {
    [Language.FR] = new NullSafeOfStringDictionary<TanakBook>
    {
      // Torah
      { TanakBook.Bereshit, "Bereshit" },
      { TanakBook.Shemot, "Shemot" },
      { TanakBook.Vayiqra, "Vayiqra" },
      { TanakBook.Bamidbar, "Bamidbar" },
      { TanakBook.Devarim, "Devarim" },
      // Nevi'im 
      { TanakBook.Yehoshoua, "Yehoshoua'" },
      { TanakBook.Shoftim, "Shoftim" },
      { TanakBook.Shemouel_I, "Shemouel I" },
      { TanakBook.Shemouel_II, "Shemouel II" },
      { TanakBook.Melakim_I, "Melakim I" },
      { TanakBook.Melakim_II, "Melakim II" },
      { TanakBook.Yeshayahou, "Yesha'yahou" },
      { TanakBook.Yirmeyahou, "Yirmeyahou" },
      { TanakBook.Yehezqel, "Ye'hezqel" },
      { TanakBook.Hoshea, "Hoshea'" },
      { TanakBook.Yoel, "Yoel" },
      { TanakBook.Amos, "'Amos" },
      { TanakBook.Obadyah, "'Obadyah" },
      { TanakBook.Yonah, "Yonah" },
      { TanakBook.Mikah, "Mikah" },
      { TanakBook.Nahoum, "Na'houm" },
      { TanakBook.Habaqouq, "'Habaqouq" },
      { TanakBook.Tsephaniah, "Tsephaniah" },
      { TanakBook.Hagai, "'Hagai" },
      { TanakBook.Zekaria, "Zekaria" },
      { TanakBook.Malaki, "Malaki" },
      // Ketouvim 
      { TanakBook.Tehilim, "Tehilim" },
      { TanakBook.Mishlei, "Mishlei" },
      { TanakBook.Iyov, "Iyov" },
      { TanakBook.Shir_HaShirim, "Shir HaShirim" },
      { TanakBook.Ruth, "Ruth" },
      { TanakBook.Eikah, "Eikah" },
      { TanakBook.Qohelet, "Qohelet" },
      { TanakBook.Esther, "Esther" },
      { TanakBook.Daniel, "Daniel" },
      { TanakBook.Ezra, "'Ezra" },
      { TanakBook.Nehemiah, "Ne'hemiah" },
      { TanakBook.Divrei_HaYamim_I, "Divrei HaYamim I" },
      { TanakBook.Divrei_HaYamim_II, "Divrei HaYamim II" }
    },
    [Language.EN] = new NullSafeOfStringDictionary<TanakBook>
    {
      // Torah
      { TanakBook.Bereshit, "Bereshit" },
      { TanakBook.Shemot, "Shemot" },
      { TanakBook.Vayiqra, "Vayiqra" },
      { TanakBook.Bamidbar, "Bamidbar" },
      { TanakBook.Devarim, "Devarim" },
      // Nevi'im 
      { TanakBook.Yehoshoua, "Yehoshua'" },
      { TanakBook.Shoftim, "Shoftim" },
      { TanakBook.Shemouel_I, "Shemuel I" },
      { TanakBook.Shemouel_II, "Shemuel II" },
      { TanakBook.Melakim_I, "Melakim I" },
      { TanakBook.Melakim_II, "Melakim II" },
      { TanakBook.Yeshayahou, "Yesha'yahu" },
      { TanakBook.Yirmeyahou, "Yirmeyahu" },
      { TanakBook.Yehezqel, "Ye'hezqel" },
      { TanakBook.Hoshea, "Hoshea'" },
      { TanakBook.Yoel, "Yoel" },
      { TanakBook.Amos, "'Amos" },
      { TanakBook.Obadyah, "'Obadyah" },
      { TanakBook.Yonah, "Yonah" },
      { TanakBook.Mikah, "Mikah" },
      { TanakBook.Nahoum, "Na'hum" },
      { TanakBook.Habaqouq, "'Habaquq" },
      { TanakBook.Tsephaniah, "Tsephaniah" },
      { TanakBook.Hagai, "'Hagai" },
      { TanakBook.Zekaria, "Zekaria" },
      { TanakBook.Malaki, "Malaki" },
      // Ketuvim 
      { TanakBook.Tehilim, "Tehilim" },
      { TanakBook.Mishlei, "Mishlei" },
      { TanakBook.Iyov, "Iyov" },
      { TanakBook.Shir_HaShirim, "Shir HaShirim" },
      { TanakBook.Ruth, "Ruth" },
      { TanakBook.Eikah, "Eikah" },
      { TanakBook.Qohelet, "Qohelet" },
      { TanakBook.Esther, "Esther" },
      { TanakBook.Daniel, "Daniel" },
      { TanakBook.Ezra, "'Ezra" },
      { TanakBook.Nehemiah, "Ne'hemiah" },
      { TanakBook.Divrei_HaYamim_I, "Divrei HaYamim I" },
      { TanakBook.Divrei_HaYamim_II, "Divrei HaYamim II" }
    }
  };

}
