function attachEvents() {
  document
    .querySelector("#submit")
    .addEventListener("click", getWeatherDataForLocation);
}

const WEATHERSYMBOLS = {
  Sunny: "☀",
  "Partly sunny": "⛅",
  Overcast: "☁",
  Rain: "☂",
};

async function getWeatherDataForLocation() {
  const locationName = document.querySelector("#location").value;
  const locationResponse = await (
    await fetch("http://localhost:3030/jsonstore/forecaster/locations")
  ).json();

  const location = locationResponse.find(
    (l) => l.name.toLowerCase() === locationName.toLowerCase()
  );

  const currentConditionsResponse = await (
    await fetch(
      `http://localhost:3030/jsonstore/forecaster/today/${location.code}`
    )
  ).json();

  const threeDayForecastResponse = await (
    await fetch(
      `http://localhost:3030/jsonstore/forecaster/upcoming/${location.code}`
    )
  ).json();

  const forecastContainer = document.querySelector("#forecast");
  forecastContainer.style.display = "block";

  const currentWeatherContainer = document.createElement("div");
  currentWeatherContainer.classList.add("forecasts");

  const weatherSymbol = document.createElement("span");
  weatherSymbol.classList.add("condition", "symbol");

  weatherSymbol.textContent =
    WEATHERSYMBOLS[currentConditionsResponse.forecast.condition];

  const dataHolder = document.createElement("span");
  dataHolder.classList.add("condition");

  const name = document.createElement("span");
  name.textContent = currentConditionsResponse.name;
  name.classList.add("forecast-data");
  dataHolder.appendChild(name);

  const temp = document.createElement("span");
  temp.textContent = `${currentConditionsResponse.forecast.low}°/${currentConditionsResponse.forecast.high}°`;
  temp.classList.add("forecast-data");
  dataHolder.appendChild(temp);

  const condition = document.createElement("span");
  condition.textContent =
    WEATHERSYMBOLS[currentConditionsResponse.forecast.condition];
  condition.classList.add("forecast-data");
  dataHolder.appendChild(condition);

  currentWeatherContainer.appendChild(weatherSymbol);
  currentWeatherContainer.appendChild(dataHolder);

  document.querySelector("#current").appendChild(currentWeatherContainer);
}

attachEvents();
