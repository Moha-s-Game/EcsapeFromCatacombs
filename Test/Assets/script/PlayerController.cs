using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using System.Collections;

public class PlayerController : Sounds
{
    public float MoveSpeed = 4f;

    private CharacterController _controller;
    public GameObject ScaryImg;
    public GameObject dot;
    public SliderScript sliderScript;
    public bool reklama = false;

    bool running;
    public Image StaminaBar;
    public float Stamina, MaxStamina;
    public float RunCost;
    public float ChargeRate;

    private Coroutine recharge;

    Vector3 velocity;
    void Start()
    {
        ScaryImg.SetActive(false);
        _controller = GetComponent<CharacterController>();
        AdBlock();
        StaminaBar.color = new Color(255, 255, 255, 0);
    }
    void Update()
    {
        if (velocity.y < 0)
        {
            velocity.y = -5f;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        _controller.Move(moveDirection * MoveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = false;
        }
        if (Stamina > 0)
        {
            if (running && (moveDirection.x != 0 || moveDirection.y != 0))
            {
                StaminaBar.color = new Color(255, 255, 255, 50);
                _controller.Move(moveDirection * .02f);
                Stamina -= RunCost * Time.deltaTime;
                if (Stamina < 0) Stamina = 0;
                StaminaBar.fillAmount = Stamina / MaxStamina;
                if (recharge != null) StopCoroutine(recharge);
                recharge = StartCoroutine(RechargeStamina());
            }
        }

        velocity.y += -9.81f * Time.deltaTime;
        _controller.Move(velocity * Time.deltaTime);
    }
    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(2f);
        while (Stamina < MaxStamina)
        {
            Stamina += ChargeRate / 10f;
            if (Stamina > MaxStamina) Stamina = MaxStamina;
            StaminaBar.fillAmount = Stamina / MaxStamina;
            yield return new WaitForSeconds(.1f);
        }
        if (Stamina >= MaxStamina)
        {
            StaminaBar.color = new Color(255, 255, 255, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            dot.SetActive(false);
            PlaySound(sounds[0], 1);
            ScaryImg.SetActive(true);
            Debug.Log("BOOOOO!!!");
            Invoke("RestartLevel", 3);
        }
        if (other.gameObject.tag == "scr")
        {
            PlaySound(sounds[3], 1);
        }
        if (other.gameObject.tag == "isTrigger")
        {
            PlaySound(sounds[4], 1);
        }
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
    void AdBlock()
    {
        YandexGame.FullscreenShow();
    }
}
