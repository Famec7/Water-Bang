using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public List<GameObject> pages;
    private int currentPage = 0;

    public GameObject prevButton;
    public GameObject nextButton;

    public void ToPreviousPage()
    {
        if (currentPage == pages.Count - 1)
            nextButton.SetActive(true);
        pages[currentPage].gameObject.SetActive(false);
        currentPage--;
        pages[currentPage].gameObject.SetActive(true);
        if(currentPage == 0)
            prevButton.SetActive(false);
    }
    public void ToNextPage()
    {
        if(currentPage == 0)
            prevButton.SetActive(true);
        pages[currentPage].gameObject.SetActive(false);
        currentPage++;
        pages[currentPage].gameObject.SetActive(true);
        if(currentPage == pages.Count - 1)
            nextButton.SetActive(false);
    }
    public void QuickPage()
    {
        pages[currentPage].gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        currentPage = 0;
        prevButton.SetActive(false);
        nextButton.SetActive(true);
        pages[currentPage].SetActive(true);
    }
}
