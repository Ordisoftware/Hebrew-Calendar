# Hebrew Calendar

>This project follows the [Manufacturing Software Guidelines](https://github.com/Ordisoftware/Guidelines).

>Licensed under the terms of the [Mozilla Public License 2.0](LICENSE)<br/>
>[Project Website](http://www.ordisoftware.com/projects/hebrew-calendar)<br/>
>[Twitter](https://twitter.com/ordisoftware)<br/>

A tool for Windows written in C# that allows to generate a daily calendar based on the lunar cycle in order to determine the new year and the celebration times according to the hebrew Torah.

## Functionalities

- Generate a calendar with sun and moon rises and sets.
- Tabular text report view.
- Month view.
- Grid view.
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
- Framework .NET 3.5 or superior
- [SQLite ODBC Driver](http://www.ch-werner.de/sqliteodbc/)

## Screenshots

![Repport Window](http://www.ordisoftware.com/uploads/2019/01/hebrew-calendar-app-768x527.png)

![Month Window](http://www.ordisoftware.com/uploads/2019/01/hebrew-calendar-month-768x527.png)

![Celebrations Window](http://www.ordisoftware.com/uploads/2019/01/hebrew-calendar-celebrations.png)

![Navigation Window](http://www.ordisoftware.com/uploads/2019/01/hebrew-calendar-navigation.png)

![Reminder Window](http://www.ordisoftware.com/uploads/2019/01/hebrew-calendar-reminder.png)

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

#### How to get latitude and longitude?

They can be found using an [online service](https://www.google.com/search?q=latitude+longitude).

## Changelog

#### 2019.__.__ - Version 1.4

- Add an event reminder.

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
