const filterItem = document.querySelector(".items");
const filterImg = document.querySelectorAll(".image");

filterItem.onclick = (selectedItem) => {
	// console.log("Hello");
	// console.log(selectedItem.target.innerText);

	// console.log(filterItem.querySelector(".active"));

	filterItem.querySelector(".active").classList.remove("active");
	selectedItem.target.classList.add("active");
	let filterName = selectedItem.target.getAttribute("data-name");

	// console.log(filterName);
	filterImg.forEach((image) => {
		// console.log(image);
		let filterImages = image.getAttribute("data-name");
		// console.log(filterImages);
		if (filterImages == filterName || filterName == "all") {
			image.classList.add("show");
			image.classList.remove("hide");
		} else {
			image.classList.add("hide");
			image.classList.remove("show");
		}
	});
};

filterImg.forEach((image) => {
	image.setAttribute("onclick", "preview(this)");
});
const previewBox = document.querySelector(".preview-box"),
	category = previewBox.querySelector(".category"),
	previewImg = previewBox.querySelector(".preview-img"),
	closeIcon = previewBox.querySelector(".icon"),
	shadow = document.querySelector(".shadow");

function preview(el) {
	// console.log(previewBox);
	const selectedImg = el.querySelector("img");
	previewImg.src = selectedImg.src;
	previewImg.alt = selectedImg.alt;
	category.textContent = el.getAttribute("data-name");
	previewBox.classList.add("show");
	shadow.classList.add("show");
	closeIcon.onclick = () => {
		previewBox.classList.remove("show");
		shadow.classList.remove("show");
	};
}
