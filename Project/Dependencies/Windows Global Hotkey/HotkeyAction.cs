using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable VSSpell001 // Spell Check
namespace Base.Hotkeys
{

  public class HotkeyAction
  {

    public Hotkey Hotkey { get; set; }

    public Action Execute { get; set; }

    public bool Active { get; set; }

    public HotkeyAction(Hotkey hotkey, Action execute, bool active = true)
    {
      Hotkey = hotkey;
      Execute = execute;
      Active = active;
    }

  }

}
#pragma warning restore VSSpell001 // Spell Check
