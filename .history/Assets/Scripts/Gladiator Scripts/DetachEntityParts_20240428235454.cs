using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachEntityParts : MonoBehaviour
{
    public void detachHead()
    {
        Transform gladiatorModel = gameObject.transform.Find("GladiatorModel");

        Transform foundHead = gladiatorModel.Find("head");

        Transform foundTorsoBone = gladiatorModel.Find("torso_bone");

        Transform foundHeadBone = foundTorsoBone.Find("head_bone");

        if (foundHead != null && foundHeadBone != null)
        {
            Vector3 headPosition = foundHead.position;

            GameObject detachedHeadObject = new GameObject("DetachedHeadObject");
            detachedHeadObject.transform.position = headPosition;

            DetachedHeadController controller = detachedHeadObject.AddComponent<DetachedHeadController>();

            GameObject detachedHead = new GameObject("DetachedHead");

            SpriteRenderer detachedRenderer = detachedHead.AddComponent<SpriteRenderer>();
            detachedHead.GetComponent<SpriteRenderer>().sprite = foundHead.GetComponent<SpriteRenderer>().sprite;
            detachedHead.GetComponent<SpriteRenderer>().color = foundHead.GetComponent<SpriteRenderer>().color;
            detachedHead.GetComponent<SpriteRenderer>().sortingLayerName = foundHead.GetComponent<SpriteRenderer>().sortingLayerName;
            detachedHead.GetComponent<SpriteRenderer>().sortingOrder = foundHead.GetComponent<SpriteRenderer>().sortingOrder;
            

            GameObject detachedHeadBone = Instantiate(foundHeadBone.gameObject);

            detachedHeadBone.transform.position = new Vector3(detachedHead.transform.position.x, detachedHead.transform.position.y/2, detachedHead.transform.position.z);
            detachedHeadBone.transform.rotation = Quaternion.Euler(detachedHead.transform.rotation.x, detachedHead.transform.rotation.y, 90);

            detachedHead.transform.SetParent(detachedHeadObject.transform);
            detachedHeadBone.transform.SetParent(detachedHeadObject.transform);

            foundHead.gameObject.SetActive(false);
            foundHeadBone.gameObject.SetActive(false);

            detachedHeadObject.transform.localScale = Vector3.one;
            detachedHeadObject.transform.localScale = foundHead.lossyScale;

            float randomAngle = Random.Range(-15f, 15f);
            float randomLaunchForce = Random.Range(1.4f, 3f);

            Vector2 launchDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.up;
            Rigidbody2D rb = detachedHeadObject.AddComponent<Rigidbody2D>();

            rb.mass = 0.5f;
            rb.drag = 0.5f;

            rb.AddForce(launchDirection * randomLaunchForce, ForceMode2D.Impulse);

            rb.angularVelocity = 100f;
        }
    }

    public void detachTorso()
    {
        Transform foundChest = transform.Find("chest");

        if (foundChest != null)
        {
            Vector3 headPosition = foundChest.position;

            GameObject detachedChest = new GameObject("DetachedChest");
            detachedChest.transform.position = headPosition;

            SpriteRenderer detachedRenderer = detachedChest.AddComponent<SpriteRenderer>();

            SpriteRenderer originalRenderer = foundChest.GetComponent<SpriteRenderer>();
            
            DetachedHeadController controller = detachedChest.AddComponent<DetachedHeadController>();

            if (originalRenderer != null)
            {
                detachedRenderer.sprite = originalRenderer.sprite;

                detachedChest.transform.localScale = Vector3.one;
                detachedChest.transform.localScale = foundChest.lossyScale;

                float randomAngle = Random.Range(-15f, 15f);
                float randomLaunchForce = Random.Range(1, 3);

                Vector2 launchDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.up;
                Rigidbody2D rb = detachedChest.AddComponent<Rigidbody2D>();

                rb.mass = 0.5f;
                rb.drag = 0.5f;

                rb.AddForce(launchDirection * randomLaunchForce, ForceMode2D.Impulse);

                rb.angularVelocity = 100f;
            }

            foundChest.gameObject.SetActive(false);
        }
    }

    public void DetachTorsoAndLimbs()
    {

        Transform torso = transform.Find("chest");

        GameObject detachedTorsoParts = new GameObject();
        detachedTorsoParts.transform.position = torso.transform.position;
        detachedTorsoParts.transform.rotation = Quaternion.identity;

        DetachedHeadController controller = detachedTorsoParts.AddComponent<DetachedHeadController>();

        detachedTorsoParts.transform.position = torso.transform.position;
        detachedTorsoParts.transform.SetParent(gameObject.transform);

        Transform leftArm = transform.Find("left_arm");
        Transform rightArm = transform.Find("right_arm");
        Transform leftForearm = transform.Find("left_forearm");
        Transform rightForearm = transform.Find("right_forearm");
        Transform head = transform.Find("Head");

        GameObject detachedTorso = new GameObject("DetachedTorso");
        detachedTorso.transform.position = torso.transform.position;
        SpriteRenderer detachedRenderertorso = detachedTorso.AddComponent<SpriteRenderer>();
        SpriteRenderer originalRenderertorso= torso.GetComponent<SpriteRenderer>();
        detachedRenderertorso.sprite = originalRenderertorso.sprite;
        detachedTorso.transform.localScale = Vector3.one;
        detachedTorso.transform.localScale = torso.lossyScale;

        GameObject detachedleftArm = new GameObject("DetachedLeftArm");
        detachedleftArm.transform.position = leftArm.transform.position;
        SpriteRenderer detachedRendererleftarm = detachedleftArm.AddComponent<SpriteRenderer>();
        SpriteRenderer originalRendererleftarm = leftArm.GetComponent<SpriteRenderer>();
        detachedRendererleftarm.sprite = originalRendererleftarm.sprite;
        detachedleftArm.transform.localScale = Vector3.one;
        detachedleftArm.transform.localScale = leftArm.lossyScale;

        GameObject detachedrightArm = new GameObject("DetachedRightArm");
        detachedrightArm.transform.position = rightArm.transform.position;
        SpriteRenderer detachedRendererrightarm = detachedrightArm.AddComponent<SpriteRenderer>();
        SpriteRenderer originalRendererrightarm = rightArm.GetComponent<SpriteRenderer>();
        detachedRendererrightarm.sprite = originalRendererrightarm.sprite;
        detachedrightArm.transform.localScale = Vector3.one;
        detachedrightArm.transform.localScale = rightArm.lossyScale;

        GameObject detachedrightForeArm = new GameObject("DetachedRightForeArm");
        detachedrightForeArm.transform.position = rightForearm.transform.position;
        SpriteRenderer detachedRendererrightforearm = detachedrightForeArm.AddComponent<SpriteRenderer>();
        SpriteRenderer originalRendererrightforearm = rightForearm.GetComponent<SpriteRenderer>();
        detachedRendererrightforearm.sprite = originalRendererrightforearm.sprite;
        detachedrightForeArm.transform.localScale = Vector3.one;
        detachedrightForeArm.transform.localScale = rightForearm.lossyScale;

        GameObject detachedleftForeArm = new GameObject("DetachedLeftForeArm");
        detachedleftForeArm.transform.position = leftForearm.transform.position;
        SpriteRenderer detachedRendererleftforearm = detachedleftForeArm.AddComponent<SpriteRenderer>();
        SpriteRenderer originalRendererleftforearm = leftForearm.GetComponent<SpriteRenderer>();
        detachedRendererleftforearm.sprite = originalRendererleftforearm.sprite;
        detachedleftForeArm.transform.localScale = Vector3.one;
        detachedleftForeArm.transform.localScale = leftForearm.lossyScale;

        GameObject detachedHead= new GameObject("DetachedHead");
        detachedHead.transform.position = head.transform.position;
        SpriteRenderer detachedRendererHead= detachedHead.AddComponent<SpriteRenderer>();
        SpriteRenderer originalRendererHead = head.GetComponent<SpriteRenderer>();
        detachedRendererHead.sprite = originalRendererHead.sprite;
        detachedHead.transform.localScale = Vector3.one;
        detachedHead.transform.localScale = head.lossyScale;

        Transform torsoBone = transform.Find("torso_bone");
        GameObject detachedBoneTorso = Instantiate(torsoBone.gameObject, torsoBone.position, Quaternion.identity);
        detachedBoneTorso.transform.localScale = Vector3.one;
        detachedBoneTorso.transform.localScale = torso.lossyScale;

        detachedTorso.transform.SetParent(detachedTorsoParts.transform);
        detachedleftArm.transform.SetParent(detachedTorsoParts.transform);
        detachedrightArm.transform.SetParent(detachedTorsoParts.transform);
        detachedrightForeArm.transform.SetParent(detachedTorsoParts.transform);
        detachedleftForeArm.transform.SetParent(detachedTorsoParts.transform);
        detachedHead.transform.SetParent(detachedTorsoParts.transform);
        detachedBoneTorso.transform.SetParent(detachedTorsoParts.transform);

        float randomAngle = Random.Range(-15f, 15f);
        float randomLaunchForce = Random.Range(1, 3);

        Vector2 launchDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.up;
        Rigidbody2D rb = detachedTorsoParts.AddComponent<Rigidbody2D>();

        rb.mass = 0.5f;
        rb.drag = 0.5f;

        rb.AddForce(launchDirection * randomLaunchForce, ForceMode2D.Impulse);

        rb.angularVelocity = 100f;

        torso.gameObject.SetActive(false);
        leftArm.gameObject.SetActive(false);
        rightArm.gameObject.SetActive(false);
        leftForearm.gameObject.SetActive(false);
        rightForearm.gameObject.SetActive(false);
        head.gameObject.SetActive(false);
        torsoBone.gameObject.SetActive(false);
    }
}
