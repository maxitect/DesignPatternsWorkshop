const connection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5130/purchase-hub")
  .withAutomaticReconnect()
  .build()

connection.start().catch(error => console.error(error.toString()))

function addProduct(name, price, quantity) {
  const product = {
    id: Math.floor(Math.random() * 1000).toString(),
    name: name,
    price: price,
    quantity: quantity,
  }
  connection
    .invoke("AddProduct", product)
    .catch(error => console.error(error.toString()))
}

connection.on("UpdatePurchase", function (updatedPurchase) {
  const productList = document.getElementById("productList")
  productList.innerHTML = ""

  updatedPurchase.products.forEach(p => {
    const li = document.createElement("li")
    li.innerHTML = `<b>${p.name}</b> - £${p.price}`
    productList.appendChild(li)
  })
})

function undoLast() {
  connection.invoke("Undo").catch(error => console.error(error.toString()))
}

function redoLast() {
  connection.invoke("Redo").catch(error => console.error(error.toString()))
}
