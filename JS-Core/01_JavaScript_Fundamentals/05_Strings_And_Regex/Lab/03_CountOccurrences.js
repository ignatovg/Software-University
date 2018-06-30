function counter(target, str) {
    let count = 0;
    let currentIndex = str.indexOf(target);

    while (currentIndex !== -1) {
        count++;
        currentIndex = str.indexOf(target,currentIndex+ 1);
    }

    console.log(count);

}

counter('haha', 'hahaha');