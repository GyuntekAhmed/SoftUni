function editElement(htmlElement, strMatch, replacer) {
    htmlElement.textContent = htmlElement.textContent.replace(new RegExp(strMatch, 'g'), replacer);
}