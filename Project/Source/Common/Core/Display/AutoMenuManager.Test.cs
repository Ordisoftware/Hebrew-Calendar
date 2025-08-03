/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2025 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2021-10 </created>
/// <edited> 2021-10 </edited>
namespace Ordisoftware.Core;

static class AutoMenuManagerTest
{

  static public void Run()
  {
    var choicesMain = new List<AutoMenuChoice>();
    var choices1 = new List<AutoMenuChoice>();
    var choices2 = new List<AutoMenuChoice>();

    const string headerMain = "WELCOME";
    const string header1 = "Menu 1";
    const string header2 = "Menu 2";

    var root = new AutoMenu(headerMain, choicesMain, null);
    var menu1 = new AutoMenu(header1, choices1, root);
    var menu2 = new AutoMenu(header2, choices2, root);

    choicesMain.Add(new AutoMenuChoice("Go to menu 1", menu1.Run));
    choicesMain.Add(new AutoMenuChoice("Go to menu 2", menu2.Run));

    choices1.Add(new AutoMenuChoice("Option 1", null));
    choices1.Add(new AutoMenuChoice("Option 2", null));
    choices1.Add(new AutoMenuChoice("Option 3", null));
    choices1.Add(new AutoMenuChoice("Option 4", null));

    choices2.Add(new AutoMenuChoice("Option 1", null));
    choices2.Add(new AutoMenuChoice("Option 2", null));

    new AutoMenuManager(root).Run();
  }

}
