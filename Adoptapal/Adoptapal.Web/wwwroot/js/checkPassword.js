// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const confirmPassword = document.querySelector("#ConfirmPassword_Id");
const password = document.querySelector("#Password_ID");
const submit = document.querySelector("#Submit_ID");
const confirmPasswordTextDanger = document.querySelector("#ConfirmPasswordTextDanger");

password.addEventListener("input", checkPasswords)
confirmPassword.addEventListener("input", checkPasswords)

function checkPasswords() {
    if (password.value != confirmPassword.value) {
        confirmPassword.style.borderColor = "red";
        submit.disabled = true;
        confirmPasswordTextDanger.innerText = 'Passwords do not match';
        console.log(confirmPasswordTextDanger);
    } else {
        confirmPassword.style.borderColor = "green";
        submit.disabled = false;
        confirmPasswordTextDanger.innerText = '';
    }
}