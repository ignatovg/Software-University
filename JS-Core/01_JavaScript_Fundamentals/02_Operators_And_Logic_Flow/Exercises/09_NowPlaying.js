function playMusic(inputArr) {
    let trackName = inputArr[0];
    let artistName = inputArr[1];
    let duration = inputArr[2];

    console.log(`Now Playing: ${artistName} - ${trackName} [${duration}]`);
}

playMusic(['Number One', 'Nelly', '4:09']);