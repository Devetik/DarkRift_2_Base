using UnityEngine;
using DarkRift.Client.Unity;
using DarkRift;

public class NetworkingManager : MonoBehaviour
{
    public UnityClient client;

    public void OnClickTestButton()
    {
        using (DarkRiftWriter writer = DarkRiftWriter.Create())
        {
            writer.Write("Click du bouton test");
            using (Message message = Message.Create(4, writer))
            {
                client.SendMessage(message, SendMode.Reliable);
            }
        }
    }
}
