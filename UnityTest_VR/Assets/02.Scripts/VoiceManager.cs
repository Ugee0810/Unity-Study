using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition;

public class VoiceManager : MonoBehaviour
{
    private GCSpeechRecognition gcSpeech;

    // 델리게이트 생성
    public delegate void OnResultEvent(string result);
    public static event OnResultEvent OnResult;

    // Singleton
    private static VoiceManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static VoiceManager Instance 
    { 
        get 
        { 
            if (instance == null) return null;

            return instance; 
        }
    }

    void Start()
    {
        gcSpeech = GCSpeechRecognition.Instance;
        gcSpeech.RecognizeSuccessEvent += RecognizeSuccessEventHandler;
    }

    void OnDestroy()
    {
        gcSpeech.RecognizeSuccessEvent += RecognizeSuccessEventHandler;
    }

    public void StartVoiceManager()
    {
        gcSpeech.StartRecord(false);
    }
    
    public void StopVoiceManager()
    {
        gcSpeech.StopRecord();
    }

    private void FinishedRecordEventHandler(AudioClip clip, float[] raw)
    {
        if (clip == null) return;

        RecognitionConfig config = RecognitionConfig.GetDefault();
        config.languageCode = Enumerators.LanguageCode.en_US.Parse();

        config.speechContexts = new SpeechContext[]
        {
            new SpeechContext()
            {

            }
        };

        config.audioChannelCount = clip.channels;

        //GeneralRecognitionRequest recogRequest = new GeneralRecognitionRequest()
        //{
        //    audio = new GeneralRecognitionRequest()
        //    {
        //        content = raw.ToBase64()
        //    }
        //    config = config
        //};
        //gcSpeech.Recognize(recogRequest);
    }

    void RecognizeSuccessEventHandler(RecognitionResponse response)
    {
        InsertRecognitionResponseInfo(response);
    }

    void InsertRecognitionResponseInfo(RecognitionResponse response)
    {
        if (response == null || response.results.Length == 0)
        {
            // 대기하다가 웹에서 response가 넘어오면 델리게이트로 처리(이벤트 트리거와 비슷한 개념이다.)
            OnResult("Falied");
            return;
        }
        // 음성 인식을 문자열로 받고 결과 값으로 넘김
        string sSpeechResult = response.results[0].alternatives[0].transcript;
        OnResult(sSpeechResult);

        var words = response.results[0].alternatives[0].words;

        if (words != null)
        {
            string times = string.Empty;
            foreach (var item in response.results[0].alternatives[0].words)
            {
                times += "<color=green>" + item.word + "</color> - start : " + item.startTime + " : end: " + item.endTime + "\n";
            }
        }

        string other = string.Empty;

        foreach (var result in response.results)
        {
            foreach (var alternative in result.alternatives)
            {
                if (response.results[0].alternatives[0] != alternative)
                {
                    other += alternative.transcript + ", ";
                }
            }
        }
    }
}
