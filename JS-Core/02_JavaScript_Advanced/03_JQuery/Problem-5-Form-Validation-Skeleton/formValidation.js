function validate() {
    let username = $('#username');
    let email = $('#email');
    let password = $('#password');
    let confirmPassword = $('#confirm-password');
    let companyCheckBox = $('#company');
    let companyNumber = $('#companyNumber');
    let companyInfo = $('#companyInfo');
    let submitBtn = $('#submit');
    let validationDiv = $('#valid');
    let allIsValid = true;

    companyCheckBox.on('change', function () {
        if (companyCheckBox.is(':checked')) {
            companyInfo.css('display', 'block');
        } else {
            companyInfo.css('display', 'none');
        }
    });

    submitBtn.on('click', function (event) {
        event.preventDefault();
        validateForm();
        validationDiv.css('display',allIsValid?'block':'none');
        allIsValid = true;
    });

    function validateForm() {
        validateInputWithRegex(username, /^[A-Za-z0-9]{3,20}$/g);
        validateInputWithRegex(email, /^.*?@.*?\..*$/g);
        if (confirmPassword.val() === password.val()) {

            validateInputWithRegex(password, /^\w{5,15}$/g);
            validateInputWithRegex(confirmPassword, /^\w{5,15}$/g);

        } else {
            password.css('border', 'solid red');
            confirmPassword.css('border', 'solid red');
            allIsValid = false;
        }

        if (companyCheckBox.is(':checked')) {
            validateCompanyInfo()
        }

    }

    function validateCompanyInfo() {
        let numValue = Number(companyNumber.val());
        if (numValue >= 1000 && numValue <= 9999) {
            companyNumber.css('border', 'none');
        } else {
            companyNumber.css('border', 'solid red');
            allIsValid=false;
        }
    }

    function validateInputWithRegex(input, pattern) {
        if (pattern.test(input.val())) {
            input.css('border', 'none');
        } else {
            input.css('border', 'solid red');
            allIsValid=false;
        }
    }
}