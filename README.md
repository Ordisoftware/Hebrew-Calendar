# Hebrew Calendar

> Licensed under the terms of the [Mozilla Public License 2.0](LICENSE)<br/>
> This project follows the [Manufacturing Software Guidelines](https://github.com/Ordisoftware/Guidelines).<br/>
> [Website](https://www.ordisoftware.com/projects/hebrew-calendar)<br/>
> [Twitter](https://twitter.com/ordisoftware)<br/>

A libre and open-source software written in C# that allows to generate a calendar based on solar and lunar cycles in order to determine the new year and the celebration times according to the Hebrew Torah, as well as to remind Shabbat and Pesach, Shavuot, Rosh Hashanah, Kippur and Sukkot festivities.

## Table of content

1. [Functionalities](#Functionalities)
2. [Review](#Review)
3. [Requirements](#Requirements)
4. [Download](#Download)
5. [Screenshots](#Screenshots)
6. [Videos](#Videos)
7. [Frequently asked questions](#Frequently-asked-questions)
8. [Keyboard shortcuts](#Keyboard-shortcuts)
9. [Future improvements](#Future-improvements)
10. [Changelog](#Changelog)

## Functionalities

- Generate a calendar with sun and moon rises and sets.
- View by tabular text report, visual month or data grid.
- Balloon tip from the Tray Icon to navigate between days with a summary.
- Event reminder for Shabat and celebrations.
- Indicate the weekly parashah.
- Search for a day, a month, or a celebration.
- Window listing the next celebrations.
- Window showing a board of celebrations by years.
- Window showing a board of new moons by years.
- Window showing a board of lunar months description.
- Window showing a board of the parashot.
- Calculate the difference between two dates with bookmarks.
- Advanced dialog to save, copy to the clipboard and print the view and the data.
- Supported export file formats: TXT, CSV, JSON, PNG, JPG, TIFF, BMP.
- English, French.

## Review

[Softpedia.com](https://www.softpedia.com/get/Others/Home-Education/Hebrew-Calendar-Olivier-Rogier.shtml)

_"Efficient and intuitive calendar and reminder app for the Hebrew Torah"_

[![Note](https://www.ordisoftware.com/theme/softpedia4.5-white.png)](https://www.softpedia.com/get/Others/Home-Education/Hebrew-Calendar-Olivier-Rogier.shtml)

## Requirements

- Windows 7 SP1 x32/x64 or higher
- Screen 1024x768 or higher
- Framework .NET 4.7.2
- SQLite ODBC Driver

## Download

**What's new in the latest version**

- The reminder box has been improved.
- An editable parashot board is available in the Tools menu.
- Parashah of the week is indicated for Shabat in visual calendar and in navigation window.
- Visual calendar and navigation window indicates intermediate days of week-long celebrations.
- Image of the Tray Icon changes during a Shabat day or celebration regardless of reminder boxes.
- Application title bar can show lunar today and weekly parashah.
- Web update check is not performed on a day off while the application is running.
- Boards are exportable as TXT files in addition to CSV and JSON.
- Fixed celebrations board showing moon times in the case of sun omer.
- Added keyboard shortchuts to navigate between months having celebrations.
- Added New in version in the Information menu.
- Update web links and Bible study providers.
- Some improvements in appearance and function.

[Last release](https://github.com/Ordisoftware/Hebrew-Calendar/releases/latest)

## Screenshots

[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-viewmonth-en-300x222.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-viewmonth-en.png)&nbsp;&nbsp;&nbsp;&nbsp;[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-raw-en-300x222.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-raw-en.png)

&nbsp;&nbsp;&nbsp;[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-navigation-en-275x300.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-navigation-en.png)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-diffdates-en-349x300.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-diffdates-en.png)

[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-celebrations-en-282x300.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-celebrations-en.png)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![](https://www.ordisoftware.com/uploads/2020/12/hebrew-calendar-celebrationsboard-en-487x300.png)](https://www.ordisoftware.com/uploads/2020/12/hebrew-calendar-celebrationsboard-en.png)

[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-reminderpopup-en-300x126.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-reminderpopup-en.png)&nbsp;&nbsp;&nbsp;&nbsp;[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-locksession-en-300x201.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-locksession-en.png)

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![](https://www.ordisoftware.com/uploads/2020/12/hebrew-calendar-export-en-252x300.png)](https://www.ordisoftware.com/uploads/2020/12/hebrew-calendar-export-en.png)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-preferences-en-300x289.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-preferences-en.png)

## Videos

[![Month view showing video](https://img.youtube.com/vi/EJni1fiXpMk/mqdefault.jpg)](https://www.youtube.com/watch?v=EJni1fiXpMk)&nbsp;&nbsp;&nbsp;&nbsp;[![Showing video](https://img.youtube.com/vi/u9LD-0u3wdE/mqdefault.jpg)](https://www.youtube.com/watch?v=u9LD-0u3wdE)

## Frequently asked questions

#### How to install SQlite ODBC Driver?

The setup installs:

- [sqliteodbc.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc.exe) on Windows 32-bit.
- [sqliteodbc_w64.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc_w64.exe) on Windows 64-bit.

In the event that an error message indicates that a DLL file could not be copied, it is usually due to the fact that an application using this driver already installed is running and is blocking the file. You can ignore this error or close the application in question and restart the installation to obtain a driver update.

#### What to do in case of ODBC datasource connection error?

The software tries to register an ODBC DSN to the registry but in case of problem run:

&emsp;`C:\Program Files\Ordisoftware\Hebrew Calendar\System\RegisterODBC.reg`

Or open the ODBC Datasource Manager (Admin tools in Windows' Control panel) and create a user datasource named:

&emsp;`Hebrew-Calendar` for `SQLite 3 ODBC Driver`

With Database Name sets to:

&emsp;`%USERPROFILE%\AppData\Roaming\Ordisoftware\Hebrew Calendar\Hebrew-Calendar.sqlite`

Watch the [video](https://www.youtube.com/watch?v=WPVF8pj9I3E).

#### What to do if the check update tells that the SSL certificate is wrong or expired?

The software verifies the validity of the certificate of the update server in addition to the SHA-512 checksum of the installation file before downloading and running it. This certificate is normally updated within the two months of its annual expiration and a new version is released. If the application has not been updated within this period, you can manually check the latest version available online.

#### What to do if the calendar month view is ugly?

Reset the preferences to default: it will restore the corrupted values in case of a problem after install or upgrade.

#### What to do if the application does not work normally despite restoring settings?

Use the Start Menu link:

&emsp;`Ordisoftware\Hebrew Calendar\Reset Hebrew Calendar settings`

This will erase all settings as well as those of old versions, which should resolve issues if there is a conflict, otherwise please contact support.

#### What is the Windows double-buffering?

When enabled, this will speed up rendering of the main form when it is displayed, but it may cause a slight black flicker.

When disabled, top menu painting may cause latency.

#### What are command-line options?

- Change interface language (does not change the text report unless using --generate):

  `Ordisoftware.Hebrew.Letters.exe --lang [en|fr]`

- Show the main window:

  `Ordisoftware.Hebrew.Letters.exe --show`

- Hide the main window:

  `Ordisoftware.Hebrew.Letters.exe --hide`

- Regenerate the calendar data:
 
  `Ordisoftware.Hebrew.Letters.exe --generate`

- Show the dates difference calculator:
 
  `Ordisoftware.Hebrew.Letters.exe --diffdates`

- Show the celebrations board:

  `Ordisoftware.Hebrew.Letters.exe --celebrations`

- Show the new moons board board:
 
  `Ordisoftware.Hebrew.Letters.exe --newmoons`

- Show the parashot board:

  `Ordisoftware.Hebrew.Letters.exe --parashot`

These options are cumulative and can be used to control the software when it is already running.

It is therefore possible to use [AutoHotKey](https://www.autohotkey.com) to define for example this Shift + Ctrl + Alt + P command:

```
!^+P:: 
  appPath := "C:\Program Files\Ordisoftware\Hebrew Calendar\Bin\"
  appExe := "Ordisoftware.Hebrew.Calendar.exe"
  Run %appPath%%appExe% --parashot
  return
```

#### What are known problems?

Data generated for cities near the poles can be inconsistent the closer we get, especially with the moon omer, due to some weird ephemeris.

Thus celebration dates may be wrong.

#### What are the times of celebration?

The times of the Torah's celebrations are Pesa'h or Easter which is the liberation of illusions, Shavu'ot or Weeks which is the gift of knowledge, Teru'ah or Ringtone which is the joy of being freedom, Kipurim or Atonement which is the sorrows of losses, and Sukot or Tabernacles which is the construction of the future.

These are important moments of the lunar year in the solar cycle whose purpose is to provide a benevolent evolution of consciousness by the knowledge of the laws of the universe and of life. The Torah says to count these days according to the moon, as opposed to Shabat which is counted according to the sun.

The application uses by default moon omer for celebrations.

If you use moon omer then celebrations dates will be calculated according to seasons and there will be an inversion between north and south hemispheres. In this case, a day is from one moon set to the next set.

You can use traditionnals sun days by modifying the option in the reminder, hence celebrations will be same in north and south. In this case, a day is from one sun set to the next set.

#### What is Shabat?

The Shabat is the "day of rest" where one do not work for a livelihood. Unless there is a vital emergency, the body, the emotions and the spirit are resting there. The study of the Torah is a privileged activity.

The tradition attributes this day to Saturday. We can however think according to Béréshit 1.1 that in the case where the first day is the day of birth as a corollary to the fusion of the gametes then it takes place the day before: thus a person coming to the world on a Sunday will have his Shabat the Saturday. From Béréshit 1.5 and 1.16 as well as from Shémot 20.8 it can be deduced that it lasts from sunset on the eve of the calendar day to sunset on the same day. For example, for a person born in Paris, the Shabat of February 19, 2019 takes place from Friday 18 at 17:25 to Saturday at 17:25 approximately.

The personal Shabat of a maried or concubin or divorced man is the previous day of the birth. A son follows his father's Shabat. The Shabat of a woman is the Shabat of her father or her husband or her concubin.

So the man and the woman respect their mutual cycles. Indeed, during the period when the married or concubine or divorced woman is Nidah from the beginning to the end of the blood flow, her vital field is dissonant and the couple avoid touching each other (the virgin girl is not concerned as long as she had no relations through the openings of the begetting) to avoid to increase as well as to transmit this state to things and people (otherwise we follow the rules of the Torah about that).

If the man were born between midnight and the sunset, the Shabat is the day before. Between sunset and midnight, the Shabat is that day. This day is from previous day (or previous previous day) at sunset to this day (or previous day) at sunset.

The day of the Shabat goes from sunset on the previous calendar day to sunset of that day, with 3% of natural margin that to say about one hour.

The day before, either the man keeps without going out and strengthens the couple during the Shabat, or he goes out and lights up the couple for Shabat, but on Shabat he does not go out of his temple, and except in case of emergency we do not produce, transform and destroys nothing, we don't plan anything, we don't work, we don't cook, we don't shave, we don't cut, we don't make fire, we don't care about information, etc. But we can for example take part in sports, study science and play with children.

If you prefer to use the traditional group Shabat, select for example Saturday for Judaism, Sunday for Christianity or Friday for Islam.

#### What are parashot?

The study of the Weekly Torah portion begins at Sim'hat Torah with the Bereshit section on 22 Tishri in the Land of Israel, or on 23 in Mitsraïm and in the desert, that is on the last day of Sukot, or the next day.

It ends with full reading on Shabat, or the next Shabat if Sim'hat Torah occurs on Shabat. The day after Shabat we move on to the next parashah that we study during the week by reading comments, listening to conferences, learning about science, and examining letters, words and verses, to read it in full on Shabat. And so on from week to week to go through the Torah in a year to build a better future world for oneself, for one's family, for one's community, for one's country, for the Nations, and for the species, thanks to Pesa'h, Shavu'ot, Teru'ah, Kipurim, and Sukot.

Israël is the conceptual worldwide land of the righteous benevolent whose body+spirit, and therefore DNA, is to some notable extent free from ignorance and evil. Sim'hat Torah means 'Joy [bestowed by the] Torah' and a Lettriq of Sim'hat is 'Sharing of the Service which Sustains the Matter': it is therefore the joy resulting from the beneficial help of the Torah and those which follow the laws of the country where one lives and the Doctrine of YHVH which have for one and only fundamental purpose to protect the life and the goods of the people without harming even the wicked and the criminals.

The generation of parashot relating to Shabatot is not guaranteed to be traditional especially as the application generates dates, although based on the lunar cycle, which can sometimes vary a little from official calendars, especially if the moon omer is used and even more with the personal shabat.

## Keyboard shortcuts

| Keys | Actions |
|-|-|
| Ctrl + Tab | Next view |
| Shift + Ctrl + Tab | Previous view |
| F1 | Text report view |
| F2 | Month view |
| F3 | Database grid view |
| F4 | Next celebrations window |
| F5 | Search a celebration window |
| F6 | Search a moon month window |
| F7 | Search a gregorian month window |
| F8 (or Ctrl + N)| Navigation window |
| Ctrl + T (or Numpad0)| Go to today |
| Ctrl + D | Search a day |
| Ctrl + S | Save current view to a file |
| Ctrl + C | Copy current view to clipboard |
| Ctrl + P | Print current view |
| Shift + Ctrl + C | Copy the text report selection to clipboard |
| Alt + T | Show tools menu |
| Alt + L | Show web links menu |
| Alt + V | Show view menu |
| Alt + S | Show settings menu |
| Alt + I | Show information menu |
| Alt + E | Open export folder |
| Alt + C | Open windows calculator |
| Alt + D | Open windows date and time settings |
| Alt + M | Windows weather |
| Alt + W | Online weather |
| Alt + G | Generate calendar |
| Ctrl + F1 | Dates difference calculator |
| Ctrl + F2 | Celebrations board |
| Ctrl + F3 | New moons board |
| Ctrl + F4 | Lunar months board |
| Ctrl + F5 (or Alt + P) | parashot board |
| Home | First month available in the database |
| End | Last month available in the database |
| Up (or PageUp) | Previous year |
| Down (or PageDown) | Next year |
| Left | Previous month |
| Right | Next month |
| Ctrl + Left | Previous month having a celebration |
| Ctrl + Right | Next month having a celebration |
| Ctrl + Home | First month available in the database having a celebration |
| Ctrl + End | Last month available in the database having a celebration |
| F9 | Preferences |
| F10 | Log file window |
| F11 | Usage statistics window |
| F12 | About |
| Alt + F4 (or Escape) | Close window |
| Ctrl + Alt + F4 | Exit application |

## Future improvements

- Add print boards.
- Add user reminders for solar and lunar anniversary of birth.
- Add user reminders for small religious festivals.
- Add 'Hanouka and Pourim ancillary religious festivals and option to consider them or not in the calendar.
- Improve log viewer to select file.
- Replace simple internal trace/logging by SeriLog.
- Add dark theme for month view.

## Changelog

#### Planned - Version 7.x

- Add lunar months board with meanings, lettriqs, study tools, edition and export.
- Add Manage date bookmarks in Tools menu.
- Add option to set Tray Icons.
- Add option to choose default auto-lock option between lock station, standby and power off.
- Improve auto-lock session.

#### 2021.03.12 - Version 7.0

- Add parashah notice.
- Add parashot board with literal translations, lettriqs, verses references, study tools, edition and export.
- Add generate weekly parashah lecture in the database.
- Add option to set parashah generation for inside or outside of Israël.
- Add option to set parashah reading always on saturday.
- Add option to indicate parashah in the Shabatot of the visual month.
- Add option to indicate current parashah in the application title bar.
- Add option to indicate current lunar day in the application title bar.
- Add option to set visual calendar events line spacing that is reduced to display parashah.
- Add current parashah in the navigation form and in the main form subtitle.
- Add common database in roaming to store parashot table and inter-process locking table.
- Add a different Tray Icon to indicate if a Shabat or a celebration day is running.
- Add option to enable or disable this special day Tray Icon.
- Add new in version notice in the Information menu.
- Add option to show the last new in version after a software update.
- Add show usage statistics from about box.
- Add check update from about box.
- Add export to TXT support for all boards.
- Add Ctrl + Home/End/Left/Right shortchut to navigate between months having celebrations.
- Add command-line options (see FAQ).
- Improve month view to show long-week celebration intermediate days.
- Improve navigation form to show long-week celebration intermediate days.
- Improve celebrations and new moons boards to allow the use of english columns title and exports.
- Improve celebrations board export file name to indicate moon or sun omer and set or rise.
- Improve Tray Icon mouse move management.
- Improve reminder box.
- Improve automatic web check update to not run when Shabat and a special celebration day but the next day.
- Change some keyboard shortcuts.
- Change the minimum year to generate to two years before instead of one in order to have consistency with the parashot.
- Change exported text files to be in UTF-8 encoding.
- Fix celebrations boards wrong times for sun omer that were from moon set or rise instead of sun.
- Fix lunar day without moon rise is not shown in text report and visual calendar in the case of sun omer.
- Fix moonrise sometimes attributed to previous day when being 00:00.
- Some fixes and UI/UX improvements.
- Some file and code refactoring.
- Add Serilog-sinks-winforms NuGet package.
- Add some online bible providers and update *chabad.org*.
- Update web links.
- Update help files.

#### 2021.02.17 - Version 6.8

- Fix the last day of Pesa'h and Sukot, when using moon omer, if moonrise occurs the next day, to be this day.
- Update web links.

#### 2021.02.14 - Version 6.7

- Reorganize, improve and update web links.
- Add more jewish calendars entries.
- Add more languages entries.

#### 2021.02.07 - Version 6.6

- Fix visual calendar too optimized in v6.3 (not repainted when resizing the window).

#### 2021.02.03 - Version 6.5

- Add celebrations and new moons boards export.
- Improve names of export files.

#### 2021.01.31 - Version 6.4

- Add *country and city* label in the middle of the subtitle.
- Add *moon or sun omer* label in the right of the subtitle.
- Add *country and city* to the window's title bar of celebrations and new moons boards.
- Add option to choose online weather provider between *meteoblue.com* and *weather.com*.
- Add option to choose between daily or weekly mode for online weather.
- Add option to show or hide weather menu items.
- Add option to set the corner of the desktop to place reminder boxes, default being bottom-right.
- Improve preferences form to select *all*, *none* or *default* events in list boxes.
- Fix automatic position of the navigation window beside the Tray Icon when the Taskbar is not at the bottom of the screen.
- Fix date bookmarks count is not saved if chenged in preferences.
- Fix sound is played when opening preferences form if volume is less than 100%.
- Update NuGet packages to last versions.
- Code refactoring and code quality improvements.

#### 2021.01.10 - Version 6.3

- Add launch system weather app like MSN Weather.
- Add option to define system weather app.
- Add option to enable Windows double-buffering drawing.
- Optimize visual month painting speed.
- Fix Rotate view is done only between visual month and grid.
- Fix null exception after changing current day once preferences form closed.
- Fix exception when running application having a config file but no database if deleted.
- Code refactoring (preferences).
- Update help.

#### 2021.01.01 - Version 6.2

- Add show online weather in browser using *meteoblue.com*.
- Add new moons board with clickable dates and selection of years interval.
- Add option for boards to use abbreviated names of month and day of week.
- Add option for boards to show real days having the moonset, else use the moonrise.
- Add option for boards to show or hide hours.
- Improve top menu bar.
- Improve information menu.
- Improve Tray Icon menu.

#### 2020.12.27 - Version 6.1

- Add export and import preferences.
- Add backup and restore date bookmarks.
- Add option to go to today when main form popup else keep the selected.
- Improve export dialog to select default image file format.
- Improve celebrations board to indicate the day of the Shabat in the title.
- Improve text report to always show selection.
- Fix text report to select the last character of the line.
- Fix print text report interval that prints all lines.
- Fix resizing celebrations board from the top or left, and un-maximize.
- Fix export dialog that has print image orientation option always enabled.
- Fix navigation form that doesn't ballon when app is started hidden.
- Fix help shortcuts.
- Some improvements.
- Code refactoring.
- Update web links.

#### 2020.12.21 - Version 6.0

- Add celebrations board with clickable dates and selection of years interval.
- Add advanced print preview window.
- Add select years interval to export/print, else process the entire report/grid or only the current month view.
- Add option to set the default print month view page orientation.
- Add option to set preferred data export file format (CSV/JSON)
- Add option to set preferred image export file format (PNG/JPEG/TIFF/BMP).
- Add export data to JSON file.
- Add option for grid export to use enums names instead of translations
- Add option to set global HotKey to popup the main form.
- Add some keyboard shortcuts and change few.
- Fix CSV export to add moon rise type field.
- Fix lunar months menu item not available yet in the main form is available in the Tray Icon menu.
- Few improvements.
- Few fixes.
- Code refactoring.
- Add Newtonsoft.Json NuGet package.
- Add MoreLINQ NuGet package.
- Add Enums.NET NuGet package.
- Add Windows Global Hotkey dependency.
- Add InputSimulatorStandard NuGet package.
- Add Serilog-sinks-file NuGet package.
- Update web links.
- Update help.

#### 2020.12.13 - Version 5.13

- Fix app does not start hidden at windows startup in v5.12.
- Fix web check update box remains on top if clicked on view release notes.
- Fix button print not disabled when data grid view and causes an unhandled error.
- Fix custom wav is played twice when clicking on the radio box.
- Fix visual calendar IDE design time exceptions.
- Add Serilog NuGet package.

#### 2020.12.12 - Version 5.12

- Optimize statistics initialization at startup to be in a background task.
- Fix usage statistics menu item not disabled in tray menu if stats are disabled at startup.
- Fix buttons position in search event, lunar month and gregorian month windows.
- Fix file and memory sizes diplayed only in english in usage statistics form.
- Fix date bookmarks storage format that altered the dates after language changed.
- Improve UI/UX.
- Few fixes.
- Replace AASharp source code dependency by the NuGet package.
- Replace GenericParsing dependency by FileHelpers NuGet package.
- Replace simple internal command-line parser by CommandLineParser NuGet package.
- Code refactoring.
- File system refactoring.

#### 2020.12.06 - Version 5.11

- Add navigation buttons to search event, lunar month and gregorian month windows.
- Add save and load theme for month view, reminder boxes and navigation window.
- Add print text report.
- Add printing option tab in preferences form.
- Add open export folder in tools menu.
- Improve UI/UX
- Change Markdownsharp dependency by Markdig NuGet package.
- Update web links.
- Update help.

#### 2020.12.01 - Version 5.10

- Add view selection for save to file, copy to clipboard and print.
- Add preview dialog for print month view.
- Add option to show print preview dialog.
- Add option to set printing margin.
- Add option to auto-open exported file.
- Add option to set the number of date bookmarks.
- Add option to restore the last view at startup else go to the month.
- Add option to enable/disable usage statistics.
- Improve usage statistics form.
- Improve start menu reset settings to delete all previous app settings folders in AppData\Local.
- Improve print image quality.
- Improve UI/UX.
- Update help.

#### 2020.11.26 - Version 5.9

- Add option to set automatic db optimize frequency.
- Add option to set automatic web check update frequency.
- Add option to set export folder.
- Add option to set application's volume.
- Add option to show tray balloon only if main form is hidden.
- Add option to enable/disable success dialogs.
- Add sounds to export, clipboard and print actions.
- Improve reminder sound selection box with more choices.
- Improve preferences form.
- Improve information menu.
- Improve UI/UX.
- Optimize by preloading sounds lists in a thread.
- Refactor project folders hierarchy.

#### 2020.11.22 - Version 5.8

- Add change tab page using function keys in preferences form.
- Improve new version available form to show current version.
- Fix view log menu item not disabled when app started when log is disabled.
- Fix view log icon not disabled in stats form when log is disabled.
- Fix small defect with Tray Icon images.
- Update web links to improve playlists and add the calendar of Torah-box.

#### 2020.11.18 - Version 5.7

- Fix start menu icons lost since the v5.3 setup.

#### 2020.11.15 - Version 5.6

- Rework of the preferences form design to have a Tab Control with pages.
- Add keyboard shortcuts notice in windows settings menu.
- Add option to set the Calculator application path.
- Add option to set the Hebrew Letters application path.
- Add option for date diff calculator form to set right date to today when opened.
- Fix some preferences controls to be disabled when related options are disabled.
- Fix use no colors option.
- Fix print dialog does not have the focus when opened.
- Fix french help.
- Improve UI.
- Update web links with Quran arabic lecture link.

#### 2020.09.29 - Version 5.5

- Fix current celebration reminder box closed when passing midnight.
- Fix "bookmarks not found exception" when reseting parameters.
- Remove title bar icon from reminder boxes.

#### 2020.09.25 - Version 5.4

- Add option to enable or disable start with Windows from the software that now runs from the registry.
- Improve weekly check update while running to manage on power resume event.
- Fix bookmarks numbering from 0 instead of 1 introduced in the previous version.

#### 2020.09.18 - Version 5.3

- Add "Start and reset preferences" link in Windows Start menu.
- Improve date bookmarks to be saved to a file in user roaming folder instead of using application settings.
- Fix the inconsequential error: "The given key was missing from the dictionary in CheckCelebrationDay()".
- Rename 32x32 icon files.

#### 2020.09.11 - Version 5.2

- Improve check update to verify the SSL certificate of the website and the checksum of the setup file.
- Add sound selection for the reminder box.
- Add permanent database file locking while running.
- Fix justify text in advanced message boxes.
- More refactorings.
- Update help

#### 2020.09.08 - Version 5.1

- Fix that sometimes the application is in the system Tray Icon but does not start and freeze.
- More refactorings.

#### 2020.09.06 - Version 5.0

- Add keyboard shortcuts to navigate in the calendar month view.
- Add search gregorian month form.
- Add tools menu duplicated in the Tray Icon.
- Add force database optimize at next startup in tools menu
- Add option to define the years interval for auto-generation.
- Add option to enable or disable the web links menu.
- Add option to enable or disable the suspend reminder functionality.
- Add button to disable auto lock option in lock session form.
- Add option to auto generate calendar when expired else show dialog box.
- Add option to set the maximum years interval allowed to generate the data.
- Add mute windows volume in addition to stop media playing in auto lock form.
- Fix "stop media playing" to stop instead of play/pause media.
- Fix day selection to allow only generated years interval.
- Improve dates diff calculator to show more stats in a form having bookmarks.
- Improve generate years box with predefined intervals and change some constants.
- Improve GPS finder to try to auto-select time zone based on country or city names.
- Improve month view drawing speed by a half.
- Improve data generation speed by a half.
- Improve keyboard shortcuts.
- Remove the generate years selection box at startup if database is empty or new.
- Change default years interval generation to 10.
- Change text report that is no more stored in the database but in a file to avoid problems when using hudge interval.
- Add usage statistics form in tools menu.
- Add option to enable or disable message boxes sounds.
- Improve message boxes.
- Improve check update to allow auto update or direct download or open app web page.
- Improve debugger to support logging.
- Improve exception form to view log.
- Some UI/UX improvements.
- Massive code refactoring.
- Update help.
- Update to SQLite 3.32.3 ODBC Driver.
- Update Framework .NET version to 4.7.2 and supported Windows only 7 SP1 or higher.
- The application now automatically creates the ODBC DSN in the Windows registry.
- Improve setup.

#### 2020.08.22 - Version 4.1

- Add bring to front app if process is started again.
- Add choosing a delay to allow auto enabling when suspending reminder.
- Add left, right and up keys support to the navigation form.
- Add option to define moon day text format for calendar month view.
- Add Windows date and time link in the tools menu.
- Add release notes link in the information menu.
- Add information menu duplicated in the Tray Icon.
- Add web links menu duplicated in the Tray Icon.
- Fix reset preferences generates data before setup GPS if undefined that causes an exception.
- Fix GPS labels appearance for Windows 10.
- Fix reminder form title bar for Windows 10.
- Fix Hebrew Letters path TextBox color for Windows 10.
- Fix long latency when opening preferences for the first time in Windows 10.
- Some fixes and improvements.

#### 2020.04.24 - Version 4.0

- Exit application at startup if user choose to download a newer version.
- Add F1/F2/F3 shortcuts to select the view.
- Add F4/F5/F6/F7 shortcuts to open searches windows.
- Add moon month name to all days in the month view.
- Add suspend reminder menu in the main form and the Tray Icon.
- Improve Tray Icon to show if the reminder is suspended.
- Add preferences menu in the Tray Icon.
- Add dialog box to choose sun or moon omer at first startup.
- Add celebrations dialog box notice.
- Improve personal Shabat dialog box notice.
- Improve preferences form.
- Improve search celebration and moon month forms to use a combobox to select year.
- Improve text report : Ctrl+A select all text.
- Add month number column in the search moon month form.
- Add tools menu.
- Add celebrations and Shabat notices in tools menu.
- Add calculate number of days between two dates in tools menu.
- Add link to windows calculator in tools menu.
- Add option to change month view text size.
- Add option to change month view back and text colors for non-event days.
- Add option to auto open destination folder of exports after done.
- Fix controls tabs and focus in auto lock session form.
- Fix reset default month view colors in preferences form.
- Fix edit report text font size in preferences form.
- Fix print bitmap size if the main form is resized.
- Fix search celebration and moon month forms when closing using the top-right cross.
- Fix celebration reminder that can be shown even the next day too with bad times.
- Few UI fixes.
- Add menu for web links about judaism.
- Add option to auto optimize database at startup once a week.
- Add option to enable debugger.
- Add debugger (exception information form with GitHub issue creation).
- Improve UI/UX.
- Code refactoring.
- Update help.

#### 2019.11.12 - Version 3.10

- Change dependency AAPlus for AASharp.
- Improve data generation to show all warnings.
- Fix data generation for south hemisphere for the last year when using moon omer.

#### 2019.11.11 - Version 3.9

- Add shutdown, hibernate and standby actions to auto lock session dialog box.
- Add option to stop current media playing to auto lock session dialog box.

#### 2019.11.04 - Version 3.8

- Add option to auto lock session during Shabat and celebrations days.

#### 2019.11.01 - Version 3.7

- Update current day highlighting when passing midnight.
- Fix first day of month not highlighted like other days.
- Fix sun rise and set on the first day of daylight saving time that was shifted by one day in the previous version.
- Fix the reminder that sometimes does not work anymore after a while if screensaver or fullscreen mode has been detected.
- Code refactoring.

#### 2019.10.21 - Version 3.6

- Add time zone setting to have good sun and moon rise and set in the whole world.

#### 2019.10.21 - Version 3.5

- Improve personal Shabat setup by asking birth time.
- Improve min and max years that can be generated (up to 2198).
- Improve reminder to change the window color when just passing the start date without waiting the remind delay.
- Fix reminder using moon days that stops remind after midnight.
- Add Ctrl+T shortcut to go to today.
- Add option to define the delay to open the looming navigation popup.
- Some improvements.
- Some fixes.
- Update help.

#### 2019.10.19 - Version 3.4

- Improve celebration and lunar month finder.
- Improve select city window.
- Change exit button now doesn't shutdown app but minimize to Tray Icon.
- Fix cities names having special diacritics.
- Fix lunar month's first day duplicated if no moon rise on the next sun day.

#### 2019.10.18 - Version 3.3

- Improve UI.
- Some fixes.
- Some code refactorings.
- Setup install SQLite ODBC Driver if not present.

#### 2019.10.17 - Version 3.2

- Add search month window.
- Fix soukot sun omer date.
- Fix calendar generated only for north hemisphere if moon omer.
- Some code refactorings.

#### 2019.10.16 - Version 3.1

- Add option to choose between sun or moon day count to determine celebrations to allow a more traditional use.

#### 2019.10.14 - Version 3.0

- Improve the reminder to remind during the celebration day like with the Shabat day.
- Improve the reminder to flash the form if already displayed.
- Improve reminder boxes location on the desktop.
- Improve session ending.
- Add loading data box instead of using a bottom progressbar.
- Add displaying begin and end dates and times in the celebration reminder form like with the Shabat.
- Add looming navigation popup from the Tray Icon when mouse is over.
- Add celebration weeks, Shabat days and reminders popup colorization.
- Add check end of calendar to automatically regenerate it.
- Add option to choose language.
- Add world cities GPS database.
- Improve UI.
- Improve speed.
- Update help.
- Some code refactorings.

#### 2019.09.19 - Version 2.4

- Add option to disable startup check update.
- Some code refactorings.

#### 2019.09.15 - Version 2.3

- Fix starting form location.

#### 2019.09.10 - Version 2.2

- Reminder is disabled if fullscreen or if screen saver is active.

#### 2019.09.04 - Version 2.1

- Improve Shabat reminder.
- Update controls tabs.

#### 2019.08.26 - Version 2.0

- Change Shabat reminder.
- Reorganize preferences form.

#### 2019.08.25 - Version 1.10

- Add colors parameters for calendar month view.

#### 2019.08.24 - Version 1.9

- Improve check update.

#### 2019.05.22 - Version 1.8

- Add check update.

#### 2019.04.25 - Version 1.7

- Fix pessah length.

#### 2019.04.08 - Version 1.6

- Fix Tray Icon.

#### 2019.01.28 - Version 1.5

- Change current day color in month view.
- Some code refactorings.
- Some improvements.

#### 2019.01.21 - Version 1.4

- Add an event reminder.
- Add help file.

#### 2019.01.20 - Version 1.3

- Add an option for the Tray Icon mouse click.
- Add an option to show/hide the main form at startup.
- Add a month view.
- Add a print menu.
- Improve the grid view.

#### 2019.01.18 - Version 1.2

- Add a celebrations window.
- Improve the navigation window.
- Improve the preferences window.
- Some bug fixes.

#### 2019.01.17 - Version 1.1

- Report is no more generated at every startup.

#### 2019.01.14 - Version 1.0

- Initial release.