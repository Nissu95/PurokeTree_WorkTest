using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    enum State
    {
        Right = 1,
        Idle = 0,
        Left = -1
    }

    [SerializeField] float maxSpeed;
    [SerializeField] float acceleration;
    [SerializeField] Vector3 smokeOffset;

    //AxisState axisState = new AxisState();
    
    Animator animator;
    SpriteRenderer sp;
    SpriteRenderer smokeSP;
    float moveInput;
    float currentSpeed = 0;
    State state = 0;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        smokeSP = GameManager.instance.GetSmokeSpriteRenderer();
    }

    void FixedUpdate()
    {
        moveInput = InputManager.instance.GetInput().GetMoveInput();

        switch (moveInput)
        {
            //Toco para ir a la derecha.
            case 1:
                if (currentSpeed < maxSpeed)
                    currentSpeed += acceleration * Time.fixedDeltaTime;
                else
                    currentSpeed = maxSpeed;

                state = (State)moveInput;
                sp.flipX = false;

                if (InputManager.instance.GetInput().GetInputDown())
                    Smoke(false, moveInput);

                animator.SetBool("isWalking", true);
                transform.Translate(currentSpeed * Time.fixedDeltaTime, 0, 0);
                break;
            //No toco nada
            case 0:
                switch (state)
                {
                    case State.Right:
                        if (currentSpeed > 0)
                            currentSpeed -= acceleration * Time.fixedDeltaTime;
                        else
                        {
                            currentSpeed = 0;
                            state = 0;
                        }

                        transform.Translate(currentSpeed * Time.fixedDeltaTime, 0, 0);
                        break;
                    case State.Idle:
                        animator.SetBool("isWalking", false);
                        transform.Translate(currentSpeed * Time.fixedDeltaTime, 0, 0);
                        break;
                    case State.Left:
                        if (currentSpeed < 0)
                            currentSpeed += acceleration * Time.fixedDeltaTime;
                        else
                        {
                            currentSpeed = 0;
                            state = 0;
                        }

                        transform.Translate(currentSpeed * Time.fixedDeltaTime, 0, 0);
                        break;
                    default:
                        break;
                }
                break;
            //Toco para ir a la izquierda
            case -1:
                if (currentSpeed > -maxSpeed)
                    currentSpeed -= acceleration * Time.fixedDeltaTime;
                else
                    currentSpeed = -maxSpeed;

                state = (State)moveInput;
                sp.flipX = true;

                if (InputManager.instance.GetInput().GetInputDown())
                    Smoke(true, moveInput);

                animator.SetBool("isWalking", true);
                transform.Translate(currentSpeed * Time.fixedDeltaTime, 0, 0);
                break;
        }
    }

    void Smoke(bool flip, float moveInput)
    {
        Vector2 aux;

        aux.x = transform.position.x + (-smokeOffset.x * moveInput);
        aux.y = transform.position.y - smokeOffset.y;
        smokeSP.transform.position = aux;

        smokeSP.flipX = flip;

        smokeSP.GetComponent<Animator>().SetTrigger("isSmoke");
    }

    public void SetCurrentSpeed(float _currentSpeed)
    {
        currentSpeed = _currentSpeed;
    }
}
