import { connection } from "/js/signalRConnection.js"

export default function addProduct(name, price, quantity) {
  const product = {
    id: Math.floor(Math.random() * 1000).toString(),
    name: name,
    price: price,
    quantity: quantity,
  }
  connection.invoke("AddProduct", product).catch(error => console.error(error))
}
