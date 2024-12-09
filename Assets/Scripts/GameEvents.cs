using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents
{
    public static UnityEvent PlayerHurt = new UnityEvent();
    public static UnityEvent PlayerDied = new UnityEvent();
    public static UnityEvent CollectibleEarned = new UnityEvent();
   
    //GameEvents.EVENTO.AddListener(FUNCION);    Espera a que el invoke se ejecute y determina las funciones que queremos que haga
    //GameEvents.EVENTO.Invoke();                Invoca dichas funciones que estan en el listener
}
