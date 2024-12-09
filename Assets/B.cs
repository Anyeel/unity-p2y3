using System.Collections;
using TMPro;
using UnityEngine;

public class B : MonoBehaviour
{
    [SerializeField] TMP_Text textUI;
    [SerializeField] float secondsPerNumber;
    private float initialSecondsPerNumber;
    [SerializeField] int randomNumber;
    [SerializeField] TMP_Text randomNumberUI;
    private float seconds = 0;
    private int number = 0;
    [SerializeField] int maxNumberGame = 14;
    [SerializeField] int record = 0;
    [SerializeField] GameObject recordUI;
    [SerializeField] TMP_Text recordText;
    [SerializeField] TMP_Text recordNumber;
    private int maxRecord = 0;
    [SerializeField] GameObject imageFail;
    [SerializeField] GameObject imageSuccess;
    private float transicionFadeIn = 0;
    private float transicionFadeOut = 1;
    [SerializeField] CanvasGroup victoryOpacity;
    [SerializeField] CanvasGroup failOpacity;
    [SerializeField] TMP_Text pressSpace;
    [SerializeField] GameObject pressSpaceUI;
    private bool isFading = false;
    private bool isShowingRecord = false;
    private int lastRandomNumber = -1;
    // Start is called before the first frame update
    void Start()
    {
        initialSecondsPerNumber = secondsPerNumber;
        RandomNumber();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            pressSpaceUI.SetActive(false);
        }
        if (!isFading)
        {
                StartCoroutine(TextOpacity(pressSpace));
        }
        UpdaterNumberTime();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (number == randomNumber)
            {
                Success();
            }
            else
            {
                Fail();
            }
        }
        if (maxNumberGame < number)
        {
            Fail();
        }
    }
    void UpdaterNumberTime()
    {
        seconds = Time.deltaTime + seconds;
        if (seconds >= secondsPerNumber)
        {
            number++;
            textUI.text = number.ToString();
            seconds = 0;
        }
    }
    void RandomNumber()
    {
        randomNumber = Random.Range(1, maxNumberGame);
        while (randomNumber == lastRandomNumber) 
        {
            randomNumber = Random.Range(1, maxNumberGame);
        }
        lastRandomNumber = randomNumber;
        randomNumberUI.text = randomNumber.ToString() + ":";
    }
    void RestartGame()
    {
        RandomNumber();
        number = 0;
        textUI.text = number.ToString();
    }
    void Success()
    {
        record++;
        if (record > maxRecord)
        {
            maxRecord = record;
            recordNumber.text = record.ToString();
            StartCoroutine(ShowRecord());
        }
        StartCoroutine(TransitionFadeInOut(victoryOpacity));
        StartCoroutine(DecrementSeconds());
        RestartGame();
    }
    void Fail()
    {
        record = 0;
        StartCoroutine(TransitionFadeInOut(failOpacity));
        RestartGame();
        secondsPerNumber = initialSecondsPerNumber;
    }
    IEnumerator ShowRecord()
    {
        isShowingRecord = true;
        recordUI.SetActive(true);
        Color color = recordText.color;
        while (color.a < 1)
        {
            color.a += Time.deltaTime * 2;
            recordText.color = color;
            recordNumber.color = color;
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        while (color.a > 0)
        {
            color.a -= Time.deltaTime * 2;
            recordText.color = color;
            recordNumber.color = color;
            yield return null;
        }
        recordUI.SetActive(false);
        isShowingRecord = false;
    }
    IEnumerator DecrementSeconds()
    {
        secondsPerNumber = (secondsPerNumber / 1.06f);
        yield return null;
    }

    IEnumerator TransitionFadeInOut(CanvasGroup cg)
    {
        while (transicionFadeIn < 1)
        {
            transicionFadeIn = transicionFadeIn + Time.deltaTime * 8;
            cg.alpha = transicionFadeIn;
            yield return new WaitForEndOfFrame();
        }
        transicionFadeIn = 0;
        while (transicionFadeOut > 0)
        {
            transicionFadeOut = transicionFadeOut - Time.deltaTime * 8;
            cg.alpha = transicionFadeOut;
            yield return new WaitForEndOfFrame();
        }
        transicionFadeOut = 1;
    }
    IEnumerator TextOpacity(TMP_Text tt)
    {
        isFading = true;

        while (tt.color.a > 0)
        {
            Color color = tt.color;
            color.a -= Time.deltaTime * 2;
            tt.color = color;
            yield return null;
        }

        while (tt.color.a < 1)
        {
            Color color = tt.color;
            color.a += Time.deltaTime * 2;
            tt.color = color;
            yield return null;
        }

        isFading = false;
    }
}
