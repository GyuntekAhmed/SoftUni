class Storage {
  constructor(capacity) {
    this.capacity = capacity;
    this.storage = [];
    this.totalCost = 0;
  }

  addProduct(product) {
    const[name, price, quantity] = product;
    const totalCostForProduct = price * quantity;

    if (this.capacity - quantity >= 0) {
        this.capacity -= quantity;
        this.storage.push({name, price, quantity});
        this.totalCost += totalCostForProduct;
    } else {
        console.log(`Cannot add ${quantity} ${name}(s) - insufficient capacity.`);
    }
  }

  getProducts() {
    return this.storage.map(product => JSON.stringify(product)).join('\n');
  }
}

let productOne = { name: "Cucamber", price: 1.5, quantity: 15 };
let productTwo = { name: "Tomato", price: 0.9, quantity: 25 };
let productThree = { name: "Bread", price: 1.1, quantity: 8 };
let storage = new Storage(50);
storage.addProduct(productOne);
storage.addProduct(productTwo);
storage.addProduct(productThree);
console.log(storage.getProducts());
console.log(storage.capacity);
console.log(storage.totalCost);
