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
/// <created> 2016-04 </created>
/// <edited> 2021-05 </edited>
using System;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Localization strings.
  /// </summary>
  static partial class SysTranslations
  {

    static public TranslationsDictionary AskToContinue
    {
      get
      {
        if ( _AskToContinue == null )
          _AskToContinue = new TranslationsDictionary
          {
            [Language.EN] = "Do you want to continue?",
            [Language.FR] = "Voulez-vous continuer ?"
          };
        return _AskToContinue;
      }
    }
    static private TranslationsDictionary _AskToContinue;

    static public readonly TranslationsDictionary NotImplemented
      = new TranslationsDictionary
      {
        [Language.EN] = "Not implemented: {0}",
        [Language.FR] = "Non implémenté : {0}",
      };

    static public readonly TranslationsDictionary NotYetAvailable
      = new TranslationsDictionary
      {
        [Language.EN] = "Not yet available.",
        [Language.FR] = "Pas encore disponible."
      };

    static public readonly TranslationsDictionary TermNotFound
      = new TranslationsDictionary
      {
        [Language.EN] = "Term \"{0}\" not found.",
        [Language.FR] = "Terme \"{0}\" non trouvé."
      };

    static public readonly TranslationsDictionary AskToDeleteFile
      = new TranslationsDictionary
      {
        [Language.EN] = $"Delete file:{Globals.NL2}{{0}}?",
        [Language.FR] = $"Effacer le fichier :{Globals.NL2}{{0}}?",
      };

    static public readonly TranslationsDictionary AskToOpenAllLinks
      = new TranslationsDictionary
      {
        [Language.EN] = "Do you want to open all \"{0}\" links?",
        [Language.FR] = "Voulez-vous ouvrir tous les liens de \"{0}\" ?"
      };

    static public readonly TranslationsDictionary AskToEmptyHistory
      = new TranslationsDictionary
      {
        [Language.EN] = "Empty history?",
        [Language.FR] = "Vider l'historique ?"
      };

    static public readonly TranslationsDictionary AskToEmptyBookmarks
      = new TranslationsDictionary
      {
        [Language.EN] = "Empty bookmarks?",
        [Language.FR] = "Vider les signets ?"
      };

    static public readonly TranslationsDictionary AskToDeleteBookmark
      = new TranslationsDictionary
      {
        [Language.EN] = "Erase the bookmark?",
        [Language.FR] = "Effacer le signet ?"
      };

    static public readonly TranslationsDictionary AskToDeleteBookmarkAll
      = new TranslationsDictionary
      {
        [Language.EN] = "Erase all bookmarks?",
        [Language.FR] = "Effacer tous les signets ?"
      };

    static public readonly TranslationsDictionary AskToReplaceBookmark
      = new TranslationsDictionary
      {
        [Language.EN] = "Replace bookmark?",
        [Language.FR] = "Remplacer le signet ?"
      };

    static public readonly TranslationsDictionary ActionCancel
      = new TranslationsDictionary
      {
        [Language.EN] = "Cancel",
        [Language.FR] = "Annuler",
      };

    static public readonly TranslationsDictionary ActionClose
      = new TranslationsDictionary
      {
        [Language.EN] = "Close",
        [Language.FR] = "Fermer",
      };

    static public readonly TranslationsDictionary Valid
      = new TranslationsDictionary
      {
        [Language.EN] = "Valid",
        [Language.FR] = "Valide"
      };

    static public readonly TranslationsDictionary Invalid
      = new TranslationsDictionary
      {
        [Language.EN] = "Invalid",
        [Language.FR] = "Invalide"
      };

    static public readonly TranslationsDictionary Accepted
      = new TranslationsDictionary
      {
        [Language.EN] = "Accepted",
        [Language.FR] = "Accepté"
      };

    static public readonly TranslationsDictionary Rejected
      = new TranslationsDictionary
      {
        [Language.EN] = "Rejected",
        [Language.FR] = "Rejeté"
      };

    static public readonly TranslationsDictionary First
      = new TranslationsDictionary
      {
        [Language.EN] = "First",
        [Language.FR] = "Premier"
      };

    static public readonly TranslationsDictionary Previous
      = new TranslationsDictionary
      {
        [Language.EN] = "Previous",
        [Language.FR] = "Précédent"
      };

    static public readonly TranslationsDictionary Next
      = new TranslationsDictionary
      {
        [Language.EN] = "Next",
        [Language.FR] = "Suivant"
      };

    static public readonly TranslationsDictionary Last
      = new TranslationsDictionary
      {
        [Language.EN] = "Last",
        [Language.FR] = "Dernier"
      };

    static public readonly TranslationsDictionary Notes
      = new TranslationsDictionary
      {
        [Language.EN] = "Notes",
        [Language.FR] = "Notes"
      };

    static public readonly TranslationsDictionary ReadOnly
      = new TranslationsDictionary
      {
        [Language.EN] = "Read only",
        [Language.FR] = "Lecture seule"
      };

    static public readonly TranslationsDictionary Uncertain
      = new TranslationsDictionary
      {
        [Language.EN] = "Uncertain",
        [Language.FR] = "Incertain"
      };

    static public readonly TranslationsDictionary BadValue
      = new TranslationsDictionary
      {
        [Language.EN] = "Wrong value",
        [Language.FR] = "Valeur incorrecte"
      };

    static public readonly TranslationsDictionary NullSlot
      = new TranslationsDictionary
      {
        [Language.EN] = "(null)",
        [Language.FR] = "(null)"
      };

    static public string GetOrNull(this string str) => str ?? EmptySlot.GetLang();

    static public readonly TranslationsDictionary UnknownSlot
      = new TranslationsDictionary
      {
        [Language.EN] = "(unknown)",
        [Language.FR] = "(inconnu)"
      };

    static public string GetOrUnknownIfNullOrEmpty(this string str) => str.IsNullOrEmpty() ? UnknownSlot.GetLang() : str;
    static public string GetOrUnknownIfEmpty(this string str) => str.IsEmpty() ? UnknownSlot.GetLang() : str;

    static public readonly TranslationsDictionary UndefinedSlot
      = new TranslationsDictionary
      {
        [Language.EN] = "(not defined)",
        [Language.FR] = "(non définit)"
      };

    static public string GetOrUndefinedIfNullOrEmpty(this string str) => str.IsNullOrEmpty() ? UndefinedSlot.GetLang() : str;
    static public string GetOrUndefinedIfEmpty(this string str) => str.IsEmpty() ? UndefinedSlot.GetLang() : str;

    static public readonly TranslationsDictionary EmptySlot
      = new TranslationsDictionary
      {
        [Language.EN] = "(empty)",
        [Language.FR] = "(vide)"
      };

    static public string GetOrEmpty(this string str) => str.IsEmpty() ? EmptySlot.GetLang() : str;

    static public readonly TranslationsDictionary ErrorSlot
      = new TranslationsDictionary
      {
        [Language.EN] = "(error)",
        [Language.FR] = "(erreur)"
      };

    static public readonly TranslationsDictionary MemorySizeSuffix
      = new TranslationsDictionary
      {
        [Language.EN] = "B",
        [Language.FR] = "o"
      };

    static public readonly NullSafeDictionary<Language, NullSafeStringList> MillisecondsFormat
      = new NullSafeDictionary<Language, NullSafeStringList>
      {
        [Language.EN] = new NullSafeStringList
        {
          "{4} ms",
          "{3} s",
          "{2} m {3} s",
          "{1} h {2} m {3} s",
          "{0} d {1} h {2} m {3} s",
        },
        [Language.FR] = new NullSafeStringList
        {
          "{4} ms",
          "{3} s",
          "{2} m {3} s",
          "{1} h {2} m {3} s",
          "{0} j {1} h {2} m {3} s",
        }
      };

  }

}
