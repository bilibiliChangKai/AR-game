using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerativePiece : MonoBehaviour {

    public AnimationClip generateAnimation;

    protected GamePiece piece;

    void Awake()
    {
        piece = GetComponent<GamePiece>();
        //this.GetComponent<Material>().color = new Color(1, 1, 1, 0);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Generate()
    {
        StartCoroutine(GenerateCoroutine());
    }

    private IEnumerator GenerateCoroutine()
    {
        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            //print("enter");
            //print(this.transform.position);
            animator.Play(generateAnimation.name);

            yield return new WaitForSeconds(generateAnimation.length);

            Destroy(this);
        }
    }
}
