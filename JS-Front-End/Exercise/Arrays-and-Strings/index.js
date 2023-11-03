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
//     names.sort((a,b) =>{
//         return a.localeCompare(b);
//     });

//     let index = 1;

//     for (const name of names) {
//         console.log(`${index}.${name}`);
//         index++;
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

// function arrayString(words, text) {
//     let wordsArr = words.split(', ');
//     let textArr = text.split(' ');

//     for (let i = 0; i < wordsArr.length; i++) {
        
//         for (let j = 0; j < textArr.length; j++) {
            
//             if (textArr[j].includes('*') && textArr[j].length === wordsArr[i].length) {
//                 textArr[j] = wordsArr[i];
//             }
//         }
//     }

//     console.log(textArr.join(' '));
// }

// arrayString('great',
// 'softuni is ***** place for learning new programming languages');

// function hashTag(text) {
//     let regex = /#[A-Za-z]+/gm;

//     let matches = text.match(regex);

//     for (let word of matches) {
//         word = word.replace('#','');
//         console.log(word);
//     }
// }

// hashTag('Nowadays everyone uses # to tag a #special word in #socialMedia');

// function substring(word, text) {
    
//     let wordsArr = text.toLowerCase().split(' ');

//     let output = `${word} not found!`;

//     for (let i = 0; i < wordsArr.length; i++) {
//         let currentWord = wordsArr[i];

//         if (currentWord === word) {
//             output = currentWord;
//         }
//     }

//     console.log(output);
// }

// substring('javascript',
// 'JavaScript is the best programming language');
// substring('python',
// 'JavaScript is the best programming language');

function spliter(text) {
    let regex = /[A-Z][a-z]*/g;
    let wordsArr = text.match(regex);
    let result = wordsArr.join(', ');

    console.log(result);
}

spliter('SplitMeIfYouCanHaHaYouCantOrYouCan');