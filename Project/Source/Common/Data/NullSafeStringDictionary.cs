/// <license>
/// This file is part of Ordisoftware Hebrew Calendar/Letters/Words.
/// Copyright 2012-2020 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at 
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file, 
/// then You may include the notice in a location(such as a LICENSE file in a 
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2020-08 </created>
/// <edited> 2020-08 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.HebrewCommon
{

  /// <summary>
  /// Provide null safe dictionary.
  /// </summary>
  public class NullSafeStringDictionary : Dictionary<string, string>
  {
    public new string this[string key]
    {
      get
      {
        return ContainsKey(key) ? base[key] : "";
      }
      set
      {
        if ( ContainsKey(key) )
          base[key] = value;
        else
          Add(key, value);
      }
    }
  }

}
