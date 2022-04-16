using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    
    [SerializeField] GameObject navigationArrow;
    [SerializeField] float rotationRate = 5f;
    [SerializeField] Image hpBar;
    [SerializeField] GameObject gameOverUI;

    private float hpPoint;
    private SpawnManager checkPoint;
    private void Awake()
    {
        checkPoint = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        hpPoint = 1;
       
    }
    private void Update()
    {
        LookAtCheckPoint();
        hpBar.fillAmount = hpPoint;
    }

    private void LookAtCheckPoint()
    {
        if (checkPoint.checkPoint == null)
        {
            navigationArrow.transform.Rotate(0, rotationRate * Time.deltaTime, 0);
        }
        else
        {
            navigationArrow.transform.LookAt(checkPoint.checkPoint.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hpPoint -= 0.10f;
            HPChecker();
        }
    }
    private void HPChecker()
    {
        if (hpPoint <= 0) GameOver();
    }

    private void GameOver ()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1;
    }
}
