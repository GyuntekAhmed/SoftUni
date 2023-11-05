// function passwordValidator(password) {

//     const errors = [];

//     if (password.length <= 6 || password.length >= 10) {
//         errors.push("Password must be between 6 and 10 characters");
//     }

//     if (!password.match("^[A-Za-z0-9]+$")) {
//         errors.push("Password must consist only of letters and digits");
//     }

//     const digitCount = password.match(/\d/g);

//     if (!digitCount || digitCount.length < 2) {
//         errors.push("Password must have at least 2 digits");
//     }

//     if (errors.length > 0) {
//         console.log(errors.join("\n"));
//         return;
//     }

//     console.log("Password is valid");
// }

// passwordValidator('logIn');
// passwordValidator('MyPass123');
// passwordValidator('Pa$s$s');

// function smallestOfThreeNumbers(num1, num2, num3) {
//     let result = [num1, num2, num3];

//     result.sort((a, b) => a-b);

//     console.log(result[0]);
// }

// smallestOfThreeNumbers(2, 5, 3);

// function rangeOfChars(ch1, ch2) {
//   const startCode = ch1.charCodeAt(0);
//   const endCode = ch2.charCodeAt(0);
//   let result = "";

//     for (let code = Math.min(startCode, endCode) + 1; code < Math.max(startCode, endCode); code++) {
//         const char = String.fromCharCode(code);
//         result += char + " ";
//     }

//   console.log(result);
// }

// rangeOfChars("C", "#");
// rangeOfChars("#", ":");

// function oddAndEvenSum(nums) {
//     let oddSum = 0;
//     let evenSum = 0;
//     let arr = nums.toString();

//     for (let i = 0; i < arr.length; i++) {
//         let num = Number(arr[i]);
//         if (num %2 == 0) {
//             evenSum += num;
//         }else{
//             oddSum += num;
//         }
//     }

//     console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
// }

// oddAndEvenSum(3495892137259234);


