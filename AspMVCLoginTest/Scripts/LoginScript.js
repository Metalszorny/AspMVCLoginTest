// Handles the KeyUp event of the LoginLoginEmailTextBox control.
$("#LoginLoginEmailTextBox").keyup(function () {
    // The value is not empty.
    if (document.getElementById("LoginLoginEmailTextBox").value !== "") {
        // Disable the buttons.
        disableLoginButtons();

        // Enable the buttons.
        enableLoginButton();
    }
    // The value is not empty.
    else {
		// Disable the login button.
        document.getElementById("LoginLoginLoginButton").disabled = true;

        // Both values are empty.
        if (document.getElementById("LoginLoginEmailTextBox").value === "" && document.getElementById("LoginLoginPasswordTextBox").value === "") {
			// Disable the reset button.
            document.getElementById("LoginLoginResetButton").disabled = true;
        }
    }
});

// Handles the KeyUp event of the LoginLoginPasswordTextBox control.
$("#LoginLoginPasswordTextBox").keyup(function () {
    // The value is not empty.
    if (document.getElementById("LoginLoginPasswordTextBox").value !== "") {
        // Disable the buttons.
        disableLoginButtons();

        // Enable the buttons.
        enableLoginButton();
    }
    // The value is empty.
    else {
		// Disable the login button.
        document.getElementById("LoginLoginLoginButton").disabled = true;

        // Both values are empty.
        if (document.getElementById("LoginLoginEmailTextBox").value === "" && document.getElementById("LoginLoginPasswordTextBox").value === "") {
			// Disable the reset button.
            document.getElementById("LoginLoginResetButton").disabled = true;
        }
    }
});

// Disables the login buttons.
function disableLoginButtons() {
    document.getElementById("LoginLoginLoginButton").disabled = true;
    document.getElementById("LoginLoginResetButton").disabled = true;
}

// Handles the Click event of the LoginLoginResetButton control.
$("#LoginLoginResetButton").click(function () {
    // Empty the TextBox values.
    document.getElementById("LoginLoginEmailTextBox").value = "";
    document.getElementById("LoginLoginPasswordTextBox").value = "";

    // Disable the buttons.
    disableLoginButtons();
});

// Enables the login buttons.
function enableLoginButton() {
    // At least one TextBox has a not empty value.
    if (document.getElementById("LoginLoginEmailTextBox").value !== "" || document.getElementById("LoginLoginPasswordTextBox").value !== "") {
        // Enable reset button.
        document.getElementById("LoginLoginResetButton").disabled = false;

        // Both TextBox has not empty value and both are number.
        if (document.getElementById("LoginLoginEmailTextBox").value !== "" && document.getElementById("LoginLoginPasswordTextBox").value !== "") {
            // Enable login button.
            document.getElementById("LoginLoginLoginButton").disabled = false;
        }
    }
    // Both TextBox are empty.
    else {
        // Disable buttons.
        disableLoginButtons();
    }
}

// Handles the KeyUp event of the LoginRegistrationNameTextBox control.
$("#LoginRegistrationNameTextBox").keyup(function () {
    // The value is not empty.
    if (document.getElementById("LoginRegistrationNameTextBox").value !== "") {
        // Disable the buttons.
        disableRegistrationButtons();

        // Enable the buttons.
        enableRegistrationButton();
    }
    // The value is empty.
    else {
		// Disable the registration button.
        document.getElementById("LoginRegistrationRegisterButton").disabled = true;

        // All the values are empty.
        if (document.getElementById("LoginRegistrationNameTextBox").value === "" && document.getElementById("LoginRegistrationEmailTextBox").value === "" &&
			document.getElementById("LoginRegistrationPasswordTextBox").value === "" && document.getElementById("LoginRegistrationPasswordAgainTextBox").value === "") {
			// Disable the reset button.
            document.getElementById("LoginRegistrationResetButton").disabled = true;
        }
    }
});

// Handles the KeyUp event of the LoginRegistrationEmailTextBox control.
$("#LoginRegistrationEmailTextBox").keyup(function () {
	// Reset the background color to default of the email control.
    $("#LoginRegistrationEmailTextBox").css("background-color", "white");

    // The value is not empty.
    if (document.getElementById("LoginRegistrationEmailTextBox").value !== "") {
        // Disable the buttons.
        disableRegistrationButtons();

        var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

        // The email regex validation failed.
        if (!re.test(document.getElementById("LoginRegistrationEmailTextBox").value)) {
            // Change the input's background color.
            $("#LoginRegistrationEmailTextBox").css("background-color", "red");

            // Disable the registration button.
            document.getElementById("LoginRegistrationRegisterButton").disabled = true;
        }
        
        // Enable the buttons.
        enableRegistrationButton();
    }
    // The value is empty.
    else {
		// Disable the registration button.
        document.getElementById("LoginRegistrationRegisterButton").disabled = true;

        // All the values are empty.
        if (document.getElementById("LoginRegistrationNameTextBox").value === "" && document.getElementById("LoginRegistrationEmailTextBox").value === "" &&
        document.getElementById("LoginRegistrationPasswordTextBox").value === "" && document.getElementById("LoginRegistrationPasswordAgainTextBox").value === "") {
			// Disable the reset button.
            document.getElementById("LoginRegistrationResetButton").disabled = true;
        }
    }
});

// Handles the KeyUp event of the LoginRegistrationPasswordTextBox control.
$("#LoginRegistrationPasswordTextBox").keyup(function () {
	// Reset the background color to default of the password controls.
    $("#LoginRegistrationPasswordTextBox").css("background-color", "white");
    $("#LoginRegistrationPasswordAgainTextBox").css("background-color", "white");

    // The value is not empty.
    if (document.getElementById("LoginRegistrationPasswordTextBox").value !== "") {
        // Disable the buttons.
        disableRegistrationButtons();

        // The value is not empty.
        if (document.getElementById("LoginRegistrationPasswordAgainTextBox").value !== "") {
            // Tha values don't match.
            if (document.getElementById("LoginRegistrationPasswordTextBox").value !== document.getElementById("LoginRegistrationPasswordAgainTextBox").value) {
                // Change the input's background color.
                $("#LoginRegistrationPasswordTextBox").css("background-color", "red");
                $("#LoginRegistrationPasswordAgainTextBox").css("background-color", "red");

                // Disable the registration button.
                document.getElementById("LoginRegistrationRegisterButton").disabled = true;
            }
        }

        // Enable the buttons.
        enableRegistrationButton();
    }
    // The value is empty.
    else {
		// Disable the registration button.
        document.getElementById("LoginRegistrationRegisterButton").disabled = true;

        // All the values are empty.
        if (document.getElementById("LoginRegistrationNameTextBox").value === "" && document.getElementById("LoginRegistrationEmailTextBox").value === "" &&
            document.getElementById("LoginRegistrationPasswordTextBox").value === "" && document.getElementById("LoginRegistrationPasswordAgainTextBox").value === "") {
			// Disable the reset button.
            document.getElementById("LoginRegistrationResetButton").disabled = true;
        }
    }
});

// Handles the KeyUp event of the LoginRegistrationPasswordAgainTextBox control.
$("#LoginRegistrationPasswordAgainTextBox").keyup(function () {
	// Reset the background color to default of the password controls.
    $("#LoginRegistrationPasswordTextBox").css("background-color", "white");
    $("#LoginRegistrationPasswordAgainTextBox").css("background-color", "white");

    // The value is not empty.
    if (document.getElementById("LoginRegistrationPasswordAgainTextBox").value !== "") {
        // Disable the buttons.
        disableRegistrationButtons();

        // The value is not empty.
        if (document.getElementById("LoginRegistrationPasswordTextBox").value !== "") {
            // The values don't match.
            if (document.getElementById("LoginRegistrationPasswordTextBox").value !== document.getElementById("LoginRegistrationPasswordAgainTextBox").value) {
                // Change the input's background color.
                $("#LoginRegistrationPasswordTextBox").css("background-color", "red");
                $("#LoginRegistrationPasswordAgainTextBox").css("background-color", "red");

                // Disable the registration button.
                document.getElementById("LoginRegistrationRegisterButton").disabled = true;
            }
        }

        // Enable the buttons.
        enableRegistrationButton();
    }
    // The value is empty.
    else {
		// Disable the registration button.
        document.getElementById("LoginRegistrationRegisterButton").disabled = true;

        // All the values are empty.
        if (document.getElementById("LoginRegistrationNameTextBox").value === "" && document.getElementById("LoginRegistrationEmailTextBox").value === "" &&
			document.getElementById("LoginRegistrationPasswordTextBox").value === "" && document.getElementById("LoginRegistrationPasswordAgainTextBox").value === "") {
			// Disable the reset button.
            document.getElementById("LoginRegistrationResetButton").disabled = true;
        }
    }
});

// Disables the registration buttons.
function disableRegistrationButtons() {
    document.getElementById("LoginRegistrationRegisterButton").disabled = true;
    document.getElementById("LoginRegistrationResetButton").disabled = true;
}

// Handles the Click event of the LoginRegistrationResetButton control.
$("#LoginRegistrationResetButton").click(function () {
    // Empty the TextBox values.
    document.getElementById("LoginRegistrationNameTextBox").value = "";
    document.getElementById("LoginRegistrationEmailTextBox").value = "";
    document.getElementById("LoginRegistrationPasswordTextBox").value = "";
    document.getElementById("LoginRegistrationPasswordAgainTextBox").value = "";

    // Disable the buttons.
    disableRegistrationButtons();
});

// Enables the registration buttons.
function enableRegistrationButton() {
    // At least one TextBox has a not empty value.
    if (document.getElementById("LoginRegistrationNameTextBox").value !== "" || document.getElementById("LoginRegistrationEmailTextBox").value !== "" || 
        document.getElementById("LoginRegistrationPasswordTextBox").value !== "" || document.getElementById("LoginRegistrationPasswordAgainTextBox").value !== "") {
        // Enable reset button.
        document.getElementById("LoginRegistrationResetButton").disabled = false;

        var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

        // The TextBox values are not empty and the given e-mail address is valid.
        if (document.getElementById("LoginRegistrationNameTextBox").value !== "" && document.getElementById("LoginRegistrationEmailTextBox").value !== "" &&
            document.getElementById("LoginRegistrationPasswordTextBox").value !== "" && document.getElementById("LoginRegistrationPasswordAgainTextBox").value !== "" && 
            (document.getElementById("LoginRegistrationPasswordTextBox").value === document.getElementById("LoginRegistrationPasswordAgainTextBox").value) && 
            re.test(document.getElementById("LoginRegistrationEmailTextBox").value)) {
            // Enable register button.
            document.getElementById("LoginRegistrationRegisterButton").disabled = false;
        }
    }
    // All the TextBox are empty.
    else {
        // Disable buttons.
        disableRegistrationButtons();
    }
}