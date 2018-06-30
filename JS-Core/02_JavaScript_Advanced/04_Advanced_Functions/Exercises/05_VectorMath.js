let solution = (() => {
    return {
        add: additionOfTwoVectors,
        multiply: scalarMultiplication,
        length: vectorLength,
        dot: dotProductOfTwoVectors,
        cross: crossProductOfTwoVectors,
    };

    function additionOfTwoVectors(firstVector,secondVector) {
        return [firstVector[0] + secondVector[0], firstVector[1] + secondVector[1]];
    }
    function scalarMultiplication(vector,scalar) {
        return [vector[0] * scalar, vector[1] * scalar];
    }
    function vectorLength(vector) {
        return Math.sqrt(vector[0] * vector[0] + vector[1] * vector[1]);
    }
    function dotProductOfTwoVectors(firstVector,secondVector) {
        return firstVector[0] * secondVector[0] + firstVector[1] * secondVector[1];
    }
    function crossProductOfTwoVectors(firstVector, secondVector) {
        return firstVector[0] * secondVector[1] - firstVector[1] * secondVector[0];
    }
})();

console.log(solution.add([1, 1], [1, 0]));

