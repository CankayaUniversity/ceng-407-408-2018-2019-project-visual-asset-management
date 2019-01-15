$(".reg-btn").click(function() {
  $(".hidden").slideToggle("slow");
  if ($("#login-btn").text() === "Login") {
    $("#login-btn").text("Register");
    $(".question").text("Already a member?");
    $(".reg-btn").text("Login");
  } else {
    $("#login-btn").text("Login");
    $(".question").text("Not a member?");
    $(".reg-btn").text("Register");
  }
});

$('#login-btn').click(function(){
    var http = new XMLHttpRequest();
    var url = 'auth/login';
    var params = 'username=' + username.value + '&password=' + password.value;
    http.open('POST', url, true);

    //Send the proper header information along with the request
    http.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');

    http.onreadystatechange = function () {//Call a function when the state changes.
        if (http.readyState == 4 && http.status == 200) {
            if (http.responseText === "true") {
                window.location.href = "home";
            }
        }
    }
    http.send(params);   
});

$('#forget-btn').click(function () {
    var http = new XMLHttpRequest();
    var url = 'auth/forgetPassword';
    var params = 'email=' + email.value ;
    http.open('POST', url, true);

    //Send the proper header information along with the request
    http.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');

    http.onreadystatechange = function () {//Call a function when the state changes.
        if (http.readyState == 4 && http.status == 200) {
            if (http.responseText === "true") {
                window.location.href = "login";
            }
        } else {
            alert("hata");
        }
    }
    http.send(params);
});