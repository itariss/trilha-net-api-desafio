// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(() => {
	let statusList = document.querySelectorAll(".status");

	statusList.forEach(status => {
		let descricaoContainer = status.parentElement;

		if (status.innerHTML.includes("Finalizado")) {
			descricaoContainer.classList.add("line-through");
			descricaoContainer.classList.add("text-danger");

			("line-through");
		} else {
			descricaoContainer.classList.remove("line-through");
			descricaoContainer.classList.remove("line-through");
		}
	});
})();
