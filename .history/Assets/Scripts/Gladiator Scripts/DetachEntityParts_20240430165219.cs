using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachEntityParts : MonoBehaviour
{
    public GameObject detachedHeadPrefab;

    public void detachHead()
    {
        Transform detachedHeadPrefabPos = detachedHeadPrefab.transform.Find("headPos");
        Transform detachedHeadBonePrefabPos = detachedHeadPrefab.transform.Find("headBonePos");

        Transform gladiatorModel = gameObject.transform.Find("GladiatorModel");

        Transform foundHead = gladiatorModel.Find("head");

        Transform foundTorsoBone = gladiatorModel.Find("torso_bone");

        Transform foundHeadBone = foundTorsoBone.Find("head_bone");

        if (foundHead != null && foundHeadBone != null)
        {
            Vector3 headPosition = foundHead.position;

            GameObject detachedHeadObject = new GameObject("DetachedHeadObject");
            detachedHeadObject.transform.position = headPosition;
            detachedHeadObject.transform.rotation = foundHead.transform.rotation;

            DetachedHeadController controller = detachedHeadObject.AddComponent<DetachedHeadController>();

            GameObject detachedHead = new GameObject("DetachedHead");
            detachedHead.transform.SetParent(detachedHeadObject.transform);

            SpriteRenderer detachedRenderer = detachedHead.AddComponent<SpriteRenderer>();
            detachedHead.GetComponent<SpriteRenderer>().sprite = foundHead.GetComponent<SpriteRenderer>().sprite;
            detachedHead.GetComponent<SpriteRenderer>().color = foundHead.GetComponent<SpriteRenderer>().color;
            detachedHead.GetComponent<SpriteRenderer>().sortingLayerName = foundHead.GetComponent<SpriteRenderer>().sortingLayerName;
            detachedHead.GetComponent<SpriteRenderer>().sortingOrder = foundHead.GetComponent<SpriteRenderer>().sortingOrder;
            
            GameObject detachedHeadBone = GameObject.Instantiate(foundHeadBone.gameObject,detachedHeadObject.transform);

            detachedHead.transform.localPosition = detachedHeadPrefabPos.position;
            detachedHeadBone.transform.localPosition = detachedHeadBonePrefabPos.position;
            detachedHeadBone.transform.localRotation = Quaternion.Euler(detachedHead.transform.localRotation.x, detachedHead.transform.localRotation.y, 90);

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

        foundHead.gameObject.SetActive(false);
        foundHeadBone.gameObject.SetActive(false);
    }
}
