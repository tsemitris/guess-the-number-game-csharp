using System.Runtime.CompilerServices;

namespace NumbersGame;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n------------------------- \nVälkommen till gissa numret! \n------------------------- \n");
        Console.WriteLine("Meny: \n[1] Starta spel \n[2] Avsluta spel");

        int userIntroMenuChoice;
        while (!int.TryParse(Console.ReadLine(), out userIntroMenuChoice))
        {
            Console.WriteLine("\n------------------------- \nDu kan välja mellan 1-2 \n------------------------- \n");
            Console.WriteLine("Meny: \n[1] Starta spel \n[2] Avsluta spel");
        }

        switch (userIntroMenuChoice)
        {
            case 1:
                ChooseDifficulty();
                break;
            case 2:
                break;
        }
    }

    static void ChooseDifficulty()
    {
        Random random = new Random();

        int randomNumber;
        int userMaxGuesses;
        int veryCloseRange;

        Console.WriteLine("\nSvårighetsgrad: \n[1] Enkelnivå [1-10, 6 försök] \n[2] Mellannivå  [1-25, 5 försök] \n[3] Svårnivå [1-50, 3 försök]");

        int userMenuChoice;
        while (!int.TryParse(Console.ReadLine(), out userMenuChoice))
        {
            Console.WriteLine("\n------------------------- \nDu kan välja mellan 1-3 \n------------------------- \n");
            Console.WriteLine("\nSvårighetsgrad: \n[1] Enkelnivå [1-10, 6 försök] \n[2] Mellannivå  [1-25, 5 försök] \n[3] Svårnivå [1-50, 3 försök]");
        }

        switch (userMenuChoice)
        {
            case 1:
                userMaxGuesses = 6;
                veryCloseRange = 2;
                randomNumber = random.Next(1, 10);
                StartGame(randomNumber, userMaxGuesses, veryCloseRange);
                break;
            case 2:
                userMaxGuesses = 5;
                veryCloseRange = 3;
                randomNumber = random.Next(1, 25);
                StartGame(randomNumber, userMaxGuesses, veryCloseRange);

                break;
            case 3:
                userMaxGuesses = 3;
                veryCloseRange = 5;
                randomNumber = random.Next(1, 50);
                StartGame(randomNumber, userMaxGuesses, veryCloseRange);

                break;
        }
    }
    static void StartGame(int randomNumber, int userMaxGuesses, int veryCloseRange)
    {
        int userGuesses = 1;

        Console.WriteLine("\n------------------------- \n Gissa nummer \n------------------------- \n");
        Console.WriteLine($"Jag tänker på ett nummer. Kan du gissa vilket? Du får {userMaxGuesses} försök. \n");

        // Kontrollerar data som användare mata in är i rätt format.
        // Sparar matat in data i variabel.
        int userInput = InputValidator();

        // Kontrollerar om nummer som användare har mata in är samma som slumpmässigt
        // Om det är inte det skrivs ut ett meddelande till användare med ledtråd. 
        while (userInput != randomNumber && userGuesses <= userMaxGuesses)
        {
            if (userGuesses == userMaxGuesses)
            {
                Console.WriteLine($"\nTyvärr, du lyckades inte gissa talet på {userMaxGuesses} försök! \n");
                break;
            }

            userInput = CheckGuess(userInput, randomNumber, userGuesses, userMaxGuesses, veryCloseRange);
            userGuesses++;
            continue;
        }


        if (userGuesses != userMaxGuesses)
        {
            Console.WriteLine("\n----------------------------- \n Wohoo! Du klarade det! \n----------------------------- \n");
        }

        Console.WriteLine("Vill du spela igen? \n[1] Ja \n[2] Nej");

        // Kontrollerar data som användare mata in är i rätt format.
        // Sparar matat in data i variabel.
        int startAgainInput = InputValidator();


        switch (startAgainInput)
        {
            case 1:
                ChooseDifficulty();
                break;
            case 2:
                break;
        }
    }

    static int CheckGuess(int userInput, int randomNumber, int userGuesses, int userMaxGuesses, int veryCloseRange)
    {
        Random random = new Random();

        string[] tooHighMessages = ["Oj! Lite för högt!", "Nära, men du gissade för högt!", "Du tog i lite för mycket!", "Inte riktigt! Gissa lägre", "Bra försök, men numret är lägre!"];
        string[] tooCloseMessages = ["Det där var nära!", "Nästan där!", "Du är supernära!", "Otroligt nära!", "Nästan, nästan!"];
        string[] tooLowMessages = ["Du behöver sikta lite högre!", "Du är under rätt nummer!", "För lågt! Höj din gissning.", "Inte illa! Men numret är högre!", "Du är kall… gissa högre!"];

        if ((userInput - randomNumber) <= veryCloseRange && (userInput - randomNumber) >= -veryCloseRange)
        {
            // Genererar en slumpmässig nummer
            int randomMessageIndex = random.Next(0, tooCloseMessages.Length);
            Console.WriteLine($"\n---------------------------------- \n [{userGuesses}/{userMaxGuesses}] {tooCloseMessages[randomMessageIndex]} \n---------------------------------- \n");
        }
        else if (userInput > randomNumber)
        {
            // Genererar en slumpmässig nummer
            int randomMessageIndex = random.Next(0, tooHighMessages.Length);
            Console.WriteLine($"\n---------------------------------- \n [{userGuesses}/{userMaxGuesses}] {tooHighMessages[randomMessageIndex]} \n---------------------------------- \n");
        }
        else
        {
            // Genererar en slumpmässig nummer
            int randomMessageIndex = random.Next(0, tooLowMessages.Length);
            Console.WriteLine($"\n---------------------------------- \n [{userGuesses}/{userMaxGuesses}] {tooLowMessages[randomMessageIndex]} \n---------------------------------- \n");
        }

        Console.WriteLine("Försök igen:");
        int.TryParse(Console.ReadLine(), out userInput);

        return userInput;
    }

    static int InputValidator()
    {
        int outputVariable;
        // Skickar ett felmeddelanden om användaren mata inte in heltal
        while (!int.TryParse(Console.ReadLine(), out outputVariable))
        {
            Console.WriteLine("\nDu måste ange ett heltal. Försök igen:");
        }

        return outputVariable;
    }
}
