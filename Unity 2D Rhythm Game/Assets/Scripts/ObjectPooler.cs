using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //이중 리스트 사용하기
    // Note 1: 10개 => 리스트 1
    // Note 2: 10개 =>리스트 2
    // Note 3: 10개 =>리스트 3
    // Note 4: 10개 =>리스트 4

    //노트 프리팹 리스트
    public List<GameObject> Notes;
    //노트 리스트의 리스트 2차원 리스트
    private List<List<GameObject>> poolsOfNotes;
    public int noteCount = 10;
    //경우에 따라서 리스트개수를 추가할때 true/false, if랑구분
    private bool more = true;

    void Start()
    {
        poolsOfNotes = new List<List<GameObject>>();
        for(int i = 0; i < Notes.Count; i++) //4번반복
        {
            //리스트를 Add 원소로 추가
            poolsOfNotes.Add(new List<GameObject>());
            for(int n = 0; n < noteCount; n++) //10번 반복
            {
                //i만큼 Notes생성
                GameObject obj = Instantiate(Notes[i]);
                obj.SetActive(false);
                poolsOfNotes[i].Add(obj); //int4에 맞게 10개씩 종류에 맞는 리스트에 추가해줌 ? ? ? 
            }
        }
    }

    public GameObject getObject(int noteType)
    {
        foreach(GameObject obj in poolsOfNotes[noteType - 1])
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        if(more)
        {
            GameObject obj = Instantiate(Notes[noteType - 1]);
            poolsOfNotes[noteType - 1].Add(obj);
            return obj;
        }
        //오류발생 대비
        return null;
    }

    void Update()
    {
        
    }
}
