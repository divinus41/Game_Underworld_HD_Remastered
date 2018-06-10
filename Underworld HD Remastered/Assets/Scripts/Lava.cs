using UnityEngine;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{
    #region System functions

    private void OnTriggerEnter(Collider other)
    {
        // Declare variables
        Player playerScript = FindObjectOfType<Player>();
        Respawn respawnScript = FindObjectOfType<Respawn>();
        LiveDisplay liveDisplayScript = FindObjectOfType<LiveDisplay>();

        if (playerScript != null)
        {
            if (playerScript.Life > 0)
            {
                playerScript.Life--;

                if (respawnScript != null)
                    respawnScript.StartPosition();

                if (liveDisplayScript != null)
                    liveDisplayScript.SetHearts();
            }
            else
            {
                SceneManager.LoadScene(3); // Load lose screen
            }
        }
    }

    #endregion
}
