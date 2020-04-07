/// <license>
/// This file is part of Ordisoftware Hebrew Calendar.
/// Copyright 2016-2020 Olivier Rogier.
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
/// <edited> 2020-03 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.HebrewCalendar
{

  /// <summary>
  /// Provide hebreu letters class.
  /// </summary>
  static public class HebrewLetters
  {

    /// <summary>
    /// Indicate letters keyboard codes.
    /// </summary>
    static public readonly string[] Codes = 
    {
      "a", "b", "g", "d", "h", "v", "z", "x", "u", "y", "k",
      "l", "m", "n", "c", "i", "p", "j", "q", "r", ">", "t"
    };

    /// <summary>
    /// Indicate finale letters enabled keys values.
    /// </summary>
    static private readonly Dictionary<char, char> FinaleDisable = new Dictionary<char, char>()
    {
      { '!', 'k' }, { ',', 'm' }, { ']', 'n' }, { '[', 'p' }, { '/', 'j' }
    };

    /// <summary>
    /// Indicate finale letters disabled keys values.
    /// </summary>
    static private Dictionary<char, char> FinaleEnable = new Dictionary<char, char>()
    {
      { 'k', '!' }, { 'm', ',' }, { 'n', ']' }, { 'p', '[' }, { 'j', '/' }
    };

    /// <summary>
    // Convert finale letters from www.fourmilab.ch/etexts/www/hebrew/Bible.
    /// </summary>
    static public string SetFinale(string str, bool enable)
    {
      var array = enable ? FinaleEnable : FinaleDisable;
      str = str.Trim();
      if ( str.Length == 0 ) return str;
      char c = str[0];
      foreach ( var v in array )
        if ( c == v.Key )
        {
          c = v.Value;
          break;
        }
      str = c + str.Remove(0, 1);
      return str;
    }

    /// <summary>
    // Convert all finale letters to non finale.
    /// </summary>
    static public string UnFinaleAll(string str)
    {
      foreach ( var v in FinaleDisable )
        str = str.Replace(v.Key, v.Value);
      return str;
    }

    /// <summary>
    // Convert standard hebrew letters of a word to hebrew font key codes.
    /// </summary>
    static public string ConvertToHebrewFont(string str)
    {
      string result = "";
      foreach ( char c in str.RemoveDiacritics() )
        result = ConvertToKey(c) + result;
      return result;
    }

    /// <summary>
    // Convert hebrew font key codes to standard hebrew letters.
    /// </summary>
    static public string ConvertToUnicode(string str)
    {
      string result = "";
      foreach ( char c in str )
        result = ConvertToUnicode(c) + result;
      return result;
    }

    /// <summary>
    // Convert letters from www.fourmilab.ch/etexts/www/hebrew/Bible to font codes.
    /// </summary>
    static public char ConvertToKey(char c)
    {
      switch ( c )
      {
        case 'א': return 'a';
        case 'ב': return 'b';
        case 'ג': return 'g';
        case 'ד': return 'd';
        case 'ה': return 'h';
        case 'ו': return 'v';
        case 'ז': return 'z';
        case 'ח': return 'x';
        case 'ט': return 'u';
        case 'י': return 'y';
        case 'כ': return 'k';
        case 'ך': return '!';
        case 'ל': return 'l';
        case 'מ': return 'm';
        case 'ם': return ',';
        case 'נ': return 'n';
        case 'ן': return ']';
        case 'ס': return 'c';
        case 'ע': return 'i';
        case 'פ': return 'p';
        case 'ף': return '[';
        case 'צ': return 'j';
        case 'ץ': return '/';
        case 'ק': return 'q';
        case 'ר': return 'r';
        case 'ש': return '>';
        case 'ת': return 't';
        case ':': return '.';
        case '-': return ' ';
        default: return ' ';
      }
    }

    static public char ConvertToUnicode(char c)
    {
      switch ( c )
      {
        case 'a': return 'א';
        case 'b': return 'ב';
        case 'g': return 'ג';
        case 'd': return 'ד';
        case 'h': return 'ה';
        case 'v': return 'ו';
        case 'z': return 'ז';
        case 'x': return 'ח';
        case 'u': return 'ט';
        case 'y': return 'י';
        case 'k': return 'כ';
        case '!': return 'ך';
        case 'l': return 'ל';
        case 'm': return 'מ';
        case ',': return 'ם';
        case 'n': return 'נ';
        case ']': return 'ן';
        case 'c': return 'ס';
        case 'i': return 'ע';
        case 'p': return 'פ';
        case '[': return 'ף';
        case 'j': return 'צ';
        case '/': return 'ץ';
        case 'q': return 'ק';
        case 'r': return 'ר';
        case '>': return 'ש';
        case 't': return 'ת';
        case '.': return ':';
        case ' ': return ' ';
        default: return ' ';
      }
    }

    /// <summary>
    /// Indicate letters simple values.
    /// </summary>
    static public readonly int[] ValuesSimple =
    {
      1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20,
      30, 40, 50, 60, 70, 80, 90, 100, 200, 300, 400
    };

    /// <summary>
    /// Indicate letters simple values.
    /// </summary>
    static public readonly int[] ValuesFull =
    {
      111, 412, 83, 434, 6, 12, 67, 418, 419, 20, 100,
      74, 90, 106, 120, 130, 81, 104, 186, 510, 360, 406
    };

    /// <summary>
    /// Indicate letters names.
    /// </summary>
    static public readonly Dictionary<string, string[]> Names
      = new Dictionary<string, string[]>()
      {
        {
          "en", new string[]
          { "Alef", "Bet", "Gimel", "Dalet", "He", "Vav", "Zayin", "'Het", "Tet", "Yod", "Kaf",
            "Lamed", "Mem", "Nun", "Samek", "'Ayin", "Pay", "Tsadi", "Qof", "Resh", "Shin", "Tav"
          }
        },
        {
          "fr", new string[]
          { "Alef", "Bet", "Guimel", "Dalet", "Hé", "Vav", "Zayin", "'Het", "Tet", "Youd", "Kaf",
            "Lamed", "Mem", "Noun", "Samek", "'Ayin", "Pé", "Tsadi", "Qouf", "Resh", "Shin", "Tav"
          }
        }
      };

    /// <summary>
    /// Indicate hebrew letters names.
    /// </summary>
    static public readonly string[] HebrewNames =
    {
      "pla", "tyb", "lmyg", "tld", "ah", "vv", "]yz", "tx", "tu", "dvy", "pk",
      "dml", ",m", "]vn", "!mc", "]yi", "hp", "ydj", "pvq", ">r", "]y>", "vt",
    };

  }

}
