// function createEmployeeList(employeeNames) {
//     const employeeList = {};

//     for (const name of employeeNames) {
//         const trimmedName = name.trim(); // Remove leading and trailing whitespaces
//         const personalNum = trimmedName.length;

//         employeeList[trimmedName] = personalNum;
//     }

//     // Print the employee list
//     for (const name in employeeList) {
//         const personalNum = employeeList[name];
//         console.log(`Name: ${name} -- Personal Number: ${personalNum}`);
//     }
// }

// // Example usage:
// const employees = [
//     "Silas Butler",
//     "Adnaan Buckley",
//     "Juan Peterson",
//     "Brendan Villarreal",
//   ];
// createEmployeeList(employees);

// function parseTable(input) {
//     for (const row of input) {
//         const [town, latitude, longitude] = row.split(' | ').map(entry => entry.trim());
//         const parsedLatitude = parseFloat(latitude).toFixed(2);
//         const parsedLongitude = parseFloat(longitude).toFixed(2);

//         const obj = {
//             town: town,
//             latitude: parsedLatitude,
//             longitude: parsedLongitude
//         };

//         console.log(obj);
//     }
// }

// // Example usage:
// const inputTable = [
//     'Sofia | 42.696552 | 23.32601',
//     'Beijing | 39.913818 | 116.363625',
//     'New York | 40.730610 | -73.935242'
// ];

// parseTable(inputTable);

// function store(currentStock, deliveredStock) {
//   const products = [...currentStock, ...deliveredStock];

//   const stock = products.reduce((acc, curr, index) => {
//     if (index % 2 === 0) {
//         if (!acc.hasOwnProperty(curr)) {
//             acc[curr] = Number(products[index + 1]);
//         } else {
//             acc[curr] += Number(products[index + 1])
//         }
//     }

//     return acc;
//   }, {});

//   Object.keys(stock).forEach((key) => {
//     console.log(`${key} -> ${stock[key]}`);
//   })
// }

// store(
//   ["Chips", "5", "CocaCola", "9", "Bananas", "14", "Pasta", "4", "Beer", "2"],
//   ["Flour", "44", "Oil", "12", "Pasta", "7", "Tomatoes", "70", "Bananas", "30"]
// );

// function moviesList(input) {
//   let movies = [];

//   input.forEach((command) => {
//     if (command.includes("addMovie")) {
//       const [_, name] = command.split("addMovie ");
//       movies.push({ name });
//     } else if (command.includes("directedBy")) {
//       const [movieName, directorName] = command.split(" directedBy ");
//       const movie = movies.find((m) => m.name === movieName);

//       if (movie) {
//         movie.director = directorName;
//       }
//     } else if (command.includes(`onDate`)) {
//       const [movieName, date] = command.split(" onDate ");
//       const movie = movies.find((m) => m.name === movieName);

//       if (movie) {
//         movie.date = date;
//       }
//     }
//   });

//   movies
//     .filter((m) => m.name && m.director && m.date)
//     .forEach((m) => console.log(JSON.stringify(m)));
// }

// moviesList([
//   "addMovie Fast and Furious",
//   "addMovie Godfather",
//   "Inception directedBy Christopher Nolan",
//   "Godfather directedBy Francis Ford Coppola",
//   "Godfather onDate 29.07.2018",
//   "Fast and Furious onDate 30.07.2018",
//   "Batman onDate 01.08.2018",
//   "Fast and Furious directedBy Rob Cohen",
// ]);

// function findWords(input) {
//   const [searchWords, ...words] = input;

//   const wordOccurences = searchWords.split(" ").reduce((acc, curr) => {
//     acc[curr] = 0;
//     return acc;
//   }, {});

//   words.forEach((word) => {
//     if (wordOccurences.hasOwnProperty(word)) {
//       wordOccurences[word] += 1;
//     }
//   });

//   const sortedWords = Object.entries(wordOccurences);
//   sortedWords.sort((a, b) => b[1] - a[1]);

//   for (const [word, count] of sortedWords) {
//     console.log(`${word} - ${count}`);
//   }
// }

// findWords([
//   "this sentence",
//   "In",
//   "this",
//   "sentence",
//   "you",
//   "have",
//   "to",
//   "count",
//   "the",
//   "occurrences",
//   "of",
//   "the",
//   "words",
//   "this",
//   "and",
//   "sentence",
//   "because",
//   "this",
//   "is",
//   "your",
//   "task",
// ]);

// function registerCarPark(input) {
//   const parking = [];

//   input.forEach((entry) => {
//     const [command, number] = entry.split(", ");

//     if (command === "IN") {
//       parking.push(number);
//     } else if (command === "OUT") {
//       const index = parking.indexOf(number);
//       parking.splice(index, 1);
//     }
//   });

//   parking.sort();

//   if (parking.length != 0) {
//     parking.forEach((c) => {
//       console.log(c);
//     });
//   } else {
//     console.log("Parking Lot is Empty");
//   }
// }

// registerCarPark([
//   "IN, CA2844AA",
//   "IN, CA1234TA",
//   "OUT, CA2844AA",
//   "IN, CA9999TT",
//   "IN, CA2866HI",
//   "OUT, CA1234TA",
//   "IN, CA2844AA",
//   "OUT, CA2866HI",
//   "IN, CA9876HH",
//   "IN, CA2822UU",
// ]);
// registerCarPark([
//   "IN, CA2844AA",
//   "IN, CA1234TA",
//   "OUT, CA2844AA",
//   "OUT, CA1234TA",
// ]);

// function parser(input) {
//     const dictionary = input
//     .map(jsonStr => JSON.parse(jsonStr))
//     .reduce((acc, curr) => {
//         return {
//             ...acc,
//             ...curr,
//         }
//     }, {});

//     const sortedDictionary = Object.keys(dictionary).sort();

//     sortedDictionary.forEach((term) =>
//      console.log(`Term: ${term} => Definition: ${dictionary[term]}`));
// }

// parser([
//     '{"Cup":"A small bowl-shaped container for drinking from, typically having a handle"}',
//     '{"Cake":"An item of soft sweet food made from a mixture of flour, fat, eggs, sugar, and other ingredients, baked and sometimes iced or decorated."} ',
//     '{"Watermelon":"The large fruit of a plant of the gourd family, with smooth green skin, red pulp, and watery juice."} ',
//     '{"Music":"Vocal or instrumental sounds (or both) combined in such a way as to produce beauty of form, harmony, and expression of emotion."} ',
//     '{"Art":"The expression or application of human creative skill and imagination, typically in a visual form such as painting or sculpture, producing works to be appreciated primarily for their beauty or emotional power."} '
//     ]);

// class Vehicle {
//   constructor(type, model, parts, fuel) {
//     this.type = type;
//     this.model = model;
//     this.parts = {
//       engine: parts.engine,
//       power: parts.power,
//       quality: parts.engine * parts.power,
//     };
//     this.fuel = fuel;
//   }

//   drive(fuelLost) {
//     this.fuel -= fuelLost;
//   }
// }

// let parts = { engine: 6, power: 100 };
// let vehicle = new Vehicle("a", "b", parts, 200);
// vehicle.drive(100);
// console.log(vehicle.fuel);
// console.log(vehicle.parts.quality);

// function solve(input) {
//   const products = input.reduce((acc, curr) => {
//     const [key, value] = curr.split(" : ");
//     acc[key] = Number(value);

//     return acc;
//   }, {});

//   const sortedKeys = Object.keys(products).sort();

//   let letter = sortedKeys[0][0];
//   console.log(letter);
//   sortedKeys.forEach((key) => {
//     if (key[0] !== letter) {
//       letter = key[0];
//       console.log(letter);
//     }
//     console.log(`  ${key}: ${products[key]}`);
//   });
// }

// solve([
//   "Appricot : 20.4",
//   "Fridge : 1500",
//   "TV : 1499",
//   "Deodorant : 10",
//   "Boiler : 300",
//   "Apple : 1.25",
//   "Anti-Bug Spray : 15",
//   "T-Shirt : 10",
// ]);

// function inventory(input) {
//   let heroes = [];

//   for (const heroData of input) {
//     let [name, level, items] = heroData.split(" / ");

//     let hero = {
//       name,
//       level: Number(level),
//       items: items,
//     };

//     heroes.push(hero);
//   }

//   heroes.sort((a, b) => a.level - b.level);

//   for (const hero of heroes) {
//     console.log(`Hero: ${hero.name}`);
//     console.log(`level => ${hero.level}`);
//     console.log(`items => ${hero.items}`);
//   }
// }

// inventory([
//   "Isacc / 25 / Apple, GravityGun",
//   "Derek / 12 / BarrelVest, DestructionSword",
//   "Hes / 1 / Desolator, Sentinel, Antara",
// ]);

function oddOccurrences(input) {
  input = input.toLowerCase();

  let arrOfElements = input.split(" ");
  let map = new Map();

  arrOfElements.forEach((element) => {
    if (map.has(element)) {
      let oldValue = map.get(element);
      let newValue = oldValue + 1;

      map.set(element, newValue);
    } else {
      map.set(element, 1);
    }
  });

  let result = [];

  map.forEach((value, key) => {
    if (value % 2 !== 0) {
      result.push(key);
    }
  });
  console.log(result.join(" "));
}

oddOccurrences("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
