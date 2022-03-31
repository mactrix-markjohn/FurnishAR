using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

using Niantic.ARDK.AR;
using Niantic.ARDK.AR.Anchors;
using Niantic.ARDK.AR.ARSessionEventArgs;
using Niantic.ARDK.AR.Configuration;
using Niantic.ARDK.AR.HitTest;
using Niantic.ARDK.External;
using Niantic.ARDK.Utilities;
using Niantic.ARDK.Utilities.Logging;
using Niantic.ARDKExamples.Helpers;
using UnityEditor;
using UnityEngine.SceneManagement;


public class ARSceneScript : MonoBehaviour
{
    public Button backButton, addModelButtton, minusModelButton,addCartButton,screenShotButton;
    private HomesItemsStorage ItemsStorage;
    public GameObject redArmchair, blacksofa, virtualobjectHolder, seriesOfButtons, screenshotholder, placementInstruction, planeindicator,
        netchair, yellowarmchair,whitechair,rockinchair, woodenchair;


    #region ARPPlaceObject
    
    public Camera Camera;

    /// The types of hit test results to filter against when performing a hit test.
    [EnumFlagAttribute]
    public ARHitTestResultType HitTestType = ARHitTestResultType.ExistingPlane;
    GameObject PlacementObjectPf;
    private List<GameObject> _placedObjects = new List<GameObject>();
    private IARSession _session;

    #endregion
    
    // a boolean variable to ensure to deactivate spawning another once one is spawned
    private bool isSpawned = false;
    
    
   
    
    // Start is called before the first frame update
    void Start()
    {
        
        ARSessionFactory.SessionInitialized += OnAnyARSessionDidInitialize;
        ItemsStorage = ProductScript.ItemsStorage;
        HandleClick();

        // At the start make seriesbutton holder and screenshotholder to be invisible
        seriesOfButtons.SetActive(false);
        screenshotholder.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_session == null)
        {
            return;
        }

        if (PlatformAgnosticInput.touchCount <= 0)
        {
            return;
        }

        var touch = PlatformAgnosticInput.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            if (!isSpawned)
            {
                TouchBegan(touch);
            }

            
        }
    }

    private void TouchBegan(Touch touch)
    {
        var currentFrame = _session.CurrentFrame;
        if (currentFrame == null)
        {
            return;
        }

        var results = currentFrame.HitTest
        (
            Camera.pixelWidth,
            Camera.pixelHeight,
            touch.position,
            HitTestType
        );

        int count = results.Count;
        Debug.Log("Hit test results: " + count);

        if (count <= 0)
            return;

        // Get the closest result
        var result = results[0];

        var hitPosition = result.WorldTransform.ToPosition();

        
        // check if the product selected is equal to the list and then assign the proper prefab to it
        if (ItemsStorage.Name.ToLower().Equals(ConstantStringStore.BlackSofa.ToLower()))
        {
            PlacementObjectPf = blacksofa;

        }else if (ItemsStorage.Name.ToLower().Equals(ConstantStringStore.RedLeatherChair.ToLower()))
        {
            PlacementObjectPf = redArmchair;
        }else if (ItemsStorage.Name.ToLower().Equals(ConstantStringStore.WhiteChair.ToLower()))
        {

            PlacementObjectPf = whitechair;

        }else if (ItemsStorage.Name.ToLower().Equals(ConstantStringStore.NetChair.ToLower()))
        {
        
            PlacementObjectPf = netchair;
            
        }else if (ItemsStorage.Name.ToLower().Equals(ConstantStringStore.WoodenChair.ToLower()))
        {
            PlacementObjectPf = woodenchair;
            
        }else if (ItemsStorage.Name.ToLower().Equals(ConstantStringStore.RockinChair.ToLower()))
        {
            PlacementObjectPf = rockinchair;
        }else if (ItemsStorage.Name.ToLower().Equals(ConstantStringStore.YellowArmChair.ToLower()))
        {
            PlacementObjectPf = yellowarmchair;
        }



        //instantiate the virtual object

        GameObject virtualObject = Instantiate(virtualobjectHolder, hitPosition, Quaternion.identity);

        GameObject spawnedObject = Instantiate(PlacementObjectPf, hitPosition, Quaternion.identity);
        
        spawnedObject.transform.SetParent(virtualObject.transform);

        _placedObjects.Add(virtualObject);

        var anchor = result.Anchor;
        
        isSpawned = true;

        
        
        //deactivate the Placement instruction and activate the buttons
        placementInstruction.SetActive(false);

        //planeindicator.GetComponent<ARCursorRenderer>().CursorObject.transform.localScale = Vector3.zero;
        planeindicator.GetComponent<ARCursorRenderer>().enabled = false;
        //planeindicator.SetActive(false);
        
        

        seriesOfButtons.SetActive(true);
        screenshotholder.SetActive(true);
        
        
        Debug.LogFormat
        (
            "Spawning cube at {0} (anchor: {1})",
            hitPosition.ToString("F4"),
            anchor == null
                ? "none"
                : anchor.AnchorType + " " + anchor.Identifier
        );
    }


    void HandleClick()
    {
        backButton.onClick.AddListener(() => { SceneManager.LoadScene(ConstantStringStore.ProductScene);});
        
        addModelButtton.onClick.AddListener(() =>
        {
            /*isSpawned = false;
            placementInstruction.SetActive(true);
            planeindicator.GetComponent<ARCursorRenderer>().enabled = true;
            planeindicator.SetActive(true);
            planeindicator.GetComponent<ARCursorRenderer>().CursorObject.transform.localScale = Vector3.one;*/

        });
        
        minusModelButton.onClick.AddListener(() => { });
        addCartButton.onClick.AddListener(() => { });
        screenShotButton.onClick.AddListener(() => {CaptureScreen();});
    }


    void CaptureScreen()
    {


        StartCoroutine(TakeScreenshot());
        
        // activate the UI
        backButton.gameObject.SetActive(true);
        seriesOfButtons.SetActive(true);
        screenshotholder.SetActive(true);





    }
    
    public IEnumerator TakeScreenshot()
    {
        
        // deactivate the UI
        backButton.gameObject.SetActive(false);
        seriesOfButtons.SetActive(false);
        screenshotholder.SetActive(false);

        string imageName = $"screenshot{Time.time}.png";

        // Take the screenshot
        ScreenCapture.CaptureScreenshot(imageName);

        //Wait for 4 frames
        for (int i = 0; i < 5; i++)
        {
            yield return null;
        }

        // Read the data from the file
        byte[] data = File.ReadAllBytes(Application.persistentDataPath + "/" + imageName);

        // Create the texture
        Texture2D screenshotTexture = new Texture2D(Screen.width, Screen.height);

        // Load the image
        screenshotTexture.LoadImage(data);

         
       
        
        
        
        // Create a sprite
        Sprite screenshotSprite = Sprite.Create(screenshotTexture, new Rect(0, 0, Screen.width, Screen.height), new Vector2(0.5f, 0.5f));

        
    }








    private void OnAnyARSessionDidInitialize(AnyARSessionInitializedArgs args)
    {
        _session = args.Session;
        _session.Run(ARWorldTrackingConfigurationFactory.Create());
        
        _session.Deinitialized += OnSessionDeinitialized;
    }

    private void OnSessionDeinitialized(ARSessionDeinitializedArgs args)
    {
        ClearObjects();
    }

    private void OnDestroy()
    {
        ARSessionFactory.SessionInitialized -= OnAnyARSessionDidInitialize;

        _session = null;

        ClearObjects();
    }

    private void ClearObjects()
    {
        foreach (var placedObject in _placedObjects)
        {
            Destroy(placedObject);
        }

        _placedObjects.Clear();
    }
}
