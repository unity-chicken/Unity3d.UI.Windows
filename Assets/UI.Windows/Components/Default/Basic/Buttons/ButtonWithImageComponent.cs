﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UI.Windows.Extensions;

namespace UnityEngine.UI.Windows.Components {

	public class ButtonWithImageComponent : ButtonComponent, IImageComponent {

		[Header("Images (Optional)")]

		//[HideInInspector][SerializeField]
		public Image image;
		
		//[HideInInspector][SerializeField]
		public RawImage rawImage;
		
		public void SetImage(Sprite sprite, bool withPivotsAndSize = false) {
			
			if (this.image != null) {
				
				this.image.sprite = sprite;
				
				if (withPivotsAndSize == true && sprite != null) {
					
					var rect = (this.transform as RectTransform);
					
					rect.sizeDelta = sprite.rect.size;
					
					rect.pivot = sprite.GetPivot();
					rect.anchoredPosition = Vector2.zero;
					
				}
				
			}
			
		}
		
		public void SetImage(Texture2D texture) {
			
			if (this.rawImage != null) this.rawImage.texture = texture;
			
		}

		public void SetMaterial(Material material) {

			if (this.image != null) {

				this.image.material = material;
				this.image.SetMaterialDirty();

			} else if (this.rawImage != null) {

				this.rawImage.material = material;
				this.rawImage.SetMaterialDirty();

			}

		}
		
		#if UNITY_EDITOR
		public override void OnValidateEditor() {
			
			base.OnValidateEditor();
			
			if (this.gameObject.activeSelf == false) return;
			
			if (this.image == null) this.image = this.GetComponent<Image>();
			if (this.rawImage == null) this.rawImage = this.GetComponent<RawImage>();
			
		}
		#endif

	}

}