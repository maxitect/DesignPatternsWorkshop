import { connection } from "/js/signalRConnection.js"

export default function removeProduct(id, name, price, quantity) {
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
