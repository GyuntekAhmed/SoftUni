// function rotation(arr, number) {

//   for (let i = 0; i < number; i++) {
//     const firstElement = arr.shift();
//     arr.push(firstElement);
//   }

//   console.log(arr.join(' '));
// }

// rotation([51, 47, 32, 61, 21], 2);
// rotation([32, 21, 61, 1], 4);
// rotation([2, 4, 15, 31], 5);

// function solve(arr, step) {
//     let result = [];

//     for (let i = 0; i < arr.length; i += step) {
//         result.push(arr[i]);
//     }

//     console.log(result);
// }

// solve(['dsa',
// 'asd', 
// 'test', 
// 'tset'], 
// 2);

// function printSortedNames(names) {
//     names.sort();

//     for (let i = 0; i < names.length; i++) {
//         console.log(`${i + 1}. ${names[i]}`);
//     }
// }

// printSortedNames(["John", "Bob", "Christina", "Ema"]);

// function sortArrayAlternating(numbers) {
//     const sortedArray = numbers.sort((a, b) => a - b);
//     const result = [];

//     for (let i = 0, j = sortedArray.length - 1; i <= j; i++, j--) {
//         if (i === j) {
//             result.push(sortedArray[i]);
//         } else {
//             result.push(sortedArray[i], sortedArray[j]);
//         }
//     }

//     return result;
// }

// // Example usage:
// const numbersArray = [5, 2, 9, 1, 5, 6];
// const resultArray = sortArrayAlternating(numbersArray);

// console.log(resultArray); // This will print the sorted array with alternating elements
