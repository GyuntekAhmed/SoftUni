// function createEmployeeList(employeeNames) {
//     const employeeList = {};

//     for (const name of employeeNames) {
//         const trimmedName = name.trim(); // Remove leading and trailing whitespaces
//         const personalNum = trimmedName.length;

//         employeeList[trimmedName] = personalNum;
//     }

//     // Print the employee list
//     for (const name in employeeList) {
//         const personalNum = employeeList[name];
//         console.log(`Name: ${name} -- Personal Number: ${personalNum}`);
//     }
// }

// // Example usage:
// const employees = [
//     "Silas Butler",
//     "Adnaan Buckley",
//     "Juan Peterson",
//     "Brendan Villarreal",
//   ];
// createEmployeeList(employees);


function parseTable(input) {
    for (const row of input) {
        const [town, latitude, longitude] = row.split(' | ').map(entry => entry.trim());
        const parsedLatitude = parseFloat(latitude).toFixed(2);
        const parsedLongitude = parseFloat(longitude).toFixed(2);

        const obj = {
            town: town,
            latitude: parsedLatitude,
            longitude: parsedLongitude
        };

        console.log(obj);
    }
}

// Example usage:
const inputTable = [
    'Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625',
    'New York | 40.730610 | -73.935242'
];

parseTable(inputTable);
