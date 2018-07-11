function generateSummary(button) {
    $(button).click(function (event) {
        let content = $('#content strong').text();

        let summary = $('<div>').attr('id','summary');
        let h2 = $('<h2>').text('Summary');
        let paragraph = $('<p>').text(content);

        summary.append(h2);
        summary.append(paragraph);
        console.log('done');
        $('#content').parent().append(summary);
    })
}