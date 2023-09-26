/**
 * 
 * @param {*} pertecentage 
 */
function onProgress( pertecentage )
{
    if(pertecentage == 1)
    {

    }
}

/**
 * 
 */
function instantiateBuild()
{
    // Create the instance of config with all the data 
    let config = createConfiguration();

    // Get the canvas object for the build 
    let canvas = document.querySelector("#build-canvas");

    createUnityInstance(canvas, config, onProgess);
}

/**
 * 
 * @returns The compatibility of the device 
 */
function checkCompatibility()
{
    if(/iPhone|iPad|iPod|Android/i.test(navigator.userAgent))
    {
        let announce = document.querySelector("#mobile-announce");

        announce.textContent = "This experience do not support mobile devices";

        return false;
    }

    return true;
}


let config 
{
    dataUrl,
    frameworkUrl,
    codeUrl,
    memoryUrl,
    symbolsUrl,
    streamingAssetsUrl,
    companyName,
    productName,
    productVersion
};

const root = "Build";

let asm = root + "";

let loader = document.createElement("script");
loader.src = asm;

loader.onload(instantiateBuild).then((instance) => 
{

    buildInstance = instance;

}).catch((err) => 
{
    console.log(err);
    console.log("this device does not support this experience");
});
