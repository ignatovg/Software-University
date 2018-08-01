function startApp() {
    sendGreeting();

    //App constants
    const baseUrl = 'https://baas.kinvey.com/';
    const appKey = 'kid_SJKsjBwNQ';
    const appSecret = '8214e32908f94c4ab10702e5ab00e387';

    $('#linkHome').click(() => showView('home'));
    $('#linkLogin').click(() => showView('login'));
    $('#linkRegister').click(() => showView('register'));
    $('#linkListBooks').click(() => showView('books'));
    $('#linkCreateBook').click(() => showView('create'));
    $('#linkLogout').click(logout);


    $('#formLogin').submit(login);
    $('#formRegister').submit(register);
    $('#formCreateBook').submit(createBook);

    //Attach AJAX 'loading' event listener
    $(document).on({
        ajaxStart: () => $('#loadingBox').show(),
        ajaxStop: () => $('#loadingBox').fadeOut()
    });

    $('#infoBox').click((e) => $(e.target).fadeOut());
    $('#errorBox').click((e) => $(e.target).fadeOut());

    function showInfo(message) {
        $('#infoBox').text(message);
        $('#infoBox').show();
        setTimeout(() => $('#infoBox').fadeOut(), 3000)
    }

    function showError(message) {
        $('#errorBox').text(message);
        $('#errorBox').show();
    }

    function handleError(reason) {
        showError(reason.responseJSON.description)
    }

    //Navigation and header
    function showView(name) {
        $('section').hide();

        switch (name) {
            case 'home':
                $('#viewHome').show();
                break;
            case 'login':
                $('#viewLogin').show();
                break;
            case 'register':
                $('#viewRegister').show();
                break;
            case 'books':
                getBooks();
                $('#viewBooks').show();
                break;
            case 'create':
                $('#viewCreateBook').show();
                break;
            case 'logout':
                $('#viewHome').show();
                break;
        }
    }

    function makeHeader(type) {
        if (type === 'basic') {
            return {
                'Authorization': 'Basic ' + btoa(appKey + ':' + appSecret),
                'Content-Type': 'application/json'
            }
        } else {
            return {
                'Authorization': 'Kinvey ' + localStorage.getItem('authtoken')
            }
        }
    }

    //User session
    function sendGreeting() {
        let username = localStorage.getItem('username');
        if (username !== null) {
            $('#loggedInUser').text(`Welcome, ${username}`);
            $('#linkLogin').hide();
            $('#linkRegister').hide();
            $('#linkListBooks').show();
            $('#linkCreateBook').show();
            $('#linkLogout').show();
        } else {
            $('#loggedInUser').text(``);
            $('#loggedInUser').text(`Welcome, ${username}`);
            $('#linkLogin').show();
            $('#linkRegister').show();
            $('#linkListBooks').hide();
            $('#linkCreateBook').hide();
            $('#linkLogout').hide();
        }
    }

    function setStorage(data) {
        localStorage.setItem('authtoken', data._kmd.authtoken);
        localStorage.setItem('username', data.username);
        $('#loggedInUser').text(`Welcome, ${data.username}`);
        sendGreeting();
        showView('books');
    }

    function login(e) {
        e.preventDefault();

        let username = $('#formLogin').find('input[name="username"]').val();
        let password = $('#formLogin').find('input[name="passwd"]').val();

        let req = {
            url: baseUrl + 'user/' + appKey + '/login',
            method: 'POST',
            headers: makeHeader('basic'),
            data: JSON.stringify({
                username: username,
                password: password,
            }),
            success: (data) => {
                showInfo('Login successful');
                setStorage(data);
            },
            error: handleError
        };

        $.ajax(req);

    }

    function register(e) {
        e.preventDefault();

        let form = $('#formRegister');
        let username = form.find('input[name="username"]').val();
        let password = form.find('input[name="passwd"]').val();
        let repeat = form.find('input[name="repeatPasswd"]').val();

        if (username.length === 0) {
            showError('Username cannot be empty')
        }
        if (password.length === 0) {
            showError('Password cannot be empty')
        }

        if (password !== repeat) {
            showError(`Passwords don't match!`);
            return;
        }

        let req = {
            url: baseUrl + 'user/' + appKey,
            method: 'POST',
            headers: makeHeader('basic'),
            data: JSON.stringify({
                username: username,
                password: password,
            }),
            success: (data) => {
                showInfo('Registration successful');
                setStorage(data);
            },
            error: handleError
        };

        $.ajax(req);


    }

    function logout() {
        let req = {
            url: baseUrl + 'user/' + appKey + '/_logout',
            method: 'POST',
            headers: makeHeader('kinvey'),
            success: logoutSuccess,
            error: handleError
        };

        $.ajax(req);

        function logoutSuccess(data) {
            localStorage.clear();
            sendGreeting();
            showView('home');
        }
    }

    //Catalog
    function getBooks() {
        let req = {
            url: baseUrl + 'appdata/' + appKey + '/books',
            method: 'GET',
            headers: makeHeader('kinvey'),
            success: displayBooks,
            error: handleError
        };

        $.ajax(req);

        function displayBooks(data) {
            let table = $('#books').find('table');
            table.empty();

            for (let book of data) {
                let row = $('<tr>');
                row.append(`<td>${book.title}</td>`);
                row.append(`<td>${book.author}</td>`);
                row.append(`<td>${book.description}</td>`);
                row.append(`<td></td>`);
                row.appendTo(table);
            }
        }
    }

    function createBook() {
        console.log('asd');
        let form = $('#formCreateBook');
        let title = form.find('input[name="title"]').val();
        let author = form.find('input[name="author"]').val();
        let description = form.find('textarea[name="description"]').val();

        console.log(title);
        console.log(author);
        console.log(description);

        if (title.length === 0) {
            showError('Title cannot be empty')
        }
        if (author.length === 0) {
            showError('Author cannot be empty')
        }

        let req = {
            url: baseUrl + 'appdata/' + appKey + '/books',
            method: 'POST',
            headers: makeHeader('kinvey'),
            data: JSON.stringify({
                title,
                author,
                description
            }),
            success: createSuccess,
            error: handleError
        };

        $.ajax(req);

        function createSuccess(data) {
            console.log(data);
        }
    }

}
