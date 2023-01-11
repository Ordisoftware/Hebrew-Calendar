/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2023 Olivier Rogier.
/// See www.ordisoftware.com for more information.
/// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
/// If a copy of the MPL was not distributed with this file, You can obtain one at
/// https://mozilla.org/MPL/2.0/.
/// If it is not possible or desirable to put the notice in a particular file,
/// then You may include the notice in a location(such as a LICENSE file in a
/// relevant directory) where a recipient would be likely to look for such a notice.
/// You may add additional accurate notices of copyright ownership.
/// </license>
/// <created> 2019-11 </created>
/// <edited> 2022-11 </edited>
namespace Ordisoftware.Core;

public readonly record struct AutoMenuChoice(string Title, Action Action);

public record class AutoMenu(string Header, List<AutoMenuChoice> Choices, AutoMenu Root)
{

  private void Print()
  {
    for ( int index = 0; index < Choices.Count; index++ )
      Console.WriteLine($"{index + 1} - {Choices[index].Title}");
    Console.WriteLine($"{Choices.Count + 1} - {( Root is null ? "Exit" : "Previous menu" )}");
  }

  public void Run()
  {
    Console.Clear();
    Console.WriteLine(AutoMenuManager.Separator);
    Console.WriteLine(Header);
    Console.WriteLine();
    Print();
    Console.WriteLine(AutoMenuManager.Separator);
    int choice = (int)GetUserChoice();
    if ( choice == Choices.Count + 1 )
      if ( Root is null )
        Console.WriteLine(AutoMenuManager.ExitMessage);
      else
        Root.Run();
    else
    {
      var action = Choices[choice - 1].Action;
      if ( action is not null )
        action();
      else
      {
        Console.WriteLine("Not implemented yet - Press a key to continue.");
        Console.ReadKey();
        Run();
      }
    }
  }

  [SuppressMessage("Performance", "CA1806:Ne pas ignorer les résultats des méthodes", Justification = "<En attente>")]
  uint GetUserChoice()
  {
    uint choice;
    getInput();
    while ( choice < 1 || choice > Choices.Count + 1 )
    {
      Console.WriteLine("Invalid choice - Press a key to try again.");
      Console.ReadKey();
      Console.Clear();
      Console.Clear();
      Console.WriteLine(AutoMenuManager.Separator);
      Console.WriteLine(Header);
      Console.WriteLine();
      Print();
      Console.WriteLine(AutoMenuManager.Separator);
      getInput();
    }
    return choice;
    //
    void getInput()
    {
      uint.TryParse(Console.ReadLine(), out choice);
      Console.WriteLine();
    }
  }

}
