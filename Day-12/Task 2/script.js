// XML HTTP Request

// var request = new XMLHttpRequest();
// request.open("GET", "https://jsonplaceholder.typicode.com/todos");
// request.send();
// request.onload = () => {
// 	console.log(JSON.parse(request.response));
// };

// jQuery Ajax

// $(document).ready(function () {
// 	$.ajax({
// 		url: "https://jsonplaceholder.typicode.com/todos",
// 		type: "GET",
// 		success: function (result) {
// 			console.log(result);
// 		},
// 	});
// });

// fetch

// fetch("https://jsonplaceholder.typicode.com/todos")
// 	.then((response) => {
// 		return response.json();
// 	})
// 	.then((data) => {
// 		console.log(data);
// 	});

// Axios

axios.get("https://jsonplaceholder.typicode.com/todos").then((response) => {
	console.log(response.data);
});
