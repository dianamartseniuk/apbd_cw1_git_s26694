# APBD Ćwiczenia 1 – Git i GitHub

W projekcie wykorzystałam prostą aplikację konsolową typu ToDo, w której można dodawać, usuwać, oznaczać jako wykonane oraz edytować zadania.

Fast-forward występuje wtedy, gdy gałąź główna nie zmieniła się od momentu utworzenia gałęzi roboczej. W takiej sytuacji Git tylko przesuwa wskaźnik gałęzi bez tworzenia dodatkowego commita. W moim projekcie taka sytuacja miała miejsce podczas łączenia gałęzi z funkcją usuwania zadania, ponieważ na `main` nie było żadnych nowych commitów.

```bash
* e415e21 (origin/feature-remove-task, feature-remove-task) Add remove task functionality
```

Merge commit powstaje wtedy, gdy obie gałęzie rozwijają się niezależnie. W projekcie miało to miejsce przy dodawaniu funkcji oznaczania zadania jako wykonanego. Po utworzeniu gałęzi wprowadziłam zmiany zarówno na `feature-complete-task`, jak i na `main`, dlatego Git nie mógł wykonać fast-forward i utworzył dodatkowy commit łączący historię (`939d8c5 Merge branch 'feature-complete-task'`).

```bash
*   939d8c5 Merge branch 'feature-complete-task'
|\  
| * 2c7caa0 (origin/feature-complete-task, feature-complete-task) Add marking task as completed
| * ef52172 Add IsCompleted property to TodoTask
* | d93025c Improve application header
|/ 
```

Merge i rebase różnią się sposobem łączenia historii. Merge zachowuje rzeczywisty przebieg pracy i tworzy osobny commit, który łączy dwie gałęzie. Rebase natomiast przenosi commity z jednej gałęzi na koniec drugiej, dzięki czemu historia jest liniowa. W projekcie użyłam rebase przy dodawaniu funkcji edycji zadania. Po wykonaniu rebase merge do `main` był prostszy i nie tworzył dodatkowego commita.

```bash
* 2ea0ecd (origin/feature-edit-task, feature-edit-task) Add validation to edit task
* dcdbfd9 Add basic edit task method
* 98e3e20 Add edit task option to menu
* 86bf2b7 Improve empty task list message
```

Konflikt został wywołany przez zmianę tej samej linii kodu w metodzie `RemoveTask` na dwóch gałęziach. Na każdej z nich zmieniłam komunikat po usunięciu zadania w inny sposób. Podczas próby merge Git nie był w stanie automatycznie wybrać poprawnej wersji. Konflikt rozwiązałam ręcznie, analizując obie zmiany i zastępując je jedną spójną wersją komunikatu. Po usunięciu markerów konfliktu sprawdziłam, czy aplikacja działa poprawnie, a następnie zakończyłam merge osobnym commitem.

```bash
*   1fc46cb (HEAD -> main, origin/main) Resolve conflict in remove task message
|\  
| * a42fece (origin/feature-conflict, feature-conflict) Update remove task success message on feature branch
* | 9b3d5c2 Change remove task message on main
|/  
```