let carsService  = (() => {

    function loadAllCars() {
        let endpoint = 'cars?query={}&sort={"_kmd.ect": -1}';

        return requester.get('appdata', endpoint, 'kinvey');
    }
    
    function createCar(brand, description, fuel, imageUrl, isAuthor, model, price, seller, title, year) {
        let data = {
            brand,
            description,
            fuel,
            imageUrl,
            isAuthor,
            model,
            price,
            seller,
            title,
            year
        };
        return requester.post('appdata', 'cars', 'kinvey', data);
    }

    function loadPostById(id) {
     let endpoint = `cars/${id}`;
        return requester.get('appdata', endpoint, 'kinvey');
    }

    function editPost(postId,brand, description, fuel, imageUrl, isAuthor, model, price, seller, title, year) {
        let data = {
            brand, description, fuel, imageUrl, isAuthor, model, price, seller, title, year
        };

        return requester.update('appdata', `cars/${postId}`, 'kinvey', data)
    }

     function deletePost(carId) {
            let endpoint = `cars/${carId}`;

            return requester.remove('appdata', endpoint, 'kinvey');
        }

        function loadMyPosts(username) {
            let endpoint = `cars?query={"seller":"${username}"}&sort={"_kmd.ect": -1}`;
            return requester.get('appdata', endpoint, 'kinvey');

        }

    return {
        loadAllCars,
        createCar,
        loadPostById,
        editPost,
        deletePost,
        loadMyPosts
    }
})()