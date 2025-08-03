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
/// <created> 2016-04 </created>
/// <edited> 2025-01 </edited>
namespace Ordisoftware.Core;

/// <summary>
/// Localization strings.
/// </summary>
static public partial class SysTranslations
{

  static public readonly TranslationsDictionary DatabaseSetDSNError = new()
  {
    [Language.EN] = "Error creating or updating SQLite ODBC DSN.",
    [Language.FR] = "Erreur de création ou de mise à jour du DSN ODBC SQLite."
  };

  static public readonly TranslationsDictionary NotConnected = new()
  {
    [Language.EN] = "Not connected.",
    [Language.FR] = "Non connecté."
  };

  static public readonly TranslationsDictionary DatabaseTableClosed = new()
  {
    [Language.EN] = "Closed",
    [Language.FR] = "Fermée"
  };

  static public readonly TranslationsDictionary FatalGenerateError = new()
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

  static public readonly TranslationsDictionary DatabaseIntegrityError = new()
  {
    [Language.EN] = $"Database integrity error:{Globals.NL2}{{0}}",
    [Language.FR] = $"Erreur d'intégrité de la base de données :{Globals.NL2}{{0}}"
  };

  static public readonly TranslationsDictionary AskToResetCorruptedDatabase = new()
  {
    [Language.EN] = DatabaseIntegrityError[Language.EN] + Globals.NL2 +
                    "The reset will erase all data." + Globals.NL2 +
                    AskToContinue[Language.EN],

    [Language.FR] = DatabaseIntegrityError[Language.FR] + Globals.NL2 +
                    "La réinitialisation va effacer toutes les données." + Globals.NL2 +
                    AskToContinue[Language.FR]
  };

  static public readonly TranslationsDictionary DatabaseVacuumError = new()
  {
    [Language.EN] = "Database vacuum failed.",
    [Language.FR] = "Échec du vacuum de la base de données."
  };

  static public readonly TranslationsDictionary DatabaseVacuumSuccess = new()
  {
    [Language.EN] = "Database vacuum succeeded.",
    [Language.FR] = "Succès du vacuum de la base de données."
  };

  static public readonly TranslationsDictionary DatabaseNoProcessConcurrency = new()
  {
    [Language.EN] = "Database can't be modified while multiple instance of the application are running.",
    [Language.FR] = "La base de données ne peut pas être modifiée lorsque plusieurs instances de l'application sont en cours d'éxécution."
  };

  static public readonly TranslationsDictionary DatabaseTableLocked = new()
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

  static public readonly TranslationsDictionary AskToCheckDataAfterDbUpgraded = new()
  {
    [Language.EN] = "Database upgraded." + Globals.NL2 +
                    "Do you want check the data?",

    [Language.FR] = "La base de données a été mise à jour." + Globals.NL2 +
                    "Voulez-vous vérifier les données ?"
  };

  static public readonly TranslationsDictionary AskToResetData = new()
  {
    [Language.EN] = "Data will be restored to their default values." + Globals.NL2 +
                    "All changes will be lost and the action cannot be undone." + Globals.NL2 +
                    AskToContinue[Language.EN],

    [Language.FR] = "Les données seront restaurées à leurs valeurs par défaut." + Globals.NL2 +
                    "Toutes les modifications seront perdues et l'action ne pourra pas être annulée." + Globals.NL2 +
                    AskToContinue[Language.FR]
  };

  static public readonly TranslationsDictionary AskToClearCustomData = new()
  {
    [Language.EN] = "All custom data will be erased. " + Globals.NL2 +
                    AskToContinue[Language.EN],

    [Language.FR] = "Toutes les données personnalisées vont être effacées." + Globals.NL2 +
                    AskToContinue[Language.FR]
  };

  static public readonly TranslationsDictionary AskToOptimizeDatabase = new()
  {
    [Language.EN] = "Optimization process will close and reopen the database." + Globals.NL2 +
                     AskToContinue[Language.EN],

    [Language.FR] = "Le processus d'optimisation va fermer et rouvrir la base de données." + Globals.NL2 +
                     AskToContinue[Language.FR]
  };

  static public readonly TranslationsDictionary AskToLoadInstalledData = new()
  {
    [Language.EN] = "This action will load the data installed with the application." + Globals.NL2 +
                    "All modifications will be lost." + Globals.NL2 +
                    AskToContinue[Language.EN],

    [Language.FR] = "Cette action va charger les données installées avec l'application." + Globals.NL2 +
                    "Toutes les modifications seront perdues." + Globals.NL2 +
                    AskToContinue[Language.FR]
  };

  static public readonly TranslationsDictionary DBDropTableError = new()
  {
    [Language.EN] = $"Error on drop table:{Globals.NL2}{{0}}",
    [Language.FR] = $"Erreur à la suppression de la table :{Globals.NL2}{{0}}"
  };

  static public readonly TranslationsDictionary DBCreateTableError = new()
  {
    [Language.EN] = $"Error on create table: {{0}}{Globals.NL2}{{1}}",
    [Language.FR] = $"Erreur à la création de la table : {{0}}{Globals.NL2}{{1}}"
  };

  static public readonly TranslationsDictionary DBCreateIndexError = new()
  {
    [Language.EN] = $"Error on create index : {{0}}{Globals.NL2}{{1}}",
    [Language.FR] = $"Erreur à la création de l'index : {{0}}{Globals.NL2}{{1}}"
  };

  static public readonly TranslationsDictionary DBCreateColumnError = new()
  {
    [Language.EN] = $"Error on create column:{Globals.NL2}{{0}}",
    [Language.FR] = $"Erreur à la création de la colonne :{Globals.NL2}{{0}}"
  };

  static public readonly TranslationsDictionary DBRenameTableError = new()
  {
    [Language.EN] = $"Error on rename table:{Globals.NL2}{{0}} -> {{1}}",
    [Language.FR] = $"Erreur au renommage de la table :{Globals.NL2}{{0}} -> {{1}}"
  };

  static public readonly TranslationsDictionary DBRenameColumnError = new()
  {
    [Language.EN] = $"Error on rename column:{Globals.NL2}{{0}} : {{1}} -> {{2}}",
    [Language.FR] = $"Erreur au renommage de la colonne :{Globals.NL2}{{0}} : {{1}} -> {{2}}",
  };

  static public readonly TranslationsDictionary ColumnTooShort = new()
  {
    [Language.EN] = "Column '{0}' is too short." + Globals.NL2 +
                    "    Available chars: {1}" + Globals.NL +
                    "    Missing chars: {2}",

    [Language.FR] = "La colonne '{0}' est trop petite." + Globals.NL2 +
                    "    Available chars: {1}" + Globals.NL +
                    "    Missing chars: {2}",
  };

  static public readonly TranslationsDictionary UpgradeDatabaseTempTableExists = new()
  {
    [Language.EN] = $"Error upgrading database:{Globals.NL2}    Temp table '{{0}}' already exists.",
    [Language.FR] = $"Erreur lors de la mise à jour de la base de données :{Globals.NL2}    Temp table '{{0}}' existe déjà."
  };

  static public readonly TranslationsDictionary UpgradeDatabaseTableUserChoice = new()
  {
    [Language.EN] = "{0}" + Globals.NL2 +
                    $"Click Retry to rename '{{2}}' in '{{1}}'." + Globals.NL2 +
                    $"Click Ignore to delete '{{2}}' and all its data, but all data from original table '{{1}}' could then be lost." + Globals.NL2 +
                    $"Click Abort to stop the process and check the database or contact the support.",
    [Language.FR] = "{0}" + Globals.NL2 +
                    $"Cliquez sur Réessayer pour renommer '{{2}}' en '{{1}}'." + Globals.NL2 +
                    $"Cliquez sur Ignorer pour supprimer '{{2}}' et toutes ses données, mais toutes les données de la table d'origine '{{1}}' pourraient alors être perdues." + Globals.NL2 +
                    $"Cliquez sur Abandonner pour arrêter le processus et vérifier la base de données ou contacter le support."
  };

}
