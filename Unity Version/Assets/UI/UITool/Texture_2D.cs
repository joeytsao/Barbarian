using UnityEngine;
using System.Collections;

/// <summary>
/// ���� - ��ܹϤ�
/// 13/03/20 Updated.
/// </summary>
public class Texture_2D : MonoBehaviour {

    //�����j�p
    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);

    //��m�P�j�p
    public Rect rect;

    //�Ϯ�
    public Texture Texture2d;

    //�Ϯר���
    public int angle;

    //�Ϯ��C��
    public Color TextureColor = Color.white;

    //�����`�� - ���ȶV�e��
    public int depth;

    //�ƥ���T
    private Rect _rect_backup;
    private Color _TextureColor_backup;

	// Use this for initialization
    void Start () {
        if (!Texture2d) Debug.LogWarning(this.name + "-Texture2d" + "-Unset");


        //Backup
        _rect_backup = rect;
        _TextureColor_backup = TextureColor;
        //��w�e�צ۰ʩ�j
        //rect.height *= Screen.width / (float)Screen.height;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {

        Rect _rect = new Rect(rect.x * _ScreenSize.x
                        , rect.y * _ScreenSize.y
                        , rect.width * _ScreenSize.x
                        , rect.height * _ScreenSize.y);

        GUI.color = TextureColor;
        GUI.depth = depth;
        GUIUtility.RotateAroundPivot(angle, new Vector2(_rect.x + _rect.width / 2, _rect.y + _rect.height / 2));
        
        GUI.DrawTexture(_rect, Texture2d);

    }

    void Init()
    {    
        rect = _rect_backup;
        TextureColor = _TextureColor_backup;
    
    }

    //�S�Ĩt��

    /// <summary>
    /// �s�yRect�ʵe�ĪG (Create)
    /// Name - RectTo
    /// </summary>
    /// <param name="effect">�S�ĵ��c</param>
    void RectTo(iTweenEffectStruct.EffectStruct effect)
    {

        iTween.ValueTo(gameObject, iTween.Hash(
            "from", rect,
            "to", effect.rect,
            "delay", effect.delay,
            "time", effect.time,
            "easetype", effect.easeType.ToString(),
            "onupdate", "updateRect",
             "loopType", effect.looptype.ToString(),
             "name", "RectTo"));
    }

    /// <summary>
    /// �s�yColor�ʵe�ĪG (Create)
    /// Name - RectTo
    /// </summary>
    /// <param name="effect">�S�ĵ��c</param>
    void ColorTo(iTweenEffectStruct.EffectStruct effect)
    {
        iTween.ValueTo(gameObject, iTween.Hash(
           "from", TextureColor,
           "to", effect.color,
           "delay", effect.delay,
           "time", effect.time,
           "easetype", iTween.EaseType.easeInOutCubic,
           "onupdate", "updateColor",
           "loopType", effect.looptype.ToString(),
           "name", "ColorTo"));
        
    }
    
    void StopRectTo()
    {
        rect = _rect_backup;
        iTween.StopByName(this.gameObject, "RectTo");
    }
    void StopColorTo()
    {
        TextureColor = _TextureColor_backup;
        iTween.StopByName(this.gameObject,"ColorTo");
    }


    // Update callback for iTween
    void updateRect(Rect input)
    {
        rect = input;
    }
    void updateColor(Color input)
    {
        TextureColor = input;
    }
}