using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snake.Devextreme.Helpers
{
    public class DevextremeSelectList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DefaultName { get; set; }


    }
    public static class DevextremeSelectListComponent
    {
        public static void RemoveEnum<t>(this List<DevextremeSelectList> list, object toRemove)
        {
            var selectedEnum = list.Where(x => x.DefaultName == Enum.GetName(typeof(t), toRemove)).FirstOrDefault();

            list.Remove(selectedEnum);
        }

        public static void Localise<t>(this List<DevextremeSelectList> list, IStringLocalizer<t> _localizer)
        {
            foreach (var item in list)
            {
                item.Name = _localizer[item.DefaultName].Value;
            }
        }

        public static List<DevextremeSelectList> GetSelectList<t>()
        {
            return ExtractEnum<t>();
        }



        private static List<DevextremeSelectList> ExtractEnum<t>()
        {
            var enumVal = new List<DevextremeSelectList>();
            byte index = 0;

            foreach (int i in Enum.GetValues(typeof(t)))
            {
                enumVal.Add(
                    new DevextremeSelectList
                    {
                        ID = index,
                        Name = Enum.GetName(typeof(t), i),
                        DefaultName = Enum.GetName(typeof(t), i)
                    });
                index++;
            }
            return enumVal;
        }
    }
}

