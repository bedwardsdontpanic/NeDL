using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Linq;

using var client = new HttpClient();

    string movieAPIKey = "?api_key=4203a600ed52ce511aa661cfd9adc02c";
    
    string movieURL = "https://api.themoviedb.org/3/movie/550.json?api_key=4203a600ed52ce511aa661cfd9adc02c";
    string usersURL = "http://webcode.me/users.json";
    
    
    var usersData = await client.GetFromJsonAsync<Users>(usersURL);
    var moviesData = await client.GetFromJsonAsync<Movie>(movieURL);

    string moviesURL = "http://webcode.me/users.json";
    var userData = await client.GetFromJsonAsync<Users>(usersURL);
    var movieData = await client.GetFromJsonAsync<Movie>(moviesURL);

//    var seriesCollection = JObject.Parse(popularJson)["results"].ToObject<ObservableCollection<SeriesModel>>();

        if(userData != null){
            foreach(var user in userData.users){
                Console.WriteLine(user.FirstName);
            }
        }


        Console.WriteLine(movieData.overview);
    



    class Users {
        public List<User> users{get; set;} = new();
    }

    class User {
        [JsonPropertyName("id")]
        public int id{get; set;}

        [JsonPropertyName("first_name")]
        public string FirstName{get; set;} = string.Empty;

        [JsonPropertyName("last_name")]
        public string LastName{get; set;}  = string.Empty;
    }

        class Movie {
        [JsonPropertyName("original_title")]
        public string title{get; set;} = string.Empty;

        [JsonPropertyName("overview")]
        public string overview{get; set;} = string.Empty;

        [JsonPropertyName("vote_average")]
        public double averageScore{get; set;}
    }