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

function createCity(name, population, treasury) {
  return {
    name,
    population,
    treasury,
    taxRate: 10,
    colletcTaxes() {
        this.treasury += this.population * this.taxRate;
    },
    applyGrowth(percentage) {
        this.population += this.population * percentage;
    },
    applyRecession(percentage) {
        this.treasury -= this.treasury * percentage;
    },
  };
}

const city = createCity('Tortuga', 7000, 15000);
city.colletcTaxes();
console.log(city.treasury);
city.applyGrowth(0.05);
console.log(city.population);
