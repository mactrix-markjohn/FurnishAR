using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProductScript : MonoBehaviour
{
    public static HomesItemsStorage ItemsStorage;

    public Button backButton, arSceneButton,addCartButton,bookmarkButton,plusItemButton,minusItemButton;
    public Text productName, productPrice, productDetail, itemCount, ratingCount, reviewCount;
    public Image productImage;
    
    



    // Start is called before the first frame update
    void Start()
    {
        ItemsStorage = HomeScript.ItemsStorage;
        
        //Handle the button click
        HandleClick();
        
        //fill up the UI
        productImage.sprite = ItemsStorage.Sprite;
        productName.text = ItemsStorage.Name;
        productPrice.text = ItemsStorage.Price;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleClick()
    {
        backButton.onClick.AddListener(() => { SceneManager.LoadScene(ConstantStringStore.HomeScene);});
        arSceneButton.onClick.AddListener(() => { SceneManager.LoadScene(ConstantStringStore.ArScene);});
        addCartButton.onClick.AddListener(() => { });
        bookmarkButton.onClick.AddListener(() => { });
        plusItemButton.onClick.AddListener(() => { });
        minusItemButton.onClick.AddListener(() => { });
        
        
        
    }
}
