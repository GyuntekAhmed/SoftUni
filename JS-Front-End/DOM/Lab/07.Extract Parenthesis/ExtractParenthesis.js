function extract(content) {
    const text = document.getElementById(content).textContent;

    const reg = /\((.+?)\)/g;
    let match = reg.exec(text);
    let result = [];

    while (match !== null) {
        result.push(match[1]);
        match = reg.exec(text);
    }

    return result.join("; ")
}