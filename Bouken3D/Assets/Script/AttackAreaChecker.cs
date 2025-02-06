using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaChecker : MonoBehaviour
{
    public bool invaded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
  {
        // “GƒLƒƒƒ‰‚ÌŒŸo”ÍˆÍ‚É“ü‚Á‚½ê‡
        if (other.gameObject.name == "Gecko")
        {
            invaded = true;
        }
  }


}
