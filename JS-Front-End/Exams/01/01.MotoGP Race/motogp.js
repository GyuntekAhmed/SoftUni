function raceActions(input) {
    const lines = Number(input.shift());

    const riders = input.slice(0, lines);
    const actions = input.slice(lines);
    
  }
  
  
  
  raceActions(["3",
  "Valentino Rossi|100|1",
  "Marc Marquez|90|2",
  "Jorge Lorenzo|80|3",
  "StopForFuel - Valentino Rossi - 50 - 1",
  "Overtaking - Marc Marquez - Jorge Lorenzo",
  "EngineFail - Marc Marquez - 10",
  "Finish"]);
  