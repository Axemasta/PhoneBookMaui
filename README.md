# Phone Book Maui

Simple phonebook app build using [MAUI](https://docs.microsoft.com/en-us/dotnet/maui/).

> This is currently work in progress, the UI looks horrendous 😁

The project has the following features:
 - Display contacts
 - Add contact form
 - View / edit contact form
 - Persisted database

 I have tried to keep everything vanilla & use no external dependencies. I have copied some code bits out of Prism & their general navigation structure since its nice for MVVM.

 There are some bugs in MAUI that I have worked around in this app such as using a converter to concat strings instead of usign a `Label.FormattedString`