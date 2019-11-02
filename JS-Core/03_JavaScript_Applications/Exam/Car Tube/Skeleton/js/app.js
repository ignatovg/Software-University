$(() => {
    //attach event handlers
    (() => {
        hideAllViews();
        $('.active').click(function () {
            if (sessionStorage.getItem('username') === '') {
                showView('main');
            } else {
                loadLists();
                showView('car-listings');
            }
        });
        $('#allList').click(loadLists);
        $('#myList').click(loadMyPosts);
        $('#createList').click(displayCreateList)
        $('#logoutUser').click(logoutUser);
        $('#registerUser').click(displayRegister);
        $('#loginUser').click(displayLogin);

    })()

    if (sessionStorage.getItem('username') === '') {
        showView('main');
    } else {
        loadLists();
        showView('car-listings');
    }

    if (sessionStorage.getItem('authtoken') === null) {
        userLoggedOut();
    } else {
        userLoggedIn();
    }

    // Shows one view/section at a time
    function showView(viewName) {
        hideAllViews();
        $('#' + viewName).show();
    }

    function hideAllViews() {
        $('#main').hide();
        $('#login').hide();
        $('#register').hide();
        $('#car-listings').hide();
        $('#create-listing').hide();
        $('#edit-listing').hide();
        $('#myListings').hide();
        $('#listingDetails').hide();
    }

    function displayCreateList(event) {
        showView('create-listing');
        event.preventDefault();

        $('#create-listing').find('.registerbtn').click(createList);
    }

    function loadMyPosts(event) {
        showView('myListings');
        let username = sessionStorage.getItem('username');

        carsService.loadMyPosts(username)
            .then(function (data) {
                console.log(data);
                displayMyPosts(data);
            }).catch(handleError);
    }

    function displayMyPosts(data) {
        let listingMain = $('#myListings').find('.car-listings');

        listingMain.empty();
        // console.log(data.length);
        if (data.length === 0) {
            listingMain.append($('<p class="no-cars">No cars in database.</p>'));
        }

        for (let car of data) {
            //   console.log(car);

            let listingForm = $('<div class="my-listing">');
            listingForm.attr('data-id', car._id);
            listingForm.append($(`<p id="listing-title">${car.title}</p>`));
            listingForm.append($(`<img src="${car.imageUrl}">`));

           let listingPropsDiv = $(`<div class="listing-props">`);
           listingPropsDiv.append($(`<h2>Brand: ${car.brand}</h2>`));
           listingPropsDiv.append($(`<h2>Model: ${car.model}</h2>`));
           listingPropsDiv.append($(`<h2>Year: ${car.year}</h2>`));
           listingPropsDiv.append($(`<h2>Price: ${car.price}$</h2>`));

           listingForm.append(listingPropsDiv);


            let dataButtonsDiv = $('<div class="my-listing-buttons">');

            dataButtonsDiv.append($(`<a href="#" class="my-button-list">Details</a>`).click(displayDetails));
            dataButtonsDiv.append($(`<a href="#" class="my-button-list">Edit</a>`).click(function (event) {
                displayEdit(event,'my-listing');
            }));
            dataButtonsDiv.append($(` <a href="#" class="my-button-list">Delete</a>`).click(function (event) {
                displayDelete(event,'my-listing');
            }));

            listingForm.append(dataButtonsDiv);

            //appending form to page
            listingMain.append(listingForm);
        }
    }

    function createList(event) {
        event.preventDefault();

        let listForm = $('#create-listing');
        let title = listForm.find('input[name="title"]');
        let description = listForm.find('input[name="description"]');
        let brand = listForm.find('input[name="brand"]');
        let model = listForm.find('input[name="model"]');
        let year = listForm.find('input[name="year"]');
        let imageUrl = listForm.find('input[name="imageUrl"]');
        let fuelType = listForm.find('input[name="fuelType"]');
        let price = listForm.find('input[name="price"]');


        let seller = sessionStorage.getItem('username');
        let titleVal = title.val();
        let descriptionVal = description.val();
        let brandVal = brand.val();
        let modelVal = model.val();
        let yearVal = year.val();
        let imageUrlVal = imageUrl.val();
        let fuelTypeVal = fuelType.val();
        let priceVal = Number(price.val());


        //validation
        if (titleVal.length > 33) {
            showError('The title length must not exceed 33 characters!');
            return;
        }

        if (descriptionVal.length > 450) {
            showError('The description length must not exceed 450 characters!');
            return;
        }

        if (descriptionVal.length < 30) {
            showError('The description length should be at least 30 characters!');
            return;
        }

        if (brandVal.length > 11 || fuelTypeVal.length > 11 || modelVal.length > 11) {
            showError('The brand,fuelType and model length must not exceed 11 characters!');
            return;
        }

        if (modelVal.length < 4) {
            showError('The model length should be at least 4 characters!');
            return;
        }

        if (yearVal.length !== 4) {
            showError('The year must be only 4 chars long!');
            return;
        }

        if (priceVal > 1000000) {
            showError('The maximum price is 1000000$');
            return;
        }

        if (!imageUrlVal.startsWith('http')) {
            showError('Link url should always start with “http”');
            return;
        }



        carsService.createCar(brandVal, descriptionVal, fuelTypeVal, imageUrlVal, true, modelVal, priceVal, seller, titleVal, yearVal)
            .then(function (carInfo) {
                title.val('');
                description.val('');
                brand.val('');
                model.val('');
                year.val('');
                imageUrl.val('');
                fuelType.val('');
                price.val('');
                imageUrl.val('');
                showInfo('listing created.');
                loadLists();
                showView('car-listings');
            }).catch(handleError);

    }

    function loadLists(event) {
        showView('car-listings');

        carsService.loadAllCars()
            .then(function (data) {
                displayLists(data);
            }).catch(handleError);
    }

    function displayLists(data) {

        let listingMain = $('#listings');


        listingMain.empty();
        // console.log(data.length);
        if (data.length === 0) {
            listingMain.append($('<p class="no-cars">No cars in database.</p>'));
        }

        for (let car of data) {
            //   console.log(car);

            let listingForm = $('<div class="listing">');
            listingForm.attr('data-id', car._id);
            listingForm.append($(`<p>${car.title}</p>`));
            listingForm.append($(`<img src="${car.imageUrl}">`));
            listingForm.append($(`<h2>Brand: ${car.brand}</h2>`));

            let infoDiv = $('<div class="info">');
            let dataInfoDiv = $('<div id="data-info">');
            dataInfoDiv.append(`<h3>Seller: ${car.seller}</h3>`);
            dataInfoDiv.append(`<h3>Fuel: ${car.fuel}</h3>`);
            dataInfoDiv.append(`<h3>Year: ${car.year}</h3>`);
            dataInfoDiv.append(` <h3>Price: ${car.price} $</h3>`);

            infoDiv.append(dataInfoDiv);

            let dataButtonsDiv = $('<div id="data-buttons">');
            let ul = $('<ul>');
            ul.append($(`<li class="action">`)
                .append($(`<a href="#" class="button-carDetails">Details</a>`)
                    .click(displayDetails)));

            if (sessionStorage.getItem('userId') === car._acl.creator) {
                ul.append(`<li class="action">`)
                    .append($(`<a href="#" class="button-carDetails">edit</a>`)
                        .click(function (event) {
                            displayEdit(event,'listing');
                        }));
                ul.append(`<li class="action">`)
                    .append($(`<a href="#" class="button-carDetails">delete</a>`)
                        .click(function (event) {
                            displayDelete(event,'listing');
                        }));
            }
            dataButtonsDiv.append(ul);
            infoDiv.append(dataButtonsDiv);

            //appending infoDiv to form
            listingForm.append(infoDiv);

            //appending form to page
            listingMain.append(listingForm);
        }
    }

    function displayDetails(event) {

        let postId = $(event.target).closest('.listing').attr('data-id');

        showView('listingDetails');
        let username = sessionStorage.getItem('username');

        let listDetails = $('#listingDetails');
        listDetails.empty();

        carsService.loadPostById(postId)
            .then(function (car) {
                let listingForm = $('<div class="my-listing-details">');

                listingForm.append($(`<p id="auto-title">${car.title}</p>`));
                listingForm.append($(`<img src="${car.imageUrl}">`));

                let listingPropsDiv = $(`<div class="listing-props">`);
                listingPropsDiv.append($(`<h2>Brand: ${car.brand}</h2>`));
                listingPropsDiv.append($(`<h2>Model: ${car.model}</h2>`));
                listingPropsDiv.append($(`<h2>Year: ${car.year}</h2>`));
                listingPropsDiv.append($(`<h2>Price: ${car.price}$</h2>`));

                listingForm.append(listingPropsDiv);



                //appending form to page
                listDetails.append(listingForm);


            }).catch(handleError);




    }

    function displayEdit(event,close) {
        let postId = $(event.target).closest('.'+close).attr('data-id');
        let editForm = $('#edit-listing');




        carsService.loadPostById(postId)
            .then((postInfo) => {
                console.log(postInfo);
                editForm.find('input[name="title"]').val(postInfo['title']);
                editForm.find('input[name="description"]').val(postInfo['description']);
                editForm.find('input[name="brand"]').val(postInfo['brand']);
                editForm.find('input[name="model"]').val(postInfo['model']);
                editForm.find('input[name="year"]').val(postInfo['year']);
                editForm.find('input[name="imageUrl"]').val(postInfo['imageUrl']);
                editForm.find('input[name="fuelType"]').val(postInfo['fuel']);
                editForm.find('input[name="price"]').val(postInfo['price']);
                editForm.attr('data-id', postInfo._id);

                showView('edit-listing');


                //edit btn
                $('#edit-listing').find('.registerbtn').click((event) => {
                    event.preventDefault();


                    let listForm = $('#edit-listing');
                    let title = listForm.find('input[name="title"]');
                    let description = listForm.find('input[name="description"]');
                    let brand = listForm.find('input[name="brand"]');
                    let model = listForm.find('input[name="model"]');
                    let year = listForm.find('input[name="year"]');
                    let imageUrl = listForm.find('input[name="imageUrl"]');
                    let fuelType = listForm.find('input[name="fuelType"]');
                    let price = listForm.find('input[name="price"]');


                    let seller = sessionStorage.getItem('username');
                    let titleVal = title.val();
                    let descriptionVal = description.val();
                    let brandVal = brand.val();
                    let modelVal = model.val();
                    let yearVal = year.val();
                    let imageUrlVal = imageUrl.val();
                    let fuelTypeVal = fuelType.val();
                    let priceVal = Number(price.val());


                    //validation
                    if (titleVal.length > 33) {
                        showError('The title length must not exceed 33 characters!');
                        return;
                    }

                    if (descriptionVal.length > 450) {
                        showError('The description length must not exceed 450 characters!');
                        return;
                    }

                    if (descriptionVal.length < 30) {
                        showError('The description length should be at least 30 characters!');
                        return;
                    }

                    if (brandVal.length > 11 || fuelTypeVal.length > 11 || modelVal.length > 11) {
                        showError('The brand,fuelType and model length must not exceed 11 characters!');
                        return;
                    }

                    if (modelVal.length < 4) {
                        showError('The model length should be at least 4 characters!');
                        return;
                    }

                    if (yearVal.length !== 4) {
                        showError('The year must be only 4 chars long!');
                        return;
                    }

                    if (priceVal > 1000000) {
                        showError('The maximum price is 1000000$');
                        return;
                    }

                    if (!imageUrlVal.startsWith('http')) {
                        showError('Link url should always start with “http”');
                        return;
                    }



                    carsService.editPost(postId,brandVal,descriptionVal,fuelTypeVal,imageUrlVal,true,modelVal,priceVal,seller,titleVal,yearVal)
                        .then(function () {
                            title.val('');
                            description.val('');
                            brand.val('');
                            model.val('');
                            year.val('');
                            imageUrl.val('');
                            fuelType.val('');
                            price.val('');
                            imageUrl.val('');
                            showInfo(`Listing ${title} updated.`);
                            loadLists();
                            showView('car-listings');
                        }).catch(handleError)
                })

            }).catch(handleError);
    }

    function displayDelete(event,close) {

        let postId = $(event.target).closest('.'+close).attr('data-id');
        console.log(postId);

        carsService.deletePost(postId)
            .then(function (data) {
                showInfo('Listing deleted.');
                loadLists();
                showView('car-listings');
            }).catch(handleError);
    }

    function logoutUser(event) {
        auth.logout()
            .then(() => {
                sessionStorage.clear();
                showInfo('Logout successful.');
                userLoggedOut();
            }).catch(handleError);
    }

    function displayRegister(event) {
        showView('register');
        event.preventDefault();

        $('#register').find('.registerbtn').click(registerUser);
    }

    function registerUser(event) {
        event.preventDefault();

        let registerForm = $('#register');
        let username = registerForm.find('input[name="username"]');
        let password = registerForm.find('input[name="password"]');
        let repeatPass = registerForm.find('input[name="repeatPass"]');



        let usernameVal = username.val();
        let passwordVal = password.val();
        let repeatPassVal = repeatPass.val();

        if (usernameVal.length < 3) {
            showError('Username must be 3 letters or more');
            return;
        }
        if (passwordVal.length < 6) {
            showError('A user‘s password should be at least 6 characters long ');
            return;
        }
        //TODO and should contain only english alphabet letters and digits
        if (passwordVal !== repeatPassVal) {
            showError('Both passwords must match');
            return;
        }

        auth.register(usernameVal, passwordVal)
            .then(function (userInfo) {
                console.log(userInfo);
                saveSession(userInfo);
                username.val('');
                password.val('');
                repeatPass.val('');
                showInfo('User registration successful.');
            }).catch(handleError);
    }

    function displayLogin(event) {
        showView('login');
        event.preventDefault();

        $('#login').find('.registerbtn').click(loginUser);
    }

    function loginUser(event) {
        event.preventDefault();

        let loginForm = $('#login');
        let username = loginForm.find('input[name="username"]');
        let password = loginForm.find('input[name="password"]');



        let usernameVal = username.val();
        let passwordVal = password.val();

        if (usernameVal.length < 3) {
            showError('Username must be 3 letters or more');
            return;
        }
        if (passwordVal.length < 6) {
            showError('A user‘s password should be at least 6 characters long ');
            return;
        }

        auth.login(usernameVal, passwordVal)
            .then(function (userInfo) {
                saveSession(userInfo);
                username.val('');
                password.val('');
                showInfo('Login successful.');
            }).catch(handleError);
    }

    function userLoggedOut() {
        $('.active').show();
        $('.useronly').hide();
        $('#loggedInUser').text('');
        showView('main');
    }

    function userLoggedIn() {
        $('.useronly').show();
        let username = sessionStorage.getItem('username');
        $('#loggedInUser').text(`Welcome, ${username}!`);
        showView('car-listings');
    }

    function saveSession(userInfo) {
        let userAuth = userInfo._kmd.authtoken;
        sessionStorage.setItem('authtoken', userAuth);
        let userId = userInfo._id;
        sessionStorage.setItem('userId', userId);
        let username = userInfo.username;
        sessionStorage.setItem('username', username);
        userLoggedIn();
    }

    function handleError(reason) {
        showError(reason.responseJSON.description);
    }

    function showInfo(message) {
        let infoBox = $('#infoBox');
        infoBox.text(message);
        infoBox.show();
        setTimeout(() => infoBox.fadeOut(), 3000);
    }

    function showError(message) {
        let errorBox = $('#errorBox');
        errorBox.text(message);
        errorBox.show();
        setTimeout(() => errorBox.fadeOut(), 3000);
    }

    // Handle notifications
    $(document).on({
        ajaxStart: () => $("#loadingBox").show(),
        ajaxStop: () => $('#loadingBox').fadeOut()
    });
});