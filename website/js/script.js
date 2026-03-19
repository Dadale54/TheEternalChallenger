// Image Modal for Gallery
const galleryImages = document.querySelectorAll('.gallery img');
const modal = document.createElement('div');
modal.classList.add('modal');
document.body.appendChild(modal);

modal.style.cssText = `
    display: none;
    position: fixed;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    z-index: 1000;
    background: rgba(0, 0, 0, 0.9);
    padding: 1rem;
    border-radius: 10px;
    border: 4px solid #ff4757;
    width: 95vw;
    max-width: 100vh;
    border-radius: 10px;
    transition: transform 0.3s, box-shadow 0.3s;
`;

galleryImages.forEach(image => {
    image.addEventListener('click', () => {
        modal.innerHTML = `<img src="${image.src}" style="width: 100%; border-radius: 8px;">`;
        modal.style.display = 'block';
    });
});

modal.addEventListener('click', () => {
    modal.style.display = 'none';
});

// Scroll-to-Top Button
const scrollTopBtn = document.createElement('button');
scrollTopBtn.textContent = '⬆️';
scrollTopBtn.classList.add('scroll-top');
document.body.appendChild(scrollTopBtn);

scrollTopBtn.style.cssText = `
    position: fixed;
    bottom: 20px;
    right: 20px;
    background: #ffa502;
    color: #fff;
    padding: 0.8rem;
    border: none;
    border-radius: 50%;
    font-size: 1.5rem;
    display: none;
    cursor: pointer;
`;

window.addEventListener('scroll', () => {
    if (window.scrollY > 300) {
        scrollTopBtn.style.display = 'block';
    } else {
        scrollTopBtn.style.display = 'none';
    }
});

scrollTopBtn.addEventListener('click', () => {
    window.scrollTo({ top: 0, behavior: 'smooth' });
});
