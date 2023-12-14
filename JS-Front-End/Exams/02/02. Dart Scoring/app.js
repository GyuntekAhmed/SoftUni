window.addEventListener("load", solve);

function solve() {
  const addButton = document.getElementById("add-btn");

  const sureList = document.getElementById("sure-list");

  const playerNameInput = document.getElementById("player");
  const scoreInput = document.getElementById("score");
  const roundInput = document.getElementById("round");

  addButton.addEventListener("click", addInputsFromForm);

  function addInputsFromForm(e) {
    e.preventDefault();

    if (
      playerNameInput.value === "" ||
      scoreInput.value === "" ||
      roundInput.value === ""
    ) {
      return;
    }

    const li = createElement("li", null, "dart-item", null, sureList);
    const article = createElement("article");
    const playerParagraph = createElement("p", playerNameInput.value);
    const scoreParagraph = createElement("p", `Score: ${scoreInput.value}`);
    const roundParagraph = createElement("p", `Round: ${roundInput.value}`);

    article.appendChild(playerParagraph);
    article.appendChild(scoreParagraph);
    article.appendChild(roundParagraph);
    li.appendChild(article);

    const editButton = createElement("button", "edit", "btn");
    editButton.classList.add("edit");
    li.appendChild(editButton);

    addButton.disabled = true;

    const currentPlayerValue = playerNameInput.value;
    const currentScoreValue = scoreInput.value;
    const currentRoundValue = roundInput.value;

    document.getElementById("player").value = "";
    document.getElementById("score").value = "";
    document.getElementById("round").value = "";

    editButton.addEventListener("click", () => {
      playerNameInput.value = currentPlayerValue;
      scoreInput.value = currentScoreValue;
      roundInput.value = currentRoundValue;

      sureList.innerHTML = "";
      addButton.disabled = false;
    });

    const okButton = createElement("button", "ok", "btn");
    okButton.classList.add("ok");
    li.appendChild(okButton);

    const scoreBoardList = document.getElementById("scoreboard-list");

    okButton.addEventListener("click", () => {
      scoreBoardList.appendChild(li);

      li.removeChild(editButton);
      li.removeChild(okButton);

      sureList.innerHTML = "";
      addButton.disabled = false;
    });
  }

  const clearButton = document.getElementsByClassName('btn clear')[0];

  clearButton.addEventListener('click', () => {
    location.reload();
  })

  function createElement(
    type,
    textContent,
    classes,
    id,
    parrent,
    useInnerHTML
  ) {
    const element = document.createElement(type);

    if (useInnerHTML && textContent) {
      element.innerHTML = textContent;
    } else if (textContent) {
      element.textContent = textContent;
    }

    if (classes && classes.length > 0) {
      element.classList.add(classes);
    }

    if (id) {
      element.setAttribute("id", id);
    }

    if (parrent) {
      parrent.appendChild(element);
    }

    return element;
  }
}
