using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Friction
{
    public class FrictionHandler : MonoBehaviour
    {
        public static FrictionHandler instance;

        public GameObject Desk;
        int position;
        int i = 0;
        Vector3 newPostion;
        public Vector3 targetPostion;
        MoveObject moveObject;
        public Text SurfaceName;
        public Material[] materials;
        public PhysicMaterial[] pMaterials;
        public int currentTexture;
        public Renderer _renderer;
        public GameObject ArrowC, Surfaces;
        public Button[] surfaceButton;

        // Greec values
        public float hGreesDrag = 0.625f;
        public float fGreesDrag = 0.3f;
        public float tGreesDrag = 0.025f;

        // Oily values
        public float hOilyDrag = 1.25f;
        public float fOilyDrag = 0.625f;
        public float tOilyDrag = 0.05f;

        //smooth drag values
        public float hSmoothDrag = 2.5f;
        public float fSmoothDrag = 1.25f;
        public float tSmoothDrag = 0.25f;

     

        //Slightly Rough values
        public float hSlightlyRoughDrag = 5f;
        public float fSlightlyRoughDrag = 2.5f;
        public float tSlightlyRoughDrag = 0.5f;

        //Very Rough values
        public float hVeryRoughDrag = 10f;
        public float fVeryRoughDrag = 5f;
        public float tVeryRoughDrag = 1f;

        public Mesh smoothMesh;
        public Mesh slightlyRoughMesh;
        public Mesh veryRoughMesh;

        public Button dropArrowButton;
        private void Awake()
        {
            instance = this;
            newPostion = targetPostion;

            //moveObject = MoveObject.instance;

        }

       
        public void GreasySelected()
        {
            _renderer.material = materials[0];
            Desk.GetComponent<MeshFilter>().mesh = smoothMesh;
            Desk.GetComponent<Collider>().sharedMaterial = pMaterials[0];
            SurfaceName.text = "Greasy Surface";
            ArrowC.SetActive(true);
            Surfaces.SetActive(false);

            //Drag value set
            HandMove.instance.hundredDrag =hGreesDrag;
            HandMove.instance.fiftyDrag = fGreesDrag;
            HandMove.instance.tenDrag = tGreesDrag;

            if (InstructionDataScriptFriction.instance.isInstructionClick)
            {
                InstructionDataScriptFriction.instance.greesySurfaceI.SetActive(false);
                surfaceButton[0].interactable = false;
                // HandMove.instance.handObject.GetComponent<BoxCollider>().enabled = true;
                UIManager.instance.playPauseButton.GetComponent<Button>().interactable = true;
                InstructionDataScriptFriction.instance.palyGameI.SetActive(true);
               
            }
        }
        public void OilySelected()
        {
            _renderer.material = materials[1];
            Desk.GetComponent<MeshFilter>().mesh = smoothMesh;
            Desk.GetComponent<Collider>().sharedMaterial = pMaterials[1];
            SurfaceName.text = "Oily Surface";
            ArrowC.SetActive(true);
            Surfaces.SetActive(false);

            //Drag value set
            HandMove.instance.hundredDrag = hOilyDrag;
            HandMove.instance.fiftyDrag = fOilyDrag;
            HandMove.instance.tenDrag = tOilyDrag;
        }
        public void SmothSelected()
        {
            _renderer.material = materials[2];
            Desk.GetComponent<MeshFilter>().mesh = smoothMesh;
            Desk.GetComponent<Collider>().sharedMaterial = pMaterials[2];
            SurfaceName.text = "Smooth Surface";
            ArrowC.SetActive(true);
            Surfaces.SetActive(false);

            //Drag value set
            HandMove.instance.hundredDrag = hSmoothDrag;
            HandMove.instance.fiftyDrag = fSmoothDrag;
            HandMove.instance.tenDrag = tSmoothDrag;
        }
        public void SlightlyRoughSelected()
        {
            _renderer.material = materials[3];
            Desk.GetComponent<MeshFilter>().mesh = slightlyRoughMesh;
            Desk.GetComponent<Collider>().sharedMaterial = pMaterials[3];
            SurfaceName.text = "Slightly Rough Surface";
            ArrowC.SetActive(true);
            Surfaces.SetActive(false);

            //Drag value set
            HandMove.instance.hundredDrag = hSlightlyRoughDrag;
            HandMove.instance.fiftyDrag = fSlightlyRoughDrag;
            HandMove.instance.tenDrag = tSlightlyRoughDrag;
        }
        public void VeryRoughSelected()
        {
            _renderer.material = materials[4];
            Desk.GetComponent<MeshFilter>().mesh = veryRoughMesh;
            Desk.GetComponent<Collider>().sharedMaterial = pMaterials[4];
            SurfaceName.text = "Very Rough  Surface";
            ArrowC.SetActive(true);
            Surfaces.SetActive(false);

            //Drag value set
            HandMove.instance.hundredDrag = hVeryRoughDrag;
            HandMove.instance.fiftyDrag = fVeryRoughDrag;
            HandMove.instance.tenDrag = tVeryRoughDrag;
        }


        public void ResetSolid()
        {
            HandMove.instance.resetBoxButton.SetActive(false);
            GetValues.instance.isSelectSurfaceDown = false;
            GetValues.instance.goneSerface();
          //  HandMove.instance.playButton.SetActive(true);
           // HandMove.instance.pauseButton.SetActive(false);
            HandMove.instance.hundredDrag = hSmoothDrag;
            HandMove.instance.fiftyDrag = fSmoothDrag;
            HandMove.instance.tenDrag = tSmoothDrag;
            TenKGBoxMove.instance.isBoxInitialPos = true;
            TenKGBoxMove.instance.OnMouseDown();
            FiftyKGBOxMove.instance.isBoxInitialPos = true;
            FiftyKGBOxMove.instance.OnMouseDown();
            HundredKGBoxMove.instance.isBoxInitialPos = true;
            HundredKGBoxMove.instance.OnMouseDown();
            //HandMove.instance.handObject.SetActive(false);
            SolidMediumController.instance.forceSlider.value = 0;
            SolidMediumController.instance.ChangeForceSlider(0);

            //freeze rotation
            TenKGBoxMove.instance.rb.freezeRotation = true;
            FiftyKGBOxMove.instance.rb.freezeRotation = true;
            HundredKGBoxMove.instance.rb.freezeRotation = true;

 
            UIManager.instance.playPauseButton.GetComponent<Button>().interactable = true;
            UIManager.instance.slowButton.interactable = true;

            TenKGBoxMove.instance.redArrowFriction.SetActive(false);
            TenKGBoxMove.instance.blueArrowPushForce.SetActive(false);
            FiftyKGBOxMove.instance.redArrowFriction.SetActive(false);
            FiftyKGBOxMove.instance.blueArrowPushForce.SetActive(false);
            HundredKGBoxMove.instance.redArrowFriction.SetActive(false);
            HundredKGBoxMove.instance.blueArrowPushForce.SetActive(false);
        }
      
    }
}







