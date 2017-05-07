//------------------------------------------------------------------------------------------
// MonoBehaviourClassic licensed under the MIT license:
//
// The MIT License (MIT)
//	
//	Copyright (c) 2015 Jarcas Studios
//	
//	Permission is hereby granted, free of charge, to any person obtaining a copy
//		of this software and associated documentation files (the "Software"), to deal
//		in the Software without restriction, including without limitation the rights
//		to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//		copies of the Software, and to permit persons to whom the Software is
//		furnished to do so, subject to the following conditions:
//		
//		The above copyright notice and this permission notice shall be included in all
//		copies or substantial portions of the Software.
//		
//		THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//		IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//		FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//		AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//		LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//		OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//		SOFTWARE.
//------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

#if !MBC_NO_UI
using UnityEngine.UI;
#endif

/// <summary>
/// MonoBehaviourClassic includes getter properties that are shortcuts for various GetComponent calls just like the old
/// pre-5.x Unity MonoBehaviours. Handles caching of components so that only the first access is expensive.
/// 
/// We also include some new shortcuts as well as the ability to include or exclude properties using compiler directives:
/// 
/// MBC_INCLUDE_LEGACY - Will include legacy components (Animation, ParticleEmitter, GUIText, GUITexture)
/// MBC_NO_PHYSICS - Will exclude all physics components (except colliders)
/// MBC_NO_3D - Will exclude all 3D-only components
/// MBC_NO_2D - Will exclude all 2D-only components
/// MBC_NO_UI - Will exclude Unity UI components (RectTransform, Image, Text)
/// </summary>
public class MonoBehaviourClassic : MonoBehaviour {

#if MBC_INCLUDE_LEGACY
	private Animation m_animation;
	new public Animation animation {
		get {
			if ( m_animation == null ) {
				m_animation = GetComponent< Animation >( );
			}
			
			return m_animation;
		}
	}
#endif


	private Animator m_animator;
	public Animator animator {
		get {
			if ( m_animator == null ) {
				m_animator = GetComponent< Animator >( );
			}
			
			return m_animator;
		}
	}


	private AudioSource m_audio;
	new public AudioSource audio {
		get {
			if ( m_audio == null ) {
				m_audio = GetComponent< AudioSource >( );
			}

			return m_audio;
		}
	}


	private Camera m_camera;
	new public Camera camera {
		get {
			if ( m_camera == null ) {
				m_camera = GetComponent< Camera >( );
			}
			
			return m_camera;
		}
	}

	
#if !MBC_NO_3D
	private Collider m_collider;
	new public Collider collider {
		get {
			if ( m_collider == null ) {
				m_collider = GetComponent< Collider >( );
			}

			return m_collider;
		}
	}
#endif

	
#if !MBC_NO_2D
	private Collider2D m_collider2D;
	new public Collider2D collider2D {
		get {
			if ( m_collider2D == null ) {
				m_collider2D = GetComponent< Collider2D >( );
			}
			
			return m_collider2D;
		}
	}
#endif


#if !MBC_NO_PHYSICS && !MBC_NO_2D
	private Effector2D m_effector2D;
	public Effector2D effector2D {
		get {
			if ( m_effector2D == null ) {
				m_effector2D = GetComponent< Effector2D >( );
			}
			
			return m_effector2D;
		}
	}
#endif


#if MBC_INCLUDE_LEGACY
	private GUIText m_guiText;
	new public GUIText guiText {
		get {
			if ( m_guiText == null ) {
				m_guiText = GetComponent< GUIText >( );
			}
			
			return m_guiText;
		}
	}


	private GUITexture m_guiTexture;
	new public GUITexture guiTexture {
		get {
			if ( m_guiTexture == null ) {
				m_guiTexture = GetComponent< GUITexture >( );
			}
			
			return m_guiTexture;
		}
	}
#endif


#if !MBC_NO_PHYSICS && !MBC_NO_3D
	private Joint m_joint;
	public Joint joint {
		get {
			if ( m_joint == null ) {
				m_joint = GetComponent< Joint >( );
			}
			
			return m_joint;
		}
	}
#endif

	
#if !MBC_NO_PHYSICS && !MBC_NO_2D
	private Joint2D m_joint2D;
	public Joint2D joint2D {
		get {
			if ( m_joint2D == null ) {
				m_joint2D = GetComponent< Joint2D >( );
			}
			
			return m_joint2D;
		}
	}
#endif
	

	private Light m_light;
	new public Light light {
		get {
			if ( m_light == null ) {
				m_light = GetComponent< Light >( );
			}
			
			return m_light;
		}
	}
	

	private MeshFilter m_meshFilter;
	public MeshFilter meshFilter {
		get {
			if ( m_meshFilter == null ) {
				m_meshFilter = GetComponent< MeshFilter >( );
			}
			
			return m_meshFilter;
		}
	}
	
	
	private NetworkView m_networkView;
	new public NetworkView networkView {
		get {
			if ( m_networkView == null ) {
				m_networkView = GetComponent< NetworkView >( );
			}
			
			return m_networkView;
		}
	}

	
#if MBC_INCLUDE_LEGACY
	private ParticleEmitter m_particleEmitter;
	new public ParticleEmitter particleEmitter {
		get {
			if ( m_particleEmitter == null ) {
				m_particleEmitter = GetComponent< ParticleEmitter >( );
			}
			
			return m_particleEmitter;
		}
	}
#endif

	
	private ParticleSystem m_particleSystem;
	new public ParticleSystem particleSystem {
		get {
			if ( m_particleSystem == null ) {
				m_particleSystem = GetComponent< ParticleSystem >( );
			}
			
			return m_particleSystem;
		}
	}


#if !MBC_NO_UI
	private RectTransform m_rectTransform;
	public RectTransform rectTransform {
		get {
			if ( m_rectTransform == null ) {
				m_rectTransform = GetComponent< RectTransform >( );
			}
			
			return m_rectTransform;
		}
	}
#endif
	
	
	private Renderer m_renderer;
	new public Renderer renderer {
		get {
			if ( m_renderer == null ) {
				m_renderer = GetComponent< Renderer >( );
			}
			
			return m_renderer;
		}
	}
	
	
#if !MBC_NO_PHYSICS && !MBC_NO_3D
	private Rigidbody m_rigidbody;
	new public Rigidbody rigidbody {
		get {
			if ( m_rigidbody == null ) {
				m_rigidbody = GetComponent< Rigidbody >( );
			}
			
			return m_rigidbody;
		}
	}
#endif


#if !MBC_NO_PHYSICS && !MBC_NO_2D
	private Rigidbody2D m_rigidbody2D;
	new public Rigidbody2D rigidbody2D {
		get {
			if ( m_rigidbody2D == null ) {
				m_rigidbody2D = GetComponent< Rigidbody2D >( );
			}
			
			return m_rigidbody2D;
		}
	}
#endif


#if !MBC_NO_UI
	private Image m_uiImage;
	public Image uiImage {
		get {
			if ( m_uiImage == null ) {
				m_uiImage = GetComponent< Image >( );
			}
			
			return m_uiImage;
		}
	}


	private Text m_uiText;
	public Text uiText {
		get {
			if ( m_uiText == null ) {
				m_uiText = GetComponent< Text >( );
			}
			
			return m_uiText;
		}
	}
#endif
}