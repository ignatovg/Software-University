function attachEvents() {
    $('#btnLoadTowns').click(attachData);

    function attachData(event) {
        let townsInput = $('#towns').val();
        let townsArr = townsInput.split(', ');
        let context = {towns: []};
        for (let town of townsArr) {
            context.towns.push({name: town});
        }

        let source = $('#towns-template').html();
        let template = Handlebars.compile(source);

        let html = template(context);
        $('#root').append(html);
    }
}