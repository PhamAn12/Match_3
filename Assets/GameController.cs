using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    Systems _systems;
    private void Start()
    {
     //   var contexts = Contexts.sharedInstance;
        

        var myTexture = Resources.Load("Assets/Resources/Art/Blocker.png") as Texture2D;
        GameObject rawImage = GameObject.Find("RawImage");
        rawImage.GetComponent<RawImage>().texture = myTexture;
    //   _systems = new Feature("Systems").Add(new BoardSystems(contexts.game));
     //   _systems.Initialize();

    }
}