using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class HotPopWindow : HotUIBase
{
    public Func<bool> Back { get; set; }
    protected HotUIPage mainPage;
    public virtual void Initial(Transform parent, HotUIPage page, object obj = null)
    {
        base.Initial(parent, page, obj);
        mainPage = page;
        if (model != null)
            if (page != null)
                Main.transform.SetParent(parent);
    }
    public virtual void Show(object obj = null)
    {
        if (Main != null)
            Main.gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        if (Main != null)
            Main.gameObject.SetActive(false);
    }
    public virtual bool Handling(string cmd, object dat)
    {
        return false;
    }
}
