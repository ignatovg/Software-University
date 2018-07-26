function loadCommits() {
    let username = $('#username');
    let repo = $('#repo');
    let baseUrl = `https://api.github.com/repos/${username.val()}/${repo.val()}/commits`;

    $.get(baseUrl)
        .then(displayData)
        .catch(displayError);

    function displayData(data) {
        let ulCommits = $('#commits');
        ulCommits.empty();

        for (let obj of data) {

            let li = $(`<li>${obj.commit.author.name}: ${obj.commit.message}</li>`);
            ulCommits.append(li);
        }
    }

    function displayError(err) {
        let ulCommits = $('#commits');
        ulCommits.empty();
        ulCommits.append($(`<li>Error: ${err.status} (${err.statusText})</li>`))
    }
}