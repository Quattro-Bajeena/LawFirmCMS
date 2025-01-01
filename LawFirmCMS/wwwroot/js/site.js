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

const openPopupBtn = document.getElementById('openPopupBtn');
const popupContainer = document.getElementById('popupContainer');
const closePopupBtn = document.getElementById('closePopupBtn');

openPopupBtn.addEventListener('click', () => {
    popupContainer.style.display = 'flex';
});

closePopupBtn.addEventListener('click', () => {
    popupContainer.style.display = 'none';
});

popupContainer.addEventListener('click', (e) => {
    if (e.target === popupContainer) {
        popupContainer.style.display = 'none';
    }
});
