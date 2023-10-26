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
