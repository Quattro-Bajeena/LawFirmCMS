// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var tabItems = document.querySelectorAll('.tab-item');

tabItems.forEach(function (item) {
    item.addEventListener('click', function () {
        tabItems.forEach(function (link) {
            link.classList.remove('active');
        });

        item.classList.add('active');
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const buttons = document.querySelectorAll("[id^='openPopupBtn_']");
    const closeButtons = document.querySelectorAll("[id^='closePopupBtn_']");
    const popups = document.querySelectorAll("[id^='popupContainer_']");

    buttons.forEach(button => {
        button.addEventListener("click", () => {
            const popupId = button.id.replace("openPopupBtn_", "popupContainer_");
            document.getElementById(popupId).style.display = "flex";
        });
    });

    closeButtons.forEach(closeButton => {
        closeButton.addEventListener("click", () => {
            const popupId = closeButton.id.replace("closePopupBtn_", "popupContainer_");
            document.getElementById(popupId).style.display = "none";
        });
    });

    popups.forEach(popup => {
        popup.addEventListener("click", (e) => {
            if (e.target === popup) {
                popup.style.display = "none";
            }
        });
    });
});
