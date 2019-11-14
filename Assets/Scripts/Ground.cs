using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject holePrefab;
    public GameObject spikePrefab;
    public GameObject pillarPrefab;

    public Guardian guardian;

    public bool isActive;

    void OnMouseDown() {
        if (!isActive)
            return;
        if (guardian.mode == 1) {
            Instantiate(holePrefab, transform.position, holePrefab.transform.rotation);
            Destroy(this.gameObject);
        } else if (guardian.mode == 2) {
            var spikes = Instantiate(spikePrefab, transform.position, spikePrefab.transform.rotation);
            spikes.GetComponent<Spike>().SetMoveUp();
            isActive = false;
        } else if (guardian.mode == 3) {
            var pillar = Instantiate(pillarPrefab, new Vector3(transform.position.x, -1, transform.position.z), pillarPrefab.transform.rotation);
            pillar.GetComponent<Pillar>().SetMoveUp();
            isActive = false;
        }
    }
}
