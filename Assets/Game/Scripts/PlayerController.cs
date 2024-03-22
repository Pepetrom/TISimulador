using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController pc;
    [SerializeField] CharacterController characterController;
    [SerializeField] GameObject PlayerCharacter;
    Vector3 direction = new Vector3(0, 0, 0);
    public float speed = 1;
    public float pushForce = 1;
    private bool pressFcheck = false;
    

    //Raycast
    [SerializeField] LayerMask interactable;
    Ray mouseRay;
    RaycastHit playerHit, mouseHit;
    GameObject interactedObject;

    public bool holdingMouse = false;

    //PlayerAssets
    Animator animator;
    public Rigidbody rb;
    Moveable ObjectBeingMoved;

    private void Awake()
    {
        pc = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        characterController = GetComponent<CharacterController>();
        pressFcheck = false;
    }
    void Update()
    {
        Interact();     
        direction = new Vector3(Input.GetAxis("Horizontal"), Mathf.Clamp(rb.velocity.y,-10,0), Input.GetAxis("Vertical"));
        if(pressFcheck == true && Input.GetKey(KeyCode.F))
        {
            GameManager.gm.ShowPUZZLE1Guide();
        }
        else
        {
            GameManager.gm.HidePUZZLE1Guide();
        }
    }
    private void FixedUpdate()
    {
        if (direction != Vector3.zero)
        {
            rb.velocity = direction * speed;
            //characterController.Move(direction * speed * Time.deltaTime);
            Rotate();
        }
    }
    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            holdingMouse = true;
            if (PlayerRaycast())
            {
                //Debug
                Debug.Log(playerHit.collider.name);
                Debug.Log("HitSomething");

                interactedObject = playerHit.collider.gameObject;

            }
            else
            {
                //Debug
                Debug.Log("HitNothing");
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (interactedObject != null)
            {

            }
        }
    }
    private void Rotate()
    {
        PlayerCharacter.transform.LookAt(new Vector3(PlayerCharacter.transform.position.x + Input.GetAxis("Horizontal"), PlayerCharacter.transform.position.y, PlayerCharacter.transform.position.z + Input.GetAxis("Vertical")));
    }
    
    public bool PlayerRaycast()
    {
        if (Physics.Raycast(PlayerCharacter.transform.position, PlayerCharacter.transform.forward, out playerHit, 2, interactable))
        {
            Debug.DrawLine(PlayerCharacter.transform.position, PlayerCharacter.transform.position+ PlayerCharacter.transform.forward, Color.green,1);
            return true;
        }
        return false;
    }
    public bool ScreenRaycast()
    {
        if (Physics.Raycast(mouseRay, out mouseHit, 100))
        {
            return true;
        }
        return false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PuzzleObject"))
        {
            Puzzle1 puzzleManager = FindObjectOfType<Puzzle1>();
            if (puzzleManager != null)
            {
                puzzleManager.HandleObjectCollision(other.gameObject);
            }
        }
        if (other.CompareTag("PZ1Totem"))
        {
            Debug.Log("Teste");
            pressFcheck = true;
        }
    }
}
