function focused() {
  const fields = Array.from(document.getElementsByTagName("input"));

  for (const field of fields) {
    field.addEventListener("focus", onFocus);
    field.addEventListener("blur", onBlur);
  }

  function onFocus(e) {
    const div = e.currentTarget.parentNode;
    div.classList.add("focused");
  }

  function onBlur(e) {
    const div = e.currentTarget.parentNode;
    div.classList.remove("focused");
  }
}
