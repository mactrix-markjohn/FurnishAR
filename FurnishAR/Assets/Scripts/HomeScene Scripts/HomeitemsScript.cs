using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeitemsScript : MonoBehaviour
{

    public Image image;
    public Text productName;
    public Text productPrice;

    private HomeScript _homeScript;
    HomesItemsStorage itemsStorage;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {

       
        itemsStorage = new HomesItemsStorage(productName.text,productPrice.text,image.sprite);
        
        GetComponent<Button>().onClick
            .AddListener(() => { HandleClick(); });
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpScript(HomesItemsStorage itemsStorage)
    {

        productName.text = itemsStorage.Name;
        productPrice.text = itemsStorage.Price;
        image.sprite = itemsStorage.Sprite;

        this.itemsStorage = itemsStorage;

    }

    void HandleClick()
    {
        HomeScript.StaticItemClickHandler(itemsStorage);
    }

}
