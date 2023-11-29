function addItem() {
  const items = document.querySelector("#items");
  const text = document.querySelector("#newItemText");
  const newListItem = document.createElement("li");

  newListItem.textContent = text.value;
  items.appendChild(newListItem);

  text.value = '';
}
