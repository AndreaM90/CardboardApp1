using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour {

    //questo script prevede di determinare i movimenti e le azioni compiute volontariamente o automaticamente dal giocatore

    private bool grounded = false; //variabile utilizzata per determinare quando il giocatore è a contatto con il suolo
    private float maxSpeed = 3f; //velocità in movimento
    private float jumpHeight = 8f; //altezza salto
    public Animator anim; //animator per richiamare le animazioni del personaggio 


    public static int coinCount = 0; //contatore per tener traccia delle monete raccolte


    private void OnCollisionEnter2D(Collision2D collision) //quando viene rilevata una collisione, il seguente metodo permette di determinare la conseguente azione che deve essere svolta
    {
        if (collision.gameObject.tag == "GroundCheck")
        {
            grounded = true; //ogni volta che il personaggio impatta su qualsiasi oggetto designato come terreno, la variabile è settata
        }

        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject); //ogni volta che il personaggio collide con una moneta, essa viene distrutta e il contatore incrementato
            coinCount++;
        }

        if (collision.gameObject.tag == "EndLevel")
        {
            grounded = false;
            anim.Play("Wolf_Idle");
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelWin"); //ogni volta che il personaggio raggiunge l'oggetto (albero) designato come fine livello, carichiamo la scena LevelWin
        }
    }

    private void Update()
    {
        if (grounded == true)
        {
            anim.Play("Wolf_run"); 
            GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, GetComponent<Rigidbody2D>().velocity.y); //il personaggio corre automaticamente quando impatta un oggetto designato come terreno
        }

        if(grounded == true && Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse); //nel caso in cui il personaggio sia sul terreno ed il tasto relativo al salto venga premuto, il personaggio salta
            grounded = false;                                                                   //notare che la variabile grounded è resettata, ma tornerà true non appena il personaggio ritoccherà il terreno
        }                                                                                       //NB: da implementare il supporto all'input del controller del visore

    }

}
