using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationMovementManager : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Cuanta gente hay en la lista de jugadores.
    /// </summary>
    private int curr_;
    /// <summary>
    /// Cola de posiciones que van a seguir los acompañantes, para no quedarse atascados en el terreno.
    /// Cambia cada vez que cambia de dirección de movimiento del personaje o cuando uno se queda sin direcciones que seguir.
    /// </summary>
    private List<Queue<(float x, float z)>> playerNextPos_;
    /// <summary>
    /// Booleano que comprueba si se está moviendo el líder
    /// </summary>
    private bool moving_;

    private float xAxis_;

    private float zAxis_;

    (float prevX, float prevZ) prevDir_;

    private Vector3 movDir_;

    private Vector3 otherDir_;
    #endregion

    #region references
    private List<PlayerController> players_;
    #endregion

    #region methods
    /// <summary>
    /// Añade un nuevo 'personaje' a la party. El primero añadido será el líder, el resto seguirán detrás
    /// </summary>
    /// <param name="newplay"></param>
    public void RegisterPlayer(PlayerController newplay)
    {
        players_.Add(newplay);
        if(curr_ > 0)
        {
            Debug.Log(curr_);
            //Añade la cola de posiciones del jugador correspondiente.
            playerNextPos_.Add(new Queue<(float x, float z)>());
            Transform aux = newplay.transform;
            playerNextPos_[curr_ - 1].Enqueue((players_[curr_ - 1].transform.position.x, 
                players_[curr_ - 1].transform.position.z));
        }
        curr_++;
    }

    private (float x, float y) RequestLeaderPosition()
    {
        return (players_[0].transform.position.x, players_[0].transform.position.z);
    }

    private (float x, float y) RequestPreviousPosition(int playernum)
    {
        return (players_[playernum - 1].transform.position.x, players_[playernum - 1].transform.position.z);
    }

    public void SetHorizontalInput(float x)
    {
        xAxis_ = x;
    }

    public void SetVerticalInput(float z)
    {
        zAxis_ = z;
    }
    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        curr_ = 0;
        players_ = new List<PlayerController>();
        playerNextPos_ = new List<Queue<(float x, float z)>>();
        xAxis_ = 0;
        zAxis_ = 0;
        prevDir_ = (0, 0);
        movDir_ = new Vector3(0, 0, 0);
        otherDir_ = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        if(prevDir_ != (xAxis_, zAxis_))
        {
            prevDir_ = (xAxis_, zAxis_);
            movDir_.x = xAxis_;
            movDir_.z = zAxis_;
            if(movDir_ != Vector3.zero)
            {
                players_[0].setDirection(movDir_);
                foreach(PlayerController player in players_)
                {
                    if(i > 0)
                    {
                        Transform aux = player.transform;
                        otherDir_.x = playerNextPos_[i - 1].Peek().x - aux.position.x;
                        otherDir_.z = playerNextPos_[i - 1].Peek().z - aux.position.z;
                        player.setDirection(otherDir_);
                        playerNextPos_[i - 1].Enqueue(RequestLeaderPosition());
                    }
                    i++;
                }
                moving_ = true;
            }
            else
            {
                moving_ = false;
            }
        }
        //Comprobamos todos los personajes y sus queues para saber si hay que girar a los seguidores o incluso añadir direcciones extras
        i = 0;
        foreach(PlayerController player in players_)
        {
            if(moving_ && i > 0)
            {
                Transform aux = player.transform;
                Queue<(float x, float z)> auxilio = playerNextPos_[i - 1];
                (float x, float z) dest = auxilio.Peek();
                if ((dest.x + 0.1 >= aux.position.x && dest.x - 0.1 <= aux.position.x) && (dest.z + 0.1 >= aux.position.z && dest.z - 0.1 <= aux.position.z))
                {
                    if(auxilio.Count < 5)
                    {
                        auxilio.Enqueue(RequestLeaderPosition());
                    }
                    auxilio.Dequeue();
                }
            }
            else
            {
                player.setDirection(movDir_);
            }
            i++;
        }  
    }
}
