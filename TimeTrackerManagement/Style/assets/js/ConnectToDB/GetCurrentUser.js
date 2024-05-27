$(document).ready(function () {
  //get username from json
  $.ajax({
    url: "../DBFolder/GetUserDetailsAPI.php",
    type: "GET",
    dataType: "json",
    success: function (data) {
      var elements = document.getElementsByClassName("CurrentUser");
      var topAvatar = document.getElementById("topAvatar");
      var leftAvatar = document.getElementById("leftAvatar");
      for (var i = 0; i < elements.length; i++) {
        elements[i].innerText = data.Username;
      }
      topAvatar.src = "assets/images/" + data.ProfilePic;
      leftAvatar.src = "assets/images/" + data.ProfilePic;
    },
  });
});
