# WorkoutNote

WorkoutNote ist eine mobile Workout-Tracking-App, entwickelt mit C# und .NET MAUI.  
Ziel des Projekts ist die Umsetzung einer strukturierten, wartbaren Architektur mit klarer Trennung von UI und Geschäftslogik.

Der Fokus liegt auf:

- sauberer MVVM-Architektur  
- lokaler Datenpersistenz  
- Dependency Injection  
- klarer Projektstruktur  

---

## Features

- Erstellen und Verwalten von Workouts  
- Hinzufügen und Bearbeiten von Übungen  
- Persistente Speicherung über SQLite  
- Strukturierte Navigation  
- Klare Trennung von View und ViewModel  

### Geplante Erweiterungen

- Unit Tests für ViewModels  
- Zeit-Tracking pro Übung und Workout  
- Erweiterte Statistiken  
- Einstellungsseite (z. B. Theme, Einheiten)

---

## Architektur

Die Anwendung folgt dem MVVM-Pattern:

- **Views** enthalten ausschließlich UI-Logik  
- **ViewModels** kapseln Zustandsverwaltung und Geschäftslogik  
- **Models** repräsentieren die Domänenstruktur  
- Datenzugriff erfolgt über SQLite  
- Services werden über Dependency Injection bereitgestellt  

Ziel war es, Logik nicht im Code-Behind zu platzieren, sondern testbar und wartbar zu strukturieren.

---

## Tech Stack

- C#  
- .NET MAUI  
- MVVM Pattern  
- SQLite  
- Dependency Injection  

---

## Projektstruktur

- `Models/` – Domänenmodelle  
- `ViewModels/` – Geschäftslogik und State Management  
- `Views/` – UI-Komponenten  
- `Services/` – Datenzugriff und abstrahierte Logik  


---

## Testing & Qualität

Das Projekt ist so aufgebaut, dass ViewModels unabhängig von der UI testbar sind.  
Die Integration von Unit Tests zur Absicherung der Geschäftslogik ist als nächster Schritt geplant.

---

## Motivation

WorkoutNote entstand als eigenständiges Projekt zur Vertiefung von:

- Architekturprinzipien im .NET-Umfeld  
- sauberer Code-Struktur  
- testbarer Anwendungslogik  
- praxisnaher App-Entwicklung mit MAUI  
