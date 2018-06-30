function createInventory(strArr) {
    let inventory = strArr.shift().split(' ');
    for (let line of strArr) {
        let tokens = line.split(' ');
        let command = tokens[0];
        let item = tokens[1];

        if(command === 'Buy' && !inventory.includes(item) ){
            inventory.push(item);

        }else if(command === 'Trash'){
            let indexOf = inventory.indexOf(item);
            if(indexOf !== -1) {
                inventory.splice(indexOf, 1);
            }
        }
        else if(command === 'Repair'){
            let indexOf = inventory.indexOf(item);
            if(indexOf !== -1) {
                let currentItem = inventory.splice(indexOf, 1);
                inventory.push(currentItem[0]);
            }
        }else if(command === 'Upgrade'){
            let [equipment,upgrade] = item.split('-');
            let indexOf = inventory.indexOf(equipment);
            if(indexOf !== -1) {
                inventory.splice(indexOf + 1 , 0, `${equipment}:${upgrade}`);
            }
        }else if(command === 'Fight!'){
            break;
        }
    }
    console.log(inventory.join(' '));
}

createInventory([
    'SWORD Shield Spear',
    'Buy Bag',
    'Trash Shield',
    'Repair Spear',
    'Upgrade SWORD-Steel',
    'Fight!',
]);