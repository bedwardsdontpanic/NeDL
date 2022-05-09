function submitFeedback() {
    console.log("clicked...");
    var name = $("#feedbackModal #nameInput").val();
    var suggestions = $("#feedbackModal #suggestions").val();
    var comments = $("#feedbackModal #additionalComments").val();
    var checkbox = $("#feedbackModal #theCheckbox").prop('checked');
    var dropdown = $("#feedbackModal #textFeedback").val();
    var radio =$("input[name='options']:checked").val();
    document.getElementById("theFeedback").innerHTML = "<b><u>Submitted feedback:</b></u><br><br>Name: " + name + "<br>Suggestions: " + suggestions + "<br>Submit anonymously? : " + checkbox + "<br>Comments: " + comments + "<br>Recommend to friends: " + radio + "<br>Dropdown: " + dropdown;
}
