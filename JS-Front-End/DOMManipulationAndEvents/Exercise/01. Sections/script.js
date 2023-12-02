function create(words) {
  const content = document.getElementById('content');

  words.forEach(word => {
    let div = document.createElement('div');
    let paragraph = document.createElement('p');

    paragraph.textContent = word;
    paragraph.style.display = 'none';
    div.appendChild(paragraph);
    
    div.addEventListener('click', () => {
      paragraph.style.display = 'block';
    })

    content.appendChild(div);
  });
}