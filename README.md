# Hebrew Calendar

>This project follows the [Manufacturing Software Guidelines](https://github.com/Ordisoftware/Guidelines).

>Licensed under the terms of the [Mozilla Public License 2.0](LICENSE)<br/>
>[Project Website](http://www.ordisoftware.com/projects/hebrew-calendar)<br/>

A tool for Windows written in C# that allows to generate a daily calendar based on the lunar cycle in order to determine the new year and the celebration times according to the hebrew Torah.

[Download v1.0](https://github.com/Ordisoftware/Hebrew-Calendar/releases/tag/v1.0)

### Requirements

- Windows Vista x32/x64 or superior
- Framework .NET 3.5 or superior
- [SQLite ODBC Driver](http://www.ch-werner.de/sqliteodbc/)
- Screen 1024x768 or superior

### Screenshots

![Main Window](http://www.ordisoftware.com/uploads/2019/01/hebrew-calendar-main-768x527.jpg)

![Trayicon Popup Window](http://www.ordisoftware.com/uploads/2019/01/hebrew-calendar-popup2-300x225.jpg)

### Frequently asked questions
- How to install SQlite ODBC Driver?

  - [sqliteodbc.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc.exe) must be installed on Windows 32-bit.
  - [sqliteodbc.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc.exe) and [sqliteodbc_w64.exe](http://www.ch-werner.de/sqliteodbc/sqliteodbc_w64.exe) must be installed on Windows 64-bit.

- What to do in case of ODBC datasource connection error?

  The setup tries to register an ODBC dsn to the registry but in case of problem run "C:\Program Files\Ordisoftware\Hebrew Calendar\Register ODBC.reg" or open the ODBC datasource manager (Admon tools in Windows' Control panel) and create a user datasource named "Hebrew-calendar" for:

  "%USERPROFILE%\AppData\Roaming\Ordisoftware\Hebrew Calendar\Hebrew-calendar.sqlite"