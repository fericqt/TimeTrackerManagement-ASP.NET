$(document).ready(function () {
  // Get references to the input elements
  const passwordInput = $("input[name='Password']");
  const confirmPasswordInput = $("input[name='ConfirmPassword']");

  // Function to update the classname based on the condition
  function updateClass() {
    if (passwordInput.val() === confirmPasswordInput.val()) {
      confirmPasswordInput
        .closest(".form-group")
        .removeClass("form-danger")
        .addClass("form-default");
    } else {
      confirmPasswordInput
        .closest(".form-group")
        .removeClass("form-default")
        .addClass("form-danger");
    }
  }
  passwordInput.on("input", updateClass);
  confirmPasswordInput.on("input", updateClass);
});
