
using System;
using System.Collections.Generic;

namespace factorio_blueprint_storage
{
    public static class MainService
    {
        public struct BPObject
        {
            public int id;
            public string name;
            public DateTime updateDate;
            public string description;
            public string imgLink;
            public string code;
            public Stack<int> tags;
        }

        public static int NewID =>
            //СДЕЛАТЬ ЗАПРОС нового ID К БД
            1;

        internal static void AddBlueprintObj(BPObject addItemBP)
        {
            //TODO Добавление строки в базу
        }
    }
}