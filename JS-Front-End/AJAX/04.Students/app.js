const baseURL = "http://localhost:3030/jsonstore/collections/students";

async function attachEvents() {
  loadAllStudent();

  document
    .getElementById("submit")
    .addEventListener("click", submitStudentForm);
}
async function loadAllStudent() {
  const tableBody = document.querySelector("tbody");

  const response = await fetch(baseURL);

  const students = await response.json();

  Object.values(students).forEach((student) => {
    const row = document.createElement("tr");

    const firstName = document.createElement("td");
    firstName.textContent = student.firstName;
    row.appendChild(firstName);

    const lastName = document.createElement("td");
    lastName.textContent = student.lastName;
    row.appendChild(lastName);

    const facultyNumber = document.createElement("td");
    facultyNumber.textContent = student.facultyNumber;
    row.appendChild(facultyNumber);

    const grade = document.createElement("td");
    grade.textContent = student.grade;
    row.appendChild(grade);

    tableBody.appendChild(row);
  });
}

async function submitStudentForm() {

  const [firstNameInput, lastNameInput, facultyNumberInput, gradeInput] =
    document.querySelectorAll("#form input");

  const firstName = firstNameInput.value;
  const lastName = lastNameInput.value;
  const facultyNumber = facultyNumberInput.value;
  const grade = gradeInput.value;

  const isValidForm =
    firstName !== "" && lastName !== "" && facultyNumber !== "" && grade !== "";

  const studentInfo = {
    firstName,
    lastName,
    facultyNumber,
    grade,
  };

  if (isValidForm) {
    await fetch(baseURL, {
      method: "POST",
      body: JSON.stringify(studentInfo),
    });

    loadAllStudent();

    firstNameInput.value = '';
    lastNameInput.value = '';
    facultyNumberInput.value = '';
    gradeInput.value = '';
  
  }
}

attachEvents();
