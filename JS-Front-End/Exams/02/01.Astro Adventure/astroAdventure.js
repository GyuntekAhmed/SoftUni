function solve(input) {
  const countOfLines = Number(input.shift());
  const details = Array.from(input.slice(0, countOfLines));
  const commands = input.slice(countOfLines);

  const astronauts = details.reduce((acc, curr) => {
    const [astronaut, oxygen, energy] = curr.split(" ");

    acc[astronaut] = {
      oxygen: Number(oxygen),
      energy: Number(energy),
    };
    return acc;
  }, {});

  const commandExecutor = {
    Explore: explore,
    Refuel: refuel,
    Breathe: breathe,
    End: end,
  };

  commands.forEach((command) => {
    const [commandName, ...rest] = command.split(" - ");

    commandExecutor[commandName](...rest);
  });

  function explore(astronaut, neededEnergy) {
    if (astronauts[astronaut].energy >= Number(neededEnergy)) {
      astronauts[astronaut].energy -= Number(neededEnergy);

      console.log(
        `${astronaut} has successfully explored a new area and now has ${astronauts[astronaut].energy} energy!`
      );
    } else {
      console.log(`${astronaut} does not have enough energy to explore!`);
    }
  }

  function refuel(astronaut, amount) {
    let result = astronauts[astronaut].energy + Number(amount);

    if (result <= 200) {
      astronauts[astronaut].energy += Number(amount);
      console.log(`${astronaut} refueled their energy by ${amount}!`);
    } else {
      astronauts[astronaut].energy = 200;
      result = result - 200;
      console.log(`${astronaut} refueled their energy by ${amount - result}!`);
    }
  }

  function breathe(astronaut, amount) {
    let result = astronauts[astronaut].oxygen + Number(amount);

    if (result <= 100) {
      astronauts[astronaut].oxygen += Number(amount);
      console.log(`${astronaut} took a breath and recovered ${amount} oxygen!`);
    } else {
      astronauts[astronaut].oxygen = 100;
      result = result - 100;
      console.log(
        `${astronaut} took a breath and recovered ${amount - result} oxygen!`
      );
    }
  }

  function end() {
    Object.keys(astronauts).forEach((astronaut) => {
      console.log(
        `Astronaut: ${astronaut}, Oxygen: ${astronauts[astronaut].oxygen}, Energy: ${astronauts[astronaut].energy}`
      );
    });
  }
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
