import {checkCompatibility}  from "./loader.js" 

let wasm = document.getElementById("wasm").getAttribute("keywords");

let script = document.createElement("script");

script.src = `Build/${wasm}`;

function buildDone(instance)
{
    instance.SetFullScreen(1);
}

script.onload = () => 
{
    checkCompatibility().Answer();
}

document.body.appendChild(script);