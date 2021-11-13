using UnityEngine;
using UnityEngine.UI;
using Core.Managers;

public class BlockButton : MonoBehaviour
{
    private LevelManager levelManager;
    [SerializeField]private int blockSize;


    void Start(){
        levelManager = LevelManager.instance;
        gameObject.GetComponent<Button>().onClick.AddListener(SetBlockSize);
    }

    void OnClick(){

    }

    void SetBlockSize(){
        levelManager.SetCurrentBlockSize(blockSize);
    }
}
