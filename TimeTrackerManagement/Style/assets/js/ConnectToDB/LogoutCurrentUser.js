function logout() {
  $(document).ready(function () {
    $.ajax({
      url: "../DBFolder/LogoutAPI.php",
      success: function (data) {
        if (data == 1) {
          window.location.href = "../Account/";
        }
      },
    });
  });
}
