# AdoptApalWebApplication

**Web-Anwendung für Web Engineering 1, entwickelt von Anna-Lisa Merkel und Molham Al-khodari.**

## Was ist AdoptAPal?

AdoptAPal ist eine Web-Anwendung, die dazu dient, Tiere zur Adoption zu finden und die Anbieter zu kontaktieren. Sowohl Anbieter (Privatpersonen, Züchter, Tierheime) als auch Interessenten können die App nutzen. Eine Registrierung ist nur für das Hochladen von Tieren erforderlich, die meisten Funktionen stehen jedoch auch ohne Registrierung zur Verfügung.

## Kernfunktionalitäten

- Übersichtliche Listenansicht aller hochgeladenen Tiere
- Detaillierte Ansicht jedes einzelnen Tierprofils
- Anzeige von Anbieterprofilen (getrennte öffentliche und private Profile)
- Filter- und Suchfunktion für die Listenansicht
- Kartenansicht mit den Standorten der Anbieter
- Formular zum Hochladen neuer Tierprofile
- Merkfunktion für individuelle Tierfavoriten
- Nutzerregistrierung und -anmeldung
- Möglichkeit zur Aktualisierung der persönlichen Daten
- Bearbeitungs- und Löschfunktion für hochgeladene Tierprofile
- Anfrage zur Standortfreigabe vor der Anzeige der Kartenansicht

## Installationsanleitung

- Klone das Repository und öffne es in Visual Studio 2022.
- Gib in der Package Manager Console `Update-Database` ein.
- Die Package Manager Console findest du unter Ansicht -> Weitere Fenster -> Package Manager Console.

## Testnutzer

| Name          | E-Mail                     | Passwort  |
| ------------- | -------------------------  | --------- |
| Hans Meyer    | hans.meyer@fakemail.io     | Test123!  |
| Gabi Schnitzler | gabi.schnitzler@tierheim.de | Test123!  |
| Richard Klöse | richard.kloese@mail.de     | Test123!  |
| Tierheim Katzentempel | katzentempel@tierheim.de | Test123!  |
| Felix Richter | felix.richter@email.com    | Test123!  |

## Aufbau

![Sitemap der AdoptAPal App](documentation/SitemapAdoptAPalV2.png)

- **Startseite (Home):** Zeigt eine Liste aller hochgeladenen Tiere.
- **Tier hinzufügen:** Ermöglicht das Hochladen neuer Tierprofile, nur nach Anmeldung verfügbar.
- **Profil:** Zeigt Profilinformationen und alle hochgeladenen Tiere eines Nutzers.
- **Anmelden (Login):** Formular zum Einloggen in die App.
- **Registrieren:** Formular zur Registrierung in der App.
- **Einstellungen:** Ermöglicht die Aktualisierung der eigenen Nutzerdaten, nur nach Anmeldung verfügbar.
- **Tier bearbeiten:** Ermöglicht die Änderung der Tierdaten, nur nach Anmeldung und für den Eigentümer verfügbar.
- **Detailseite Tier:** Zeigt detaillierte Informationen zu einem Tier und den dazugehörigen Anbieterangaben.
- **Öffentliches Profil:** Zeigt Kontaktinformationen und hochgeladene Tiere eines Nutzers, für alle Nutzer sichtbar.

## Datenbank

![Datenbank der AdoptAPal App](documentation/Database-Entity-Diagram.png)

## Bekannte Bugs / Verbesserungsmöglichkeiten

_(Hier können bekannte Probleme oder mögliche Verbesserungen aufgelistet werden.)_

## Schwierigkeiten bei der Entwicklung

_(Hier können aufgetretene Herausforderungen oder Schwierigkeiten während der Entwicklung beschrieben werden.)_

## Verwendete Tools und Quellen

- Visual Studio 2022 (IDE)
- Gitlab (Versionsverwaltung)
- drawio (Diagramme)
- Figma (Mockups)
- Open Street Map (Kartenansicht)

## Präsentationen

- [Auftaktpräsentation](documentation/AdoptAPal_Auftaktpräsentation.pdf)
- [Abschlusspräsentation](documentation/AdoptAPal_Abschlusspräsentation.pdf)
