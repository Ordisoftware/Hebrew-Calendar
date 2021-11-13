/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2021 Olivier Rogier.
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
/// <edited> 2019-11 </edited>
using System;
using System.Collections.Generic;

namespace Ordisoftware.Core
{

  public class MenuChoice
  {
    public string Title { get; }
    public Action Action { get; }
    public MenuChoice(string title, Action action)
    {
      Title = title;
      Action = action;
    }
  }

  public partial class AutoMenu
  {
    private string Separator => new('-', SeperatorLength);

    private readonly string Header;

    private readonly List<MenuChoice> Choices;

    private readonly AutoMenu Root;

    const int SeperatorLength = 100;

    const string ExitMessage = "Goodbye.";

    public AutoMenu(string header, List<MenuChoice> choices, AutoMenu root)
    {
      Header = header;
      Choices = choices;
      Root = root;
    }

    private void Print()
    {
      for ( int index = 0; index < Choices.Count; index++ )
        Console.WriteLine($"{index + 1} - {Choices[index].Title}");
      Console.WriteLine($"{Choices.Count + 1} - {( Root == null ? "Exit" : "Previous menu" )}");
    }

    public void Run()
    {
      Console.Clear();
      Console.WriteLine(Separator);
      Console.WriteLine(Header);
      Console.WriteLine();
      Print();
      Console.WriteLine(Separator);
      uint choice = GetUserChoice();
      if ( choice == Choices.Count + 1 )
        if ( Root == null )
          Console.WriteLine(ExitMessage);
        else
          Root.Run();
      else
      {
        var action = Choices[(int)choice - 1].Action;
        if ( action != null )
          action();
        else
        {
          Console.WriteLine("Not implemented yet - Press a key to continue.");
          Console.ReadKey();
          Run();
        }
      }
    }

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
        Console.WriteLine(Separator);
        Console.WriteLine(Header);
        Console.WriteLine();
        Print();
        Console.WriteLine(Separator);
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

  public class MenuManager
  {
    private readonly AutoMenu Root;

    public MenuManager(AutoMenu root)
    {
      Root = root;
    }

    public void Run()
    {
      Root.Run();
    }

  }

}
