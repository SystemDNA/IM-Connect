// wwwroot/js/fancybox-init.js
window.initFancyBox = () => {
    $(document).ready(function () {
        $('[data-fancybox="gallery"]').fancybox({
            loop: true,
            buttons: ["zoom", "slideShow", "thumbs", "close"]
        });
    });
};
