// function firstAndLastInd(input) {
//     let first = input[0];
//     let last = input[input.length - 1];

//     console.log(first + last);
// }

// firstAndLastInd([10, 17, 22, 33]);

// function reverse(n, inputArray) {
//     let arr = [];

//     for (let i = 0; i < n; i++) {
//         arr.push(inputArray[i]);
//     }

//     let output = "";

//     for(i = arr.length - 1; i >= 0; i--){
//         output += arr[i] + " ";
//     }

//     console.log(output);
// }

// reverse(4, [-1, 20, 99, 5]);

// function solve(arr) {
//   let evenSum = 0;
//   let oddSum = 0;

//   for (let i = 0; i < arr.length; i++) {
//     arr[i] = Number(arr[i]);

//     if (arr[i] % 2 == 0) {
//       evenSum += arr[i];
//     } else {
//       oddSum += arr[i];
//     }
//   }

//   console.log(evenSum - oddSum);
// }

// solve([2,4,6,8,10]);

// function solve(str, startIndex, count) {

//     let rezult = str.substring(startIndex, count + 1);

//     console.log(rezult);
// }

// solve('SkipWord', 4, 7);

// function solve(text, word) {
//   const regex = new RegExp(word, "g");

//   const result = text.replace(regex, (match) => "*".repeat(match.length));

//   console.log(result);
// }

// solve("A small sentence with some words", "small");
// solve('Find the hidden word', 'hidden');

function countOccurrences(text, searchedWord) {
  let words = text.split(' ');
  let counter = 0;

  for(let word of words){
    if (word === searchedWord) {
        counter++;
    }
  }

  console.log(counter);
}

countOccurrences("This is a word and it also is a sentence", "is");
countOccurrences(
  "softuni is great place for learning new programming languages",
  "softuni"
);
