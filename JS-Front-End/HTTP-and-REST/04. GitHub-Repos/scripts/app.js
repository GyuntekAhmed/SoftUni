function loadRepos() {
  fetch("https://api.github.com/users/GyuntekAhmed/repos")
    .then((res) => res.json())
    .then((body) => console.log(body));
}
