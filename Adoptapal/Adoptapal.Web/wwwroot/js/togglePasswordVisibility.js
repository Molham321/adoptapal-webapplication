
document.addEventListener("DOMContentLoaded", function () {
    const passwordInput = document.querySelector("#password_Id");
    const passwordToggle = document.querySelector("#password-toggle");

    const confirmPasswordInput = document.querySelector("#confirmPassword_Id");
    const confirmPasswordToggle = document.querySelector("#confirmPassword-toggle");

    passwordToggle.addEventListener("click", function () {
        togglePasswordVisibility(passwordInput, passwordToggle);
    });

    confirmPasswordToggle.addEventListener("click", function () {
        togglePasswordVisibility(confirmPasswordInput, confirmPasswordToggle);
    });
});

function togglePasswordVisibility(inputField, toggleButton) {
    if (inputField.type === "password") {
        inputField.type = "text";
        toggleButton.innerHTML = '<i class="fas fa-eye-slash"></i>';
    } else {
        inputField.type = "password";
        toggleButton.innerHTML = '<i class="fas fa-eye"></i>';
    }
}

