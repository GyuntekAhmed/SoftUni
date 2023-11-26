function solve() {
  let input = document.getElementById('input').value;
  let container = document.getElementById('output');
  let sentences = input.split('.');

  sentences = sentences.filter(s => s.length > 0).map(s => s += '.');

  while (sentences.length > 0) {
    let p = document.createElement("p");
    p.textContent = sentences.splice(0, 3).join("");
    container.appendChild(p);
  }
}
