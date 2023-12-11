async function lockedProfile() {
  const baseURL = "http://localhost:3030/jsonstore/advanced/profiles";

  const response = await fetch(baseURL);

  const data = await response.json();

  Object.values(data).forEach((profile) => {
    const userName = profile.username.value;

    let info = document.querySelector(`input[name="user1Username"]`);

    info.textContent = userName;
  });
}