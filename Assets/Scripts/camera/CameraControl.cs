using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Aim Info")]
    public float sensibilidade = 15;
    public float suavizacao = 1.5f;
    public float limiteVertical;



    public Transform playerTransform;



    private Vector2 velocidadeFrame, velocidadeRotacao;
    
    
    void Start()
    {
        sensibilidade = PlayerPrefs.GetFloat("PlayerSense", 15f);

        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        Vector2 mouseOnly = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector2 JoystickOnly = new Vector2(Input.GetAxis("HorizontalTurn"), Input.GetAxis("VerticalTurn"));
        Vector2 mouseInputs = JoystickOnly != Vector2.zero ? JoystickOnly : mouseOnly;
        Vector2 rawVelocidadeFrame = Vector2.Scale(mouseInputs, Vector2.one * sensibilidade);
        velocidadeFrame = Vector2.Lerp(velocidadeFrame, rawVelocidadeFrame, 1 / suavizacao);
        velocidadeRotacao += velocidadeFrame;
        velocidadeRotacao.y = Mathf.Clamp(velocidadeRotacao.y, -limiteVertical, limiteVertical);

        transform.localRotation = Quaternion.AngleAxis(-velocidadeRotacao.y, Vector3.right);
        playerTransform.localRotation = Quaternion.AngleAxis(velocidadeRotacao.x, Vector3.up);
        
    }
}
