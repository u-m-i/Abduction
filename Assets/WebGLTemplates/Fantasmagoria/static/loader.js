class IDevice
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
    symbolsUrl;
    companyName;
    productName;
    productVersion;

    // Default and unique value
    streamingAssetsUrl = "StreamingAssets";

    constructor(root)
    {

        let padded = root + "/";

        this.dataUrl = padded + this.getValue("data_filename");

        this.frameworkUrl = padded + this.getValue("framework_filename");

        this.codeUrl = padded + this.getValue("code_filename");

        this.companyName = padded + document.getElementById("company_name").getAttribute("author"); 

        this.productVersion = padded + this.getValue("product_version");

    }


    getValue(id)
    {
        return document.getElementById(id).getAttribute("keywords");
    }
}


/**
 *  Is called on the progress of the build load 
 * 
 * @param {Number} pertecentage of load progress 
 */
function onProgress( pertecentage )
{
    if(pertecentage == 1)
    {
        let container = document.getElementById("unity-container");

        container.style.animation = "fadeOut .45s forwards";

    }
}


/**
 * 
 * @returns Configuration dispatched
 */
function createConfiguration()
{

    const sourceRoot = "Build";

    return new Configuration(sourceRoot);

}


/**
 *  Instantiates the build on the selected canvas 
 */
function instantiateBuild()
{
    // Create the instance of with all the data 
    let config = createConfiguration();

    // Get the canvas object for the build 
    let canvas = document.querySelector("#unity-canvas");

    createUnityInstance(canvas, config, onProgress).then((instance) => 
    {

        instance.SetFullScreen(1);

    });
}


/**
 *  Prints the announce of not supported device 
 */
function notSupported()
{
    let announce = document.getElementById("mobile-announce");

    announce.textContent = "This experience do not support mobile devices";

    announce.style.display = "block";
}


/**
 * 
 * @returns The device adapted to the platform 
 */
function checkCompatibility()
{
    let device = new IDevice();

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

export {checkCompatibility, notSupported, instantiateBuild, createConfiguration, onProgress, IDevice, Configuration};