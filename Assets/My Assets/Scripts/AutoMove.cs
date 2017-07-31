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
    public AudioClip gameEndclip; //audio di fine lv.10



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

        if (collision.gameObject.tag == "FloatGround")
        {
            grounded = true;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1; //il terreno fluttuante diventa soggetto alla gravità solo dopo che il giocatore lo colpisce (ci salta sopra)
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
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 0;
            StartCoroutine("lostRoutine");
        }

        if (collision.gameObject.tag == "EndLevel")
        {
            grounded = false;
            anim.Play("Wolf_Idle");
            StartCoroutine("winRoutine"); //ogni volta che il personaggio raggiunge l'oggetto (albero) designato come fine livello, carichiamo la scena LevelWin
        }

        if (collision.gameObject.tag == "EndGame")
        {
            grounded = false;
            anim.Play("Wolf_Idle");
            StartCoroutine("endRoutine"); //quando il personaggio raggiunge l'oggetto finale (invisibile, lv.10), carichiamo la scena finale
        }
    }

    private void FixedUpdate()
    {
        if (grounded == true)
        {
            anim.Play("Wolf_run"); 
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, GetComponent<Rigidbody2D>().velocity.y); //il personaggio corre automaticamente quando impatta un oggetto designato come terreno
        }

        //NB:nell'input manager Vertical Controller è settato come "joystick button 0", che sul controller Trust corrisponde al tasto A

        if(grounded == true && (Input.GetKey(KeyCode.Space) || Input.touchCount > 0 || Input.GetButton("VerticalController"))) 
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse); //nel caso in cui il personaggio sia sul terreno ed il tasto relativo al salto venga premuto, il personaggio salta
            grounded = false;                                                                   //notare che la variabile grounded è resettata, ma tornerà true non appena il personaggio ritoccherà il terreno
        }            

    }

    //routine di sconfitta: si carica l'audio appropriato, si attende un timeout di 4 sec e si azzera il contatore locale, poi si carica la scena di sconfitta
    
    IEnumerator lostRoutine()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(enemyclip);
        yield return new WaitForSeconds(4);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        coinCount = 0; // azzero contatore locale -> le monete raccolte in un livello perso non devono essere conteggiate ai fini del calcolo delle monete del giocatore
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

    IEnumerator endRoutine()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(gameEndclip);
        yield return new WaitForSeconds(8);
        coinPlayer = coinPlayer + coinCount;
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndWolf");
    }
}
