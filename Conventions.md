# Coventions BarrocIntens
**What is this?**:
These are the Coventions for BarrocIntens.

**GitHub Rules**
- **Rule 1:** Do not push errors, or code that isn't finished unless Everyone needs the code!
- **Rule 2:** Show your code to at least one team member
- **Rule 3:** Do not push to the main branch, unless it is needed.

**Code Rules**
- **Rule 1:** All code must be written in English.
```C#
//This is correct
public int Id { get; set; }
public string Name { get; set; }
public string Description { get; set; }
public DateTime Release { get; set; 
public double Rating { get; set; }

//This is incorrect
public int Id { get; set; }
public string Naam { get; set; }
public int Omschrijving { get; set; }
public int Uitgave { get; set; }
public int Beoordeling { get; set; }
```
- **Rule 2:** Use camelCase for method arguments and local variables.
```C#
//This is correct
encounter1.Name = "Battle";
encounter1.EnemyName = Program.enemyList[0].Name;
encounter1.EnemyHealth = Program.enemyList[0].Health;
encounter1.EnemyPower = Program.enemyList[0].Damage;
encounter1.DidPlayerRun = "";

//This is incorrect
Encounter1.Name = "Battle";
Encounter1.EnemyName = Program.enemyList[0].Name;
Encounter1.EnemyHealth = Program.enemyList[0].Health;
Encounter1.EnemyPower = Program.enemyList[0].Damage;
Encounter1.DidPlayerRun = "";
```
- **Rule 3:** Use PascalCase for class names and method names.
```C#
//This is correct
internal class Program{}

public string Id { get; set; }
public string Name { get; set; }
public string EnemyName { get; set; }
public int EnemyHealth { get; set; }
public int EnemyPower { get; set; }
public string DidPlayerRun { get; set; }

//This is incorrect
internal class program{}

public string id { get; set; }
public string name { get; set; }
public string enemyName { get; set; }
public int enemyHealth { get; set; }
public int enemyPower { get; set; }
public string didPlayerRun { get; set; }

```
- **Rule 4:** When calling things in Console.WriteLine  
use $ instead of +
```C#
//This is correct
Console.WriteLine($"The name of the game is {game.Name}")

//This is incorrect
Console.WriteLine("The name of the game is" + Game.Name)
```
- **Rule 5:** Make use of Console.Clear To keep things clean 
```C#
//This is correct
Console.WriteLine("");
Console.WriteLine("Press Enter to continue...");
Console.ReadKey();
Console.Clear()

//This is incorrect
Console.WriteLine("");
Console.WriteLine("Press Enter to continue...");
Console.ReadKey();
```
- **Rule 6:** Code must stay consistent
```C#
//This is correct
n = this.GameName;
p = this.GameRating;
h = this.GameRelease;

//This is incorrect
n = this.gameName;
P = this.game_Beoordeling;
H = this.UitgaveGame;
```
- **Rule 7:** End sentences with a . ! or ?
```C#
//This is correct
Console.WriteLine($"Hello {user.Name}, how is it going?")
Console.WriteLine("Awesome! that's good to hear!")

//This is incorrect
Console.WriteLine("$"Hello {user.Name}, how is it going")
Console.WriteLine("But is it really")
```
- **Rule 8:** Use single-line comments (//) for brief explanations.
```C#
//This is correct

/* This is incorrect */
```
