
window.addEventListener("load", () => {
    let passwordInputField = document.getElementById("login-password-field");
    console.log("setting listeners");
    // When the user starts to type something inside the password field
    passwordInputField.onkeyup = function () {
        let field = document.getElementById("login-password-field");
        let isValid = isPassCombinationValid(field.value);
        
        if (isValid) {
            CloseAlertText();
        }
        else {
            ShowAlertText();
        }
    }

    let submitButton = document.getElementById("login-submit-btn");
    submitButton.onclick = SubmitLogin;

    let popup = document.getElementById("wrong-password-popup");
    popup.addEventListener("click", () => {
        document.getElementById("wrong-password-popup").style.visibility= "hidden";
    });

});

const ShowAlertText = () => {
    let alertText = document.getElementById("pass-alert");
    alertText.innerText = "invalid combination";
}
const CloseAlertText = () => {
    let alertText = document.getElementById("pass-alert");
    alertText.innerText = "";
}
const isPassCombinationValid = (pass) => {
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


const SubmitLogin = () => {
    console.log("logging....")
    let userName = document.getElementById("login-username-field").value.trim();
    let password = document.getElementById("login-password-field").value.trim();
    if(!isPassCombinationValid(password)){
        ShowAlertText();
        return;
    }
    let res = Fetchmock("luxpmsoft.com/loginBackend", {
        body: JSON.stringify({ 'userName': userName, 'password': password }),
    })
    if (res === "success") {
        window.open();
    }
    else {
        let WrongPassPopup = document.getElementById("wrong-password-popup");
        WrongPassPopup.style.visibility = "visible";
    }
}

const Fetchmock = (url, context) => {
    // only mocking a fetch call
    let credentials = JSON.parse(context.body);
    let userName = credentials.userName;
    let password = credentials.password;
    if (userName === "test@luxpmsoft.com" && password === "test1234!") {
        return "success";
    }
    else {
        return "fail";
    }
}