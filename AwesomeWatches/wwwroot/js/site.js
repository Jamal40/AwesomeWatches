// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.sidenav').sidenav();
});

//
const categoriesCheckboxes =
    document.querySelectorAll(".categories-container input");

const selectedCategories = new Map();

for (let i = 0; i < categoriesCheckboxes.length; i++) {
    categoriesCheckboxes[i].addEventListener("change", (e) => {
        const boxValue = e.target.value;
        if (e.target.checked) {
            selectedCategories.set(boxValue, boxValue);
        }

        if (!e.target.checked) {
            selectedCategories.delete(boxValue);
        }
    })
}
