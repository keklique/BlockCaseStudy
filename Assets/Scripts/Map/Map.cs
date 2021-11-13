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
        private List<GameObject> containers = new List<GameObject>();
        [SerializeField]private GameObject blockPrefab;
        [SerializeField]private GameObject buttonPrefab;
        [SerializeField]private GameObject containerPrefab;
        private GameObject containersObj;
        private LevelManager levelManager;
        
        [SerializeField]private Camera mainCamera;
        

#region  Unity Functions
        void Start(){
            levelManager = LevelManager.instance;
            EventManager.instance.OnButtonClicked += ButtonFunc;
            mainCamera = Camera.main;
            
        }

        void ButtonFunc(ButtonType btype,int bPosition,Vector3 Vposition){
            int[] result = mapMatrix.CheckEmptyBlocks(btype,bPosition);
            Debug.Log("[Map]: empty blocks :"+result[0]+" --x :"+result[2]+" --y :"+result[1]);
            if(levelManager.currentBlockSize<=result[0]){
                CreateContainerObject();
                int zRotation = GetRotationOfContainer(btype);
                GameObject tempContainer = Instantiate(containerPrefab,Vposition,Quaternion.identity);
                tempContainer.transform.rotation = Quaternion.Euler(0f,0f,(float)zRotation);
                tempContainer.GetComponent<Container>().SetLength(levelManager.currentBlockSize);
                tempContainer.transform.SetParent(containersObj.transform);
                Vector3 targetPosition = new Vector3(result[2],-result[1],0f);
                tempContainer.GetComponent<Container>().Move(targetPosition);
                mapMatrix.FillMatrix(btype,new int[]{result[1],result[2]},levelManager.currentBlockSize);
                
            }else{
                Debug.Log("Not Fits");
            }  
        }

        private void CreateContainerObject(){
            if(containersObj==null){
                containersObj = new GameObject("Containers");
                containersObj.transform.SetParent(this.gameObject.transform);
                containers.Add(containersObj);  
            }
        }
#endregion

#region  Public Functions
        public void SetPrefabs(GameObject _blockPrefab, GameObject _buttonPrefab, GameObject _containerPrefab){
            
            blockPrefab = _blockPrefab;
            buttonPrefab = _buttonPrefab;
            containerPrefab = _containerPrefab;
        }

        public void SetSizes(int x, int y){
            mapMatrix = new MapMatrix(x,y);
        }
        public void CreateMap(){
            CreateBlocks();
            CreateButtons();
            SetCameraPosition();
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
                    GameObject tempBlock = Instantiate(blockPrefab,new Vector3(j,-i,0.55f),Quaternion.identity).gameObject;
                    blocks.Add(tempBlock);
                    tempBlock.transform.SetParent(blocksObject.transform);
                }
            }
        }

        private void CreateButtons(){
            int vn = mapMatrix.matrix.GetLength(0);
            int hn = mapMatrix.matrix.GetLength(1);
            GameObject buttonsObject =  new GameObject("Buttons");
            buttonsObject.transform.SetParent(this.gameObject.transform);
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

        private int GetRotationOfContainer(ButtonType type){
            int _rotation = 0;
            if(type==ButtonType.ToRight){_rotation= 0;}
            if(type==ButtonType.ToTop){_rotation= 90;}
            if(type==ButtonType.ToLeft){_rotation= 180;}
            if(type==ButtonType.ToButtom){_rotation= 270;}
            return _rotation;
        }

        private void SetCameraPosition(){
            float xpos = (float)mapMatrix.matrix.GetLength(0)/2f;
            float ypos = (float)mapMatrix.matrix.GetLength(1)*-1f/2f;
            Camera.main.transform.position = new Vector3(xpos,ypos,-10f);
        }

        private void DestroyObjectArray(List<GameObject> array){
                foreach(GameObject gameObj in array){
                    if(gameObj!=null){Destroy(gameObj);}
                }
            }
#endregion
    }
}
