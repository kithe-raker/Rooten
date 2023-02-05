using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBaseLevelSquencer : MonoBehaviour
{
    public Canvas dialogCanvas;
    public GameObject buttonRow;
    public SceneLoader sceneLoader;
    public TMP_Text textLebel;

    private List<string> dialogList = new List<string>();

    private TypeWriterEffect _effect;
    private bool _isFinishTyping = false, _isFinishIntro = false, _confirmChoice = false, _ending = false, end = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogList.Add("You have traveled all this way here.\n");
        dialogList.Add("Right in front of the root’s heart.\n");
        dialogList.Add("Ever slowly beating.\n");
        dialogList.Add("Make your decision.\n\n");

        _effect = GetComponent<TypeWriterEffect>();
        _effect.OnFinishTyping += OnFinishTyping;

        RunDialog();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (end)
            {
                sceneLoader.StartLoadScene(0);
            }
            else if (_isFinishTyping && !_isFinishIntro)
            {
                RunDialog();
            }
            else if (_isFinishTyping && _ending)
            {
                end = true;
                textLebel.enableAutoSizing = false;
                textLebel.fontSize = 121f;
                textLebel.alignment = TextAlignmentOptions.Center;
                _effect.ClearText(textLebel);
                TypeEffect("\"The End\"");
            }
        }


    }


    public void MakeDecision(bool killRoot)
    {
        SetButtonRow(false);
        if (!_confirmChoice)
        {
            if (killRoot)
            {
                TypeEffect("Cut it? That’s what Jack hired you to do.\n");
            }
            else
            {
                TypeEffect("Spare it? Life around the stalk is thriving; they aren’t bothering anyone.\n");
            }
            _confirmChoice = true;
        }
        else
        {
            _effect.ClearText(textLebel);
            _isFinishTyping = false;
            _ending = true;
            textLebel.enableAutoSizing = true;
            if (killRoot)
            {
                TypeEffect("Cut it,\r\n\r\nThe environment transforms into chaos and you hear the agonizing cries from the creatures nearby.\r\n\r\nYou quickly ascend to the surface and successfully flee from underground.\r\nWhen you glance back, the stalk appears as a normal lifeless tree, devoid of any signs of life before.\r\n\r\nYou fulfill the final task by removing it from the ground completely.\r\n\r\nJack is extremely satisfied and rewards you handsomely.\r\n\r\nBut can you rest peacefully, with the knowledge that you have caused the destruction of innocent beings who posed no threat.");
            }
            else
            {
                TypeEffect("Spare it,\r\n\r\nAll life around the stock are grateful for your compassion, they vow not to cause any trouble.\r\n\r\nAs you rise from the ground, you gaze upon the brilliant blue sky.\r\n\r\nAnd see Jack, who is extremely upset by your behavior.\r\nAs the typical businessman he is, he fire you on the spot.\r\n\r\nThough you may have fallen short in fulfilling your duties,\r\nYou have recognized the kindness within your heart.");
            }
        }
    }

    void RunDialog()
    {
        _isFinishTyping = false;
        _effect.StartTyping(dialogList[0], textLebel);
        dialogList.RemoveAt(0);

        if (dialogList.Count == 0)
        {
            _isFinishIntro = true;
        }
    }

    void SetButtonRow(bool active)
    {
        if (buttonRow != null)
        {
            buttonRow.SetActive(active);
        }

    }

    void OnFinishTyping()
    {
        _isFinishTyping = true;

        if (_isFinishIntro && !_ending)
        {
            SetButtonRow(true);
        }
    }

    void TypeEffect(string text)
    {
        _isFinishTyping = false;
        _effect.StartTyping(text, textLebel);
    }

}
