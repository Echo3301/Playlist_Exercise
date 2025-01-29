using System;
using System.ComponentModel.Design;

class Playlist(string playlistName)

{
    public string PlaylistName { get; private set; } = playlistName;
    public string[] Songs { get; private set; } = new string[100];
    public int SongCount { get; private set; } = 0;

    // Metod 1: Lägg till låt
    public void AddSong(string song)
    {
        // ta in sånger
        if (SongCount == 99)
        {
            Console.WriteLine("Spellistan är full");
        }
        else if (song is IsNullOrEmpty)
        {
            Console.WriteLine("Ogiltig inmatning");
        }
        else
        {
            Songs[SongCount] = song;
            SongCount++;
        }
    }

    // Metod 2: Ta bort låt
    public void RemoveSong(string song)
    {
        for (int i = 0; i < SongCount; i++)
        {
            if (Songs[i] == song)
            {
                Songs[i] = null;
                break;
            }
            else if (Songs[i] != song)
            {
                Console.WriteLine("Error");
            }
        }   
    }

    // Metod 3: Visa spellisteinformation
    public void DisplayPlaylistInfo()
    {
        int revSongCount = SongCount;
        for (int i = 0; i < SongCount; i++)
        {
            if (Songs[i] == null)
            {
                --revSongCount;
            }
        }
        Console.WriteLine($"Du har registrerat {revSongCount} låtar i {PlaylistName}");
        for (int i = 0; i < SongCount; i++)
        {
            Console.WriteLine(Songs[i]);
        }
        return;
    }

    // Metod 4: Sök låtar
    public void SearchSongs(string keyword)
    {
        // Kan tas bort
        //keyword = keyword.ToLower();

        // Om sökningen är tom eller bara innehåller mellanrum så avslutas sökningen och ett meddelande visas.
        if (String.IsNullOrEmpty(keyword) || String.IsNullOrWhiteSpace(keyword))
        {
            Console.WriteLine("Sök är tom, tryck enter för att fortsätta");
            Console.ReadLine();
            return;
        }
        // Giltig sökning
        else
        {
            // Nollställer resultCheck om det inte är 0
            int resultCheck = 0;

            // Går igenom Songs-array
            for (int i = 0; i < Songs.Length; i++)
            {
                // Om Songs[i] är null, hopppa över
                if (!String.IsNullOrEmpty(Songs[i]) || !String.IsNullOrWhiteSpace(Songs[i]))
                {
                    // Alla låtar som passar keyword visas, Hela låtens namn behöver inte vara like och den är case-insensitive
                    if (Songs[i].Contains(keyword, StringComparison.InvariantCultureIgnoreCase))
                    {
                        // Ger resultCheck ett värde så det inte blir 0
                        resultCheck++;
                        Console.WriteLine($"Låt {i + 1}: {Songs[i]}");
                    }
                    else if (Songs[i] != keyword)
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }

            // Om resultCheck blir 0 så visas ett meddelande som säger att ingen låt hittades
            if (resultCheck == 0)
            {
                Console.WriteLine("Ingen låt hittades");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Playlist myPlaylist = new Playlist("Min favoritlista");

        while (true)
        {
            Console.WriteLine("\nVälj en åtgärd:");
            Console.WriteLine("1. Lägg till låt");
            Console.WriteLine("2. Ta bort låt");
            Console.WriteLine("3. Visa spellisteinformation");
            Console.WriteLine("4. Sök låtar");
            Console.WriteLine("5. Avsluta");

            string choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":
                    Console.Write("Ange låtens namn att lägga till: ");
                    string songToAdd = Console.ReadLine();
                    myPlaylist.AddSong(songToAdd);
                    break;

                case "2":
                    myPlaylist.DisplayPlaylistInfo();
                    Console.Write("Ange låtens namn att ta bort: ");
                    string songToRemove = Console.ReadLine();
                    myPlaylist.RemoveSong(songToRemove);
                    break;

                case "3":
                    myPlaylist.DisplayPlaylistInfo();
                    break;

                case "4":
                    Console.Write("Ange sökord för låtar: ");
                    string keyword = Console.ReadLine();
                    myPlaylist.SearchSongs(keyword);
                    break;

                case "5":
                    Console.WriteLine("Tack för att du använde vår spellisteapplikation!");
                    return;

                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }
    }
}
