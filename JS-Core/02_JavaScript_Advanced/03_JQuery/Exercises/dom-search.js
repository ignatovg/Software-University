function domSearch(selector, sensitive) {
    let container = $(selector);

    let addControlsDiv = $('<div class="add-controls"></div>');
    let labelEnterText = $('<label>Enter text:</label>');
    let inputEnterText = $('<input>');
    let anchorAdd = $('<a class="button" style="display: inline-block">Add</a>');
    anchorAdd.on('click', addInput);

    inputEnterText.appendTo(labelEnterText);
    labelEnterText.appendTo(addControlsDiv);
    anchorAdd.appendTo(addControlsDiv);

    let searchControlsDiv = $('<div class="search-controls"></div>');
    let labelSearch = $('<label>Search:</label>');
    let inputSearch = $('<input>');
    inputSearch.on('keyup', searching);

    inputSearch.appendTo(labelSearch);
    labelSearch.appendTo(searchControlsDiv);

    let resultControlsDiv = $('<div class="result-controls"></div>');
    let listResults = $('<ul class="items-list"></ul>');

    listResults.appendTo(resultControlsDiv);

    addControlsDiv.appendTo(container);
    searchControlsDiv.appendTo(container);
    resultControlsDiv.appendTo(container);

    function searching(event) {
        let searchInput = $('.search-controls label input').val();
        let listContent = $('.list-item strong');
        let elementText = '';
        for (let el of listContent) {
            elementText = el.textContent;

            if (!sensitive) {
                searchInput = searchInput.toLowerCase();
                elementText = elementText.toLowerCase();
            }

            if (elementText === searchInput) {
                $(el).parent().css('display', '');
            } else {
                $(el).parent().css('display', 'none');
            }
        }

        for (let el of listContent) {

            if (searchInput === '') {
                $(el).parent().css('display', '');
            }
        }
    }

    function addInput(event) {
        let inputText = $('.add-controls label input').val();

        let newLi = $('<li class="list-item"></li>');
        let anchorLi = ($('<a class="button">X</a>')).on('click', removeItem);
        let elementText = $(`<strong>${inputText}</strong>`);

        anchorLi.appendTo(newLi);
        elementText.appendTo(newLi);
        newLi.appendTo(listResults);
    }

    function removeItem(event) {
        console.log($(this).parent().remove());
    }
}