// function personInfo(firstName, lastName, age) {
//   const person = {
//     firstName,
//     lastName,
//     age,
//   }

//   return person;
// }

// console.log("Peter", "Pan", "20");

// function printCityInfo(city) {
//   Object.entries(city).forEach(function ([key, value]) {
//     console.log(key + " -> " + value);
//   });
// }

// printCityInfo({
//   name: "Plovdiv",
//   area: 389,
//   population: 1162358,
//   country: "Bulgaria",
//   postCode: "4000",
// });

// function printJSONKeysAndValues(jsonString) {
//   const jsonObject = JSON.parse(jsonString);

//   for (const key in jsonObject) {
//     const value = jsonObject[key];
//     console.log(`${key}: ${value}`);
//   }
// }

// const jsonStr = '{"name": "George", "age": 40, "town": "Sofia"}';
// printJSONKeysAndValues(jsonStr);

// function convertToJson(name, lastName, hairColor) {
//     const person = {
//         name,
//         lastName,
//         hairColor,
//     };

//     console.log(JSON.stringify(person));
// }

// convertToJson('George', 'Jones', 'Brown');

// function createCity(name, population, treasury) {
//   return {
//     name,
//     population,
//     treasury,
//     taxRate: 10,
//     colletcTaxes() {
//         this.treasury += this.population * this.taxRate;
//     },
//     applyGrowth(percentage) {
//         this.population += this.population * percentage;
//     },
//     applyRecession(percentage) {
//         this.treasury -= this.treasury * percentage;
//     },
//   };
// }

// const city = createCity('Tortuga', 7000, 15000);
// city.colletcTaxes();
// console.log(city.treasury);
// city.applyGrowth(0.05);
// console.log(city.population);

// function collectPhones(arr) {
//   const phoneObj = arr.reduce((acc, current) => {
//     const [name, phone] = current.split(" ");
//     acc[name] = phone;

//     return acc;
//   }, {});

//   Object.entries(phoneObj).forEach(([key, value]) => {
//     console.log(`${key} -> ${value}`);
//   });
// }

// collectPhones(['Tim 0834212554',
// 'Peter 0877547887',
// 'Bill 0896543112',
// 'Tim 0876566344']);

// function schedule(input) {
//   const schedule = input.reduce((acc, current) => {
//     const [day, name] = current.split(" ");

//     if (acc.hasOwnProperty(day)) {
//       console.log(`Conflict on ${day}!`);
//     } else {
//       acc[day] = name;
//       console.log(`Scheduled for ${day}`);
//     }

//     return acc;
//   }, {});

//   Object.entries(schedule).forEach(([key, value]) => {
//     console.log(`${key} -> ${value}`);
//   });
// }

// schedule([
//   "Friday Bob",
//   "Saturday Ted",
//   "Monday Bill",
//   "Monday John",
//   "Wednesday George",
// ]);

// function storeAndPrintInfo(input) {
//   const addressBook = {};

//   // Process the input
//   for (const entry of input) {
//       const [name, address] = entry.split(':').map(part => part.trim());

//       // Store or replace the address for each person
//       addressBook[name] = address;
//   }

//   // Sort the names alphabetically
//   const sortedNames = Object.keys(addressBook).sort();

//   // Print the sorted list
//   for (const name of sortedNames) {
//       const address = addressBook[name];
//       console.log(`${name} -> ${address}`);
//   }
// }

// // Example usage:
// const inputArray = ['Tim:Doe Crossing',
// 'Bill:Nelson Place',
// 'Peter:Carlyle Ave',
// 'Bill:Ornery Rd'];

// storeAndPrintInfo(inputArray);


// function createCats(input) {

//   class Cat {
//     constructor(name, age){
//       this.name = name;
//       this.age = age;
//     }

//     meow() {
//       console.log(`${this.name}, age ${this.age} says Meow`);
//     }
//   }

//   input.forEach(line => {
//     const [name, age] = line.split(" ");
//     const cat = new Cat(name, age);
//     cat.meow();
//   });
// }

// createCats(['Candy 1', 'Poppy 3', 'Nyx 2']);

function songsList(input) {

  class Song{
    constructor(type, name, length) {
      this.type = type;
      this.name = name;
      this.length = length;
    }
  }

  const inputCopy = [...input];
  const typeToDisplay = inputCopy.pop();
  const [_, ...songs] = inputCopy;

  songs.map((songAsText) => {
    const [type, name, length] = songAsText.split("_");
    const song = new Song(type, name, length);

     if (type === typeToDisplay || typeToDisplay === 'all') {
      console.log(name);
    }
  })
}

songsList([2,
  'like_Replay_3:15',
  'ban_Photoshop_3:48',
  'all']);

  songsList([3,
    'favourite_DownTown_3:14',
    'favourite_Kiss_4:16',
    'favourite_Smooth Criminal_4:01',
    'favourite']);