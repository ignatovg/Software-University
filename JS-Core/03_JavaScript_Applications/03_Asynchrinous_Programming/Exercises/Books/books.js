function attachEvents() {
    const baseUrl = 'https://baas.kinvey.com/appdata/kid_r1R6DyIEX';
    const kinveyUsername = 'joro';
    const kinveyPassword = 'joro';
    const base64 = btoa(`${kinveyUsername}:${kinveyPassword}`);
    const authHeader = {
        'Authorization': 'Basic ' + base64,
        'Content-Type': 'application/json'
    };

    $('.load').click(loadBooks);
    $('.add').click(createBook);

    function request(method, endpoint, data) {
        return $.ajax({
            method: method,
            url: baseUrl + endpoint,
            headers: authHeader,
            data: JSON.stringify(data)
        });

    }

    function loadBooks() {
        request('GET','/books')
            .then(displayBooks)
            .catch(handleError);
    }

    function displayBooks(data) {
        let books = $('#books');
        books.empty();

        for (let currentBook of data) {
            let divBook = $(`<div class="book" data-id="${currentBook._id}"></div>`);

            divBook.append($(`<label>Title</label>`));
            divBook.append($(`<input type="text" class="title" value="${currentBook.title}"/>`));
            divBook.append($(`<label>Author</label>`));
            divBook.append($(` <input type="text" class="author" value="${currentBook.author}"/>`));
            divBook.append($(`<label>Isbn</label>`));
            divBook.append($(`<input type="text" class="isbn" value="${currentBook.isbn}"/>`));
            divBook.append($(`<button class="update">Update</button>`).click(updateBook));
            divBook.append($(`<button class="delete">Delete</button>`).click(deleteBook));

            books.append(divBook);
        }
    }

    function createBook(event) {
        let bookEl = $('#addForm');
        let dataObj = createDataJSON(bookEl);

        request('POST','/books',dataObj)
            .then(loadBooks)
            .catch(handleError)
    }

    function createDataJSON(bookEl) {
        return {
            'title':bookEl.find('.title').val(),
            'author':bookEl.find('.author').val(),
            'isbn':bookEl.find('.isbn').val()
        }
    }

    function updateBook(event) {
        let bookEl = $(this).parent();
        let dataObj = createDataJSON(bookEl);
        let bookId = bookEl.attr('data-id');

        request('PUT',`/books/${bookId}`,dataObj)
            .then(loadBooks)
            .catch(handleError);
    }

    function deleteBook(event) {
        let bookId = $(this).parent().attr('data-id');
        request(`DELETE`,`/books/${bookId}`)
            .then(loadBooks)
            .catch(handleError);
    }

    function handleError(err) {
        alert('Error');
        console.log(err);
    }

}
