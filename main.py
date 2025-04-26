class Track:
    def __init__(self, title: str, artist: str):
        self.title = title
        self.artist = artist

    def __str__(self) -> str:
        return f"{self.title} - {self.artist}"

class Playlist:
    def __init__(self, name: str):
        self.name = name
        self.tracks = []

    def add_track(self, track: Track) -> None:
        if isinstance(track, Track):
            self.tracks.append(track)
            print(f"Dodano utwór '{track.title}' do playlisty '{self.name}'.")
        else:
            print("Nie można dodać elementu, który nie jest utworem.")

    def remove_track(self, track: Track) -> None:
        if track in self.tracks:
            self.tracks.remove(track)
            print(f"Usunięto utwór '{track.title}' z playlisty '{self.name}'.")
        else:
            print(f"Utwór '{track.title}' nie istnieje w playliście '{self.name}'.")

    def display_playlist(self) -> None:
        if self.tracks:
            print(f"Playlista: {self.name}")
            for i, track in enumerate(self.tracks):
                print(f"{i+1}. {track}")
        else:
            print(f"Playlista '{self.name}' jest pusta.")

    def play_playlist(self) -> None:
        if self.tracks:
            print(f"Odtwarzanie playlisty: {self.name}")
            for track in self.tracks:
                print(f"Odtwarzanie: {track}")
        else:
            print(f"Playlista '{self.name}' jest pusta, nie ma czego odtwarzać.")

class User:
    def __init__(self, username: str):
        self.username = username
        self.playlists = {}

    def create_playlist(self, playlist_name: str) -> Playlist:
        if playlist_name not in self.playlists:
            self.playlists[playlist_name] = Playlist(playlist_name)
            print(f"Użytkownik '{self.username}' utworzył playlistę '{playlist_name}'.")
            return self.playlists[playlist_name]
        else:
            print(f"Playlista '{playlist_name}' już istnieje dla użytkownika '{self.username}'.")
            return self.playlists[playlist_name]

    def get_playlist(self, playlist_name: str) -> Playlist|None:
        if playlist_name in self.playlists:
            return self.playlists[playlist_name]
        else:
            print(f"Playlista '{playlist_name}' nie istnieje dla użytkownika '{self.username}'.")
            return None

    def display_all_playlists(self) -> None:
        if self.playlists:
            print(f"Playlisty użytkownika '{self.username}':")
            for name in self.playlists:
                print(f"- {name}")
        else:
            print(f"Użytkownik '{self.username}' nie ma jeszcze żadnych playlist.")


def main() -> None:
    user1 = User("Kowalski")

    my_playlist = user1.create_playlist("My playlist")
    other_playlist = user1.create_playlist("Other playlist")

    song1 = Track("Bohemian Rhapsody", "Queen")
    song2 = Track("Stairway to Heaven", "Led Zeppelin")
    song3 = Track("Imagine", "John Lennon")
    song4 = Track("Watermelon Sugar", "Harry Styles")

    if my_playlist:
        my_playlist.add_track(song1)
        my_playlist.add_track(song2)
        my_playlist.display_playlist()
        my_playlist.play_playlist()
        my_playlist.remove_track(song1)
        my_playlist.display_playlist()

    if other_playlist:
        other_playlist.add_track(song3)
        other_playlist.add_track(song4)
        other_playlist.display_playlist()
        other_playlist.play_playlist()

    user1.display_all_playlists()


if __name__ == "__main__":
    main()
