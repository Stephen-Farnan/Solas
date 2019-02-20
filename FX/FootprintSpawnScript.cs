using UnityEngine;

public class FootprintSpawnScript : MonoBehaviour
{

    #region
    public bool snowFootprints = false;
    public GameObject footprintPrefab;
    public Animator playerAnim;
    public Transform spawnPointLeft;
    public Transform spawnPointRight;
    private ParticleSystem psLeft;
    private ParticleSystem psRight;
    [Space]
    public int maxFootprints;

    private float timer;
    private bool leftSpawn = false;

    private int currentFootprints = 0;
    private GameObject[] footprints;

    [Space]
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip[] footprintClips;
    public AudioClip[] iceFootprintClips;
    public AudioClip[] rockFootprintClips;
    private AudioClip[] currentFootprintClips;
    private int footprintClip = 0;

    public enum FootPrintSound { snow, ice, rock }
    #endregion

    void Start()
    {
        footprints = new GameObject[maxFootprints + 4];
        psLeft = spawnPointLeft.GetComponent<ParticleSystem>();
        psRight = spawnPointRight.GetComponent<ParticleSystem>();
        currentFootprintClips = footprintClips;
    }



    /// <summary>
    /// Spawns footprint projections on the ground below the player
    /// </summary>
    void SpawnFootprints()
    {
        Transform spawnPoint;

        if (snowFootprints)
        {
            if (leftSpawn)
            {
                spawnPoint = spawnPointLeft;
                psLeft.Emit(4);
            }
            else
            {
                spawnPoint = spawnPointRight;
                psRight.Emit(4);
            }

            //Spawn footprint projection
            GameObject footprintForArray = Instantiate(footprintPrefab, new Vector3(spawnPoint.position.x, spawnPoint.position.y + 0.3f, spawnPoint.position.z),
                transform.rotation * Quaternion.Euler(new Vector3(90, 0, 90)));

            currentFootprints++;
            footprints[currentFootprints - 1] = footprintForArray;

            if (currentFootprints > maxFootprints)
            {
                ReplaceFootprint();
            }
        }

        PlayFootprintSound();
        leftSpawn = !leftSpawn;
    }

    /// <summary>
    /// Fades out older footprints when new ones are made
    /// </summary>
    void ReplaceFootprint()
    {
        GameObject toDestroy = footprints[0];
        Destroy(toDestroy, 3);

        footprints[0].GetComponent<Animator>().SetTrigger("Fade");
        footprints[0] = null;
        currentFootprints--;
        for (int i = 0; i < footprints.Length - 1; i++)
        {
            footprints[i] = footprints[i + 1];
        }
    }

    void PlayFootprintSound()
    {
        footprintClip++;
        if (footprintClip > footprintClips.Length - 1)
        {
            footprintClip = 0;
        }
        audioSource.clip = currentFootprintClips[footprintClip];
        audioSource.Play();
    }

    public void ChangeFootprintSound(FootPrintSound footprintSound)
    {
        switch (footprintSound)
        {
            case FootPrintSound.snow:
                currentFootprintClips = footprintClips;
                break;
            case FootPrintSound.ice:
                currentFootprintClips = iceFootprintClips;
                break;
            case FootPrintSound.rock:
                currentFootprintClips = rockFootprintClips;
                break;
            default:
                break;
        }
    }
}
