import { connection } from "/js/signalRConnection.js"

export default function addDiscount(discountType, value) {
      connection.invoke("AddDiscount", discountType, value)
}
