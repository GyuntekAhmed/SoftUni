const baseUrl = "http://localhost:3030/jsonstore/tasks/";

const loadHistoryButton = document.getElementById("load-history");
const weatherList = document.getElementById("list");

const addWeatherBtn = document.getElementById("add-weather");
addWeatherBtn.addEventListener("click", addNewWeather);

let currentWeatherId = "";

const editWeatherBtn = document.getElementById("edit-weather");
editWeatherBtn.addEventListener("click", editWeather);

loadHistoryButton.addEventListener("click", loadHistory);

const locationFieldInput = document.getElementById("location");
const temperatureFieldInput = document.getElementById("temperature");
const dateFieldInput = document.getElementById("date");

async function loadHistory() {
  const response = await fetch(baseUrl);
  const weatherData = await response.json();

  weatherList.innerHTML = "";

  for (const weather of Object.values(weatherData)) {
    const h2Element = document.createElement("h2");
    h2Element.textContent = weather.location;

    const h3DateElement = document.createElement("h3");
    h3DateElement.textContent = weather.date;

    const h3TempElement = document.createElement("h3");
    h3TempElement.textContent = weather.temperature;

    const buttonsContainerDiv = document.createElement("div");
    buttonsContainerDiv.className = "buttons-container";

    const changeBtn = document.createElement("button");
    changeBtn.className = "change-btn";
    changeBtn.textContent = "Change";

    changeBtn.addEventListener("click", async () => {
      locationFieldInput.value = weather.location;
      temperatureFieldInput.value = weather.temperature;
      dateFieldInput.value = weather.date;
      currentWeatherId = weather._id;

      addWeatherBtn.setAttribute("disabled", "disabled");
      editWeatherBtn.removeAttribute("disabled");

      weatherList.removeChild(mainContainerDiv);
    });

    const deleteBtn = document.createElement("button");
    deleteBtn.className = "delete-btn";
    deleteBtn.textContent = "Delete";

    deleteBtn.addEventListener("click", async () => {
      currentWeatherId = weather._id;

      await fetch(baseUrl + currentWeatherId, {
        method: "DELETE",
      });

      loadHistory();
    });

    buttonsContainerDiv.appendChild(changeBtn);
    buttonsContainerDiv.appendChild(deleteBtn);

    const mainContainerDiv = document.createElement("div");
    mainContainerDiv.className = "container";

    mainContainerDiv.appendChild(h2Element);
    mainContainerDiv.appendChild(h3DateElement);
    mainContainerDiv.appendChild(h3TempElement);
    mainContainerDiv.appendChild(buttonsContainerDiv);

    weatherList.appendChild(mainContainerDiv);
  }
}

async function addNewWeather() {
  const isValid =
    locationFieldInput.value !== "" &&
    temperatureFieldInput.value !== "" &&
    dateFieldInput.value !== "";

  if (isValid) {
    const newWeatherObj = {
      location: locationFieldInput.value,
      temperature: temperatureFieldInput.value,
      date: dateFieldInput.value,
    };

    await fetch(baseUrl, {
      method: "POST",
      body: JSON.stringify(newWeatherObj),
    });

    locationFieldInput.value = "";
    temperatureFieldInput.value = "";
    dateFieldInput.value = "";

    loadHistory();
  }
}

async function editWeather() {
  const editedWeatherObj = {
    location: locationFieldInput.value,
    temperature: temperatureFieldInput.value,
    date: dateFieldInput.value,
    _id: currentWeatherId,
  };

  await fetch(baseUrl + currentWeatherId, {
    method: "PUT",
    body: JSON.stringify(editedWeatherObj),
  });

  addWeatherBtn.removeAttribute("disabled");
  editWeatherBtn.setAttribute("disabled", "disabled");

  loadHistory();
}
