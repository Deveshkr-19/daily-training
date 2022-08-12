const reg_form_div = document.getElementById("reg-form");

const form = `
<form name="register-form" id="register-form">
    <div class="mb-3">
        <label for="exampleInputEmail1" class="form-label"
            >Full Name</label
        >
        <input
            type="text"
            class="form-control"
            id="exampleInputEmail1"
            name="fullname"
            required
        />
    </div>
    <div class="mb-3">
        <label for="exampleInputPassword1" class="form-label"
            >Email</label
        >
        <input
            type="email"
            class="form-control"
            id="exampleInputPassword1"
            name="email"
            required
        />
    </div>
    <div class="mb-3">
        <label for="exampleInputPassword1" class="form-label"
            >Mobile</label
        >
        <input
            type="tel"
            class="form-control"
            id="exampleInputPassword1"
            name="mobile"
            required
        />
    </div>
    <button type="submit" data-bs-toggle="modal" data-bs-target="#exampleModal" class="btn btn-outline-primary">
        Sign me up
    </button>
</form>`;

function disp_form() {
	reg_form_div.innerHTML = form;
	document.getElementById("register-form").addEventListener("submit", (e) => {
		e.preventDefault();
		document.getElementById(
			"modal-body"
		).innerHTML = `Congratulations ${e.target[0].value}, you have succesfully signed up!`;
	});
}
