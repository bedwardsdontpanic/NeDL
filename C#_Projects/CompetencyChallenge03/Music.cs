class Artist {  // base class (parent) 
    private string artistName;  
    private int age;
    public string getArtistName() {
        return artistName; 
    }

    public void setArtistName (string newName) {
        artistName = newName;
    }

    public int getArtistAge() {
        return age; 
    }

    public void setArtistAge (int newAge) {
        age = newAge;
    }

    public Artist(string newArtist, int newRating) {
        artistName = newArtist;
        age = newRating;
    }

    public Artist() {
        artistName = "";
        age = -1;
    }

}

class Album : Artist {  // derived class (child)
    private string albumName;
    private int releaseDate;

    public string getAlbumName() {
        return albumName; 
    }

    public void setAlbumName(string newName) {
        albumName = newName;
    }

    public int getAlbumReleaseDate() {
        return releaseDate; 
    }

    public void setAlbumReleaseDate (int newReleaseDate) {
        releaseDate = newReleaseDate;
    }

    public Album(string newAlbum, int newReleaseDate) {
        albumName = newAlbum;
        releaseDate = newReleaseDate;
    }

    public Album() {
        albumName = "";
        releaseDate = -1;
    }

    public override string ToString() {
        return "Album: " + albumName;
    }
}