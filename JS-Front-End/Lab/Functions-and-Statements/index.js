// function formatGrade(grade) {
//   if (grade < 3) {
//     console.log("Fail (2)");
//   } else if(grade < 3.5){
//     console.log(`Poor (${grade.toFixed(2)})`);
//   }else if (grade < 4.5) {
//     console.log(`Good (${grade.toFixed(2)})`);
//   }else if (grade < 5.5) {
//     console.log(`Very good (${grade.toFixed(2)})`);
//   }else if (grade) {
//     console.log(`Excellent (${grade.toFixed(2)})`);
//   }
// }

// formatGrade(4.50);

// function mathPower(number, power) {
//     console.log(Math.pow(number, power));
// }

// mathPower(3, 4);

// function repeatString(text, count) {
//     let result = "";

//     for (let i = 0; i < count; i++) {
//         result += text;
//     }

//     return result;
// }

// repeatString("abc", 3);

// function orders(product, quantity) {
//     let price = 0;

//     if (product === "coffee") {
//         price = 1.50;
//     }else if (product === "coke") {
//         price = 1.40;
//     }else if (product === "water") {
//         price = 1.00;
//     }else if (product === "snacks") {
//         price = 2.00;
//     }

//     let result = quantity * price;

//     console.log(result.toFixed(2));
// }

// orders("water", 5);
// orders("coffee", 2);

// const calculator = {
//     multiply: (x, y) => x * y,
//     divide: (x, y) => x / y,
//     sum: (x, y) => x + y,
//     subtract: (x, y) => x - y,
// };

// const calculate = (num1, num2, operator) =>
//  calculator[operator] ? calculator[operator](num1, num2) : 0;

// const result = calculate(5, 5, 'multiply');
// console.log(result);

function solve(num1, num2, num3) {
    let result = num1 * num2 * num3;

    if (result > 0) {
        console.log("Positive");
    }else{
        console.log("Negative");
    }
}

solve(-6, -12, 14);