# Hebrew Calendar

>This project follows the [Manufacturing Software Guidelines](https://github.com/Ordisoftware/Guidelines).

>Licensed under the terms of the [Mozilla Public License 2.0](LICENSE)<br/>
>[Project Website](http://www.ordisoftware.com/projects/hebrew-calendar)<br/>
>[Twitter](https://twitter.com/ordisoftware)<br/>

A tool for Windows written in C# that allows to generate a daily calendar based on the lunar cycle in order to determine the new year and the celebration times according to the hebrew Torah.

## Functionalities

- Generate a calendar with sun and moon rises and sets.
- Tabular text report, month or grid view.
- Event reminder for shabat and celebrations.
- Search for a day in the database.
- Window listing annual celebrations.
- Print the month view.
- Copy the report to the clipboard.
- Save the report to a text file.
- Export data to CSV.
- Navigation by day window from the Tray Icon.
- English, French.

## Requirements

- Windows Vista x32/x64 or superior
- Screen 1024x768 or superior
- Framework .NET 4.5 or superior
- [SQLite ODBC Driver](http://www.ch-werner.de/sqliteodbc/)

## Screenshots

![Repport Window](http://www.ordisoftware.com/uploads/2019/10/hebrew-calendar-raw-en-768x527.png)

![Month Window](http://www.ordisoftware.com/uploads/2019/10/hebrew-calendar-viewmonth-en-768x527.png)

![Settings Window](http://www.ordisoftware.com/uploads/2019/10/hebrew-calendar-preferences-en.png)

![Celebrations Window](http://www.ordisoftware.com/uploads/2019/10/hebrew-calendar-celebrations-en.png)

![Navigation Window](http://www.ordisoftware.com/uploads/2019/10/hebrew-calendar-navigation-en.png)

![Reminder Window](http://www.ordisoftware.com/uploads/2019/10/hebrew-calendar-popupreminder-en.png)

## Videos

[![Showing video](https://img.youtube.com/vi/u9LD-0u3wdE/0.jpg)](https://www.youtube.com/watch?v=u9LD-0u3wdE)

[![Month view showing video](https://img.youtube.com/vi/EJni1fiXpMk/0.jpg)](https://www.youtube.com/watch?v=EJni1fiXpMk)

## Frequently asked questions

#### How to install SQlite ODBC Driver?

- [sqliteodbc.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc.exe) must be installed on Windows 32-bit.
- [sqliteodbc.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc.exe) and [sqliteodbc_w64.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc_w64.exe) must be installed on Windows 64-bit.

#### What to do in case of ODBC datasource connection error?

The setup tries to register an ODBC DSN to the registry but in case of problem run "C:\Program Files\Ordisoftware\Hebrew Calendar\Register ODBC.reg" or open the ODBC datasource manager (Admin tools in Windows' Control panel) and create a user datasource named "Hebrew-calendar" for "SQLite 3 ODBC Driver" with "Database Name" sets to:

"%USERPROFILE%\AppData\Roaming\Ordisoftware\Hebrew Calendar\Hebrew-calendar.sqlite"

Watch the [video](https://www.youtube.com/watch?v=WPVF8pj9I3E).

#### What is Shabat?

It's the "day of rest" where one do not work for a livelihood and where there is no creative activity. Unless there is a vital emergency, the body, the emotions and the spirit are resting there. The study of the Torah is a privileged activity. Tradition attributes this day to Saturday. We can however think according to Béréshit 1.1 that in the case where the first day is the day of birth as a corollary to the fusion of the gametes then it takes place the day before: thus a person coming to the world on a Sunday will have his Shabat the Saturday. From Béréshit 1.5 and 1.16 as well as from Shémot 20.8 it can be deduced that it lasts from sunset on the eve of the calendar day to sunset on the same day. For example, for a person born in Paris, the Shabat of February 19, 2019 takes place from Friday 18 at 17:25 to Saturday at 17:25 approximately.

#### What are the times of celebration?

These are Pesa'h or Easter which is the liberation of illusions, Shavuot or Weeks which is the gift of knowledge, Teruah or Ringtone which is the joy of being freedom, Kipurim or Atonement which is the sorrow of losses, and Sukot or Tabernacles which is the construction of the future. These are important moments of the lunar year in the solar cycle whose purpose is to provide a benevolent evolution of consciousness by the knowledge of the laws of the universe and of life. The Torah says to count these days according to the moon, as opposed to Shabat which is counted according to the sun.

## Changelog

#### 2019.10.__ - Version 3.0

- Improve the reminder to remind during the celebration day like with the shabat day.
- Improve the reminder to flash the form if already displayed.
- Improve reminder boxes location on the desktop.
- Improve tray icon with open navigation popup on mouse mouve.
- Improve session ending.
- Add loading data box instead of using a bottom progressbar.
- Add displaying begin and end dates and times in the celebration reminder form like with the shabat.
- Add looming navigation popup from the tray icon wher mouse is over.
- Add celebration weeks, shabat days and reminders popup olorization.
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
- Some improvments.

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
