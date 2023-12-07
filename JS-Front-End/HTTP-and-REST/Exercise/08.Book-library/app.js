const baseUrl = 'http://localhost:3030/jsonstore/collections/books';

function attachEvents() {
  document
    .querySelector("#form button")
    .addEventListener("click", handleFormSubmision);
  document.querySelector("#loadBooks").addEventListener("click", loadBooks);
}

async function loadBooks() {
  const books = await (
    await fetch(baseUrl)
  ).json();

  Object.entries(books).forEach(createAndAppendElement);
}

function createAndAppendElement([id, book]) {
  const title = document.createElement("td");
  title.textContent = book.title;

  const author = document.createElement("td");
  author.textContent = book.author;

  const deleteButton = document.createElement("button");
  deleteButton.setAttribute("data-bookid", id);
  deleteButton.addEventListener("click", deleteBook);
  deleteButton.textContent = "Delete";

  const editButton = document.createElement("button");
  editButton.setAttribute("data-bookid", id);
  editButton.addEventListener("click", fillEditForm);
  editButton.textContent = "Edit";

  const buttons = document.createElement("td");
  buttons.appendChild(editButton);
  buttons.appendChild(deleteButton);

  const row = document.createElement("tr");
  row.appendChild(title);
  row.appendChild(author);
  row.appendChild(buttons);

  document.querySelector("tbody").appendChild(row);
}

async function deleteBook(e) {
  const bookId = e.currentTarget.dataset.bookid;

  await fetch(`${baseUrl}/${bookId}`, {
    method: "DELETE",
  });
}

async function fillEditForm(e) {
  const title =
    e.currentTarget.parentElement.parentElement.querySelector(
      "td:first-child"
    ).textContent;

  const author =
    e.currentTarget.parentElement.parentElement.querySelector(
      "td:nth-child(2)"
    ).textContent;

  document.querySelector("h3").textContent = "Edit Form";
  document.querySelector('#form input[name="title"]').value = title;
  document.querySelector('#form input[name="author"]').value = author;
  document
    .querySelector("#form button")
    .setAttribute("data-bookid", e.currentTarget.dataset.bookid);
}

async function handleFormSubmision(e) {
  const isEditing = document.querySelector("h3").textContent.includes("Edit");

  isEditing ? updateBook(e) : saveBook(e);
}

async function updateBook(e) {
  const bookid = e.currentTarget.dataset.bookid;
  const title = document.querySelector('#form input[name="title"]').value;
  const author = document.querySelector('#form input[name="author"]').value;

  fetch(`${baseUrl}/${bookid}`, {
    method: "PUT",
    headers: {
      "Content-type": "application/json",
    },
    body: JSON.stringify({ title, author }),
  });

  title = '';
  author = '';
}

async function saveBook() {
  const title = document.querySelector('#form input[name="title"]').value;
  const author = document.querySelector('#form input[name="author"]').value;

  if (!title || !author) {
    return;
  }

  await fetch(baseUrl, {
    method: "POST",
    headers: {
      "Content-type": "application/json",
    },
    body: JSON.stringify({ title, author }),
  });

  title = '';
  author = '';
}

attachEvents();
