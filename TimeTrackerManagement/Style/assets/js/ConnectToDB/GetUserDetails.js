$(document).ready(function () {
  //get details from json
  $.ajax({
    url: "../DBFolder/GetUserDetailsAPI.php",
    type: "GET",
    dataType: "json",
    success: function (data) {
      autoFillTextboxes(data);
    },
  });

  // Function to auto-fill the textboxes using JSON data
  function autoFillTextboxes(data) {
    for (var key in data) {
      // Check if the textbox with the same name as the JSON property exists
      var textbox = $('[name="' + key + '"]');
      if (textbox.length > 0) {
        // Special check for input type="checkbox" to handle checked property
        if (textbox.attr("type") === "checkbox") {
          textbox.prop("checked", data[key]);
        } else {
          textbox.val(data[key]);
        }
      }
    }
  }
});
