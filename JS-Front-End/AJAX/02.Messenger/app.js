function attachEvents() {
  const baseURL = "http://localhost:3030/jsonstore/messenger";

  const messagesArea = document.getElementById("messages");

  const [nameInput, contentInput, sendButton, refreshButton] =
    document.getElementsByTagName("input");

  sendButton.addEventListener("click", sendMessage);

  async function sendMessage() {
    const messageFormat = {
      author: nameInput.value,
      content: contentInput.value,
    };

    const isValidMessage = nameInput.value !== "" && contentInput.value !== "";

    if (isValidMessage) {
      await fetch(baseURL, {
        method: "POST",
        body: JSON.stringify(messageFormat),
      });
    }

    nameInput.value = "";
    contentInput.value = "";
  }

  refreshButton.addEventListener("click", getAllMessages);

  async function getAllMessages() {
    const messagesToDisplay = [];

    const response = await fetch(baseURL);
    const data = await response.json();

    for (const messageInfo of Object.values(data)) {
        messagesToDisplay.push(`${messageInfo.author}: ${messageInfo.content}`);
    }

    messagesArea.textContent = messagesToDisplay.join('\n');
  }
}

attachEvents();
