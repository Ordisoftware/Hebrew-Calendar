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
/// <edited> 2021-02 </edited>
using System;

namespace Ordisoftware.Core
{

  /// <summary>
  /// Provide localization helper.
  /// </summary>
  static public partial class SysTranslations
  {

    static public readonly TranslationsDictionary DatabaseSetDSNError
      = new TranslationsDictionary()
      {
        [Language.EN] = "Error creating or updating SQLite ODBC DSN.",
        [Language.FR] = "Erreur de création ou de mise à jour du DSN ODBC SQLite."
      };

    static public readonly TranslationsDictionary FatalGenerateError
      = new TranslationsDictionary()
      {
        [Language.EN] = "Fatal error while generating data." + Globals.NL +
                        ApplicationMustExit[Language.EN] + Globals.NL +
                        ContactSupport[Language.EN] + Globals.NL2 +
                        "{0}",

        [Language.FR] = "Erreur fatale lors de la génération des données." + Globals.NL +
                        ApplicationMustExit[Language.FR] + Globals.NL +
                        ContactSupport[Language.FR] + Globals.NL2 +
                        "{0}"
      };

    static public readonly TranslationsDictionary DatabaseIntegrityError
      = new TranslationsDictionary()
      {
        [Language.EN] = $"Database integrity error:{Globals.NL2}{{0}}",
        [Language.FR] = $"Erreur d'intégrité de la base de données :{Globals.NL2}{{0}}"
      };

    static public readonly TranslationsDictionary DatabaseVacuumError
      = new TranslationsDictionary()
      {
        [Language.EN] = "Database vacuum failed.",
        [Language.FR] = "Echec du vacuum de la base de données."
      };

    static public readonly TranslationsDictionary DatabaseNoProcessConcurrency
      = new TranslationsDictionary()
      {
        [Language.EN] = "Database can't be modified while multiple instance of the application are running.",
        [Language.FR] = "La base de données ne peut pas être modifiée lorsque plusieurs instances de l'application sont en cours d'éxécution."
      };

    static public readonly TranslationsDictionary DatabaseTableLocked
      = new TranslationsDictionary()
      {
        [Language.EN] = "The table {0} is used by other processes and therefore cannot be modified or exported: " + Globals.NL2 +
                        "{1}" + Globals.NL2 +
                        "You must close the edit window for this table in these applications." + Globals.NL2 +
                        "This state is checked every {2} seconds." + Globals.NL2 +
                        "You can also verify this manually.",

        [Language.FR] = "La table {0} est utilisée par d'autres processus et ne peut donc pas être modifiée ou exportée: " + Globals.NL2 +
                        "{1}" + Globals.NL2 +
                        "Vous devez fermer la fenêtre d'édition de cette table dans ces applications." + Globals.NL2 +
                        "Cet état est vérifié toutes les {2} secondes." + Globals.NL2 +
                        "Vous pouvez également vérifier cela manuellement."
      };

    static public readonly TranslationsDictionary AskToCheckParametersAfterDatabaseUpgraded
      = new TranslationsDictionary()
      {
        [Language.EN] = "Database upgraded." + Globals.NL2 +
                        "Do you want check the parameters?",

        [Language.FR] = "La base de données a été mise à jour." + Globals.NL2 +
                        "Voulez-vous vérifier les paramètres ?"
      };

    static public readonly TranslationsDictionary AskToResetData
      = new TranslationsDictionary
      {
        [Language.EN] = "The data will be restored to their default values. " + Globals.NL2 +
                        "All changes will be lost." + Globals.NL2 +
                        AskToContinue[Language.EN],

        [Language.FR] = "Les données seront restaurées à leurs valeurs par défaut." + Globals.NL2 +
                        "Toutes les moidifications seront perdues." + Globals.NL2 +
                        AskToContinue[Language.FR]
      };

    static public readonly TranslationsDictionary AskToOptimizeDatabase
      = new TranslationsDictionary()
      {
        [Language.EN] = "Optimization process will close and reopen the database." + Globals.NL2 +
                         AskToContinue[Language.EN],

        [Language.FR] = "Le processus d'optimisation va fermer et rouvrir la base de données." + Globals.NL2 +
                         AskToContinue[Language.FR]
      };

    static public readonly TranslationsDictionary AskToLoadInstalledData
      = new TranslationsDictionary()
      {
        [Language.EN] = "This action will load the data installed with the application." + Globals.NL2 +
                        "All modifications will be lost." + Globals.NL2 +
                        AskToContinue[Language.EN],

        [Language.FR] = "Cette action va charger les données installées avec l'application." + Globals.NL2 +
                        "Toutes les modifications seront perdues." + Globals.NL2 +
                        AskToContinue[Language.FR]
      };

    static public readonly TranslationsDictionary DBDropTableError
      = new TranslationsDictionary()
      {
        [Language.EN] = $"Error on drop table:{Globals.NL2}{{0}}",
        [Language.FR] = $"Erreur à la suppression de la table :{Globals.NL2}{{0}}",
      };

    static public readonly TranslationsDictionary DBCreateTableError
      = new TranslationsDictionary()
      {
        [Language.EN] = $"Error on create table:{Globals.NL2}{{0}}",
        [Language.FR] = $"Erreur à la création de la table :{Globals.NL2}{{0}}",
      };

    static public readonly TranslationsDictionary DBCreateColumnError
      = new TranslationsDictionary()
      {
        [Language.EN] = $"Error on create column:{Globals.NL2}{{0}}",
        [Language.FR] = $"Erreur à la création de la colonne :{Globals.NL2}{{0}}",
      };

  }

}
