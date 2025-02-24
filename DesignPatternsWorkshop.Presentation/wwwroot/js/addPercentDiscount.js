import { connection } from "/js/signalRConnection.js"

export default function addPercentDiscount(discountType) {
  switch (discountType) {
    case "percentile":
      connection.invoke("AddDiscount")
      break
    default:
      break
  }
}
