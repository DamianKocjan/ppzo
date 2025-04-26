using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Kowalski");

            Playlist myPlaylist = user1.CreatePlaylist("My playlist");
            Playlist otherPlaylist = user1.CreatePlaylist("Other playlist");

            Track song1 = new Track("Bohemian Rhapsody", "Queen");
            Track song2 = new Track("Stairway to Heaven", "Led Zeppelin");
            Track song3 = new Track("Imagine", "John Lennon");
            Track song4 = new Track("Watermelon Sugar", "Harry Styles");

            if (myPlaylist != null)
            {
                myPlaylist.AddTrack(song1);
                myPlaylist.AddTrack(song2);
                myPlaylist.DisplayPlaylist();
                myPlaylist.PlayPlaylist();
                myPlaylist.RemoveTrack(song1);
                myPlaylist.DisplayPlaylist();
            }

            if (otherPlaylist != null)
            {
                otherPlaylist.AddTrack(song3);
                otherPlaylist.AddTrack(song4);
                otherPlaylist.DisplayPlaylist();
                otherPlaylist.PlayPlaylist();
            }

            user1.DisplayAllPlaylists();
        }
    }

    public class Track
    {
        public string Title { get; }
        public string Artist { get; }

        public Track(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }

        public override string ToString()
        {
            return $"{Title} - {Artist}";
        }
    }

    public class Playlist
    {
        public string Name { get; }
        private List<Track> tracks;

        public Playlist(string name)
        {
            Name = name;
            tracks = new List<Track>();
        }

        public void AddTrack(Track track)
        {
            if (track != null)
            {
                tracks.Add(track);
                Console.WriteLine($"Dodano utwór '{track.Title}' do playlisty '{Name}'.");
            }
            else
            {
                Console.WriteLine("Nie można dodać null jako utworu.");
            }
        }

        public void RemoveTrack(Track track)
        {
            if (tracks.Contains(track))
            {
                tracks.Remove(track);
                Console.WriteLine($"Usunięto utwór '{track.Title}' z playlisty '{Name}'.");
            }
            else
            {
                Console.WriteLine($"Utwór '{track.Title}' nie istnieje w playliście '{Name}'.");
            }
        }

        public void DisplayPlaylist()
        {
            if (tracks.Count > 0)
            {
                Console.WriteLine($"Playlista: {Name}");
                for (int i = 0; i < tracks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tracks[i]}");
                }
            }
            else
            {
                Console.WriteLine($"Playlista '{Name}' jest pusta.");
            }
        }

        public void PlayPlaylist()
        {
            if (tracks.Count > 0)
            {
                Console.WriteLine($"Odtwarzanie playlisty: {Name}");
                foreach (var track in tracks)
                {
                    Console.WriteLine($"Odtwarzanie: {track}");
                }
            }
            else
            {
                Console.WriteLine($"Playlista '{Name}' jest pusta, nie ma czego odtwarzać.");
            }
        }
    }

    public class User
    {
        public string Username { get; }
        private Dictionary<string, Playlist> playlists;

        public User(string username)
        {
            Username = username;
            playlists = new Dictionary<string, Playlist>();
        }

        public Playlist CreatePlaylist(string playlistName)
        {
            if (!playlists.ContainsKey(playlistName))
            {
                Playlist newPlaylist = new Playlist(playlistName);
                playlists.Add(playlistName, newPlaylist);
                Console.WriteLine($"Użytkownik '{Username}' utworzył playlistę '{playlistName}'.");
                return newPlaylist;
            }
            else
            {
                Console.WriteLine($"Playlista '{playlistName}' już istnieje dla użytkownika '{Username}'.");
                return playlists[playlistName];
            }
        }

        public Playlist GetPlaylist(string playlistName)
        {
            if (playlists.ContainsKey(playlistName))
            {
                return playlists[playlistName];
            }
            else
            {
                Console.WriteLine($"Playlista '{playlistName}' nie istnieje dla użytkownika '{Username}'.");
                return null;
            }
        }

        public void DisplayAllPlaylists()
        {
            if (playlists.Count > 0)
            {
                Console.WriteLine($"Playlisty użytkownika '{Username}':");
                foreach (var playlistName in playlists.Keys)
                {
                    Console.WriteLine($"- {playlistName}");
                }
            }
            else
            {
                Console.WriteLine($"Użytkownik '{Username}' nie ma jeszcze żadnych playlist.");
            }
        }
    }

}
