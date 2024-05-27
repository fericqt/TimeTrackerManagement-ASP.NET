$(document).ready(function () {
  $.ajax({
    url: "../DBFolder/CheckLoggedInAPI.php",
    success: function (data) {
      if (data == 0) {
        window.location.href = "../Account/";
      } else {
      }
    },
  });
});
