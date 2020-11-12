# Hebrew Calendar

>This project follows the [Manufacturing Software Guidelines](https://github.com/Ordisoftware/Guidelines).

>Licensed under the terms of the [Mozilla Public License 2.0](LICENSE)<br/>
>[Project Website](https://www.ordisoftware.com/projects/hebrew-calendar)<br/>
>[Twitter](https://twitter.com/ordisoftware)<br/>

A tool for Windows written in C# that allows to generate a calendar based on the lunar cycle in order to determine the new year and the celebration times according to the Hebrew Torah, as well as to remind Shabbat and Pesach, Shavuot, Rosh Hashanah, Kippour and Sukkot festivities.

## Functionalities

- Generate a calendar with sun and moon rises and sets.
- Tabular text report, visual month or data grid view.
- Event reminder for shabat and celebrations.
- Search for a day in the database.
- Window listing annual celebrations.
- Calculate the difference between two dates.
- Print the month view.
- Copy the report to the clipboard.
- Save the report to a text file.
- Export data to CSV.
- Navigation by day window from the Tray Icon.
- English, French.

## Review

[Softpedia.com](https://www.softpedia.com/get/Others/Home-Education/Hebrew-Calendar-Olivier-Rogier.shtml)

_"Efficient and intuitive calendar and reminder app for the Hebrew Torah"_

![Note](https://www.ordisoftware.com/uploads/2019/10/softpedia4.5-1.png)

## Requirements

- Windows 7 SP1 x32/x64 or higher
- Screen 1024x768 or higher
- Framework .NET 4.7.2
- SQLite ODBC Driver

## Screenshots

[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-viewmonth-en-300x222.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-viewmonth-en.png)&nbsp;&nbsp;&nbsp;&nbsp;[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-raw-en-300x222.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-raw-en.png)

&nbsp;&nbsp;&nbsp;[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-navigation-en-275x300.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-navigation-en.png)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-celebrations-en-282x300.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-celebrations-en.png)

[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-reminderpopup-en-300x126.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-reminderpopup-en.png)&nbsp;&nbsp;&nbsp;&nbsp;[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-locksession-en-300x201.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-locksession-en.png)

[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-diffdates-en-300x258.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-diffdates-en.png)&nbsp;&nbsp;&nbsp;&nbsp;[![](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-preferences-en-300x289.png)](https://www.ordisoftware.com/uploads/2020/09/hebrew-calendar-preferences-en.png)

## Videos

[![Month view showing video](https://img.youtube.com/vi/EJni1fiXpMk/mqdefault.jpg)](https://www.youtube.com/watch?v=EJni1fiXpMk)
[![Showing video](https://img.youtube.com/vi/u9LD-0u3wdE/mqdefault.jpg)](https://www.youtube.com/watch?v=u9LD-0u3wdE)

## Frequently asked questions

#### How to install SQlite ODBC Driver?

The setup installs:

- [sqliteodbc.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc.exe) on Windows 32-bit.
- [sqliteodbc_w64.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc_w64.exe) on Windows 64-bit.

In the event that an error message indicates that a DLL file could not be copied, it is usually due to the fact that an application using this driver already installed is running and is blocking the file. You can ignore this error or close the application in question and restart the installation to obtain a driver update.

#### What to do in case of ODBC datasource connection error?

The software tries to register an ODBC DSN to the registry but in case of problem run "C:\Program Files\Ordisoftware\Hebrew Calendar\Register ODBC.reg" or open the ODBC datasource manager (Admin tools in Windows' Control panel) and create a user datasource named "Hebrew-Calendar" for "SQLite 3 ODBC Driver" with "Database Name" sets to:

"%USERPROFILE%\AppData\Roaming\Ordisoftware\Hebrew Calendar\Hebrew-Calendar.sqlite"

Watch the [video](https://www.youtube.com/watch?v=WPVF8pj9I3E).

#### What to do if the check update tells that the SSL certificate is wrong or expired?

The software verifies the validity of the certificate of the update server in addition to the SHA-512 checksum of the installation file before downloading and running it. This certificate is normally updated within the two months of its annual expiration and a new version is released. If the application has not been updated within this period, you can manually check the latest version available online.

#### What to do if the calendar month view is ugly?

Reset the preferences to default: it will restore the corrupted values in case of a problem after install or upgrade.

#### What are the times of celebration?

The times of the Torah's celebrations are Pesa'h or Easter which is the liberation of illusions, Shavuot or Weeks which is the gift of knowledge, Teru'ah or Ringtone which is the joy of being freedom, Kipurim or Atonement which is the sorrows of losses, and Sukot or Tabernacles which is the construction of the future.

These are important moments of the lunar year in the solar cycle whose purpose is to provide a benevolent evolution of consciousness by the knowledge of the laws of the universe and of life. The Torah says to count these days according to the moon, as opposed to Shabat which is counted according to the sun.

The application uses by default moon omer for celebrations.

If you use moon omer then celebrations dates will be calculated according to seasons and there will be an inversion between north and south hemispheres. In this case, a day is from one moon set to the next set.

You can use traditionnals sun days by modifying the option in the reminder, hence celebrations will be same in north and south. In this case, a day is from one sun set to the next set.

#### What is Shabat?

The shabat is the "day of rest" where one do not work for a livelihood. Unless there is a vital emergency, the body, the emotions and the spirit are resting there. The study of the Torah is a privileged activity.

The tradition attributes this day to Saturday. We can however think according to Béréshit 1.1 that in the case where the first day is the day of birth as a corollary to the fusion of the gametes then it takes place the day before: thus a person coming to the world on a Sunday will have his Shabat the Saturday. From Béréshit 1.5 and 1.16 as well as from Shémot 20.8 it can be deduced that it lasts from sunset on the eve of the calendar day to sunset on the same day. For example, for a person born in Paris, the Shabat of February 19, 2019 takes place from Friday 18 at 17:25 to Saturday at 17:25 approximately.

The personal shabat of a maried or concubin or divorced man is the previous day of the birth. A son follows his father's shabat. The shabat of a woman is the shabat of her father or her husband or her concubin.

So the man and the woman respect their mutual cycles. Indeed, during the period when the married or concubine or divorced woman is Nidah from the beginning to the end of the blood flow, her vital field is dissonant and the couple avoid touching each other (the virgin girl is not concerned as long as she had no relations through the openings of the begetting) to avoid to increase as well as to transmit this state to things and people (otherwise we follow the rules of the Torah about that).

If the man were born between midnight and the sunset, the shabat is the day before. Between sunset and midnight, the shabat is that day. This day is from previous day (or previous previous day) at sunset to this day (or previous day) at sunset.

The day of the shabat goes from sunset on the previous calendar day to sunset of that day, with 3% of natural margin that to say about one hour.

The day before, either the man keeps without going out and strengthens the couple during the shabat, or he goes out and lights up the couple for shabat, but on shabat he does not go out of his temple, and except in case of emergency we do not produce, transform and destroys nothing, we don't plan anything, we don't work, we don't cook, we don't shave, we don't cut, we don't make fire, we don't care about information, etc. But we can for example take part in sports, study science and play with children.

If you prefer to use the traditional group shabat, select for example Saturday for Judaism, Sunday for Christianity or Friday for Islam.

#### Keyboard shortcuts

- F1 : Text report view
- F2 : Month view
- F3 : Database grid view
- F4 : Next celebrations window
- F5 : Search a celebration window
- F6 : Search a moon month window
- F7 : Search a gregorian month window
- F9 : Navigation window (also Ctrl+N)
- Ctrl+Tab : Next view
- Shift+Ctrl+Tab : Previous view
- Ctrl+T : Go to today (also Numpad0)
- Ctrl+D : Search a day
- Ctrl+C : Copy text report to clipboard
- Ctrl+P : Print month view
- Ctrl+S : Save text report to text file
- Alt+S : Save text report to CSV file
- Alt+C : Open windows calculator
- Alt+T : Open windows date and time settings
- Ctrl+F1 : Dates difference calculator
- Ctrl+F2 : Generate calendar data
- Ctrl+F11 : Current log window
- Ctrl+F12 : Statistics window
- Home : First month available in the database
- End : Last month available in the database
- Up : Previous year
- Down : Next year
- Left : Previous month
- Right : Next month
- F8 : Preferences
- F11 : Help
- F12 : About
- Escape : Close window

## Roadmap

- Add moon months description form and menu in tools.
- Add reminder for solar and lunar anniversary of birth.
- Add 'Hanouka and Pourim dates and an option to consider them or not in the calendar.
- Add a different tray icon to indicate if a celebration is running, including week days.
- Improve navigation form to show celebration week days.

## Changelog

#### 2020.11.__ - Version 5.6

- Improve date diff calculator to set second date to current day when (re)opened.
- Rework preferences form design to have TabControl with pages.
- Fix some preferences controls to be disabled when related options are disabled.
- Fix print dialog does not have the focus when opened.

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
- Add tools menu duplicated in the tray icon.
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
- Add information menu duplicated in the tray icon.
- Add web links menu duplicated in the tray icon.
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
- Add suspend reminder menu in the main form and the tray icon.
- Improve tray icon to show if the reminder is suspended.
- Add preferences menu in the tray icon.
- Add dialog box to choose sun or moon omer at first startup.
- Add celebrations dialog box notice.
- Improve personal shabat dialog box notice.
- Improve preferences form.
- Improve search celebration and moon month forms to use a combobox to select year.
- Improve text report : Ctrl+A select all text.
- Add month number column in the search moon month form.
- Add tools menu.
- Add celebrations and shabat notices in tools menu.
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

- Add option to auto lock session during shabat and celebrations days.

#### 2019.11.01 - Version 3.7

- Update current day highlighting when passing midnight.
- Fix first day of month not highlighted like other days.
- Fix sun rise and set on the first day of daylight saving time that was shifted by one day in the previous version.
- Fix the reminder that sometimes does not work anymore after a while if screensaver or fullscreen mode has been detected.
- Code refactoring.

#### 2019.10.21 - Version 3.6

- Add time zone setting to have good sun and moon rise and set in the whole world.

#### 2019.10.21 - Version 3.5

- Improve personal shabat setup by asking birth time.
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
- Change exit button now doesn't shutdown app but minimize to tray icon.
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

- Improve the reminder to remind during the celebration day like with the shabat day.
- Improve the reminder to flash the form if already displayed.
- Improve reminder boxes location on the desktop.
- Improve session ending.
- Add loading data box instead of using a bottom progressbar.
- Add displaying begin and end dates and times in the celebration reminder form like with the shabat.
- Add looming navigation popup from the tray icon when mouse is over.
- Add celebration weeks, shabat days and reminders popup colorization.
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

- Improve shabat reminder.
- Update controls tabs.

#### 2019.08.26 - Version 2.0

- Change shabat reminder.
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

- Fix tray icon.

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