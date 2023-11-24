function solve() {
  let input = document.querySelector("#text").value.toLowerCase();
  let command = document.querySelector("#naming-convention").value;
  let result = document.querySelector("#result");

  if (command === "Camel Case") {
    let sentence = [];

    input = input.split(" ");
    sentence.push(input[0]);

    for (let i = 1; i < input.length; i++) {
      sentence.push(input[i].charAt(0).toUpperCase() + input[i].slice(1));
    }

    result.textContent = sentence.join("");
  } else if (command === "Pascal Case") {
    let sentence = [];
    input = input.split(" ");
    for (let i = 0; i < input.length; i++) {
      sentence.push(input[i].charAt(0).toUpperCase() + input[i].slice(1));
    }

    result.textContent = sentence.join("");
  } else {
    result.textContent = "Error!"
  }
}
