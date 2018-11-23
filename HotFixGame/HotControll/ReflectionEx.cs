using huqiang.UIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Controller
{
    public class ReflectionEx
    {
        public static List<ReflectionModel> ClassToList(object o)
        {
            List<ReflectionModel> models = new List<ReflectionModel>();
            var fs = o.GetType().GetFields();
            for (int i = 0; i < fs.Length; i++)
            {
                ReflectionModel model = new ReflectionModel();
                model.TargetName = fs[i].Name;
                model.FieldName = fs[i].Name;
                model.FieldType = fs[i].FieldType;
                models.Add(model);
            }
            return models;
        }
        public static void ListToClass(List<ReflectionModel> reflections, object o)
        {
            var fs = o.GetType().GetFields();
            for (int i = 0; i < fs.Length; i++)
            {
                var m = fs[i];
                for (int j = 0; j < reflections.Count; j++)
                {
                    var r = reflections[j];
                    if (r.TargetName == m.Name)
                    {
                        m.SetValue(o, r.Value);
                        break;
                    }
                }
            }
        }
        public static object Reflection(GameObject game, object com)
        {
            var list = ClassToList(com);
            ModelManager.GetComponent(game.transform, list);
            ListToClass(list, com);
            return com;
        }
    }
}
