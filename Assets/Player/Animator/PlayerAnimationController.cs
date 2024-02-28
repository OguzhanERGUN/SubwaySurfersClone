using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }


	public void EndInclineAnimaton()
	{
        if (playerAnimator == null) return;
		playerAnimator.SetBool("Incline", false);
	}

    public void EndJumpAnimation()
    {
		if (playerAnimator == null) return;
		playerAnimator.SetBool("Jump", false);
	}

}
