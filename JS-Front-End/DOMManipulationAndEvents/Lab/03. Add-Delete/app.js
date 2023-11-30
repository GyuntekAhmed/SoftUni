function addItem() {
    const items = document.querySelector("#items");
    const text = document.querySelector("#newItemText");
    const newListItem = document.createElement("li");
    const linkToDelete = document.createElement("a");

    linkToDelete.href = "#";
    linkToDelete.textContent = "[Delete]";
  
    linkToDelete.addEventListener('click', deleteItem);
    newListItem.textContent = text.value;
    newListItem.appendChild(linkToDelete);

    items.appendChild(newListItem);
  
    text.value = '';


    function deleteItem(e) {
        const row = e.currentTarget.parentNode;
        row.remove();
    }
  }