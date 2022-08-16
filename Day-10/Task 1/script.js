console.log("Hey there");

let numArr = [6, 1, 9, 7, 21, 13, 27, 8];

let stringArr = [
	"Devesh",
	"Atul",
	"Shobhit",
	"Naveen",
	"Harshit",
	"Rahul",
	"Vinay",
	"Abhay",
];

// Using copyWithin()
console.log(
	"Copying and appending the first 2 elements of num array to the array itself: numArr = ",
	numArr.copyWithin(2)
);

// filtering the records in the array
console.log(
	"Filtering all the elements greater than 10 from an array: ",
	numArr.filter((value) => value >= 10)
);

//Using find()
console.log(
	"Finding the fisrt occurence of a particular record from an array using find method: ",
	stringArr.find((el) => el.length > 5)
);

// Using findIndex()
console.log(
	"Finding the index of first occuring element from an array: ",
	numArr.findIndex((el) => el > 5)
);

//forEach using callback function
stringArr.forEach(function (name) {
	console.log("Hi There! " + name);
});

// sort method
console.log("sorted array: ", numArr.sort());

// Greet user using an Anonymous function
let greetUser = function () {
	console.log("WELCOME TO THIS TRAINING BOOTCAMP!!");
};

greetUser();

// Using setTimeout() with anonymous function
setTimeout(function () {
	console.log("This will trigger just after 5 seconds");
}, 5000);
