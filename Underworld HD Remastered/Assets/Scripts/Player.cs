using UnityEngine;

public class Player : MonoBehaviour
{
    #region Consts

    public const float POS_X = 0.011f;
    public const float POS_Y = 1.16f;

    #endregion

    #region Value types

    private int lives = 3;
    private float resetPoint = -30f;

    #endregion

    #region Reference types

    private GameObject respawnGameObject;
    private Respawn respawnScript;

    #endregion

    #region Unity messages

    /// <summary>
    /// Get the respawn game object and script.
    /// </summary>
    private void Awake()
    {
        respawnGameObject = GameObject.FindGameObjectWithTag("Respawn");

        respawnScript = FindObjectOfType<Respawn>();
    }

    // Update is called once per frame
    void Update()
    {
        // When the x value from the player doesn't match with respawn point, ...
        if (transform.position.x != (respawnGameObject.transform.position.x - POS_X))
        {
            // ...than set the player on this x point.
            transform.position = new Vector3
            (
                (respawnGameObject.transform.position.x - POS_X),
                transform.position.y,
                transform.position.z
            );
        }

        // When the player fall from the platform, than set the player position on the start position.
        if (transform.position.y < resetPoint)
            respawnScript.StartPosition();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Return/Set life from player.
    /// </summary>
    public int Life
    {
        get { return lives; }
        set { lives = value; }
    }

    #endregion
}