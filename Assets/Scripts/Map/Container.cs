using UnityEngine;

namespace Game{
    public class Container : MonoBehaviour
    {
        [SerializeField]int lenght = 1;
        [SerializeField]private GameObject elementPrefab;
        [SerializeField]private Vector3 targetPos;

        public void SetLength(int l){
            lenght =l;
            for(int i=0;i<lenght;i++){
                GameObject temp = Instantiate(elementPrefab,Vector3.zero,Quaternion.identity);
                temp.transform.SetParent(this.gameObject.transform);
                temp.transform.localPosition = new Vector3(-i,0,0);
            }
        }

        public void Move(Vector3 targetPosition){
            targetPos = targetPosition;
        }

        void Update(){
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 1*Time.deltaTime);
        }

    }
}