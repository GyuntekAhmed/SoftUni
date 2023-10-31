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

function printSortedNames(names) {
    names.sort();

    for (let i = 0; i < names.length; i++) {
        console.log(`${i + 1}. ${names[i]}`);
    }
}

printSortedNames(["John", "Bob", "Christina", "Ema"]);