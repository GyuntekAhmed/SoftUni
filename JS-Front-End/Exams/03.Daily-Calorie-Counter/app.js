const baseUrl = "http://localhost:3030/jsonstore/tasks/";

const loadMealsButton = document.getElementById("load-meals");
const taskList = document.getElementById("list");

const addMealButton = document.getElementById("add-meal");
addMealButton.addEventListener("click", addNewMeal);

let currentMealId = "";

const editMealButton = document.getElementById("edit-meal");
editMealButton.addEventListener("click", editMeal);

loadMealsButton.addEventListener("click", loadMeals);

const foodFieldInput = document.getElementById("food");
const timeFieldInput = document.getElementById("time");
const caloriesFieldInput = document.getElementById("calories");

async function loadMeals() {
  const response = await fetch(baseUrl);
  const mealData = await response.json();

  taskList.innerHTML = "";

  for (const meal of Object.values(mealData)) {
    const h2Element = document.createElement("h2");
    h2Element.textContent = meal.food;

    const h3DateElement = document.createElement("h3");
    h3DateElement.textContent = meal.time;

    const h3TempElement = document.createElement("h3");
    h3TempElement.textContent = meal.calories;

    const buttonsContainerDiv = document.createElement("div");
    buttonsContainerDiv.setAttribute('id', 'meal-buttons')
    // buttonsContainerDiv.className = "buttons-container";

    const changeBtn = document.createElement("button");
    changeBtn.className = "change-meal";
    changeBtn.textContent = "Change";

    changeBtn.addEventListener("click", async () => {
      foodFieldInput.value = meal.food;
      timeFieldInput.value = meal.time;
      caloriesFieldInput.value = meal.calories;
      currentMealId = meal._id;

      addMealButton.setAttribute("disabled", "disabled");
      editMealButton.removeAttribute("disabled");

      taskList.removeChild(mainContainerDiv);
    });

    const deleteBtn = document.createElement("button");
    deleteBtn.className = "delete-meal";
    deleteBtn.textContent = "Delete";

    deleteBtn.addEventListener("click", async () => {
      currentMealId = meal._id;

      await fetch(baseUrl + currentMealId, {
        method: "DELETE",
      });

      loadMeals();
    });

    buttonsContainerDiv.appendChild(changeBtn);
    buttonsContainerDiv.appendChild(deleteBtn);

    const mainContainerDiv = document.createElement("div");
    mainContainerDiv.className = "meal";

    mainContainerDiv.appendChild(h2Element);
    mainContainerDiv.appendChild(h3DateElement);
    mainContainerDiv.appendChild(h3TempElement);
    mainContainerDiv.appendChild(buttonsContainerDiv);

    taskList.appendChild(mainContainerDiv);
  }
}

async function addNewMeal() {
  const isInValid =
    foodFieldInput.value !== "" &&
    timeFieldInput.value !== "" &&
    caloriesFieldInput.value !== "";

  if (isInValid) {
    const newMealObj = {
      food: foodFieldInput.value,
      time: timeFieldInput.value,
      calories: caloriesFieldInput.value,
    };

    await fetch(baseUrl, {
      method: "POST",
      body: JSON.stringify(newMealObj),
    });

    foodFieldInput.value = "";
    timeFieldInput.value = "";
    caloriesFieldInput.value = "";

    loadMeals();
  }
}

async function editMeal() {
  const editedMealObj = {
    food: foodFieldInput.value,
    time: timeFieldInput.value,
    calories: caloriesFieldInput.value,
    _id: currentMealId,
  };

  await fetch(baseUrl + currentMealId, {
    method: "PUT",
    body: JSON.stringify(editedMealObj),
  });

  addMealButton.removeAttribute("disabled");
  editMealButton.setAttribute("disabled", "disabled");

  loadMeals();
}
