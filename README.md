# AdoptApalWebApplication

Eine Wep Applikation für Web Engenering 1. Entwickelt von Anna-Lisa Merkel und Molham Al-khodari.

## Was ist AdoptAPal?

AdoptAPal ist eine Wep Applikation, die dabei helfen soll, Tiere zu finden, die zur Adoption angeboten werden, und deren Anbieter zu kontaktieren. Dabei sollen sowohl die Anbieter (Privatpersonen, Züchter, Tierheime) als auch die Interessenten die App nutzen können. Eine Registrierung ist nur notwendig, wenn man als Anbieter Tiere hochladen möchte. Der Großteil der Funktionalitäten ist auch ohne Registrierung erreichbar.


## Kernfunktionalitäten
- Listenansicht mit allen hochgeladenen Tieren
- Detailansicht aller Tiere
- Detailansicht aller Anbieter (separates öffentliches und privates Profil)
- Filterung der Listenansicht / Suchfunktion
- Kartenansicht mit Standorten der Anbieter
- Formular zum Hochladen neuer Tiere
- Speichern einzelner Tiere für später und dazugehörige Merkliste
- Registrierung und Anmeldung
- Möglichkeit zum Ändern eigener Daten
- Möglichkeit zum Bearbeiten und Löschen hochgeladener Tiere
- Frage nach Erlaubnis zur Standortfreigabe (vor dem Anzeigen der Kartenansicht)


## Installationsanleitung
- Grundsätzlich kann das Repository einfach geklont und mit Visual Studio 2022 geöffnet werden.
- Package Manager Console öfnnen und `Update-Database` eingeben 

Package Manager Console ist unter Ansicht -> Weitere Fenster -> Package Manager Console zu finden


## Testnutzer
| Name | Email-Adresse | Passwort
| --- | --- |
| Hans Meyer | hans.meyer@fakemail.io | Test123!
| Gabi Schnitzler | gabi.schnitzler@tierheim.de | Test123!
| Richard Klöse | richard.kloese@mail.de | Test123!
| Tierheim Katzentempel | katzentempel@tierheim.de | Test123!
| Felix Richter | felix.richter@email.com | Test123!


## Aufbau
![Sitemap der AdoptAPal App](documentation/SitemapAdoptAPalV2.png)

**Home:** Startseite der Wep Applikation mit einer Liste aller hochgeladenen Tiere

**Tier hinzufügen:** Formular zum Hochladen eines neuen Tieres, nur nach Anmeldung verfügbar

**Profil:** zeigt Profile Informationen und alle seine hochgeladene Tiere

**Login:** Formular zum Anmelden in der App

**Registrierung:** Formular zum Registrieren in der App

**Einstellungen:** Formular zum Ändern der eigenen Nutzerdaten, nur nach Anmeldung verfügbar

**Tier bearbeiten** Formular zum Ändern der Daten eines Tieres, nur nach Anmeldung für den Eigentümer des entsprechenden Tieres verfügbar

**Detailseite Tier:** detaillierte Informationen zu jedem Tier und Angabe des Anbieters

**Öffentliches Profil:** zeigt Kontaktinformationen und hochgeladene Tiere des jeweiligen Nutzers, für alle Nutzer sichtbar


## Datenbank
![Datenbank der AdoptAPal App](documentation/Database-Entity-Diagram.png)



## bekannte Bugs / Verbesserungsmöglichkeiten


## Schwierigkeiten bei der Arbeit


## genutzte Tools und andere Quellen
- Visual Studio 2022 (IDE)
- Gitlab (Versionsverwaltung)
- drawio (Diagramme)
- Figma (Mockups)
- Open Street Map (Kartenansicht)


## Präsentationen
- [Auftaktpräsentation](documentation/AdoptAPal_Auftaktpräsentation.pdf)
- [Abschlusspräsentation](documentation/AdoptAPal_Abschlusspräsentation.pdf)
