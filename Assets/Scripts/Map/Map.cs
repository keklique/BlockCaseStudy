using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Managers;


namespace Game{
    public class Map : MonoBehaviour
    {
        private MapMatrix mapMatrix;
        private List<GameObject> blocks = new List<GameObject>();
        private List<GameObject> buttons = new List<GameObject>();
        [SerializeField]private GameObject blockPrefab;
        private GameObject buttonPrefab;
        private LevelManager levelManager;
        

#region  Unity Functions
        // void Start(){
        //     levelManager = LevelManager.instance;
        // }
#endregion

#region  Public Functions
        public void SetPrefabs(GameObject _blockPrefab, GameObject _buttonPrefab){
            
            blockPrefab = _blockPrefab;
            buttonPrefab = _buttonPrefab;
        }

        public void SetSizes(int x, int y){
            mapMatrix = new MapMatrix(x,y);
        }
        public void CreateMap(){
            CreateBlocks();
            CreateButtons();
        }

        public void Dispose(){
                DestroyObjectArray(blocks);
            } 
#endregion

#region  private Functions
        private void CreateBlocks(){
            GameObject blocksObject =  new GameObject("Blocks");
            
            blocksObject.transform.SetParent(gameObject.transform);
            for(int i=0; i<mapMatrix.matrix.GetLength(0);i++){
                for(int j=0; j<mapMatrix.matrix.GetLength(1);j++){
                    GameObject tempBlock = Instantiate(blockPrefab,new Vector3(i,-j,0),Quaternion.identity).gameObject;
                    blocks.Add(tempBlock);
                    tempBlock.transform.SetParent(blocksObject.transform);
                }
            }
        }

        private void CreateButtons(){
            int vn = mapMatrix.matrix.GetLength(1);
            int hn = mapMatrix.matrix.GetLength(0);
            GameObject buttonsObject =  new GameObject("Buttons");
            blocks.Add(buttonsObject);

            //ToRight buttons
            for(int j=0;j<vn;j++){
                GameObject tempButton = Instantiate(buttonPrefab,new Vector3(-1,-j,0),Quaternion.identity).gameObject;
                blocks.Add(tempButton);
                tempButton.transform.SetParent(buttonsObject.transform);
                tempButton.GetComponent<Button>().buttonType = ButtonType.ToRight;
                tempButton.GetComponent<Button>().buttonPosition =j;
            }

            //ToButtom buttons
            for(int i=0;i<hn;i++){
                GameObject tempButton = Instantiate(buttonPrefab,new Vector3(hn-1-i,1,0),Quaternion.identity).gameObject;
                blocks.Add(tempButton);
                tempButton.transform.SetParent(buttonsObject.transform);
                tempButton.GetComponent<Button>().buttonType = ButtonType.ToButtom;
                tempButton.GetComponent<Button>().buttonPosition =i;
            }

            //ToLeft buttons
            for(int j=0;j<vn;j++){
                GameObject tempButton = Instantiate(buttonPrefab,new Vector3(hn,-vn+1+j,0),Quaternion.identity).gameObject;
                blocks.Add(tempButton);
                tempButton.transform.SetParent(buttonsObject.transform);
                tempButton.GetComponent<Button>().buttonType = ButtonType.ToLeft;
                tempButton.GetComponent<Button>().buttonPosition =j;
            }

            //TotOP buttons
            for(int i=0;i<hn;i++){
                GameObject tempButton = Instantiate(buttonPrefab,new Vector3(i,-vn,0),Quaternion.identity).gameObject;
                blocks.Add(tempButton);
                tempButton.transform.SetParent(buttonsObject.transform);
                tempButton.GetComponent<Button>().buttonType = ButtonType.ToTop;
                tempButton.GetComponent<Button>().buttonPosition =i;
            }


        }

        private void DestroyObjectArray(List<GameObject> array){
                foreach(GameObject gameObj in array){
                    if(gameObj!=null){Destroy(gameObj);}
                }
            }
#endregion
    }
}
