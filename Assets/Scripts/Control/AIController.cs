using UnityEngine;
using RPG.Combat;
using RPG.Core;

namespace RPG.Control
{
    public class AIController : MonoBehaviour 
    {

        /*
            Reuse of the fighter methods for simular acts and damage.
        */

        [SerializeField] float chaseDistance = 5f;  //distance in which they attack

        Fighter fighter;
        Health health;
        GameObject player;

        private void Start() 
        {
            fighter = GetComponent<Fighter>();  
            health = GetComponent<Health>(); 
            player = GameObject.FindWithTag("Player"); //the tag of the player
        }

        /*Check if player is in distance. If so attack*/
        private void Update()
        {

            if(InAttackRangeOfPlayer() && fighter.CanAttack(player))
            { 
                fighter.Attack(player);
            }
            else 
            {
                fighter.Cancel(); //cancel chase 
            }
        }

        /*Calculate distance from AI position and player position*/
        private bool InAttackRangeOfPlayer()
        {
           float distanceOfPlayer = Vector3.Distance(player.transform.position, transform.position); //distance between a and b
           return distanceOfPlayer < chaseDistance; //return true if chasedistance is bigger than the distance to the player.
        }

        //called by Unity. Character selected -> Show Gizmo
        private void OnDrawGizmosSelected() 
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);   //position of character + the chase distance
        }



    }



}