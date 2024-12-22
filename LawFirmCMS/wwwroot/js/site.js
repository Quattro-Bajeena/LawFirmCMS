// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var tabItems = document.querySelectorAll('.tab-item');

// Dodajemy nasłuchiwacz zdarzeń na każdy element
tabItems.forEach(function (item) {
    item.addEventListener('click', function () {
        // Usuwamy klasę 'active' ze wszystkich elementów
        tabItems.forEach(function (link) {
            link.classList.remove('active');
        });

        // Dodajemy klasę 'active' do klikniętego elementu
        item.classList.add('active');
    });
});