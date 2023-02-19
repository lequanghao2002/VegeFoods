const menus = document.querySelectorAll('.menu-item');

menus.forEach((menu) => {
    menu.onclick = function () {
        document.querySelector('.menu-item.active').classList.remove('active');

        menu.classList.add('active');
    }
})