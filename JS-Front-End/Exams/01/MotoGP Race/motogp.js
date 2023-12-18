function raceActions(input) {
  const countOfRiders = Number(input.shift());

  const lines = input.slice(0, countOfRiders);

  const commands = input.slice(countOfRiders);

  const riders = lines.reduce((acc, curr) => {
    const [rider, fuelCapacity, position] = curr.split("|");

    acc[rider] = {
      fuelCapacity: Number(fuelCapacity),
      position: Number(position),
    };

    if (fuelCapacity > 100) {
      acc[rider].fuelCapacity = 100;
    }
    return acc;
  }, {});

  const commandExecutor = {
    StopForFuel: stopForFuel,
    Overtaking: overtaking,
    EngineFail: engineFail,
    Finish: finish,
  };

  commands.forEach((command) => {
    const [commandName, ...rest] = command.split(" - ");

    commandExecutor[commandName](...rest);
  });

  function stopForFuel(rider, minimumFuel, changedPosition) {
    if (riders[rider].fuelCapacity < minimumFuel) {
      console.log(`${rider} stopped to refuel but lost his position, now he is ${changedPosition}.`);
      riders[rider].position = changedPosition;
    } else {
      console.log(`${rider} does not need to stop for fuel!`);
    }
  }
  

  function overtaking(firstRider, secondRider) {
    const firstRiderPosition = riders[firstRider].position;
    const secondRiderPosition = riders[secondRider].position;

    if (firstRiderPosition < secondRiderPosition) {
      console.log(`${firstRider} overtook ${secondRider}!`);
      const temp = riders[firstRider].position;
      riders[firstRider].position = riders[secondRider].position;
      riders[secondRider].position = temp;
    }
  }

  function engineFail(rider, lapsLeft) {
    console.log(
      `${rider} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`
    );

    delete riders[rider];
  }

  function finish() {
    Object.keys(riders).forEach((rider) => {
      console.log(`${rider}\n  Final position: ${riders[rider].position}`);
    });
  }
}

raceActions([
  "3",
  "Valentino Rossi|100|1",
  "Marc Marquez|90|2",
  "Jorge Lorenzo|80|3",
  "StopForFuel - Valentino Rossi - 50 - 1",
  "Overtaking - Marc Marquez - Jorge Lorenzo",
  "EngineFail - Marc Marquez - 10",
  "Finish",
]);

raceActions([
  "4",
  "Valentino Rossi|100|1",
  "Marc Marquez|90|3",
  "Jorge Lorenzo|80|4",
  "Johann Zarco|80|2",
  "StopForFuel - Johann Zarco - 90 - 5",
  "Overtaking - Marc Marquez - Jorge Lorenzo",
  "EngineFail - Marc Marquez - 10",
  "Finish",
]);
