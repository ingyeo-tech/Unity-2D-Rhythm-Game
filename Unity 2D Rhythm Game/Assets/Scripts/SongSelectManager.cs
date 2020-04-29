using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SongSelectManager : MonoBehaviour
{
    public Image musicImageUI;
    public Text musicTitleUI;
    public Text bpmUI;

    private int musicIndex;
    private int musicCount = 3;

    private void UpdateSong(int musicIndex) //특정한 곡을 선택(인덱스로)했다면 곡실행
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        // 리소스에서 비트 텍스트 파일을 불러옵니다. 
        TextAsset textAsset = Resources.Load<TextAsset>("Beats/" + musicIndex.ToString()); //기능 객체화해서 실행
        StringReader stringReader = new StringReader(textAsset.text); //신기한 초기화
        // 첫 번째 줄에 적힌 곡 이름을 읽어서 UI를 업데이트 합니다.
        musicTitleUI.text = stringReader.ReadLine();
        // 두 번째 줄은 읽기만하고 아무 처리도 하지 않습니다.
        stringReader.ReadLine();
        // 세번째 줄에 적힌 BPM을 읽어 UI를 업데이트 합니다.
        bpmUI.text = "BPM: " + stringReader.ReadLine().Split(' ')[0];
        // 리소스에서 비트 음악 파일을 불러와 재생합니다.
        AudioClip audioClip = Resources.Load<AudioClip>("Beats/" + musicIndex.ToString());
        audioSource.clip = audioClip;
        audioSource.Play();
        // 리소스에서 비트(Beat) 이미지 파일을 불러옵니다.
        musicImageUI.sprite = Resources.Load<Sprite>("Beats/" + musicIndex.ToString());
    }

    public void Right()
    {
        musicIndex = musicIndex + 1;
        if (musicIndex > musicCount) musicIndex = 1;
        UpdateSong(musicIndex);
    }

    public void Left()
    {
        musicIndex = musicIndex - 1;
        if (musicIndex < 1) musicIndex = musicCount;
        UpdateSong(musicIndex);
    }

    void Start()
    {
        musicIndex = 1;
        UpdateSong(musicIndex);
    }

    public void GameStart()
    {
        PlayerInformation.selectedMusic = musicIndex.ToString();
        SceneManager.LoadScene("GameScene");
    }
}
