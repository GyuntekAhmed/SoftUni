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

const API_URL = "http://localhost:3030/jsonstore/forecaster/";

const service = {
  async getLocations() {
    return (await fetch(`${API_URL}/locations`)).json();
  },
  async getCurrentConditions(code) {
    return (await fetch(`${API_URL}/today/${code}`)).json();
  },

  async getUpcomingWeather(code) {
    return (await fetch(`${API_URL}/upcoming/${code}`)).json();
  },
};

async function getWeatherDataForLocation() {
  const locationName = document.querySelector("#location").value;
  const locationResponse = await service.getLocations();

  const location = locationResponse.find(
    (l) => l.name.toLowerCase() === locationName.toLowerCase()
  );

  const [currentConditions, upcomingWeather] = await Promise.all([
    service.getCurrentConditions(location.code),
    service.getUpcomingWeather(location.code),
  ]);

  document.querySelector("#forecast").style.display = "block";

  document
    .querySelector("#current")
    .appendChild(createCurrentWeatherContainer(currentConditions));

  document
    .querySelector("#upcoming")
    .appendChild(createUpcomingWeatherContainer(upcomingWeather));
}

function createUpcomingWeatherContainer(forecast) {
  const upcomingForecastContainer = document.createElement("div");
  upcomingForecastContainer.classList.add("forecast-info");

  forecast.forecast.forEach((data) => {
    const element = document.createElement("span");
    element.classList.add("upcoming");
    element.appendChild(
      createForecastElement(WEATHERSYMBOLS[data.condition], "symbol")
    );
    element.appendChild(
      createForecastElement(`${data.low}°/${data.high}°`, "forecast-data")
    );
    element.appendChild(createForecastElement(data.condition, "forecast-data"));

    upcomingForecastContainer.appendChild(element);
  });

  return upcomingForecastContainer;
}

function createCurrentWeatherContainer(forecast) {
  const currentWeatherContainer = document.createElement("div");
  currentWeatherContainer.classList.add("forecasts");
  currentWeatherContainer.appendChild(
    createForecastElement(
      WEATHERSYMBOLS[forecast.forecast.condition],
      "condition",
      "symbol"
    )
  );

  currentWeatherContainer.appendChild(createForecastDataContainer(forecast));

  return currentWeatherContainer;
}

function createForecastDataContainer(forecast) {
  const container = document.createElement("span");
  container.classList.add("condition");

  container.appendChild(createForecastElement(forecast.name, "forecast-data"));
  container.appendChild(
    createForecastElement(
      `${forecast.forecast.low}°/${forecast.forecast.high}°`,
      "forecast-data"
    )
  );
  container.appendChild(
    createForecastElement(
      WEATHERSYMBOLS[forecast.forecast.condition],
      "forecast-data"
    )
  );

  return container;
}

function createForecastElement(textContent, ...classes) {
  const forecastElement = document.createElement("span");
  forecastElement.textContent = textContent;
  forecastElement.classList.add(...classes);

  return forecastElement;
}

attachEvents();
