# Hebrew Calendar

>This project follows the [Manufacturing Software Guidelines](https://github.com/Ordisoftware/Guidelines).

>Licensed under the terms of the [Mozilla Public License 2.0](LICENSE)<br/>
>[Project Website](http://www.ordisoftware.com/projects/hebrew-calendar)<br/>
>[Twitter](https://twitter.com/ordisoftware)<br/>

A tool for Windows written in C# that allows to generate a daily calendar based on the lunar cycle in order to determine the new year and the celebration times according to the hebrew Torah.

## Functionalities

- Generate a calendar with sun and moon rises and sets.
- Create a tabular text report.
- Search for a day in the database.
- Save the report to a text file.
- Export data to CSV.
- Copy the report to the clipboard.
- Visualization of the data in a grid.
- Popup box from the tray icon displaying the day data.
- English, French.

## Requirements

- Windows Vista x32/x64 or superior
- Screen 1024x768 or superior
- Framework .NET 3.5 or superior
- [SQLite ODBC Driver](http://www.ch-werner.de/sqliteodbc/)

## Screenshots

![Main Window](http://www.ordisoftware.com/uploads/2019/01/hebrew-calendar-app-768x527.png)

![Trayicon Celebration Window](http://www.ordisoftware.com/uploads/2019/01/hebrew-calendar-celebrations.png)

![Trayicon Navigation Window](http://www.ordisoftware.com/uploads/2019/01/hebrew-calendar-navigation.png)

## Video

[![Video](https://img.youtube.com/vi/u9LD-0u3wdE/0.jpg)](https://www.youtube.com/watch?v=u9LD-0u3wdE)

## Frequently asked questions

#### How to install SQlite ODBC Driver?

- [sqliteodbc.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc.exe) must be installed on Windows 32-bit.
- [sqliteodbc.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc.exe) and [sqliteodbc_w64.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc_w64.exe) must be installed on Windows 64-bit.

#### What to do in case of ODBC datasource connection error?

The setup tries to register an ODBC dsn to the registry but in case of problem run "C:\Program Files\Ordisoftware\Hebrew Calendar\Register ODBC.reg" or open the ODBC datasource manager (Admin tools in Windows' Control panel) and create a user datasource named "Hebrew-calendar" for "SQLite 3 ODBC Driver" with "Database Name" sets to:

"%USERPROFILE%\AppData\Roaming\Ordisoftware\Hebrew Calendar\Hebrew-calendar.sqlite"

#### How to get latitude and longitude?

They can be found using an [online service](https://www.google.com/search?q=latitude+longitude).

## Changelog

#### 2019.01.19 - Version 1.2

- Add celebrations window.
- Improve navigation window.
- Improve preferences window.
- Some bug fixes.

#### 2019.01.17 - Version 1.1

- Report is no more generated at every startup.

#### 2019.01.14 - Version 1.0

- Initial release.