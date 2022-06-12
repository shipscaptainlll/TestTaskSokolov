using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class FlexibleUI : MonoBehaviour
{
    public TintData tintData;
    public ColorData colorData;
    public WheelsData wheelsData;
    public SpoilerData spoilerData;
    public ExhaustData exhaustData;
    public UIGroupsData uiGroupsData;
    public AdditionalUIData additionalUIData;

    protected virtual void OnSkinUI()
    {

    }

    public virtual void Awake()
    {
        //OnSkinUI();

    }

    public virtual void Update()
    {
        //Application.isEditor
        if (!Application.isPlaying)
        {
            
            OnSkinUI();
        }
    }
}
