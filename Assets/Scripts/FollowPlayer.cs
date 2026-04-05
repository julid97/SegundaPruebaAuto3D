using UnityEngine;

public class FollowPlayer : MonoBehaviour

{

    public GameObject player;
    //3rd persona camera
    [SerializeField] private Vector3 offset = new Vector3(0, 7, -10);
    //1st person camera
    private Vector3 povOffset = new Vector3(0, 2.5f, 1.0f);
    // Boolean to track whether the camera is in first-person view.
    private bool isFirstPerson = false;

    // Update is called once per frame
    void LateUpdate()
    {
        // Check if the camera should be in first-person mode
        if (isFirstPerson)
        {
            // Set the camera position for first-person view using the `povOffset`.
            transform.position = player.transform.position + povOffset;
        }

        else

        {
            // Set the camera position for third-person view using the `offset`.
            transform.position = player.transform.position + offset;
        }

        // Check if the "V" key is pressed to toggle the camera view.
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchCameraView(); // Call the method to switch between views.
        }
    
    }


    // Method to toggle the camera between first-person and third-person views.
    void SwitchCameraView()
    {
        // Toggle the value of `isFirstPerson` (true becomes false, false becomes true).
        isFirstPerson = !isFirstPerson;
    }
}
