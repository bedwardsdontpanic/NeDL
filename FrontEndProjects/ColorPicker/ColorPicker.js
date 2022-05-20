function changeBackground() {
    let colorChoice = document.getElementById('colorChoice');
    console.log(colorChoice.value);
    document.body.style.backgroundColor = colorChoice.value;
}