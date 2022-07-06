using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
   [SerializeField]private int nextLevelIndex;
    [SerializeField]private int homeLevelIndex;
   private void OnTriggerEnter2D(Collider2D collision) 
   {
       if (collision.gameObject.tag=="Player")
       {
           ChangeScene();
       }
   }
   public void ChangeScene(){
       SceneManager.LoadScene(nextLevelIndex);
   }
 public void Home_button(){
       SceneManager.LoadScene(homeLevelIndex);
   }
}
