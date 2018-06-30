/*
let createBook = (function () {
    let id = 1;
    return function (selector, title, author, ISBN) {
        let container = $(selector);
        let fragment = document.createDocumentFragment();

        let div = $('<div>');
        div.attr('id', `book${id++}`);
        let paragraphTitle = $(`<p class="title">${title}</p>`);
        let paragraphAuthor = $(`<p class="author">${author}</p>`);
        let paragraphIsbn = $(`<p class="isbn">${ISBN}</p>`);
        let selectBtn = $($('<button>Select</button>').click(selectEvent));
        let deselectBtn = $($('<button>Deselect</button>').click(deselectEvent));

        div.append(paragraphTitle);
        div.append(paragraphAuthor);
        div.append(paragraphIsbn);
        div.append(selectBtn);
        div.append(deselectBtn);

        container.append(div);

        function selectEvent(event) {
            div.css('border', '2px solid blue');
        }

        function deselectEvent(event) {
            div.css('border', 'none');
        }
    }
}());
*/

function createBook(selector,bookTitle,authorName, isbn) {
    let bookGenerator = (function () {
        let id =1;
        return function (selector, bookTitle, authorName, isbn) {
            let container = $(selector);
            let bookContainer = $('<div>');
            bookContainer.attr('id',`book${id}`);
            bookContainer.css('border','none');
            $(`<p class="title">${bookTitle}</p>`)
                .appendTo(bookContainer);
            $(`<p class="author">${authorName}</p>`)
                .appendTo(bookContainer);
            $(`<p class="isbn">${isbn}</p>`)
                .appendTo(bookContainer);

            let selectBtn = $('<button>Select</button>');
            let deselectBtn= $('<button>Deselect</button>');
            selectBtn.on('click',() => bookContainer.css('border','2px solid blue')) ;
            deselectBtn.on('click', () => bookContainer.css('border','none'));

            selectBtn.appendTo(bookContainer);
            deselectBtn.appendTo(bookContainer);
            bookContainer.appendTo(container);

            id++;
        }
    }());

    bookGenerator(selector,bookTitle,authorName, isbn)
}


