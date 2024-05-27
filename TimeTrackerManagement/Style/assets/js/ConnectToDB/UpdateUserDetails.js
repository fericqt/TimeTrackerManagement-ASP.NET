$(document).ready(function () {
  $("#UserForm").submit(function (e) {
    e.preventDefault();
    $.ajax({
      type: "POST",
      url: "../DBFolder/UpdateUserAPI.php",
      data: new FormData(this),
      contentType: false,
      cache: false,
      processData: false,
      success: function (response) {
        if (response == 1) {
          location.reload();
          alert("Save Successfully!");
        } else {
          alert("Error");
        }
      },
      error: function (jqXHR, textStatus, errorThrown) {
        console.log("There was an error: " + errorThrown);
      },
    });
  });
});

$(document).ready(function () {
  $("#UserDetailsForm").submit(function (e) {
    e.preventDefault();
    $.ajax({
      type: "POST",
      url: "../DBFolder/UpdateUserDetailsAPI.php",
      data: new FormData(this),
      contentType: false,
      cache: false,
      processData: false,
      success: function (response) {
        if (response == 1) {
          location.reload();
          alert("Save Successfully!");
        } else {
          alert("Error");
        }
      },
      error: function (jqXHR, textStatus, errorThrown) {
        console.log("There was an error: " + errorThrown);
      },
    });
  });
});
