using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class TypingTest: MonoBehaviour
{
    public TextMeshProUGUI player1Text; // UI Text pro hráče 1 (WSAD)
    public TextMeshProUGUI player2Text; // UI Text pro hráče 2 (Arrow keys)

    private string player1Sequence; // Pořadí kláves pro hráče 1
    private string player2Sequence; // Pořadí kláves pro hráče 2

    private int player1Index = 0; // Kterou klávesu hráč 1 zmáčkl správně
    private int player2Index = 0; // Kterou klávesu hráč 2 zmáčkl správně

    void Start()
    {
        GenerateNewSequences();
    }

    void Update()
    {
        HandlePlayerInput(ref player1Index, player1Sequence, player1Text, new KeyCode[] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D });
        HandlePlayerInput(ref player2Index, player2Sequence, player2Text, new KeyCode[] { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow });
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

                    if (KeyCodeToChar(key) == expectedKey) // Správně zmáčknutá klávesa
                    {
                        HighlightKey(currentIndex, sequence, text);
                        currentIndex++;

                        if (currentIndex >= sequence.Length) // Vše správně → skryje text
                        {
                            text.text = "";
                        }
                    }
                    else // Špatná klávesa → reset
                    {
                        ResetSequence(ref currentIndex, sequence, text);
                    }
                    break;
                }
            }
        }
    }

    void GenerateNewSequences()
    {
        player1Sequence = ShuffleString("WSAD");
        player2Sequence = ShuffleString("↑↓←→"); // Arrow symbols

        player1Text.text = player1Sequence;
        player2Text.text = player2Sequence;

        player1Index = 0;
        player2Index = 0;
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
        text.text = sequence; // Reset textu
    }

    string ShuffleString(string input)
    {
        return new string(input.ToCharArray().OrderBy(x => Random.value).ToArray());
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
