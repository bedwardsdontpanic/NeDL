async function getTheBacon() {
    let input = document.getElementById('theNumber');
    let output = document.getElementById('theBacon');
    let nextValue = input.value;
    if (nextValue == '' || nextValue == null || nextValue < 1 || nextValue > 5) 
    {
        alert('Please enter a number 1-5. ');
        return false;
    }

    output.innerHTML = '';
    let theURL = "https://baconipsum.com/api/?type=all-meat&paras=" + nextValue;
    console.log(theURL);
    let response = await
    fetch(theURL);
    let data = await response.json()
//    output.innerHTML = data;

     for(pg in data){
        output.innerHTML += ("<p>" + data[pg] + "</p>")
    }
}


async function getChuckNorrisFacts()
{
    let theURL = "https://api.chucknorris.io/jokes/random"
    let response = await
    fetch(theURL);
    var output = document.getElementById('chuckNorris');
    let data = await response.json()
    output.innerHTML = data.value;
}

async function getPuppyPicture()
{
    let theURL = "https://dog.ceo/api/breeds/image/random"
//    let theURL = "https://place-puppy.com/300x300"
    let response = await
    fetch(theURL);
    var output = document.getElementById('puppyPicture');
    let data = await response.blob()
    const blobUrl = URL.createObjectURL(data) // blob is the Blob object
    let image = new Image();
    image.src = blobUrl
    console.log(data);
    document.body.appendChild(image);
}

async function getGithubInfo()
{
    let input = document.getElementById('usernameInput');
    let output = document.getElementById('githubInfo');
    let nextValue = input.value;
    if (nextValue == '' || nextValue == null) 
    {
        alert('Please enter a username. ');
        return false;
    }
    output.innerHTML = '';
    let theURL = "https://api.github.com/users/" + nextValue + "/repos";
    console.log(theURL);
    let response = await fetch(theURL);
    let data = await response.json()
//    output.innerHTML = data;
    console.log(data)
    output.innerHTML = "<h6><strong>" + nextValue + "'s repos: </strong></h6>"
    for(repos in data)
    {
        output.innerHTML += ("<p><a href =" +data[repos].html_url + "> " + data[repos].name + "</a></p>")
    }

}


  async function getBreweries()
  {
      let output = document.getElementById('breweries');
      output.innerHTML = '';
      let theCoordinates = getLocation();
      let theURL = "https://api.openbrewerydb.org/breweries?by_dist=" + theCoordinates + "&per_page=3";
      console.log(theURL);
      let response = await fetch(theURL);
      let data = await response.json()
  //    output.innerHTML = data;
      console.log(data)
      output.innerHTML = "<h6><strong>list: </strong></h6>"
      for(breweries in data)
      {
          output.innerHTML += ("<p><a href =" +data[breweries].website_url + "> " + data[breweries].name + "</a></p>")
      }
  
  }