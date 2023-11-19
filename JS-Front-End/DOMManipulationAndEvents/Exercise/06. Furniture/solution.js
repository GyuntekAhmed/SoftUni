function solve() {
  const button = document.querySelector("#exercise button");
  button.addEventListener("click", parseFurnitureInput);

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
}
