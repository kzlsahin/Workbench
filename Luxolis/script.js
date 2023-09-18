
window.addEventListener("load", () => {
    let passwordInputField = document.getElementById("login-input-field");
    console.log("setting listener");
    // When the user starts to type something inside the password field
    passwordInputField.onkeyup = function () {
        let field = document.getElementById("login-input-field");
        let isValid = isPassCombinationValid(field.value);
        let alertText = document.getElementById("pass-alert");
        if (isValid) {
            alertText.innerText = "";
            console.log("valid combination");
        }
        else {
            alertText.innerText = "Wrong combination";
            console.log("invalid combination");
        }
    }
});

const isPassCombinationValid = (pass) => {
    console.log(pass)
    // Validate lowercase letters
    let lowerCaseLetters = /[a-zA-Z]/g;
    let specialCharacters = /[#?!@$%^&*\-\]\[]/g;
    let numbers = /[0-9]/g;


    if (!pass.match(lowerCaseLetters)) {
        return false;
    }
    // Validate special characters
    if (!pass.match(specialCharacters)) {
        return false;
    }
    // Validate numbers
    if (!pass.match(numbers)) {
        return false;
    }
    // Validate length
    if (pass.length < 8) {
        return false;
    }
    return true;
};