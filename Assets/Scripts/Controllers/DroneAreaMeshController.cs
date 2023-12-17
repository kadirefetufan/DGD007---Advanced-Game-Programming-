using Enums;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Controllers
{
    public class DroneAreaMeshController : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        public void ChangeAreaColor(ColorTypes _colorType)
        {
            var colorHandler=Addressables.LoadAssetAsync<Material>($"CoreColor/Color_{_colorType}");
            meshRenderer.material = (colorHandler.WaitForCompletion() != null)?colorHandler.Result:null;
        }
    }
}