using UnityEngine;

namespace Game{
    public class Container : MonoBehaviour
    {
        [SerializeField]int lenght = 1;
        [SerializeField]private GameObject elementPrefab;
        [SerializeField]private GameObject[] elementPrefabs;
        [SerializeField]private Vector3 targetPos;
        [SerializeField]private float containerSpeed = 3f;
        [SerializeField]private int _random;


        void Awake(){
            _random = Random.Range(0,3);
        }
        public void SetLength(int l){
            lenght =l;
            for(int i=0;i<lenght;i++){
                GameObject temp = Instantiate(elementPrefabs[_random],Vector3.zero,Quaternion.identity);
                temp.transform.SetParent(this.gameObject.transform);
                temp.transform.localPosition = new Vector3(-i,0,0);
            }
        }

        public void Move(Vector3 targetPosition){
            targetPos = targetPosition;
        }

        void Update(){
            transform.position = Vector3.MoveTowards(transform.position, targetPos, containerSpeed*Time.deltaTime);
        }

    }
}