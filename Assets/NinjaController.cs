using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    private Camera mainCamera;
    private float lastAngle = 0f;
    public float SpeedScale;

    private float mainAttackCooldDown;
    private float secondaryAttackCoolDown;
    private float utilityCooldown;

    [SerializeField]
    public Attack CurrentMainAttack;
    public Attack CurrentSecondaryAttack;
    public Utility CurrentUtility;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        mainAttackCooldDown = 0;
        secondaryAttackCoolDown = 0;
        utilityCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var vert = Input.GetAxis("Vertical");
        var hori = Input.GetAxis("Horizontal");
        UpdateMovment(vert, hori);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MainAttack();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            SecondaryAttack();
        }
    }

    private void UpdateMovment(float vert, float hori)
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, maxDistance: 100f, hitInfo: out RaycastHit hit))
        {
            gameObject.transform.LookAt(hit.point, Vector3.up);
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, gameObject.transform.rotation.eulerAngles.y, 0));

        }

        var direction = new Vector3(hori, 0, vert).normalized;
        var dis = Vector3.Distance(direction, gameObject.transform.forward);

        if (hori == 0 && vert == 0)
        {
            animator.SetBool("moving", false);
        }
        else
        {
            animator.SetBool("moving", true);
            animator.speed = 1 / ((dis + 1) / 3);
        }

        gameObject.transform.position += ((direction * SpeedScale) / (dis + 1)) * Time.deltaTime;

        if (Physics.Raycast(gameObject.transform.position, Vector3.down, out RaycastHit raycastHit))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, raycastHit.point.y + 0.2f, gameObject.transform.position.z);
        }


        //if(vert != 0 || hori != 0)
        //    gameObject.transform.forward = direction;
        //var newAngle = Vector3.Angle(Vector3.zero, direction);
        //var angleDiff = newAngle - lastAngle;
    }

    public void MainAttack()
    {
        if (Time.time > mainAttackCooldDown)
        {
            animator.SetTrigger("slash");
            CurrentMainAttack.Invoke(gameObject.transform.position, gameObject.transform.forward);
            mainAttackCooldDown = Time.time + CurrentMainAttack.cooldown;
        }
    }

    public void SecondaryAttack()
    {
        if (Time.time > secondaryAttackCoolDown)
        {
            CurrentSecondaryAttack.Invoke(gameObject.transform.position, gameObject.transform.forward);
            secondaryAttackCoolDown = Time.time + CurrentSecondaryAttack.cooldown;
        }
    }

    public void Utitility()
    {
        if (Time.time > utilityCooldown)
        {
            CurrentUtility.Invoke(this.gameObject);
            mainAttackCooldDown = Time.time + CurrentUtility.cooldown;
        }
    }

}

public abstract class Utility : MonoBehaviour
{
    public float cooldown;
    public abstract void Invoke(GameObject source);
}

public abstract class Attack : MonoBehaviour
{
    public int damage;
    public float cooldown;
    public GameObject Ignore;
    public abstract void Invoke(Vector3 sourcePos, Vector3 sourceDir);
}
