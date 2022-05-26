/// <license>
/// This file is part of Ordisoftware Core Library.
/// Copyright 2004-2022 Olivier Rogier.
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
/// <edited> 2022-05 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Localization strings.
/// </summary>
static partial class SysTranslations
{

  static public TranslationsDictionary AskToContinue
  {
    get
    {
      return _AskToContinue ??= new TranslationsDictionary
      {
        [Language.EN] = "Do you want to continue?",
        [Language.FR] = "Voulez-vous continuer ?"
      };
    }
  }
  static private TranslationsDictionary _AskToContinue;

  static public readonly TranslationsDictionary NotImplemented = new()
  {
    [Language.EN] = "Not implemented: {0}",
    [Language.FR] = "Non implémenté : {0}",
  };

  static public readonly TranslationsDictionary NotYetAvailable = new()
  {
    [Language.EN] = "Not yet available.",
    [Language.FR] = "Pas encore disponible."
  };

  static public readonly TranslationsDictionary TermNotFound = new()
  {
    [Language.EN] = "Term \"{0}\" not found.",
    [Language.FR] = "Terme \"{0}\" non trouvé."
  };

  static public readonly TranslationsDictionary AskToDeleteFile = new()
  {
    [Language.EN] = $"Delete file:{Globals.NL2}{{0}}?",
    [Language.FR] = $"Effacer le fichier :{Globals.NL2}{{0}}?",
  };

  static public readonly TranslationsDictionary ConfigureProviders = new()
  {
    [Language.EN] = "Configure providers",
    [Language.FR] = "Configurer les fournisseurs"
  };

  static public readonly TranslationsDictionary AskToOpenAllLinks = new()
  {
    [Language.EN] = "Do you want to open all the {1} links of this menu?" + Globals.NL2 + "{0}",
    [Language.FR] = "Voulez-vous ouvrir tous les {1} liens de ce menu ?" + Globals.NL2 + "{0}"
  };

  static public readonly TranslationsDictionary AskToEmptyHistory = new()
  {
    [Language.EN] = "Empty history?",
    [Language.FR] = "Vider l'historique ?"
  };

  static public readonly TranslationsDictionary AskToEmptyBookmarks = new()
  {
    [Language.EN] = "Empty bookmarks?",
    [Language.FR] = "Vider les signets ?"
  };

  static public readonly TranslationsDictionary AskToDeleteBookmark = new()
  {
    [Language.EN] = "Erase the bookmark?" + Globals.NL2 + "{0}",
    [Language.FR] = "Effacer le signet ?" + Globals.NL2 + "{0}"
  };

  static public readonly TranslationsDictionary AskToDeleteBookmarkAll = new()
  {
    [Language.EN] = "Erase all bookmarks?",
    [Language.FR] = "Effacer tous les signets ?"
  };

  static public readonly TranslationsDictionary AskToReplaceBookmark = new()
  {
    [Language.EN] = $"Replace bookmark?{Globals.NL2}Actual: {{0}}{Globals.NL2}New: {{1}}",
    [Language.FR] = $"Remplacer le signet ?{Globals.NL2}Actuel : {{0}}{Globals.NL2}Nouveau : {{1}}",
  };

  static public readonly TranslationsDictionary ImportBookmarksTooManyBookmarks = new()
  {
    [Language.EN] = $"Can't import more than {{0}} bookmarks.{Globals.NL}" +
                    $"Please check the file having {{1}}:{Globals.NL2}{{2}}",

    [Language.FR] = $"Impossible d'importer plus de {{0}} signets.{Globals.NL}" +
                    $"Veuillez vérifier le fichier qui en contient {{1}} :{Globals.NL2}{{2}}",
  };

  static public readonly TranslationsDictionary ActionCancel = new()
  {
    [Language.EN] = "Cancel",
    [Language.FR] = "Annuler",
  };

  static public readonly TranslationsDictionary ActionClose = new()
  {
    [Language.EN] = "Close",
    [Language.FR] = "Fermer",
  };

  static public readonly TranslationsDictionary ActionCopy = new()
  {
    [Language.EN] = "Copy",
    [Language.FR] = "Copier",
  };

  static public readonly TranslationsDictionary Valid = new()
  {
    [Language.EN] = "Valid",
    [Language.FR] = "Valide"
  };

  static public readonly TranslationsDictionary Invalid = new()
  {
    [Language.EN] = "Invalid",
    [Language.FR] = "Invalide"
  };

  static public readonly TranslationsDictionary Accepted = new()
  {
    [Language.EN] = "Accepted",
    [Language.FR] = "Accepté"
  };

  static public readonly TranslationsDictionary Rejected = new()
  {
    [Language.EN] = "Rejected",
    [Language.FR] = "Rejeté"
  };

  static public readonly TranslationsDictionary First = new()
  {
    [Language.EN] = "First",
    [Language.FR] = "Premier"
  };

  static public readonly TranslationsDictionary Previous = new()
  {
    [Language.EN] = "Previous",
    [Language.FR] = "Précédent"
  };

  static public readonly TranslationsDictionary Next = new()
  {
    [Language.EN] = "Next",
    [Language.FR] = "Suivant"
  };

  static public readonly TranslationsDictionary Last = new()
  {
    [Language.EN] = "Last",
    [Language.FR] = "Dernier"
  };

  static public readonly TranslationsDictionary Notes = new()
  {
    [Language.EN] = "Notes",
    [Language.FR] = "Notes"
  };

  static public readonly TranslationsDictionary Memo = new()
  {
    [Language.EN] = "Memo",
    [Language.FR] = "Mémo"
  };

  static public readonly TranslationsDictionary Board = new()
  {
    [Language.EN] = "Board",
    [Language.FR] = "Tableau"
  };

  static public readonly TranslationsDictionary NavigationTip = new()
  {
    [Language.EN] = "Tip: use Home, End, PageUp and PageDown to navigate.",
    [Language.FR] = "Astuce : utilisez Début, Fin, PagePrec et PageSuiv pour naviguer."
  };

  static public readonly TranslationsDictionary ReadOnly = new()
  {
    [Language.EN] = "Read only",
    [Language.FR] = "Lecture seule"
  };

  static public readonly TranslationsDictionary Uncertain = new()
  {
    [Language.EN] = "Uncertain",
    [Language.FR] = "Incertain"
  };

  static public readonly TranslationsDictionary BadValue = new()
  {
    [Language.EN] = "Wrong value",
    [Language.FR] = "Valeur incorrecte"
  };

  static public readonly TranslationsDictionary NonthingSlot = new()
  {
    [Language.EN] = "(nothing)",
    [Language.FR] = "(aucun)"
  };

  static public readonly TranslationsDictionary NullSlot = new()
  {
    [Language.EN] = "(null)",
    [Language.FR] = "(null)"
  };

  static public string GetOrNull(this string str) => str ?? EmptySlot.GetLang();

  static public readonly TranslationsDictionary UnknownSlot = new()
  {
    [Language.EN] = "(unknown)",
    [Language.FR] = "(inconnu)"
  };

  static public string GetOrUnknownIfNullOrEmpty(this string str) => str.IsNullOrEmpty() ? UnknownSlot.GetLang() : str;
  static public string GetOrUnknownIfEmpty(this string str) => str.IsEmpty() ? UnknownSlot.GetLang() : str;

  static public readonly TranslationsDictionary UndefinedSlot = new()
  {
    [Language.EN] = "(not defined)",
    [Language.FR] = "(non définit)"
  };

  static public string GetOrUndefinedIfNullOrEmpty(this string str)
    => str.IsNullOrEmpty() ? UndefinedSlot.GetLang() : str;

  static public string GetOrUndefinedIfEmpty(this string str)
    => str.IsEmpty() ? UndefinedSlot.GetLang() : str;

  static public readonly TranslationsDictionary EmptySlot = new()
  {
    [Language.EN] = "(empty)",
    [Language.FR] = "(vide)"
  };

  static public string GetOrEmpty(this string str)
    => str.IsEmpty() ? EmptySlot.GetLang() : str;

  static public readonly TranslationsDictionary ErrorSlot = new()
  {
    [Language.EN] = "(error)",
    [Language.FR] = "(erreur)"
  };

  static public readonly TranslationsDictionary MemorySizeSuffix = new()
  {
    [Language.EN] = "B",
    [Language.FR] = "o"
  };

  static public readonly NullSafeDictionary<Language, NullSafeStringList> MillisecondsFormat = new()
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
      "{0} j {1} h {2} m {3} s"
    }
  };

}
