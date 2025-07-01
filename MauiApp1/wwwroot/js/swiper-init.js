//function initSwiper() {
//    new Swiper(".col-1-swiper", {
//        loop: true,
//        //slidesPerView: 2,
//        //spaceBetween: 10,
//        navigation: true,
//        //pagination: {
//        //    el: ".swiper-pagination",
//        //},
//        //navigation: {
//        //    nextEl: ".swiper-button-next",
//        //    prevEl: ".swiper-button-prev",
//        //},
//    });
//}
function initSwiper() {
    new Swiper('.col-1-swiper', {
        loop: false,
        spaceBetween: 10, // Adjust based on preference
        //slidesPerView: 'auto',
        slidesPerView: 1.1,
        centeredSlides: false,
        autoplay: {
            delay: 3000,
            disableOnInteraction: false,
        },
        pagination: {
            el: ".swiper-pagination",
        },
    });
    new Swiper('.col-3-swiper', {
        loop: false,
        spaceBetween: 10, // Adjust based on preference
        slidesPerView: 3.3,
        centeredSlides: false,
    });
}
