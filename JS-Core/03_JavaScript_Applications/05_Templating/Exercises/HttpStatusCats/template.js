$(() => {
    renderCatTemplate();

    function renderCatTemplate() {
        let allCats = $('#allCats');

        let source = $('#cat-template').html();
        let template = Handlebars.compile(source);
        let context = {
            cats: [
                {imgCat: 'images/cat100.jpg', statusCode: '100', statusText: 'Continue'},
                {imgCat: 'images/cat200.jpg', statusCode: '200', statusText: 'Ok'},
                {imgCat: 'images/cat204.jpg', statusCode: '204', statusText: 'No content'},
                {imgCat: 'images/cat301.jpg', statusCode: '301', statusText: 'Moved permanently'},
                {imgCat: 'images/cat304.jpg', statusCode: '304', statusText: 'Not modified'},
                {imgCat: 'images/cat400.jpg', statusCode: '400', statusText: 'Bad request'},
                {imgCat: 'images/cat404.jpg', statusCode: '404', statusText: 'Not Found'},
                {imgCat: 'images/cat406.jpg', statusCode: '406', statusText: 'Not Acceptable'},
                {imgCat: 'images/cat410.jpg', statusCode: '410', statusText: 'Gone'},
                {imgCat: 'images/cat500.jpg', statusCode: '500', statusText: 'Internal Server Error'},
                {imgCat: 'images/cat511.jpg', statusCode: '511', statusText: 'Network Authentication Required'},
            ]};
        let html = template(context);
        allCats.html(html);

       $('.btn-primary').click(showStatus);
    }

    function showStatus(event) {
        $(this).next().toggle();
    }
});
