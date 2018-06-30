function addItem() {
    let inputText = document.getElementById('newItemText').value;
    let inputValue = document.getElementById('newItemValue').value;

    let newOption = document.createElement('option');
    newOption.textContent = inputText;
    newOption.value = inputValue;

    document.getElementById('menu').appendChild(newOption);
    document.getElementById('newItemText').value = '';
    document.getElementById('newItemValue').value = '';

}