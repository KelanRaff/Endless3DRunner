using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]private float startingHealth;
    public float currentHealth {get; private set;}
    private Animator anim;
    private bool dead;

    private void Awake(){
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(currentHealth > 0){
            //playerhurt
            anim.SetTrigger("hurt");
        }else{
            if(!dead){
                //player dead
            anim.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false;
            dead = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E))
        TakeDamage(1);
    }

}
