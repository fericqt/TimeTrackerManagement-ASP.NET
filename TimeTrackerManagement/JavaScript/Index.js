
//Get the modal element
const modal = document.getElementById("myModal");

// Get the button that opens the modal
const openModalBtn = document.getElementById("openModalBtn");

// Get the <span> element that closes the modal
const closeModalBtn = document.getElementById("closeModalBtn");

// Function to open the modal
openModalBtn.addEventListener("click", function () {
    modal.style.display = "block";
});

// Function to close the modal
closeModalBtn.addEventListener("click", function () {
    modal.style.display = "none";
});

//Signup and Login Modal
function showSignUpForm() {
    document.getElementById("signup-section").style.display = "block";
    document.getElementById("signin-section").style.display = "none";
}

function showSignInForm() {
    document.getElementById("signup-section").style.display = "none";
    document.getElementById("signin-section").style.display = "block";
}

document.addEventListener("DOMContentLoaded", function () {
    // Attach click event listeners to the links
    document
        .getElementById("show-signup-form")
        .addEventListener("click", showSignUpForm);
    document
        .getElementById("show-signin-form")
        .addEventListener("click", showSignInForm);
});

