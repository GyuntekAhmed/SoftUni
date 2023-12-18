function solve(input) {
    const baristas = [];
  
    const baristasCount = Number(input.shift());
    const lines = input.slice(0, baristasCount);
  
    for (let currentBarista = 1; currentBarista <= baristasCount; currentBarista++) {
      const [name, shift, ...types] = lines.shift().split(" ");
      const coffeeTypes = types.join(" ").split(",");
  
      baristas.push({
        name,
        shift,
        coffeeTypes,
      });
    }
  
    const commands = input.slice(baristasCount);
  
    const commandExecutor = {
      Prepare: prepare,
      'Change Shift': changeShift,
      Learn: learn,
      Closed: closed,
    };
    commands.forEach((command) => {
      const [commandName, ...rest] = command.split(" / ");
  
      commandExecutor[commandName](...rest);
    });
  
    function prepare(name, shift, type) {
      const currentBarista = baristas.find(b => b.name === name);
  
      if (currentBarista && currentBarista.shift === shift && currentBarista.coffeeTypes.includes(type)) {
          console.log(`${name} has prepared a ${type} for you!`);
      } else {
          console.log(`${name} is not available to prepare a ${type}.`);
      }
    }
  
    function changeShift(name, shift) {
      const currentBarista = baristas.find(b => b.name === name);
  
      if (currentBarista) {
        currentBarista.shift = shift;
        console.log(`${name} has updated his shift to: ${shift}`);
      }
      else {
        console.log(`${name} is not a barista.`);
      }
    }
  
    function learn(name, newCoffeeType) {
      const currentBarista = baristas.find(b => b.name === name);
  
      if (currentBarista) {
        if (currentBarista.coffeeTypes.includes(newCoffeeType)) {
          console.log(`${name} knows how to make ${newCoffeeType}.`);
        } else {
          currentBarista.coffeeTypes.push(newCoffeeType);
          console.log(`${name} has learned a new coffee type: ${newCoffeeType}.`);
        }
      }
      else {
        console.log(`${name} is not a barista.`);
      }
    }
  
    function closed() {
      baristas.forEach(barista => {
        const drinks = barista.coffeeTypes.join(", ");
        console.log(`Barista: ${barista.name}, Shift: ${barista.shift}, Drinks: ${drinks}`);
      })
    }
  }
  
  solve([
    "3",
    "Alice day Espresso,Cappuccino",
    "Bob night Latte,Mocha",
    "Carol day Americano,Mocha",
    "Prepare / Alice / day / Espresso",
    "Change Shift / Bob / night",
    "Learn / Carol / Latte",
    "Learn / Bob / Latte",
    "Prepare / Bob / night / Latte",
    "Closed",
  ]);
  