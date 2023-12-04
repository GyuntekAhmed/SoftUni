function attachEvents() {
  document.querySelector("#form button").addEventListener("click", saveBook);
}

async function saveBook() {
  const name = document.querySelector('#form input[name="title"]').value;
  const author = document.querySelector('#form input[name="author"]').value;

  if (!name || !author) {
    return;
  }

  fetch()
}

attachEvents();
