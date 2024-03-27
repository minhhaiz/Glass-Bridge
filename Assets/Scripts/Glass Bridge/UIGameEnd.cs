using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameEnd : MonoBehaviour
{
    public GameObject panelEndGame, buttonNextOrRestart, buttonReward;
    public RectTransform pathPointsParent, container, targetPoint;
    public TextMeshProUGUI textCoin, textReward;
    public Slider choiceReward;
    public Tween tweenChoiceReward, tweenScaleButtonReward;
    bool isFirst, isChoice, isWin;
    int reward = 100;

    void Start()
    {
        textCoin.text = "" + Player.coin;
        FadeObj(panelEndGame.GetComponent<RectTransform>(), 0, 0);
        panelEndGame.SetActive(false);
    }

    public void ChoicedRewardOnClick()
    {
        if (isChoice == true)
        {
            buttonReward.GetComponent<Button>().interactable = false;
            Debug.LogError("qqqq");

            tweenChoiceReward.Kill();
            float value = choiceReward.value;
            if ((value >= 0 && value <= 0.25f) || (value > 0.75f && value <= 1))
            {
                reward = 200;
            }
            else if ((value > 0.25f && value <= 0.43f) || (value > 0.57f && value <= 0.75))
            {
                reward = 300;
            }
            else
            {
                reward = 500;
            }
            MovePath(10);
        }
        isChoice = false;


    }

    void Update()
    {
        if (isChoice == true)
        {
            float value = choiceReward.value;
            if ((value >= 0 && value <= 0.25f) || (value > 0.75f && value <= 1))
            {
                textReward.text = "+200";
            }
            else if ((value > 0.25f && value <= 0.43f) || (value > 0.57f && value <= 0.75))
            {
                textReward.text = "+300";
            }
            else
            {
                textReward.text = "+500";
            }
        }
    }

    public void HomeScene()
    {
        if (isWin == true)
        {
            Player.coin += 100;
        }
        SceneManager.LoadScene("Home");
    }

    public void NextOrRestart()
    {
        if (isWin == true)
        {
            Player.coin += 100;
        }
        SceneManager.LoadScene(buttonNextOrRestart.name);
    }

    public void ShowPanel(bool isWin)
    {
        Debug.LogError("wwww");
        panelEndGame.SetActive(true);
        var rectChildSeconds = panelEndGame.GetComponent<RectTransform>().GetChild(2).gameObject;
        this.isWin = isWin;
        if (isWin == true)
        {
            rectChildSeconds.GetComponent<TextMeshProUGUI>().text = "VICTORY";
            isChoice = true;
        }
        else
        {
            rectChildSeconds.GetComponent<TextMeshProUGUI>().text = "DEFEAT";
            rectChildSeconds.gameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            panelEndGame.GetComponent<RectTransform>().GetChild(3).gameObject.SetActive(false);
            panelEndGame.GetComponent<RectTransform>().GetChild(4).gameObject.SetActive(false);
        }
        tweenChoiceReward = choiceReward.DOValue(1, 2f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        var rectPanel = panelEndGame.GetComponent<RectTransform>();
        FadeObj(rectPanel, 1f, 0.5f);
        rectPanel.DOAnchorPosY(0, 0.5f);
    }

    public void FadeObj(RectTransform parent, float alpha, float duration)
    {
        parent.GetComponent<Image>().DOFade(alpha, duration);
        FadeChild(parent, alpha, duration);
    }

    public void FadeChild(RectTransform parent, float alpha, float duration)
    {
        foreach (RectTransform child in parent)
        {
            if (child.name != "Fill")
            {
                Image image = child.GetComponent<Image>();
                TextMeshProUGUI text = child.GetComponent<TextMeshProUGUI>();
                if (image != null)
                {
                    child.GetComponent<Image>().DOFade(alpha, duration);
                }
                else if (text != null)
                {
                    child.GetComponent<TextMeshProUGUI>().DOFade(alpha, duration);
                }
                FadeChild(child, alpha, duration);
            }
        }
    }

    void MovePath(int index)
    {
        if (index > 0)
        {
            int random = UnityEngine.Random.Range(0, pathPointsParent.childCount);
            GameObject coin = Instantiate(panelEndGame.GetComponent<RectTransform>().GetChild(4).gameObject.GetComponent<RectTransform>().GetChild(1).gameObject, container);
            var rectCoin = coin.GetComponent<RectTransform>();
            coin.GetComponent<RectTransform>().DOMove(pathPointsParent.GetChild(random).position, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                DOVirtual.DelayedCall(0.15f, () =>
                {
                    rectCoin.DOMove(targetPoint.position, 0.5f);
                    rectCoin.DOScale(0.5f, 0.5f);
                    if (isFirst == false)
                    {
                        isFirst = true;
                        DOVirtual.DelayedCall(0.5f, () =>
                        {
                            int startValue = Player.coin;
                            DOTween.To(() => startValue, x =>
                            {
                                startValue = x;
                                textCoin.text = "" + startValue;
                            }, Player.coin + reward, 1f).SetEase(Ease.Linear).OnComplete(() =>
                            {
                                Player.coin += reward;
                            });
                        });
                    }
                });
            });
            rectCoin.DOScale(2f, 0.5f);
            DOVirtual.DelayedCall(0.1f, () =>
            {
                MovePath(--index);
            });
        }
    }
}