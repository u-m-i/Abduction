class Device
{
    /**
     *  Empty method, that lately is fill with the aproppiate response for
     *  the device capabilities support. 
     */
    Answer()
    { }
}

class Configuration
{
    /**Properties */

    dataUrl;
    frameworkUrl
    codeUrl;
    memoryUrl;
    symbolsUrl;
    streamingAssetsUrl;
    companyName;
    productName;
    productVersion;

}


/**
 *Is called on the progress of the build load 
 * 
 * @param {Number} pertecentage of load progress 
 */
function onProgress( pertecentage )
{
    if(pertecentage == 1)
    {

        let container = document.getElementById("container");

        container.style.animation = "fadeOut .45s forwards";

    }
}


function createConfiguration()
{

    let config = new Configuration();

    config.codeUrl = source + document.querySelector("file_name");

    config.dataUrl = 

}


/**
 * 
 */
function instantiateBuild()
{
    // Create the instance of with all the data 
    let config = createConfiguration();

    // Get the canvas object for the build 
    let canvas = document.querySelector("#build-canvas");

    return createUnityInstance(canvas, config, onProgess);
}


/**
 * Prints the announce of not supported device 
 */
function notSupported()
{
        let announce = document.querySelector("#mobile-announce");

        announce.textContent = "This experience do not support mobile devices";
}



/**
 * 
 * @returns The device adapted to the platform 
 */
function checkCompatibility()
{
    let device = new Device();

    if(/iPhone|iPad|iPod|Android/i.test(navigator.userAgent))
    {
        device.Answer = notSupported; 
    }
    else
    {
        device.Answer = instantiateBuild;
    }

    return device;
}
