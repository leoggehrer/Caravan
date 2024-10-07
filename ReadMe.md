# Karawane

## Lehrziele

* Wie eine einfache Klassenstruktur aufgebaut wird (Vertiefung).
* Wie Objekten miteinander verkettet werden (Vertiefung).
* Wie Listen um Elemente dynamisch erweitert werden (Vertiefung).
* Wie Ausnahmen bei unklaren Situationen eingesetzt werden (Vertiefung).

## Aufgabenstellung

Es ist ein Programm zu erstellen, mit dem nordafrikanische Karawansereien in Zukunft ihre
Karawanen elektronisch kontrollieren möchten. Eine Karawane besteht aus einer Anzahl Packtiere
(PackAnimal). Dies können entweder Kamele (Camel) oder Pferde (Horse) sein. Diese Kamele und
Pferde haben folgende Eigenschaften:

```csharp

string Name 
    Der Name des Tieres (PackAnimal).

int MaxPace
    Die Anzahl Meilen, die ein Tier ohne Ladung pro Stunde zurücklegt. Diese Größe ist unveränderlich. Ein Kamel(Camel) darf ein max. Geschwindigkeit von 20 haben, Pferde hingegen eine max. Geschwindigkeit von 70.

int Load
    Die Anzahl der Ballen, die ein Tier im Moment trägt. Allerdings reduziert sich bei einem Kamel die tatsächliche Reisegeschwindigkeit gegenüber der maximalen Marschgeschwindigkeit um 1 für jeden Ballen, das das Kamel tragen muss. Bei Pferden reduziert sich die tatsächliche Reisegeschwindigkeit um 10 pro Ballen, die das Pferd tragen muss. Bei load > maxPace lassen sich sowohl Kamele als auch Pferde nieder und stehen nicht mehr auf.

PackAnimal Next
    Die Tiere einer Karawane sind in einer Reihe aneinandergebunden. An jedem Tier hängt genau ein nachfolgendes Tier (PackAnimal). Nur am letzten Tier der Karawane hängt kein weiteres Tier.

Caravan MyCaravan
    Zusätzlich muss noch jedes Tier wissen, zu welcher Karawane (Caravane) es gehört. Kann auch direkt geändert werden.

int Pace
    Liefert die tatsächliche Geschwindigkeit eines Tieres. Dabei wird die aktuelle Ladung berücksichtigt. 

```

Beim Anlegen eines Tieres werden sein Name (name) und seine maximale Marschgeschwindigkeit
(mp) übergeben. Schon beim Anlegen wird – je nach Kamel oder Pferd – überprüft, ob diese max.
Marschgeschwindigkeit nicht zu hoch oder zu niedrig (< 0) ist. Im Fehlerfall wird die Geschwindigkeit
nach oben (max. Geschwindigkeit) oder nach unten (0) korrigiert.
Eine Karawane (Caravan) bildet mit den Packtieren eine logische Liste. Zwei Methoden
(GetByName(..) und GetByPosition(…)) stellen über den Namen und über die Position des Packtieres
den Zugriff auf das Tier bereit. Die Reisegeschwindigkeit (Pace) der Karawane entspricht der
Geschwindigkeit des langsamsten Tiers. Über Load erhält man die Gesamtanzahl der Ballen, die von
der Karawane transportiert werden.
Es können Tiere in die Karawane aufgenommen werden (AddPackAnimal). Gehörte das Tier bisher
einer anderen Karawane (Caravane) an, ist es natürlich vorher aus dieser zu entfernen
(RemovePackAnimal). Ein Tier kann natürlich nicht mehrmals in einer Karawane oder gleichzeitig in
mehreren Karawanen vorkommen. Tiere können auch direkt aus der Karawane entfernt werden,
indem ihr Property MyCaravan auf eine andere Karawane oder null gesetzt wird. Die Tiere der
Karawane können von ihrer Last befreit werden (Unload). Die Karawane (Caravane) übernimmt
weitere Ballen und verteilt diese so auf die Lasttiere, dass die Karawanengeschwindigkeit
möglichst hoch bleibt (AddLoad).

Natürlich sind noch die ToString-Methoden der Klasse Caravane und PackAnimal zu
überschreiben.

Die Ausgabe, für die Klasse PackAnimal, hat folgendes Format:

 Name(Ladung/Pace/MaxPace)

Die Ausgabe, für die Klasse Caravane, hat folgendes Format:

Caravane: Gobi
MaxPace: 10 mp
PackAnimal(s): NameTier1(10/50), NameTier2(15/10)…

Für die Karawane gelten folgende Einschränkungen:

* Die Anzahl der Tiere ist dynamisch (0 ≤ n < ∞)

Zu all diesen Anforderungen schreibe ein Programm, mit welchem unsere Klasse Caravane
ausführlich getestet werden kann.

Viel Spaß beim Umsetzen