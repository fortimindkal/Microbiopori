using UnityEngine;

namespace Microbiopori
{
    public class ScrollBackground : MonoBehaviour
    {
        [Range(-1f, 5f)]
        public float scrollSpeed = 0.5f;
        private float offset;
        private Material mat;

        private void Start()
        {
            mat = GetComponent<Renderer>().material;
        }

        private void Update()
        {
            if(GameManager.Instance.state == GameState.Playing)
            {
                offset += (Time.deltaTime * scrollSpeed) / 10f;
                mat.SetTextureOffset("_MainTex", new Vector2(0, -offset));
            }
        }
    }
}
