function sumTable() {
    const prices = Array.from(document.querySelectorAll("td:nth-child(2)"));

    const total = prices.reduce((acc, current) => {
        return acc + Number(current.textContent);
    }, 0);

    document.querySelector("#sum").textContent = total;
}