using UnityEngine;

using UnityEngine.Rendering;

public class PortalManager : MonoBehaviour
{
    public GameObject Sponza;
    //private Material[] SponzaMaterials;

    //private bool InsideSponza = false;

    private Material PortalPlaneMaterial;
    private bool InsideRoom = false;

    // Use this for initialization
    private void Start()
    {
        //SponzaMaterials = Sponza.GetComponent<Renderer>().sharedMaterials;
        PortalPlaneMaterial = GetComponent<Renderer>().sharedMaterial;
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider collider)
    {
        Camera MainCamera = GameObject.Find("First Person Camera").GetComponent<Camera>();
        Vector3 cameraRelative = MainCamera.transform.InverseTransformPoint(transform.position);

        if (cameraRelative.z > 0) // The portal is in front of the camera
        {
            //this.InsideSponza = false;
            // Disable Stencil test
            //for (int i = 0; i < SponzaMaterials.Length; i++)
            //{
            //    SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.NotEqual);
            //}
            this.InsideRoom = false;
            MainCamera.GetComponent<AudioSource>().mute = false;
            //transform.GetComponent<BoxCollider>().enabled = true;
            Sponza.SetActive(false);
            //PortalPlaneMaterial.SetInt("_CullMode", (int)CullMode.Front);
        }
        else
        {
            this.InsideRoom = true;
            MainCamera.GetComponent<AudioSource>().mute = true;
            //transform.GetComponent<BoxCollider>().enabled = false;
            // Enable Stencil test
            //for (int i = 0; i < SponzaMaterials.Length; i++)
            //{
            //    SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            //}
            Sponza.SetActive(true);
            //PortalPlaneMaterial.SetInt("_CullMode", (int)CullMode.Back);
        }

        //if (cameraRelative.y <= 0.0f)
        //{
        //    for (int i = 0; i < SponzaMaterials.Length; ++i)
        //    {
        //        SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.NotEqual);
        //    }

        //    PortalPlaneMaterial.SetInt("_CullMode", (int)CullMode.Front);
        //}
        //else if (cameraRelative.y < 0.5f)
        //{
        //    for (int i = 0; i < SponzaMaterials.Length; ++i)
        //    {
        //        SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
        //    }

        //    PortalPlaneMaterial.SetInt("_CullMode", (int)CullMode.Off);
        //}
        //else
        //{
        //    for (int i = 0; i < SponzaMaterials.Length; ++i)
        //    {
        //        SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
        //    }

        //    PortalPlaneMaterial.SetInt("_CullMode", (int)CullMode.Back);
        //}
    }
}