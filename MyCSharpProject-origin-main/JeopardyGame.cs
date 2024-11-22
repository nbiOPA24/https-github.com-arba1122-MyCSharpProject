//biblotek
using System;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//klassen för själva spelet
public class JeopardyGame
{
    static int cat1_100 = 100, cat1_200 = 200, cat1_300 = 300, cat1_400 = 400, cat1_500 = 500;
    static int cat2_100 = 100, cat2_200 = 200, cat2_300 = 300, cat2_400 = 400, cat2_500 = 500;
    static int cat3_100 = 100, cat3_200 = 200, cat3_300 = 300, cat3_400 = 400, cat3_500 = 500;
    static int cat4_100 = 100, cat4_200 = 200, cat4_300 = 300, cat4_400 = 400, cat4_500 = 500;

    static SoundManager soundManager = new SoundManager();
     


     // startar spelt
    public void StartGame()
    {
        Console.WriteLine("*      VÄLKOMMEN TILL JEOPARDY!     *");
        Console.WriteLine("**************************************");
        Console.WriteLine("   Testa era kunskaper och ha kul!    ");
        Console.WriteLine("**********************************\n");

        Console.WriteLine("Tryck alltid på Enter för att gå vidare i spelet eller Q för att avbryta.");
        Console.WriteLine();

        // Spelare 1
        Console.WriteLine("Spelare 1, var god skriv in ditt namn:");
        string inputName1 = Console.ReadLine();
        Player player1 = new Player(string.IsNullOrWhiteSpace(inputName1) ? "Anonym Spelare" : inputName1);

        // Spelare 2
        Console.WriteLine("Spelare 2, var god skriv in ditt namn:");
        string inputName2 = Console.ReadLine();
        Player player2 = new Player(string.IsNullOrWhiteSpace(inputName2) ? "Anonym Spelare" : inputName2);

        Console.Clear();

        // Presentera Spelare 1
        Console.Clear();
        PresentPlayer(player1.Name);
        Console.ReadKey();

        // Rensa skärmen och presentera Spelare 2
        Console.Clear();
        PresentPlayer(player2.Name);
        Console.ReadKey();

        // Visa regler och starta spelet
        Console.Clear();
        PresentGameRules();
        PlayGame(player1, player2);
    }

    static void PresentPlayer(string name)
    {
        if (name.ToLower().Contains("krister"))
        {
            Console.WriteLine($"Här har vi {name} – en göteborgare som förvandlat snö till hav och fjäll till kust – men hans hjärta slår fortfarande för Östersund!\n" +
                              $"{name} är inte bara en skicklig spelare; han har även en imponerande bakgrund som lärare, författare och mjukvaruutvecklare.\n" +
                              "Med sin passion för programmering och databaser utbildar han både elever och andra lärare och har skrivit skolböcker inom datorprogrammering.\n" +
                              "Men det slutar inte där! Krister är också en förespråkare för mental hälsa och välbefinnande genom sin undervisning i meditation och arrangemang av tysta retreater.\n" +
                              $"Som spelare är {name} kreativ och innovativ, alltid redo att samarbeta i team och utveckla nya idéer.\n" +
                              "Hans kärlek till skönlitteratur ger honom ett unikt perspektiv på spelet, vilket gör varje match ännu mer spännande.\n" +
                              $"Låt oss ge ett stort varmt välkomnande till {name}!");
        }
        else if (name.ToLower().Contains("jonathan"))
        {
            Console.WriteLine($"{name} – en riktig stjärna från Borås! \n" +
                              $"{name} är inte bara en stolt boråsare, han är också en mästare i frisbeegolf! \n" +
                              "Med en frisbee i handen och ett leende på läpparna tar han sig an banorna som en riktig proffs.\n" +
                              "Efter en lång dag på banan är det dags för en festmåltid... av proteinpannkakor! \n" +
                              "Kanske hoppas han att om han äter tillräckligt många, kommer de att förvandlas till hamburgare i hans drömmar? \n" +
                              $"{name} är även en hängiven supporter av FC Barcelona.\n" +
                              "Han har mer än en gång skrikit av glädje när de gör mål – allt medan han planerar sin nästa pannkaksfest!\n" +
                              $"Så, låt oss ge ett stort och varmt välkomnande till {name}!");
        }
        else
        {
            Console.WriteLine($"Låt oss välkomna {name}! \n\n" +
                              $"{name} är mästaren på att svara \"jag vet inte\" i spelet – men oroa er inte, hen har en förmåga att gissa rätt på första försöket! \n\n" +
                              $"När {name} inte spelar Jeopardy, kan du hitta hen med en stor kopp kaffe och en ännu större dröm om att vinna på lotteri.\n\n" +
                              $"Ge ett varmt välkomnande till {name}!");
        }
    }

    //spelregler
    static void PresentGameRules()
    {
        Console.Clear();
        Console.WriteLine("\nRegler:");
        Console.WriteLine("För att få svara, tryck på din knapp så snabbt du kan:");
        Console.WriteLine("Spelare 1 använder tangenten 'A'.");
        Console.WriteLine("Spelare 2 använder tangenten 'L'.");
        Console.WriteLine("Ni har 7 sekunder på er att svara.");
        Console.WriteLine("Vid rätt svar får ni fortsätta välja kategori, vid fel får den som senast hade rätt fortsätta.");
        Console.WriteLine("Spelare 1 får börja spelet.");
        Console.WriteLine("Tryck på Enter för att börja spelet!");
        Console.ReadKey();
        Console.Clear();
    }


     // spelkategorierna   
    static void PresentCategories()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("+-------------------------------------------------------------------------------------------------------------+");
        Console.WriteLine("|                                   Här är dagens kategorier                                                 |");
        Console.WriteLine("+--------------------------+--------------------------+--------------------------+--------------------------+");
        Console.WriteLine("|      1. Kända Citat      |   2. FILMTITLAR I EMOJI 🎬 |     3. GISSA LJUDET 🔊   |  4. SANT ELLER FALSKT    |");
        Console.WriteLine("+--------------------------+--------------------------+--------------------------+--------------------------+");

        Console.WriteLine($"|{DisplayPoints(cat1_100).PadLeft(11).PadRight(26)}|" +
                          $"{DisplayPoints(cat2_100).PadLeft(11).PadRight(26)}|" +
                          $"{DisplayPoints(cat3_100).PadLeft(11).PadRight(26)}|" +
                          $"{DisplayPoints(cat4_100).PadLeft(11).PadRight(26)}|");

        Console.WriteLine($"|{DisplayPoints(cat1_200).PadLeft(11).PadRight(26)}|" +
                          $"{DisplayPoints(cat2_200).PadLeft(11).PadRight(26)}|" +
                          $"{DisplayPoints(cat3_200).PadLeft(11).PadRight(26)}|" +
                          $"{DisplayPoints(cat4_200).PadLeft(11).PadRight(26)}|");

        Console.WriteLine($"|{DisplayPoints(cat1_300).PadLeft(11).PadRight(26)}|" +
                          $"{DisplayPoints(cat2_300).PadLeft(11).PadRight(26)}|" +
                          $"{DisplayPoints(cat3_300).PadLeft(11).PadRight(26)}|" +
                          $"{DisplayPoints(cat4_300).PadLeft(11).PadRight(26)}|");

        Console.WriteLine($"|{DisplayPoints(cat1_400).PadLeft(11).PadRight(26)}|" +
                          $"{DisplayPoints(cat2_400).PadLeft(11).PadRight(26)}|" +
                          $"{DisplayPoints(cat3_400).PadLeft(11).PadRight(26)}|" +
                          $"{DisplayPoints(cat4_400).PadLeft(11).PadRight(26)}|");

        Console.WriteLine($"|{DisplayPoints(cat1_500).PadLeft(11).PadRight(26)}|" +
                          $"{DisplayPoints(cat2_500).PadLeft(11).PadRight(26)}|" +
                          $"{DisplayPoints(cat3_500).PadLeft(11).PadRight(26)}|" +
                          $"{DisplayPoints(cat4_500).PadLeft(11).PadRight(26)}|");

        Console.WriteLine("+--------------------------+--------------------------+--------------------------+--------------------------+");
    }

    static string DisplayPoints(int points)
    {
        return points > 0 ? points.ToString() : " ";
    }

    static bool AllQuestionsAnswered()
    {
    return cat1_100 == 0 && cat1_200 == 0 && cat1_300 == 0 && cat1_400 == 0 && cat1_500 == 0 &&
           cat2_100 == 0 && cat2_200 == 0 && cat2_300 == 0 && cat2_400 == 0 && cat2_500 == 0 &&
           cat3_100 == 0 && cat3_200 == 0 && cat3_300 == 0 && cat3_400 == 0 && cat3_500 == 0 &&
           cat4_100 == 0 && cat4_200 == 0 && cat4_300 == 0 && cat4_400 == 0 && cat4_500 == 0;
    }

    // körning huvudspel
    static void PlayGame(Player player1, Player player2)
    {
    Player currentPlayer = player1;

    while (true)
    {
        // Kontrollera om alla frågor är slut loop
        if (AllQuestionsAnswered())
        {
            Console.Clear();
            Console.WriteLine("Spelet är slut! Dags för finalfrågan!");
            PlayFinal(player1, player2);
            return; // Avsluta spelet efter finalen
        }

        Console.Clear();
        DisplayPlayerScores(player1, player2);
        PresentCategories();

        Console.WriteLine($"{currentPlayer.Name}, välj en kategori (1-4) och tryck Enter:");
        int categoryChoice = ReadCategoryChoice();

        Console.WriteLine("Välj poäng (100, 200, 300, 400, 500):");
        int pointsChoice = ReadPointsChoice();

        int selectedPoints = GetPointsForCategory(categoryChoice, pointsChoice);
        if (selectedPoints == 0)
        {
            Console.WriteLine("Den här frågan har redan ställts! Välj en annan fråga.");
            continue;
        }

        bool correctAnswer = AskQuestion(categoryChoice, pointsChoice, player1, player2, currentPlayer);

        if (correctAnswer)
        {
            Console.WriteLine($"{currentPlayer.Name} svarade rätt och får välja igen!");
        }
        else
        {
            currentPlayer = currentPlayer == player1 ? player2 : player1;
        }

            Console.Clear();
            DisplayPlayerScores(player1, player2);
        }
    }

    static void DisplayPlayerScores(Player player1, Player player2)
    {
        Console.WriteLine("**************************************");
        Console.WriteLine($"Spelare 1: {player1.Name} | Poäng: {player1.Score}");
        Console.WriteLine($"Spelare 2: {player2.Name} | Poäng: {player2.Score}");
        Console.WriteLine("**************************************\n");
    }

    static int ReadCategoryChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.WriteLine("Vänligen ange ett giltigt kategori nummer (1-4):");
        }
        return choice;
    }

    static int ReadPointsChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 100 && choice != 200 && choice != 300 && choice != 400 && choice != 500))
        {
            Console.WriteLine("Vänligen ange ett giltigt poäng (100, 200, 300, 400, 500):");
        }
        return choice;
    }

    static int GetPointsForCategory(int category, int points)
    {
        return category switch
        {
            1 => points switch { 100 => cat1_100, 200 => cat1_200, 300 => cat1_300, 400 => cat1_400, 500 => cat1_500, _ => 0 },
            2 => points switch { 100 => cat2_100, 200 => cat2_200, 300 => cat2_300, 400 => cat2_400, 500 => cat2_500, _ => 0 },
            3 => points switch { 100 => cat3_100, 200 => cat3_200, 300 => cat3_300, 400 => cat3_400, 500 => cat3_500, _ => 0 },
            4 => points switch { 100 => cat4_100, 200 => cat4_200, 300 => cat4_300, 400 => cat4_400, 500 => cat4_500, _ => 0 },
            _ => 0
        };
    }

    static bool AskQuestion(int category, int points, Player player1, Player player2, Player currentPlayer)
    {
        string question = "";
        string answer = "";
        string explanation = "";

        switch (category)
        {
            case 1:
                switch (points)
                {
                    case 100:
                        question = "To be or not to be, that is the question.";
                        answer = "William Shakespeare";
                        explanation = "Denna berömda rad är från William Shakespeares pjäs 'Hamlet'.";
                        cat1_100 = 0;
                        break;
                    case 200:
                        question = "May the Force be with you.";
                        answer = "Star Wars";
                        explanation = "Denna fras är ikonisk för 'Star Wars'.";
                        cat1_200 = 0;
                        break;
                    case 300:
                        question = "I have a dream";
                        answer = "Martin Luther King";
                        explanation = "Martin Luther King Jr. sa detta i sitt kända tal.";
                        cat1_300 = 0;
                        break;
                    case 400:
                        question = "Det bästa med att vara barn är att man får lov att drömma.";
                        answer = "Astrid Lindgren";
                        explanation = "Astrid Lindgren är känd för barns äventyr.";
                        cat1_400 = 0;
                        break;
                    case 500:
                        question = "En liten gnista kan sätta eld på ett stort hav.";
                        answer = "Alfred Nobel";
                        explanation = "Alfred Nobel uttryckte ofta filosofiska tankar.";
                        cat1_500 = 0;
                        break;
                }
                break;

            case 2:
                switch (points)
                {
                    case 100:
                        question = "👨‍❤️‍👨🚢💔";
                        answer = "Titanic";
                        explanation = "Denna emoji kombinerar det tragiska Titanic.";
                        cat2_100 = 0;
                        break;
                    case 200:
                        question = "🦁👑";
                        answer = "Lejonkungen";
                        explanation = "Symbolerna refererar till Lejonkungen.";
                        cat2_200 = 0;
                        break;
                    case 300:
                        question = "🐍⚡";
                        answer = "Harry Potter";
                        explanation = "Blixten och ormen representerar Harry Potter.";
                        cat2_300 = 0;
                        break;
                    case 400:
                        question = "🧙‍♂️💍";
                        answer = "Sagan om ringen";
                        explanation = "Gandalf och Ringen från 'Sagan om ringen'.";
                        cat2_400 = 0;
                        break;
                    case 500:
                        question = "🏹🎯";
                        answer = "Hunger Games";
                        explanation = "Pilar och mål i 'Hunger Games'.";
                        cat2_500 = 0;
                        break;
                }
                break;

            case 3:
                switch (points)
                {
                    case 100:
                        question = "Gissa Ljudet";
                        answer = "Super Mario";
                        explanation = "Ljud från Super Mario.";
                        soundManager.PlaySound("C:\\PROJEKT\\OopProjekt\\sounds\\Super Mario Bros. Theme Song [ ezmp3.cc ]-[AudioTrimmer.com].wav");
                        cat3_100 = 0;
                        break;
                    case 200:
                        question = "Gissa Ljudet";
                        answer = "The Flintstones";
                        explanation = "Ljud från 'The Flintstones'.";
                        soundManager.PlaySound("C:\\PROJEKT\\OopProjekt\\sounds\\Yabba Dabba Doo with Fred Flintstone! [ ezmp3.cc ]-[AudioTrimmer.com].wav");
                        cat3_200 = 0;
                        break;
                    case 300:
                        question = "Gissa Ljudet";
                        answer = "Psycho";
                        explanation = "Klassiskt ljud från 'Psycho'.";
                        soundManager.PlaySound("C:\\PROJEKT\\OopProjekt\\sounds\\Psycho Full Violin Screech [ ezmp3.cc ]-[AudioTrimmer.com].wav");
                        cat3_300 = 0;
                        break;
                    case 400:
                        question = "Gissa Ljudet";
                        answer = "Indiana Jones";
                        explanation = "Musik från Indiana Jones.";
                        soundManager.PlaySound("C:\\PROJEKT\\OopProjekt\\sounds\\Indiana Jones Theme Song [HD] [ ezmp3.cc ]-[AudioTrimmer.com].wav");
                        cat3_400 = 0;
                        break;
                    case 500:
                        question = "Gissa Ljudet";
                        answer = "Hesa Fredrik";
                        explanation = "Ljud från Hesa Fredrik.";
                        soundManager.PlaySound("C:\\PROJEKT\\OopProjekt\\sounds\\Hesa fredrik.wav");
                        cat3_500 = 0;
                        break;
                }
                break;

            case 4:
                switch (points)
                {
                    case 100:
                        question = "Sant eller falskt: Människor nyser snabbare än en geopard kan springa.";
                        answer = "Sant";
                        explanation = "Nysningar kan komma upp i 160 km/h.";
                        cat4_100 = 0;
                        break;
                    case 200:
                        question = "Sant eller falskt: Du bränner fler kalorier av att skratta än av löpband.";
                        answer = "Falskt";
                        explanation = "Löpband är effektivare för kaloriförbränning.";
                        cat4_200 = 0;
                        break;
                    case 300:
                        question = "Sant eller falskt: Det är omöjligt att slicka sin egen armbåge.";
                        answer = "Falskt";
                        explanation = "Det är svårt, men vissa kan.";
                        cat4_300 = 0;
                        break;
                    case 400:
                        question = "Sant eller falskt: Bananskal är halare än is.";
                        answer = "Sant";
                        explanation = "Bananskal är extremt hala.";
                        cat4_400 = 0;
                        break;
                    case 500:
                        question = "Sant eller falskt: Det finns en sport där man kastar pannkakor så högt som möjligt.";
                        answer = "Sant";
                        explanation = "Finns som sport under evenemang.";
                        cat4_500 = 0;
                        break;
                }
                break;
        }

        Console.Clear();
        DisplayPlayerScores(player1, player2);
        Console.WriteLine($"Fråga för {points} poäng: {question}");
        Player answeringPlayer = StartTimerWithKeyCheck(7, player1, player2);

        if (answeringPlayer == null)
        {
            Console.WriteLine("Tiden är slut! Ingen tryckte på knappen i tid.");
        }
        else
        {
            Console.WriteLine($"\n{answeringPlayer.Name}, vad är ditt svar?");
            string playerAnswer = Console.ReadLine();

            if (playerAnswer.Equals(answer, StringComparison.OrdinalIgnoreCase))
            {
                answeringPlayer.Score += points;
                Console.WriteLine($"\n{answeringPlayer.Name} svarade rätt och får {points} poäng!");
            }
            else
            {
                Console.WriteLine($"\n{answeringPlayer.Name} svarade fel.");
            }
        }

        Console.WriteLine($"Rätt svar: {answer}");
        Console.WriteLine($"Förklaring: {explanation}");
        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
        Console.ReadKey();

        return answeringPlayer != null && answeringPlayer.Score > 0;
    }

    static Player StartTimerWithKeyCheck(int seconds, Player player1, Player player2)
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        Player answeringPlayer = null;

        Task timerTask = Task.Run(() =>
        {
            for (int i = seconds; i > 0; i--)
            {
                if (cts.Token.IsCancellationRequested) break;
                Console.WriteLine($"Tid kvar: {i} sekunder");
                Thread.Sleep(1000);
            }
        }, cts.Token);

        Task keyPressTask = Task.Run(() =>
        {
            while (!cts.Token.IsCancellationRequested)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey keyPressed = Console.ReadKey(true).Key;
                    if (keyPressed == ConsoleKey.A)
                    {
                        answeringPlayer = player1;
                        cts.Cancel();
                    }
                    else if (keyPressed == ConsoleKey.L)
                    {
                        answeringPlayer = player2;
                        cts.Cancel();
                    }
                }
            }
        });

        Task.WhenAny(timerTask, keyPressTask).Wait();
        return answeringPlayer;
    }


    //FINAlen

    

    static void PlayFinal(Player player1, Player player2)
    {
        Console.Clear();
        Console.WriteLine("Spelet är slut! Dags för finalfrågan.");
        Console.WriteLine("\nKategorin är: Oväntade Uppfinningar");
        Console.WriteLine("Ni kommer nu få satsa era poäng på sista frågan och ni har 20 sekunder på er.\n");

        // Spelare 1 satsar sina poäng
        Console.WriteLine($"{player1.Name}, du har {player1.Score} poäng.");
        Console.WriteLine("Hur mycket vill du satsa?");
        int player1Bet = ReadBet(player1.Score);

        // Spelare 2 satsar sina poäng
        Console.WriteLine($"{player2.Name}, du har {player2.Score} poäng.");
        Console.WriteLine("Hur mycket vill du satsa?");
        int player2Bet = ReadBet(player2.Score);

        // Presentera finalfrågan
        Console.Clear();
        Console.WriteLine("Finalfrågan lyder:");
        Console.WriteLine("Denna oväntade uppfinning, skapad av en svensk ingenjör 1949, förändrade hur vi arbetar i köket och gjorde att vi kunde säga adjö till trasslig knytning. Vad är det?");
        Console.WriteLine("\nTryck på er knapp för att svara!");

        // Starta timer och få spelare som trycker först
        Player answeringPlayer = StartTimerWithKeyCheck(20, player1, player2);

        if (answeringPlayer == null)
        {
            Console.WriteLine("Ingen tryckte på knappen i tid. Ingen får poäng.");
        }
        else
        {
            Console.WriteLine($"\n{answeringPlayer.Name}, vad är ditt svar?");
            string playerAnswer = Console.ReadLine();

            string correctAnswer = "Plastpåsklämman";

            if (playerAnswer.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))
            {
                if (answeringPlayer == player1)
                {
                    player1.Score += player1Bet;
                    Console.WriteLine($"{player1.Name} svarade rätt och vinner {player1Bet} poäng!");
                }
                else
                {
                    player2.Score += player2Bet;
                    Console.WriteLine($"{player2.Name} svarade rätt och vinner {player2Bet} poäng!");
                }
            }
            else
            {
                if (answeringPlayer == player1)
                {
                    player1.Score -= player1Bet;
                    Console.WriteLine($"{player1.Name} svarade fel och förlorar {player1Bet} poäng.");
                }
                else
                {
                    player2.Score -= player2Bet;
                    Console.WriteLine($"{player2.Name} svarade fel och förlorar {player2Bet} poäng.");
                }
            }
        }

        // Presentera vinnaren
        Console.Clear();
        Console.WriteLine("Finalen är över! Här är resultatet:");
        DisplayPlayerScores(player1, player2);

        if (player1.Score > player2.Score)
        {
            Console.WriteLine($"{player1.Name} vinner spelet med {player1.Score} poäng! Grattis!");
        }
        else if (player2.Score > player1.Score)
        {
            Console.WriteLine($"{player2.Name} vinner spelet med {player2.Score} poäng! Grattis!");
        }
        else
        {
            Console.WriteLine("Spelet slutar oavgjort! Bra kämpat båda två!");
        }
    }


    //satsningen
    static int ReadBet(int maxBet)
    {
        int bet;
        while (!int.TryParse(Console.ReadLine(), out bet) || bet < 0 || bet > maxBet)
        {
            Console.WriteLine($"Ange en giltig insats mellan 0 och {maxBet}:");
        }
        return bet;
    }


}

