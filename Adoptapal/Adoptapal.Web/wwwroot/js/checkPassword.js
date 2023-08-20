
const confirmPassword = document.querySelector("#confirmPassword_Id");
const password = document.querySelector("#password_Id");
const submit = document.querySelector("#submit_ID");
const confirmPasswordTextDanger = document.querySelector("#ConfirmPasswordTextDanger");


password.addEventListener("input", checkPasswords)
confirmPassword.addEventListener("input", checkPasswords)

function checkPasswords() {
    if (password.value != confirmPassword.value) {
        confirmPassword.style.borderColor = "red";
        submit.disabled = true;
        confirmPasswordTextDanger.innerText = 'Passwords do not match';

    } else {
        confirmPassword.style.borderColor = "green";
        submit.disabled = false;
        confirmPasswordTextDanger.innerText = '';

    }
}