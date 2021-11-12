using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Managers;


namespace Game{
    public class Map : MonoBehaviour
    {
        private MapMatrix mapMatrix;
        private List<GameObject> blocks = new List<GameObject>();
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
        }

        public void Dispose(){
                DestroyObjectArray(blocks);
            } 
#endregion

#region  private Functions
        private void CreateBlocks(){
            GameObject blocksObject =  new GameObject("Blocks");
            blocks.Add(blocksObject);
            blocksObject.transform.SetParent(gameObject.transform);
            for(int i=0; i<mapMatrix.matrix.GetLength(0);i++){
                for(int j=0; j<mapMatrix.matrix.GetLength(1);j++){
                    GameObject tempBlock = Instantiate(blockPrefab,new Vector3(i,-j,0),Quaternion.identity).gameObject;
                    blocks.Add(tempBlock);
                    tempBlock.transform.SetParent(blocksObject.transform);
                }
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
