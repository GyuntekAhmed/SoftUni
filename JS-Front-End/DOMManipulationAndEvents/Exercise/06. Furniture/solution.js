function solve() {
  const formatButton = document.querySelector("#exercise button");
  formatButton.addEventListener("click", parseFurnitureInput);

  const buyButton = document.querySelector("#exercise button:nth-of-type(2)");
  buyButton.addEventListener("click", buySelectedFurniture);

  Array.from(document.querySelectorAll('input[type="checkbox"]')).forEach(
    (checkbox) => checkbox.removeAttribute("disabled")
  );

  function parseFurnitureInput() {
    const input = JSON.parse(
      document.querySelector("#exercise textarea").value
    );

    const tableBody = document.querySelector("tbody");

    input
      .map((furniture) => {
        const row = document.createElement("tr");
        const imageCell = document.createElement("td");
        const image = document.createElement("img");

        image.src = furniture.img;
        imageCell.appendChild(image);

        const nameCell = document.createElement("td");
        nameCell.textContent = furniture.name;

        const priceCell = document.createElement("td");
        priceCell.textContent = furniture.price;

        const decorationFactorCell = document.createElement("td");
        decorationFactorCell.textContent = furniture.decFactor;

        const chekCell = document.createElement("td");
        const checkbox = document.createElement("input");
        checkbox.type = "checkbox";
        chekCell.appendChild(checkbox);

        row.appendChild(imageCell);
        row.appendChild(nameCell);
        row.appendChild(priceCell);
        row.appendChild(decorationFactorCell);
        row.appendChild(chekCell);

        return row;
      })
      .forEach((row) => {
        tableBody.appendChild(row);
      });
  }

  function buySelectedFurniture() {
    const checkboxes = Array.from(
      document.querySelectorAll('input[type="checkbox"]:checked')
    );

    const cart = checkboxes.map(mapCheckboxToObject).reduce(
      (acc, current) => {
        acc.names.push(current.name);
        acc.price += current.price;
        acc.averageDecorationFactor += current.decFactor / checkboxes.length;

        return acc;
      },
      {
        names: [],
        price: 0,
        averageDecorationFactor: 0,
      }
    );

    const cartTextArea = document.querySelector(
      "#exercise textarea:nth-of-type(2)"
    );

    cartTextArea.value = `
      Bought furniture: ${cart.names.join(", ")}
      Total price: ${cart.price.toFixed(2)}
      Average decoration factor: ${cart.averageDecorationFactor.toFixed(2)}
    `;
  }

  function mapCheckboxToObject(checkbox) {
    const row = checkbox.parentElement.parentElement;
    const name = row.querySelector("td:nth-of-type(2)").innerText;
    const price = Number(row.querySelector("td:nth-of-type(3)").innerText);
    const decFactor = Number(row.querySelector("td:nth-of-type(4)").innerText);

    return { name, price, decFactor };
  }
}
