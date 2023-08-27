# AdoptApalWebApplication

**Web-Anwendung für Web Engineering 1, entwickelt von Anna-Lisa Merkel und Molham Al-khodari.**

## Was ist AdoptAPal?

AdoptAPal ist eine Web-Anwendung, die dazu dient, Tiere zur Adoption zu finden und die Anbieter zu kontaktieren. Sowohl Anbieter (Privatpersonen, Züchter, Tierheime) als auch Interessenten können die App nutzen. Eine Registrierung ist nur für das Hochladen von Tieren erforderlich, die meisten Funktionen stehen jedoch auch ohne Registrierung zur Verfügung.

## Hauptfunktionen im Überblick

Unsere Plattform bietet eine Fülle von leistungsstarken Funktionen, um dein Erlebnis bei der Tieradoption so reibungslos und erfreulich wie möglich zu gestalten:

### Entdecken und Filtern

-   **Übersichtliche Listenansicht:** Auf unserer Startseite findt man eine gut strukturierte Liste aller hochgeladenen Tiere, die zur Adoption bereitstehen. Diese Liste ermöglicht es, einen schnellen Überblick zu behalten.
    
-   **Intelligente Filterfunktion:** Dank unserer Filterleiste kann man die Tierliste nach Kategorien, Geschlecht und Alter filtern, um genau die Tiere zu finden, die seinen Vorstellungen entsprechen.

### Detaillierte Tierprofile

-   **Umfangreiche Profilansicht:** Jedes Tier verfügt über eine detaillierte Profilseite, die umfangreiche Informationen über das Tier und seine Geschichte bietet. Von dort aus kann man weitere Details erkunden und sogar den Betreuer des Tiers kontaktieren.
    
-   **Verantwortungsbewusste Anbieter:** Wenn man ein Tierprofil besucht, hat man die Möglichkeit, zum Profil des Betreuers zu navigieren. Dort findet man nicht nur Kontaktinformationen, sondern auch relevante Informationen über den Anbieter sowie seine neuesten Beiträge im Schwarzes brett.

### Interaktion und Kommunikation

-   **Kontaktmöglichkeiten:** Durch unsere Plattform kann man direkt mit Tieranbietern in Kontakt treten und ihnen Fragen stellen. So kann man sicherstellen, dass du alle Informationen hat, um die richtige Entscheidung zu treffen.
    
-   **Message Board:** Unser Schwarzes brett ermöglicht es, Beiträge zu schreiben, zu lesen und Kommentare hinzuzufügen. Hier kann man seine Gedanken teilen, Fragen stellen und wertvolle Informationen von anderen Mitgliedern erhalten.

### Benutzerfreundliches Konto-Management

-   **Registrierung und Anmeldung:** man kann sich einfach registrieren und anmelden, um die volle Funktionalität unserer Plattform zu nutzen.
    
-   **Account-Einstellungen:** Die Einstellungsseite ermöglicht es, Kontoinformationen zu bearbeiten und persönlichen Daten zu aktualisieren. man kann auch sein Konto sicher löschen, wenn man dies wünschst.
    
-   **Passwortwiederherstellung:** Falls man sein Passwort vergessen hat, bieten wir eine bequeme Funktion zur Passwortwiederherstellung per E-Mail.

### Verwaltung deiner Interaktionen

-   **Meine Tiere:** Unter dieser Rubrik findet man eine Liste der von hochgeladenen Tiere. Hier kann man Tiere bearbeiten oder löschen.
    
-   **Favoritenliste:** man kann seine Lieblingstiere markieren und in seiner Favoritenliste speichern, um sie jederzeit schnell wiederzufinden oder bei Bedarf zu entfernen.

### Sicherheit und Zuverlässigkeit

Alle eingegebenen Daten werden sorgfältig validiert und gesichert, um deine Privatsphäre und Sicherheit zu gewährleisten.

## Installationsanleitung

### Schritt 1: Repository klonen

Öffnen Sie ihr Terminal und führen Sie den folgenden Befehl aus, um das Repository auf ihrem lokalen System zu klonen:

    git clone https://git.ai.fh-erfurt.de/adoptapal/adoptapalwebapplication.git

### Schritt 2: Projekt in Visual Studio 2022 öffnen

Navigieren Sie zu dem Ordner, in dem Sie das Repository geklont haben, und öffnen Sie es in Visual Studio 2022.

### Schritt 3: Löschen der Adoptapal-Datenbank

Öffnen Sie den SQL Server Object Explorer in Visual Studio und überprüfen Sie, ob die "Adoptapal"-Datenbank vorhanden ist. Falls ja, löschen Sie sie, um mögliche Konflikte zu vermeiden.

### Schritt 4: Datenbankmigration durchführen

Öffnen Sie die "Package Manager Console" in Visual Studio und führen Sie den folgenden Befehl aus, um die erforderlichen Datenbankmigrationen durchzuführen:

    Update-Database
    
Sie werden eine Meldung ähnlich der folgenden sehen:

    Build started...
    Build succeeded.
    Applying migration '20230825124708_initial'.
    Applying migration '20230826102219_testData'.
    Done.

### Schritt 5: Anwendung starten

Nach erfolgreicher Migration können Sie die Anwendung starten. Registrieren Sie sich, um Zugriff zu erhalten, oder verwenden Sie Testdaten, um sich anzumelden und die Anwendung zu erkunden.

## Testnutzer

| Name          | E-Mail                     | Passwort  |
| ------------- | -------------------------  | --------- |
| Hans Meyer    | hans.meyer@fakemail.io     | Test123!  |
| Gabi Schnitzler | gabi.schnitzler@tierheim.de | Test123!  |
| Richard Klöse | richard.kloese@mail.de     | Test123!  |
| Tierheim Katzentempel | katzentempel@tierheim.de | Test123!  |
| Felix Richter | felix.richter@email.com    | Test123!  |

## Seitenstruktur

### 1. Startseite (Home)

Die Startseite gibt einen schnellen Überblick über die Vielfalt der verfügbaren Tiere. Hier kann man die Liste der hochgeladenen Tiere durchstöbern und mit den Filteroptionen deine Suche nach bestimmten Tierkategorien, Geschlechtern und Altersgruppen verfeinern.

### 2. Message Board

Das Message Board bietet die Möglichkeit, Beiträge zu schreiben, Beiträge von anderen zu lesen und Kommentare zu hinterlassen. Hier kann man wertvolle Informationen teilen, Fragen stellen und sich mit anderen Tierliebhabern austauschen.

### 3. Einstellungen (Settings)

Die Einstellungsseite erlaubt es, persönlichen Nutzerdaten zu verwalten. man kann seine Kontoinformationen aktualisieren und sicherstellen, dass seine Daten immer auf dem neuesten Stand sind.

### 4. Profil

Die Profilseite bietet einen umfassenden Einblick in seine Aktivitäten auf der Plattform. Hier kann man nicht nur seine hochgeladenen Tiere anzeigen lassen, sondern auch Informationen zu seinen Kontaktmöglichkeiten und anderen relevanten Details finden.

### 5. Meine Tiere (My Animals)

In diesem Bereich kann man eine Liste der Tiere anzeigen, die man hochgeladen hat. man hat die Möglichkeit, diese Tiere zu bearbeiten oder zu löschen, um sicherzustellen, dass die Informationen immer aktuell sind.

### 6. Favorisierte Tiere (Favorite Animals)

Favoritenliste zeigt die Tiere, die man als Favoriten markiert hat. man kann Tiere von dieser Liste entfernen oder neue hinzufügen, um die Tiere, die dir besonders am Herzen liegen, immer griffbereit zu haben.

### 7. Detailseite / Erstellen / Löschen Tier

Die Detailseite eines Tiers bietet ausführliche Informationen zu diesem Tier sowie Angaben zum zugehörigen Anbieter. Zusätzlich kann man Tierdaten bearbeiten oder das Tier löschen, sofern man der Eigentümer ist.

### 8. Anmelden (Login) / Registrieren / Passwort vergessen

Die Anmeldeseite ermöglicht es, sich in sein Konto einzuloggen, während die Registrierungsseite die Möglichkeit gibt, ein neues Konto zu erstellen. Falls man sein Passwort vergessen hast, bieten wir eine bequeme Funktion zur Wiederherstellung.

## Datenbank

![Datenbank der AdoptAPal App](documentation/Database-Entity-Diagram.png)

## Verwendete Tools und Quellen

- Visual Studio 2022 (IDE)
- Gitlab (Versionsverwaltung)
- drawio (Diagramme)
- Figma (Mockups)
- Open Street Map (Kartenansicht)

## Präsentationen

- [Auftaktpräsentation](documentation/AdoptAPal_Auftaktpräsentation.pdf)
- [Abschlusspräsentation](documentation/AdoptAPal_Abschlusspräsentation.pdf)
