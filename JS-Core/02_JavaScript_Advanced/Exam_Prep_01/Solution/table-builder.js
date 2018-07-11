function tableBuilder(selector) {
    let container = $(selector);

    function createTable(columnNames) {
        container.empty();
        let table = $('<table>');
        let tr = $('<tr>');
        for (let name of columnNames) {
            let th = $(`<th>${name}</th>`);
            th.appendTo(tr);
        }
        //action th
        $(`<th>Action</th>`).appendTo(tr);
        tr.appendTo(table);
        table.appendTo(container);
    }

    function fillData(dataRows) {
        let table = $(`${selector} table`);

        for (let row of dataRows) {
            let tr = $('<tr>');
            for (let rowElement of row) {
                let td = $('<td>');
                td.text(rowElement);
                td.appendTo(tr);
            }
            let deleteBtn = $('<td><button>Delete</button></td>');
            deleteBtn.on('click', function (event) {
                $(this).parent().remove();
            });
            deleteBtn.appendTo(tr);

            tr.appendTo(table);
        }
    }

    return {createTable, fillData}
}