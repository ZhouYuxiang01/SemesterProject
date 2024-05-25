using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;
    [SerializeField] AudioClip hoverSound;
    [SerializeField] AudioClip clickSound;

    private bool isSelected = false;

    // Called when the cursor enters the button area
    public void OnPointerEnter(PointerEventData eventData)
    {
        isSelected = true;
        animator.SetBool("selected", true);
        menuButtonController.SetIndex(thisIndex);
        animatorFunctions.PlaySound(hoverSound); // Play hover sound
    }

    // Called when the cursor exits the button area
    public void OnPointerExit(PointerEventData eventData)
    {
        isSelected = false;
        animator.SetBool("selected", false);
    }

    // Called when the button is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isSelected)
        {
            animator.SetBool("pressed", true);
            StartCoroutine(ResetPressedState());
            animatorFunctions.PlaySound(clickSound);
        }
    }

    // Coroutine to reset the pressed state after a short delay
    private IEnumerator ResetPressedState()
    {
        yield return new WaitForEndOfFrame();
        animator.SetBool("pressed", false);
        animatorFunctions.disableOnce = true;
    }
}
