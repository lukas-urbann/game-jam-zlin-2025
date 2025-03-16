using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System;

public class TypingTest: MonoBehaviour
{
    public static TypingTest Instance { get; private set; }
    
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;
    public GameObject typingPanel;
    
    private string player1Sequence;
    private string player2Sequence;
    
    private int player1Index = 0;
    private int player2Index = 0;
    
    private Action onPlayer1Success;
    private Action onPlayer2Success;
    private bool isActive = false;
    private bool isPlayer1Active = true;
    
    private void Awake()
    {
        Instance = this;
        typingPanel.SetActive(false);
    }

    void Start()
    {
        GenerateNewSequences();
    }

    void Update()
    {
        if (!isActive) return;
        if (isPlayer1Active)
            HandlePlayerInput(ref player1Index, player1Sequence, player1Text, new KeyCode[] 
                { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D });
        else
            HandlePlayerInput(ref player2Index, player2Sequence, player2Text, new KeyCode[] 
                { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow });
    }

    void HandlePlayerInput(ref int currentIndex, string sequence, TextMeshProUGUI text, KeyCode[] keys)
    {
        if (currentIndex < sequence.Length)
        {
            foreach (var key in keys)
            {
                if (Input.GetKeyDown(key))
                {
                    char expectedKey = sequence[currentIndex];

                    if (KeyCodeToChar(key) == expectedKey)
                    {
                        HighlightKey(currentIndex, sequence, text);
                        currentIndex++;

                        if (currentIndex >= sequence.Length)
                        {
                            text.text = "<color=green>SUCCESS!</color>";
                            if (isPlayer1Active && onPlayer1Success != null)
                            {
                                onPlayer1Success();
                                Invoke("HidePanel", 1.0f);
                            }
                                
                            else if (!isPlayer1Active && onPlayer2Success != null)
                            {
                                onPlayer2Success();
                                Invoke("HidePanel", 1.0f);
                            }
                        }
                    }
                    else
                    {
                        ResetSequence(ref currentIndex, sequence, text);
                    }
                    break;
                }
            }
        }
    }
    
    public void StartTypingChallenge(bool isPlayer1, Action successCallback)
    {
        isActive = true;
        isPlayer1Active = isPlayer1;
        typingPanel.SetActive(true);
        
        GenerateNewSequences();
        player1Index = 0;
        player2Index = 0;
        player1Text.gameObject.SetActive(isPlayer1);
        player2Text.gameObject.SetActive(!isPlayer1);
        
        Debug.Log("Player 1 text: " + player1Text.text);
        Debug.Log("Player 2 text: " + player2Text.text);
        
        if (isPlayer1)
        {
            onPlayer1Success = successCallback;
            onPlayer2Success = null;
        }
        else
        {
            onPlayer2Success = successCallback;
            onPlayer1Success = null;
        }
        
        player1Index = 0;
        player2Index = 0;
    }
    
    private void HidePanel()
    {
        typingPanel.SetActive(false);
        isActive = false;
    }

    void GenerateNewSequences()
    {
        player1Sequence = ShuffleString("WSAD");
        player2Sequence = ShuffleString("↑↓←→");
        
        player1Text.text = player1Sequence;
        player2Text.text = player2Sequence;
    }

    void HighlightKey(int index, string sequence, TextMeshProUGUI text)
    {
        string coloredText = "";

        for (int i = 0; i < sequence.Length; i++)
        {
            if (i <= index)
                coloredText += $"<color=green>{sequence[i]}</color>";
            else
                coloredText += sequence[i];
        }

        text.text = coloredText;
    }

    void ResetSequence(ref int currentIndex, string sequence, TextMeshProUGUI text)
    {
        currentIndex = 0;
        text.text = sequence;
    }

    string ShuffleString(string input)
    {
        return new string(input.ToCharArray().OrderBy(x => UnityEngine.Random.value).ToArray());
    }

    char KeyCodeToChar(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.W: return 'W';
            case KeyCode.S: return 'S';
            case KeyCode.A: return 'A';
            case KeyCode.D: return 'D';
            case KeyCode.UpArrow: return '↑';
            case KeyCode.DownArrow: return '↓';
            case KeyCode.LeftArrow: return '←';
            case KeyCode.RightArrow: return '→';
            default: return ' ';
        }
    }
}