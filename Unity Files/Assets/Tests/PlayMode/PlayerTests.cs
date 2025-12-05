using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PlayerTests
{

    [UnityTest]
    public IEnumerator PlayerExistAndMove()
    {
        // this test loads our main scene and checks for:
        // player existing, player left/right movement working
        SceneManager.LoadScene("test-stage");

        float timePassed = 0f;
        while (timePassed < 2f)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }
        timePassed = 0f;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(player, "Player object must be within the scene");

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rb, "Player is expected to have Rigidbody2D component");

        PlayerController pc = player.GetComponent<PlayerController>();

        float TestOut = pc.MoveTest("Left", 10);
        Assert.Less(0, TestOut);

        TestOut = pc.MoveTest("Right", 10);
        Assert.Greater(0, TestOut);

    }
}
