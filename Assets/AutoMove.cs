using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour {

    //questo script prevede di determinare i movimenti e le azioni compiute volontariamente o automaticamente dal giocatore

    private bool grounded = false; //variabile utilizzata per determinare quando il giocatore è a contatto con il suolo
    private float maxSpeed = 3f; //velocità in movimento
    private float jumpHeight = 9f; //altezza salto
    public Animator anim; //animator per richiamare le animazioni del personaggio 


    public static int coinCount; //contatore per tener traccia delle monete raccolte: si azzera se si perde il livello
    public static int coinPlayer;//contatore monete totali raccolte

    public AudioClip coinclip; //audio della raccolta delle monete
    public AudioClip levelclip; //audio di sottofondo del livello
    public AudioClip enemyclip; //audio innescato a contatto con un nemico
    public AudioClip endclip; //audio di fine livello (vittoria)


    private void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(levelclip);
        
    }


    private void OnCollisionEnter2D(Collision2D collision) //quando viene rilevata una collisione, il seguente metodo permette di determinare la conseguente azione che deve essere svolta
    {
        if (collision.gameObject.tag == "GroundCheck")
        {
            grounded = true; //ogni volta che il personaggio impatta su qualsiasi oggetto designato come terreno, la variabile è settata
        }

        if (collision.gameObject.tag == "Coin")
        {
            GetComponent<AudioSource>().PlayOneShot(coinclip);

            Destroy(collision.gameObject); //ogni volta che il personaggio collide con una moneta, essa viene distrutta e il contatore incrementato
            coinCount++; //si incrementa il contatore locale
        }

        if(collision.gameObject.tag == "Enemy")
        {
            //al contatto con un nemico, il personaggio del giocatore viene freezato, dopodichè si attiva la routine indicata

            grounded = false;
            anim.enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            GetComponent<Rigidbody2D>().gravityScale = 0;
            StartCoroutine("lostRoutine");
        }

        if (collision.gameObject.tag == "EndLevel")
        {
            grounded = false;
            anim.Play("Wolf_Idle");
            StartCoroutine("winRoutine"); //ogni volta che il personaggio raggiunge l'oggetto (albero) designato come fine livello, carichiamo la scena LevelWin
        }
    }

    private void FixedUpdate()
    {
        if (grounded == true)
        {
            anim.Play("Wolf_run"); 
            GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, GetComponent<Rigidbody2D>().velocity.y); //il personaggio corre automaticamente quando impatta un oggetto designato come terreno
        }
        if(grounded == true && (Input.GetKey(KeyCode.Space) || Input.touchCount > 0))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse); //nel caso in cui il personaggio sia sul terreno ed il tasto relativo al salto venga premuto, il personaggio salta
            grounded = false;                                                                   //notare che la variabile grounded è resettata, ma tornerà true non appena il personaggio ritoccherà il terreno
        }                                                                                       //NB: da implementare il supporto all'input del controller del visore

    }

    //routine di sconfitta: si carica l'audio appropriato, si attende un timeout di 4 sec e si azzera il contatore locale, poi si carica la scena di sconfitta
    
    IEnumerator lostRoutine()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(enemyclip);
        yield return new WaitForSeconds(4);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        coinCount = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelLose");
    }

    //routine di vittoria: si carica l'audio appropriato, si attende un timeout di 4 sec e si aggiorna il contatore globale del giocatore

    IEnumerator winRoutine()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(endclip);
        yield return new WaitForSeconds(4);
        coinPlayer = coinPlayer + coinCount;
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelWin");
    }
}
