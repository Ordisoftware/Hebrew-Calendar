using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordisoftware.Core
{

  public partial class AutoMenu
  {

    static internal void Test()
    {
      var choicesMain = new List<MenuChoice>();
      var choices1 = new List<MenuChoice>();
      var choices2 = new List<MenuChoice>();

      string headerMain = "WELCOME";
      string header1 = "Menu 1";
      string header2 = "Menu 2";

      var root = new AutoMenu(headerMain, choicesMain, null);
      var menu1 = new AutoMenu(header1, choices1, root);
      var menu2 = new AutoMenu(header2, choices2, root);

      choicesMain.Add(new MenuChoice("Go to menu 1", menu1.Run));
      choicesMain.Add(new MenuChoice("Go to menu 2", menu2.Run));

      choices1.Add(new MenuChoice("Option 1", null));
      choices1.Add(new MenuChoice("Option 2", null));
      choices1.Add(new MenuChoice("Option 3", null));
      choices1.Add(new MenuChoice("Option 4", null));

      choices2.Add(new MenuChoice("Option 1", null));
      choices2.Add(new MenuChoice("Option 2", null));

      new MenuManager(root).Run();
    }

  }

}
