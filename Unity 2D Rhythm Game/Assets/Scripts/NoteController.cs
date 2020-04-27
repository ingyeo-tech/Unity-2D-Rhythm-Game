using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{

    // 하나의 노트에 대한 정보를 담는 노트 클래스를 정의
    class Note
    {
        //프로퍼티 왜 얘네만 만들어줌
        public int noteType { get; set; }
        public int order { get; set; }
        //생성자 만들기
        public Note(int noteType, int order)
        {
            this.noteType = noteType;
            this.order = order;
        }
    }

    // 노트클래스의 노트변수로 노트 리스트 생성
    public GameObject[] Notes;

    private ObjectPooler noteObjectPooler;
    private List<Note> notes = new List<Note>();
    private float x, z, startY = 8.0f;
    // 비트생성용
    private float beatInterval = 1.0f;

    void MakeNote(Note note)
    {
        GameObject obj = noteObjectPooler.getObject(note.noteType);
        // 설정된 시작 라인으로 노트를 이동시킵니다.
        x = obj.transform.position.x;
        z = obj.transform.position.z;
        obj.transform.position = new Vector3(x, startY, z); //뭔데
        obj.GetComponent<NoteBehaviour>().Initialize();
        obj.SetActive(true);

    }

    //노트 생성용 코루틴 생성
    IEnumerator AwaitMakeNote(Note note)
    {
        //또 선언 또 또
        int noteType = note.noteType;
        int order = note.order;
        yield return new WaitForSeconds(order * beatInterval);
        //1초 뒤에 노트 생성, 인덱스 0 부터 시작하기 때문에 -1 부터 시작
        MakeNote(note);
    }

    void Start()
    {
        //리스트 추가
        noteObjectPooler = gameObject.GetComponent<ObjectPooler>();
        notes.Add(new Note(1, 1));
        notes.Add(new Note(2, 2));
        notes.Add(new Note(3, 3));
        notes.Add(new Note(4, 4));
        notes.Add(new Note(1, 5));
        notes.Add(new Note(2, 6));
        notes.Add(new Note(3, 7));
        notes.Add(new Note(4, 8));
        // 모든 노트를 정해진 시간에 출발하도록 설정
        for (int i = 0; i < notes.Count; i++)
        {
            StartCoroutine(AwaitMakeNote(notes[i]));
        }

    }

    void Update()
    {
        
    }
}
