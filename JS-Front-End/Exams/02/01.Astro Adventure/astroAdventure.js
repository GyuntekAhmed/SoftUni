function solve(input) {
  const astronauts = [];

  const astronautsCount = Number(input.shift());

  for (let currentAstronaut = 1;currentAstronaut <= astronautsCount; currentAstronaut++) {
    const [name, oxygen, energy] = input.shift().split(" ");
    astronauts.push({
      name,
      oxygen: Number(oxygen),
      energy: Number(energy),
    });
  }

  while (input.length > 0) {
    const command = input.shift();

    if (command === "End") {
      break;
    }

    const [action, name, value] = command.split(" - ");

    switch (action) {
      case "Explore":
        const energyNeeded = Number(value);
        const astronaut = astronauts.find(
          (astronaut) => astronaut.name === name
        );

        if (astronaut && astronaut.energy >= energyNeeded) {
          astronaut.energy -= energyNeeded;
          console.log(
            `${name} has successfully explored a new area and now has ${astronaut.energy} energy!`
          );
        } else if (astronaut) {
          console.log(`${name} does not have enough energy to explore!`);
        }
        break;

      case "Refuel":
        const amount = Number(value);
        const astronautToRefuel = astronauts.find(
          (astronaut) => astronaut.name === name
        );

        if (astronautToRefuel) {
          const energyRecovered = Math.min(
            amount,
            200 - astronautToRefuel.energy
          );
          astronautToRefuel.energy += energyRecovered;

          console.log(`${name} refueled their energy by ${energyRecovered}!`);
        }
        break;

      case "Breathe":
        const amountOxygen = Number(value);
        const astronautToBreathe = astronauts.find(
          (astronaut) => astronaut.name === name
        );

        if (astronautToBreathe) {
          const oxygenRecovered = Math.min(
            amountOxygen,
            100 - astronautToBreathe.oxygen
          );
          astronautToBreathe.oxygen += oxygenRecovered;

          console.log(
            `${astronautToBreathe.name} took a breath and recovered ${oxygenRecovered} oxygen!`
          );
        }
        break;
    }
  }

  astronauts.forEach((a) => {
    console.log(
      `Astronaut: ${a.name}, Oxygen: ${a.oxygen}, Energy: ${a.energy}`
    );
  });
}

solve([
  "3",
  "John 50 120",
  "Kate 80 180",
  "Rob 70 150",
  "Explore - John - 50",
  "Refuel - Kate - 30",
  "Breathe - Rob - 20",
  "End",
]);

solve([
  "4",
  "Alice 60 100",
  "Bob 40 80",
  "Charlie 70 150",
  "Dave 80 180",
  "Explore - Bob - 60",
  "Refuel - Alice - 30",
  "Breathe - Charlie - 50",
  "Refuel - Dave - 40",
  "Explore - Bob - 40",
  "Breathe - Charlie - 30",
  "Explore - Alice - 40",
  "End",
]);
