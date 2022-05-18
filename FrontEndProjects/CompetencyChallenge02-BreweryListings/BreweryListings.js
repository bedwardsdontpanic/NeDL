let theCoordinates = "";




async function getBreweries()
{
    console.log(theCoordinates);
    let theURL = "https://api.openbrewerydb.org/breweries?by_dist=" + theCoordinates + "&per_page=10";
    console.log(theURL);
    let response = await fetch(theURL);
    let data = await response.json()
    console.log(data)
    var toDoTable = document.getElementById('breweriesTable');
    toDoTable.innerHTML = "";
    for(breweries in data)
    {

        let nextValue = data[breweries].website_url + ", " + data[breweries].name + 
        " address: " + data[breweries].street
        var row = toDoTable.insertRow(-1);
        row.insertCell().appendChild(document.createTextNode(data[breweries].name));
        row.insertCell().appendChild(document.createTextNode(data[breweries].street));
        var a = document.createElement('a');
        var linkText = document.createTextNode("website link");
        a.appendChild(linkText);
        a.title = "my title text";
        a.href = data[breweries].website_url;
        row.insertCell().appendChild(a);        
    }
}

async function suggestADrink(){
    let output = document.getElementById('cocktails');
    output.innerHTML = '';
    let theURL = "https://www.thecocktaildb.com/api/json/v1/1/random.php";
    console.log(theURL);
    let response = await fetch(theURL);
    let data = await response.json()
    output.innerHTML = "<h4><strong>Suggested drink </strong></h4>"
    for(cocktails in data.drinks)
    {
        output.innerHTML += "<p><strong>Name: </strong>" + data.drinks[cocktails].strDrink;
        if(data.drinks[cocktails].strIngredient1 != null){
            output.innerHTML += "<strong>Ingredients: </strong>" + data.drinks[cocktails].strIngredient1
        }
        if(data.drinks[cocktails].strIngredient2 != null){
            output.innerHTML += ", " + data.drinks[cocktails].strIngredient2
        }
        if(data.drinks[cocktails].strIngredient3 != null){
            output.innerHTML += ", " +  data.drinks[cocktails].strIngredient3
        }
        if(data.drinks[cocktails].strIngredient4 != null){
            output.innerHTML +=  ", " + data.drinks[cocktails].strIngredient4
        }
        if(data.drinks[cocktails].strIngredient5 != null){
            output.innerHTML += ", " +  data.drinks[cocktails].strIngredient5
        }
        

        output.innerHTML += "<br><br><strong>Instructions: </strong>" + data.drinks[cocktails].strInstructions
    }
}

function getLocation(callback) {
    if (navigator.geolocation) {
        var lat_lng = navigator.geolocation.getCurrentPosition(function(position){
            var user_position = {};
            theCoordinates = position.coords.latitude + "," + position.coords.longitude;
            user_position.lat = position.coords.latitude; 
            user_position.lng = position.coords.longitude; 
            callback(theCoordinates);
        });
    } else {
        alert("Geolocation is not supported by this browser.");
        }
}
    getLocation(function(lat_lng){
        console.log(lat_lng)
        return lat_lng;
    });
