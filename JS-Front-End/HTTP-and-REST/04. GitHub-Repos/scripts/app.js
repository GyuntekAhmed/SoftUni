function loadRepos() {
  fetch("https://api.github.com/users/GyuntekAhmed/repos")
    .then((res) => res.json())
    .then((body) => {
      body.forEach(repo => {
        const name = document.createElement('h2');
        name.textContent = repo.name;

        document.querySelector('body').appendChild(name);
      });
    });

  // const simulatedResponse = new Promise((resolve, reject) => {
  //   setTimeout(() => {
  //     resolve();
  //   }, 500);
  // });

  // simulatedResponse
  //   .then(() => console.log("Success"))
  //   .catch(() => console.log("Error"));
}
