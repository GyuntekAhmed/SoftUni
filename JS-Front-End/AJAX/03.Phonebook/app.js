function attachEvents() {
  const baseURL = "http://localhost:3030/jsonstore/phonebook";

  document.getElementById("btnLoad").addEventListener("click", loadAllContacts);
  document.getElementById("btnCreate").addEventListener("click", createContact);

  const person = document.getElementById("person");
  const phone = document.getElementById("phone");

  async function loadAllContacts() {
    const phonesInfo = await (await fetch(baseURL)).json();

    const ul = document.getElementById("phonebook");

    Object.values(phonesInfo).forEach((contact) => {
      const deleteButton = document.createElement("button");
      deleteButton.textContent = "Delete";

      const li = document.createElement("li");
      li.textContent = `${contact.person}: ${contact.phone}`;
      li.appendChild(deleteButton);

      ul.appendChild(li);

      const contactId = contact._id;

      deleteButton.addEventListener("click", deleteContact);

      function deleteContact() {
        fetch(`${baseURL}/${contactId}`, {
          method: "DELETE",
        });

        li.remove();
        loadAllContacts();
      }
    });
  }

  async function createContact() {
    const contactFormat = {
      person: person.value,
      phone: phone.value,
    };

    await fetch(baseURL, {
      method: "POST",
      body: JSON.stringify(contactFormat),
    });

    document.getElementById("person").value = "";
    document.getElementById("phone").value = "";
    loadAllContacts();
  }
}

attachEvents();
