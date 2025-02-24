import { connection } from "/js/signalRConnection.js"

export default function undoLast() {
  connection.invoke("Undo").catch(error => console.error(error))
}
