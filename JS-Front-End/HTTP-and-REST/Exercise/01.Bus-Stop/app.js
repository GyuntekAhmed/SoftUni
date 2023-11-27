async function getInfo() {
  const busStopId = document.querySelector("#stopId").value;
  const list = document.querySelector("ul");
  const stopName = document.querySelector("#stopName");

  list.innerHTML = "";

  const service = {
    busInfoURL: (ID) => `http://localhost:3030/jsonstore/bus/businfo/${ID}`,
  };

  try {
    const response = await fetch(service.busInfoURL(busStopId));
    const busStopInfo = await response.json();

    stopName.textContent = busStopInfo.name;

    Object.entries(busStopInfo.buses).map(([busNumber, timeInMinutes]) => {
      const item = document.createElement("li");
      item.textContent = `Bus ${busNumber} arrives in ${timeInMinutes} minutes`;

      list.appendChild(item);
    });
  } catch (_) {
    stopName.textContent = "Error";
  }
}
