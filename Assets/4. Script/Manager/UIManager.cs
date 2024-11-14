using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//원래는 Resources/UI에서 UI프리펩 다 꺼내와서 싹 넣고 생성하고 이러고 싶었는데 한 1주 더 걸릴 것 같아 그냥 일단 구현하려고 넣었습니다.
public class UIManager : Singleton<UIManager>
{
    public UILevelTxt UILevelTxt;
    public UITreeEXP UITreeEXP;
    public UITimer UITimer;
    public UIShopWindow UIShopWindow;

}
