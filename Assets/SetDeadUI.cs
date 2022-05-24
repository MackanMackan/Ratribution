using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SetDeadUI : MonoBehaviour
{
    public Image fade;
    Animator playerAnimator;
    GameObject player;
    CharacterMovement charMove;
    CharacterAttack charAtt;

    void Start()
    {
        if (!SceneManager.GetActiveScene().name.Equals("DeadScene"))
        {
            StartCoroutine(nameof(GetPlayerRef));
        }
    }
    IEnumerator GetPlayerRef()
    {
        yield return new WaitForSeconds(2f);
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponentInChildren<Animator>();
        player.GetComponent<CharacterHealth>().onDeadPlayer += ActivateDead;
        charMove = player.GetComponent<CharacterMovement>();
        charAtt = player.GetComponent<CharacterAttack>();
    }
    void ActivateDead()
    {
        playerAnimator.SetTrigger("isDeadT");
        fade.enabled = true;
        fade.DOFade(1, 3).SetUpdate(true).OnComplete(LoadDeadScene);
    }
    void LoadDeadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("DeadScene");
    }
}
