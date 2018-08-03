function attachEvents() {
    $('#btnLoadTowns').click(attachData);

    function attachData(event) {
        let towns = $('#towns').val();
        let townsArr = towns.split(', ');

        let source = $('#towns-template').html();
        let template = Handlebars.compile(source);

        let ul = $('<ul>');

        for (let town of townsArr) {
            let li = template({name:town});
            ul.append(li)
        }
        $('#root').append(ul);
    }
}