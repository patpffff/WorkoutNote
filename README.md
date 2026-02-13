# WorkoutNote

WorkoutNote ist eine mobile Workout-Tracking-App, entwickelt mit C# und .NET MAUI.  

https://play.google.com/store/apps/details?id=com.patpffff.workNote

---
![Screenshot_20260212_205141](https://github.com/user-attachments/assets/7bc1bb82-641c-4b60-80b6-e3888c395ee2)

![Screenshot_20260212_204907](https://github.com/user-attachments/assets/1cc2451c-ee2e-4e98-9764-d9d14a261f71)

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
