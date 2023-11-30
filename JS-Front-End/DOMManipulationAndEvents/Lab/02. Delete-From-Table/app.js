function deleteByEmail() {
  const input = document.querySelector('input[name="email"]');
  const rows = Array.from(document.querySelectorAll("tbody tr"));
  const result = document.querySelector("#result");
  let isRemoved = false;

  for (const row of rows) {
    const email = row.children[1];

    if (email.textContent === input.value) {
      row.remove();
      isRemoved = true;
    }
  }

  if (isRemoved) {
    result.textContent = "Deleted";
  } else {
    result.textContent = "Not found.";
  }
}
