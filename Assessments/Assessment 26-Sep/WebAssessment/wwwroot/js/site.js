// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const buyBtns = document.getElementsByClassName("buy-btn");
const contactBtn = document.getElementsByClassName("contact-btn")[0];
const inpFields = document.getElementsByClassName("inp-fields");

for (const buyBtn of buyBtns) {
    buyBtn.addEventListener("click", (e) => {
        e.preventDefault();
        alert("Item added to the cart successfully!");
    })
}

contactBtn.addEventListener("click", (e) => {
    console.log(inpFields);
    e.preventDefault();
    alert("Thank you your response has been submitted.");
    for (let inpField of inpFields)
        inpField.value = "";
    
});