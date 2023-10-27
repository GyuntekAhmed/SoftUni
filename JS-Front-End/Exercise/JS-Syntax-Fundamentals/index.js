// function Ages(age) {
//   let result;

//   if (age >= 0 && age <= 2) {
//     result = "baby";
//   }
//   else if (age >= 3 && age <= 13) {
//     result = "child";
//   }
//   else if (age >= 14 && age <= 19) {
//     result = "teenager";
//   }
//   else if (age >= 20 && age <= 65) {
//     result = "adult";
//   }
//   else if (age >= 66) {
//     result = "elder";
//   }
//   else {
//     result = "out of bounds";
//   }

//   console.log(result);
// }

// Ages(20);


// function Vacation(countOfPeoples, typeOfGroup, day){

//     let price;
//     let sum;

//     if (typeOfGroup == "Students") {
//          if (day == "Friday") {
//             price = 8.45;
//         }
//          else if (day == "Saturday") {
//             price = 9.80;
//         }
//          else if (day == "Sunday") {
//             price = 10.46;
//         }
//     }
//     else if (typeOfGroup == "Business") {

//         if (countOfPeoples >= 100) {
//             countOfPeoples -= 10;
//         }

//         if (day == "Friday") {
//             price = 10.90;
//         }
//          else if (day == "Saturday") {
//             price = 15.60;
//         }
//          else if (day == "Sunday") {
//             price = 16;
//         }
//     }
//     else if (typeOfGroup == "Regular") {
//         if (day == "Friday") {
//             price = 15;
//         }
//          else if (day == "Saturday") {
//             price = 20;
//         }
//          else if (day == "Sunday") {
//             price = 22.50;
//         }
//     }

//     sum = countOfPeoples * price;

//     if (typeOfGroup == "Students" && countOfPeoples >= 30) {
//         sum *= 0.85;
//     }
    
//     if (typeOfGroup == "Regular") {
//         if (countOfPeoples >= 10 && countOfPeoples <= 20) {
//             sum *= 0.95
//         }
//     }

//     console.log(`Total price: ${sum.toFixed(2)}`);
// }

// Vacation(10, "Business", "Sunday");

// function isLeapYear(year) {
//     if ((year % 4 === 0 && year % 100 !== 0) || year % 400 === 0) {
//         console.log("yes");
//     } else {
//         console.log("no");
//     }
// }

//isLeapYear(2003);

// function print(num1, num2){
//     let sum = 0;
//     let output = "";

//     for (let i = num1; i <= num2; i++) {
//         if (i === num1) {
//             output += i;
//         } else {
//             output += " " + i;
//         }
//         sum += i;
//     }

//     console.log(output);
//     console.log(`Sum: ${sum}`)
// }

//print(0, 26);

// function multiTable(num){
//    for (let i = 1; i <= 10; i++) {
//        let sum = i * num;

//        console.log(`${num} X ${i} = ${sum}`);
//    }
// }

// multiTable(2);

// function sumOfDigits(numbers) {

//     let numStr = numbers.toString();
    
//     let sum = 0;
    
//     for (let i = 0; i < numStr.length; i++) {
//         sum += parseInt(numStr[i]);
//     }
    
//     console.log(sum);
// }

// sumOfDigits(543);

// function split(char1, char2, char3) {

//     let result = char3 + " " + char2 + " " + char1;
    
//     console.log(result);
// }

// split(`1`, `L`, `&`);

// function calc(fruit, grams, price) {
//     let kg = grams * 0.001;
//     let money = kg * price;
    
//     console.log(`I need $${money.toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${fruit}.`);
// }

// calc(`apple`, 1563, 2.35);

// function checkDigits(number) {
//     let numberStr = number.toString();
//     let firstDigit = numberStr[0];

//     let allSame = true;
//     let digitSum = 0;

//     for (let i = 0; i < numberStr.length; i++) {
//         digitSum += parseInt(numberStr[i]);

//         if (numberStr[i] !== firstDigit) {
//             allSame = false;
//         }
//     }

//     console.log(allSame);
    
//     console.log(digitSum);
// }

// checkDigits(1234);

function checkSpeed(speed, area) {
    const speedLimits = {
        'motorway': 130,
        'interstate': 90,
        'city': 50,
        'residential': 20,
    };

    const difference = speed - speedLimits[area];

    if (difference <= 0) {
        console.log(`Driving ${speed} km/h in a ${area} zone`);
    } else {
        let status = '';
        if (difference <= 20) {
            status = 'speeding';
        } else if (difference <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimits[area]} - ${status}`);
    }
}

// Example usage:
checkSpeed(40, 'city');
