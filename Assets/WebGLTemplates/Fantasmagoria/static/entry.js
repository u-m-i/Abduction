import "loader.js"

const source = "Build";

let script = document.createElement("script");
script.src = loaderUrl;

script.onload = () => 
{
    let device = checkCompatibility();

    device.Answer();
}



