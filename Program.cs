
using System.Reflection.Metadata.Ecma335;

string[] wl =
{
@"
┌───────────────────────────┐
│                           │
│ WW       WW  **  NN   N   │
│ WW       WW  ii  NNN  N   │
│  WW WWW WW   ii  N NN N   │
│   WWWWWWW    ii  N  NNN   │
│    WW WW     ii  N   NN   │
│                           │
│ Good job!                 │
│ You guessed the word!     │
└───────────────────────────┘
",
@"
┌────────────────────────────────────┐
│ LLL         OOOO    SSSS   SSSS    │
│ LLL        OO  OO  SS  SS SS  SS   │
│ LLL       OO    OO SS     SS       │
│ LLL       OO    OO  SSSS   SSSS    │
│ LLL       OO    OO     SS     SS   │
│ LLLLLLLLL  OO  OO  SS  SS SS  SS   │
│ LLLLLLLLL   OOOO    SSSS   SSSS    │
│                                    |
│ You were so close.                 │
│ Next time you will guess the word! │
└────────────────────────────────────┘
"
};

string[] frames =
{
    @"      ╔═══╗   " + '\n' +
    @"          ║   " + '\n' +
    @"          ║   " + '\n' +
    @"          ║   " + '\n' +
    @"          ║   " + '\n' +
    @"     ███  ║   " + '\n' +
    @"    ══════╩═══",

    @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"          ║   " + '\n' +
    @"          ║   " + '\n' +
    @"     ███  ║   " + '\n' +
    @"    ══════╩═══",

    @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"          ║   " + '\n' +
    @"     ███  ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"      |   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"     ███  ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"      |\  ║   " + '\n' +
    @"          ║   " + '\n' +
    @"     ███  ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"     /|\  ║   " + '\n' +
    @"          ║   " + '\n' +
    @"     ███  ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"     /|\  ║   " + '\n' +
    @"       \  ║   " + '\n' +
    @"     ███  ║   " + '\n' +
    @"    ══════╩═══",

    @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"     /|\  ║   " + '\n' +
    @"     / \  ║   " + '\n' +
    @"     ███  ║   " + '\n' +
    @"    ══════╩═══",
    @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"     /|\  ║   " + '\n' +
    @"     / \  ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══"
};
int misses = 0;
List<char> usedLetters = new List<char>();
bool endGame = false;
string directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
string path = $@"{directory}\words.txt";
string[] words = File.ReadAllLines(path);
Random random = new Random();
string chosenWord = words[random.Next(words.Length - 1)];
int wordLength = chosenWord.Length;
bool[] guessedSpaces = new bool[wordLength];
Console.CursorVisible = false;
DrawScreen(); PickLetter();




void PickLetter()
{
    if (endGame) return;
    char.TryParse(Console.ReadLine(), out char curLetter);
    if(Char.IsLetter(curLetter))
    {
        if (usedLetters.Contains(curLetter))
        {
            Console.Clear();
            Console.WriteLine("You've already tried this letter");
            DrawScreen(); PickLetter();
        }
        else
        {
            usedLetters.Add(curLetter);
                if (chosenWord.Contains(curLetter) && guessedSpaces.Contains(false))
                {

                    for (int i = 0; i < wordLength; i++)
                    {
                        if (chosenWord[i] == curLetter) guessedSpaces[i] = true;

                    }
                    Console.Clear();
                    if (!guessedSpaces.Contains(false))
                    {
                        Console.WriteLine(wl[0]);
                        while(true) { 
                        string blockade = Console.ReadLine();
                        DrawScreen(); PickLetter(); break;
                        }
                    }
                    DrawScreen(); PickLetter();
                }
                else
                {
                    misses++;
                    Console.Clear();
                    Console.WriteLine("The word doesn't contain this letter");
                    DrawScreen(); PickLetter();
                }
            }
        }
        else
        {
            Console.Clear(); Console.WriteLine("Invalid input, try again");
            DrawScreen(); PickLetter();
        }
    

    
}
void DrawScreen()
{
    if (misses < 7) Console.WriteLine(frames[misses].ToString());
    else { Console.Clear(); 
           Console.WriteLine(frames[7]);
           Thread.Sleep(1000); Console.Clear(); 
           Console.WriteLine(frames[8]); Thread.Sleep(1000); 
           Console.Clear(); Console.WriteLine(wl[1]); 
           endGame = true;
            while (true)
            {
                string blockade = Console.ReadLine();
                DrawScreen(); PickLetter(); break;
            }
    }
    Console.Write("Guess: ");
    for(int i = 0; i < wordLength; i++)
    {
        if (guessedSpaces[i]) Console.Write(chosenWord[i] + " ");
        else Console.Write("_ "); 
    }
    Console.WriteLine();
    Console.Write("You used these letters:");
    Console.WriteLine(String.Join(" ", usedLetters));
    Console.Write("Choose a letter:");
}
