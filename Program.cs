using Lab_2_C__Data_Structures;

string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
string filePath = projectFolder + "\\videogames.csv";
List<Videogames> videogames = new List<Videogames>();
Stack<string> userInputMemory = new Stack<string>();
bool endMenu = true;
    using (var sr = new StreamReader(filePath))
    {
        while (!sr.EndOfStream)
        {
            string fileHeader = sr.ReadLine();
            string? line = sr.ReadLine();
            string[] lineElements = line.Split(',');
            Videogames v = new Videogames()
            {
                Name = lineElements[0],
                Platform = lineElements[1],
                Year = Convert.ToInt32(lineElements[2]),
                Genre = lineElements[3],
                Publisher = lineElements[4],
                NA_Sales = Convert.ToDouble(lineElements[5]),
                EU_Sales = Convert.ToDouble(lineElements[6]),
                JP_Sales = Convert.ToDouble(lineElements[7]),
                Other_Sales = Convert.ToDouble(lineElements[8]),
                Global_Sales = Convert.ToDouble(lineElements[9])
            };
            videogames.Add(v);
        }
    }
    var genreDictionary = new Dictionary<string, List<Videogames>>();

    var genres = videogames.Select(v => v.Genre).Distinct();

    foreach (var genre in genres)
    {
        List<Videogames> gamesInGenre = new List<Videogames>();

        foreach (var v in videogames)
        {
            if (v.Genre == genre)
            {
                gamesInGenre.Add(v);
            }
        }

        genreDictionary.Add(genre, gamesInGenre);
    }
    //List Genres
        foreach (var genre in genreDictionary)
        {
            Console.WriteLine(genre.Key);
        }

while (endMenu == true)
{
    //Start user input
    Console.WriteLine("Pick a genre from the list to see all of the games from that genre: ");
    string userInputGenre = Console.ReadLine();
    userInputMemory.Push(userInputGenre);

    bool hasGenre = genreDictionary.ContainsKey(userInputGenre);
    //List games from user input
    if (hasGenre)
    {
        foreach (var game in genreDictionary[userInputGenre])
        {
            Console.WriteLine(game);
        }
    }

    //Rank games based on user input
    Console.WriteLine($"I played every single one of these {userInputGenre} games and these are my totally legit and real rankings. Please be respectful Will. hit enter to continue");
    Console.ReadLine();
    //Create Queue for ranking games
    Queue<Videogames> videogameRank = new Queue<Videogames>();
    List<Videogames> valuesForKey = genreDictionary[userInputGenre];
    int numberOfValues = valuesForKey.Count;
    int c = 5;
    Console.WriteLine("\n");
    Console.WriteLine($"{userInputGenre} rankings: ");

    //Super secret ranking formula that ranks the games I've definitely played
    for (int i = 0; i < 5; i++)
    {
        Random random = new Random();
        int randomGame = random.Next(0, numberOfValues);
        videogameRank.Enqueue(valuesForKey[randomGame]);
    }
    //Display the ranked games
    while (videogameRank.Count > 0)
    {
        string cString = Convert.ToString(c);
        var element = videogameRank.Dequeue();
        Console.WriteLine($"#{cString}: \n" + element);
        c--;
    }

    Console.WriteLine("Would you like to view a new genre or view the previous one or exit? New/Prev");
    string newOrPrev = Console.ReadLine();
    bool prevMenu = true;
    if (newOrPrev.ToLower() == "new")
    {
        foreach (var genre in genreDictionary)
        {
            Console.WriteLine(genre.Key);
        }
        endMenu = true;
    }
    else if(newOrPrev.ToLower() == "prev")
    {
        while (prevMenu == true)
        {
            userInputGenre = userInputMemory.Pop();
            //List games from user input
            if (hasGenre)
            {
                foreach (var game in genreDictionary[userInputGenre])
                {
                    Console.WriteLine(game);
                }
            }

            //Rank games based on user input
            Console.WriteLine($"I played every single one of these {userInputGenre} games and these are my totally legit and real rankings. Please be respectful Will. hit enter to continue");
            Console.ReadLine();
            //Create Queue for ranking games
            valuesForKey = genreDictionary[userInputGenre];
            numberOfValues = valuesForKey.Count;
            c = 5;
            Console.WriteLine("\n");
            Console.WriteLine($"{userInputGenre} rankings: ");

            //Super secret ranking formula that ranks the games I've definitely played
            for (int i = 0; i < 5; i++)
            {
                Random random = new Random();
                int randomGame = random.Next(0, numberOfValues);
                videogameRank.Enqueue(valuesForKey[randomGame]);
            }
            //Display the ranked games
            while (videogameRank.Count > 0)
            {
                string cString = Convert.ToString(c);
                var element = videogameRank.Dequeue();
                Console.WriteLine($"#{cString}: \n" + element);
                c--;
            }
            Console.WriteLine("Would you like to view a new genre or view the previous one or exit? New/Prev");
            string newOrPrev2 = Console.ReadLine();
            if(newOrPrev2.ToLower() == "new")
            {
                prevMenu = false;
            }
            else if (newOrPrev2.ToLower() == "prev")
            {
                prevMenu = true;
            }
            else
            {
                endMenu = false;
            }
        }
        endMenu = true;
    }
    else
    {
        endMenu = false;
    }
}

    


