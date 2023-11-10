let slider = document.getElementById('slider');
let sliderList = slider.querySelector('ul');
let images = slider.querySelectorAll('li');
let imageWidth = images[0].offsetWidth;
let currentIndex = 0;
let isPaused = false;

function moveSlider(index) {
    sliderList.style.transform = `translateX(-${index * imageWidth}px)`;
}

function nextSlide() {
    currentIndex = (currentIndex + 1) % images.length;
    moveSlider(currentIndex);
}

function prevSlide() {
    currentIndex = (currentIndex - 1 + images.length) % images.length;
    moveSlider(currentIndex);
}

let autoSlide = setInterval(nextSlide, 3000);

slider.addEventListener('mouseenter', () => {
    clearInterval(autoSlide);
    isPaused = true;
});

slider.addEventListener('mouseleave', () => {
    if (isPaused) {
        autoSlide = setInterval(nextSlide, 3000);
        isPaused = false;
    }
});

document.querySelector('.left-arrow').addEventListener('click', () => {
    prevSlide();
});

document.querySelector('.right-arrow').addEventListener('click', () => {
    nextSlide();
});