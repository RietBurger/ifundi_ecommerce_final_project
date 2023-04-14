// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function increaseCount(a, b, max) {
    var input = b.previousElementSibling;
    var value = parseInt(input.value, 10);
    
    if (value < max){
      value = isNaN(value) ? 0 : value;
      value++;
    }
    input.value = value;
  }
  
  function decreaseCount(a, b) {
    var input = b.nextElementSibling;
    var value = parseInt(input.value, 10);
    if (value > 1) {
      value = isNaN(value) ? 0 : value;
      value--;
      input.value = value;
    }
  }