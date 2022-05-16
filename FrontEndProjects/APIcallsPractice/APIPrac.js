async function getTheBacon() {
    var input = document.getElementById('theNumber');
    var output = document.getElementById('theBacon');
    var nextValue = input.value;
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
    let response = await
    fetch(theURL);
    var output = document.getElementById('puppyPicture');
    let data = await response.blob()
    var image = new Image;
    image = data;
    output.append(image);
}