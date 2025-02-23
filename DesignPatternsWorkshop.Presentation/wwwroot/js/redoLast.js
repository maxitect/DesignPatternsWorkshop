import { connection } from "/js/signalRConnection.js"

export default function redoLast() {
  connection.invoke("Redo").catch(error => console.error(error))
}
