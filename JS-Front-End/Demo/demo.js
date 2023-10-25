// function student(name, age, grade){
//     console.log(`Name: ${name}, Age: ${age}, Grade: ${grade.toFixed(2)}`);
// }

// student("John", 15, 5.55);

// function solve(grade){
//     if(grade >= 5.50){
//         console.log("Excellent");
//     }
//     else{
//         console.log("Not excellent");
//     }
// }

// solve(4);

// function solve(month){
//     switch (month) {
//         case 1:
//             console.log("January")
//             break;
//             case 2:
//             console.log("February")
//             break;
//             case 3:
//             console.log("March")
//             break;
//             case 4:
//             console.log("April")
//             break;
//             case 5:
//             console.log("May")
//             break;
//             case 6:
//             console.log("June")
//             break;
//             case 7:
//             console.log("July")
//             break;
//             case 8:
//             console.log("August")
//             break;
//             case 9:
//             console.log("September")
//             break;
//             case 10:
//             console.log("October")
//             break;
//             case 11:
//             console.log("November")
//             break;
//             case 12:
//             console.log("December")
//             break;

//         default:
//             console.log("Error!");
//             break;
//     }
// }

// solve(10);

// function solve(num1, num2, operator) {
//   let result;

//   switch (operator) {
//     case "+":
//       result = num1 + num2;
//       break;
//     case "-":
//       result = num1 - num2;
//       break;
//     case "*":
//       result = num1 * num2;
//       break;
//     case "/":
//       result = num1 / num2;
//       break;
//     case "%":
//       result = num1 % num2;
//       break;
//     case "**":
//       result = num1 ** num2;
//       break;
//   }
//   console.log(result);
// }

// solve(6, 2, "**");

// function solve(num1, num2, num3){
//     let result =(Math.max(num1, num2, num3));

//     console.log(`The largest number is ${result}.`);
// }

// solve(3, 5, 10);

// function theatre(dayType, age) {
//   let result;

//   if (age >= -1000 && age <= 1000) {
//     if (age > 0 && age <= 18) {
//       if (dayType == "Weekday") {
//         result = 12;
//         console.log(`${result}$`);
//       } else if (dayType == "Weekend") {
//         result = 15;
//         console.log(`${result}$`);
//       } else if (dayType == "Holiday") {
//         result = 5;
//         console.log(`${result}$`);
//       }
//     } else if (age > 18 && age <= 64) {
//       if (dayType == "Weekday") {
//         result = 18;
//         console.log(`${result}$`);
//       } else if (dayType == "Weekend") {
//         result = 20;
//         console.log(`${result}$`);
//       } else if (dayType == "Holiday") {
//         result = 12;
//         console.log(`${result}$`);
//       }
//     } else if (age > 64 && age <= 122) {
//       if (dayType == "Weekday") {
//         result = 12;
//         console.log(`${result}$`);
//       } else if (dayType == "Weekend") {
//         result = 15;
//         console.log(`${result}$`);
//       } else if (dayType == "Holiday") {
//         result = 10;
//         console.log(`${result}$`);
//       }
//     } else {
//       console.log("Error!");
//     }
//   } else {
//     console.log("Error!");
//   }
// }

// theatre("Holiday", 12);

// function solve(input){
//     let inputType = typeof(input);

//     if (inputType === `number`) {
//         console.log((Math.pow(input, 2) * Math.PI).toFixed(2));
//     }
//     else{
//         console.log(`We can not calculate the circle area, because we receive a ${inputType}.`);
//     }
// }

//solve(5);

// function solve(m, n){
//     for (let index = m; index >= n; index--) {
//         console.log(index)
//     }
// }

// solve(4, 1);

function solve(){
    for (let i = 1; i <=5; i++) {
        console.log(i)
    }
}

solve();
