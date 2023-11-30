function validate() {
  document.getElementById("email").addEventListener("change", onChange);

  function onChange(e) {
    const element = e.currentTarget;
    let patern = /^[a-z]+@[a-z]+\.[a-z]+$/g;

    if (!patern.test(element.value)) {
      element.classList.add("error");
    } else {
      element.classList.remove("error");
    }
  }
}
