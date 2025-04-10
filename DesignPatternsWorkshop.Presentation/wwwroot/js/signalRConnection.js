import addProduct from "/js/addProduct.js";
import removeProduct from "/js/removeProduct.js";
import undoLast from "/js/undoLast.js";
import redoLast from "/js/redoLast.js";
import addDiscount from "/js/addDiscount.js";

export const connection = new signalR.HubConnectionBuilder()
  .withUrl("http://localhost:5130/purchase-hub")
  .withAutomaticReconnect()
  .build();

connection.start().catch((error) => console.error(error));

connection.on("UpdatePurchase", function () {
  fetch("Home/GetProductList")
    .then((response) => response.text())
    .then(
      (html) => (document.getElementById("purchaseContainer").innerHTML = html)
    )
    .catch((error) => console.error(error));

  fetch("Home/GetTotal")
    .then((response) => response.text())
    .then(
      (html) =>
        (document.getElementById("purchaseTotalDisplay").innerHTML = html)
    )
    .catch((error) => console.error(error));
});

window.addProduct = addProduct;
window.removeProduct = removeProduct;
window.undoLast = undoLast;
window.redoLast = redoLast;
window.addDiscount = addDiscount;

window.addEventListener("keydown", function (event) {
  if (event.ctrlKey && event.key === "z") {
    event.preventDefault();
    return undoLast;
  }
  if (event.ctrlKey && event.key === "y") {
    event.preventDefault();
    return redoLast;
  }
});
