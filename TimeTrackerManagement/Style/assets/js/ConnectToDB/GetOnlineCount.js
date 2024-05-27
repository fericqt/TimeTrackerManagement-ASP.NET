$(document).ready(function () {
  $.ajax({
    url: "../DBFolder/GetOnlineFriendCountAPI.php",
    type: "GET",
    dataType: "json",
    success: function (data) {
      if (data <= 0) {
        document.getElementById("IsOnline").className = "badges bg-c-red";
      }
    },
  });
});
