const connection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5130/purchase-hub")
  .withAutomaticReconnect()
  .build()

connection.start().catch(error => console.error(error))

function addProduct(name, price, quantity) {
  const product = {
    id: Math.floor(Math.random() * 1000).toString(),
    name: name,
    price: price,
    quantity: quantity,
  }
  connection.invoke("AddProduct", product).catch(error => console.error(error))
}

connection.on("UpdatePurchase", function () {
  fetch("Home/GetProductList")
    .then(response => response.text())
    .then(
      html => (document.getElementById("purchaseContainer").innerHTML = html)
    )
    .catch(error => console.error(error))

  fetch("Home/GetTotal")
    .then(response => response.text())
    .then(
      html => (document.getElementById("purchaseTotalDisplay").innerHTML = html)
    )
    .catch(error => console.error(error))
})

function removeProduct(id, name, price, quantity) {
  const product = {
    id,
    name,
    price,
    quantity,
  }

  connection
    .invoke("RemoveProduct", product)
    .catch(error => console.error(error))
}

function undoLast() {
  connection.invoke("Undo").catch(error => console.error(error))
}

function redoLast() {
  connection.invoke("Redo").catch(error => console.error(error))
}
