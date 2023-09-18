
window.addEventListener("load", () => {
    let passwordInputField = document.getElementById("login-input-field");
    console.log("setting listener");
    // When the user starts to type something inside the password field
    passwordInputField.onkeyup = function () {
        let field = document.getElementById("login-input-field");
        let isValid = isPassCombinationValid(field.Value);
        let alertText = document.getElementById("pass-alert");
        if (isValid) {
            alertText.Text = "";
            console.log("valid combination");
        }
        else {
            alertText.Text = "Wrong combination";
            console.log("invalid combination");
        }
    }
});

const isPassCombinationValid = (pass) => {
    let isCombinationsCorrect = true;
    // Validate lowercase letters
    let lowerCaseLetters = /[a-zA-Z]/g;
    let specialCharacters = /[#?!@$%^&*\-\]\[]/g;
    let numbers = /[0-9]/g;


    if (!pass.match(lowerCaseLetters)) {
        isCombinationsCorrect &= false;
    }
    // Validate special characters
    if (!pass.match(specialCharacters)) {
        isCombinationsCorrect &= false;
    }
    // Validate numbers
    if (!pass.match(numbers)) {
        isCombinationsCorrect &= false;
    }
    // Validate length
    if (pass.length >= 8) {
        isCombinationsCorrect &= false;
    }
    return isCombinationsCorrect;
};