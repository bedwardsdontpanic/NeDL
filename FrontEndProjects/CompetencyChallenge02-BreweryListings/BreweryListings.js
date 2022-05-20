let theCoordinates = "";

async function getBreweries()
{
    let theURL = "https://api.openbrewerydb.org/breweries?by_dist=" + theCoordinates + "&per_page=10";
    let response = await fetch(theURL);
    let data = await response.json()
    var toDoTable = document.getElementById('breweriesTable');
    toDoTable.innerHTML = "";
    for(breweries in data)
    {
        var row = toDoTable.insertRow(-1);
        row.insertCell().appendChild(document.createTextNode(data[breweries].name));
        row.insertCell().appendChild(document.createTextNode(data[breweries].street));
        if(data[breweries].website_url != null)
        {
            var a = document.createElement('a');
            var linkText = document.createTextNode("website");
            a.appendChild(linkText);
            a.href = data[breweries].website_url;
            row.insertCell().appendChild(a);    
        }
        else 
        {
            row.insertCell().appendChild(document.createTextNode("No website."))
        }

        var a2 = document.createElement('a');
        var linkText = document.createTextNode("directions");
        a2.appendChild(linkText);
        a2.href = "https://www.google.com/maps/dir/" + theCoordinates + "/" + data[breweries].street + " " + data[breweries].city;
        row.insertCell().appendChild(a2);
    }
}

async function findDrink() {
    let input = document.getElementById('drinkEntry');
    if(input.value != '' && input.value != null)
    {
        let theURL = 'https://www.thecocktaildb.com/api/json/v1/1/search.php?s=' + input.value;
        showDrink(theURL);
    }
    else
    {
        alert('Please enter a value to search. ');
        return false;
    }
}

async function suggestDrink(){
    let theURL = "https://www.thecocktaildb.com/api/json/v1/1/random.php";
    showDrink(theURL);
}

async function showDrink(theURL)
{
    let output = document.getElementById('cocktails');
    output.innerHTML = '';
    let response = await fetch(theURL);
    let data = await response.json()
    if(data.drinks == null)
    {
        output.innerHTML = "<h4>Sorry, drink not found... Try another. </h4>"
        document.getElementById("cocktailImage").remove()
        return false;
    }
    output.innerHTML = "<h4><strong>The Drink: </strong></h4>"
//    console.log(data);
    for(cocktails in data.drinks)
    {
        output.innerHTML += "<p><strong>Name: </strong>" + data.drinks[cocktails].strDrink;
        if(data.drinks[cocktails].strIngredient1 != null && data.drinks[cocktails].strIngredient1 != "")
        {
            output.innerHTML += "<strong>Ingredients: </strong>" + data.drinks[cocktails].strIngredient1
        }
        if(data.drinks[cocktails].strIngredient2 != null && data.drinks[cocktails].strIngredient2 != "")
        {
            output.innerHTML += ", " + data.drinks[cocktails].strIngredient2
        }
        if(data.drinks[cocktails].strIngredient3 != null && data.drinks[cocktails].strIngredient3 != "")
        {
            output.innerHTML += ", " +  data.drinks[cocktails].strIngredient3
        }
        if(data.drinks[cocktails].strIngredient4 != null && data.drinks[cocktails].strIngredient4 != "")
        {
            output.innerHTML +=  ", " + data.drinks[cocktails].strIngredient4
        }
        if(data.drinks[cocktails].strIngredient5 != null && data.drinks[cocktails].strIngredient5 != "")
        {
            output.innerHTML += ", " +  data.drinks[cocktails].strIngredient5
        }
        if(data.drinks[cocktails].strIngredient6 != null && data.drinks[cocktails].strIngredient6 != "")
        {
            output.innerHTML += ", " +  data.drinks[cocktails].strIngredient6
        }
        if(data.drinks[cocktails].strIngredient7 != null && data.drinks[cocktails].strIngredient7 != "")
        {
            output.innerHTML += ", " +  data.drinks[cocktails].strIngredient7
        }
        if(data.drinks[cocktails].strIngredient8 != null && data.drinks[cocktails].strIngredient8 != "")
        {
            output.innerHTML += ", " +  data.drinks[cocktails].strIngredient8
        }
        if(data.drinks[cocktails].strIngredient9 != null && data.drinks[cocktails].strIngredient9 != "")
        {
            output.innerHTML += ", " +  data.drinks[cocktails].strIngredient9
        }
        if(data.drinks[cocktails].strIngredient10 != null && data.drinks[cocktails].strIngredient10 != "")
        {
            output.innerHTML += ", " +  data.drinks[cocktails].strIngredient10
        }        
        output.innerHTML += "<br><br><strong>Instructions: </strong>" + data.drinks[cocktails].strInstructions;
        
        
        if(document.getElementById('cocktailImage') != null)
        {
            document.getElementById('cocktailImage').src = data.drinks[cocktails].strDrinkThumb;
        }

        else 
        {
            let newImg = document.createElement('img');
            newImg.id = "cocktailImage";
            newImg.src = data.drinks[cocktails].strDrinkThumb;
            output.insertAdjacentElement("afterend", newImg);
        }
        break;
    }
}

function getLocation(callback) 
{
    if (navigator.geolocation) 
    {
        var lat_lng = navigator.geolocation.getCurrentPosition(function(position){
            var user_position = {};
            theCoordinates = position.coords.latitude + "," + position.coords.longitude;
            user_position.lat = position.coords.latitude; 
            user_position.lng = position.coords.longitude; 
            latitude = position.coords.latitude;
            longitude = position.coords.longitude;
            callback(theCoordinates);
        });
    } 
    else 
    {
        alert("Geolocation is not supported by this browser.");
    }
}
    
getLocation(function(lat_lng){
        return lat_lng;
});

