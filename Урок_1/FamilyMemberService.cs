using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Урок_1
{

    internal class FamilyMemberService
    {
        private List<FamilyMember> Family { get; set; }  //список членов семьи

        //Конструктор:
        public FamilyMemberService()
        {
            Family = new();  //создаём новый список членов семьи
        }

        //Добавляем члена семьи:
        public void AddPerson(params FamilyMember[] member)
        {
            if (member != null && member.Length > 0)
            {
                Family.AddRange(member);
            }
        }

        //Получаем дедушек:
        public List<FamilyMember> GetGrandFathers(FamilyMember member)
        {
            List<FamilyMember> grandFathers = new();
            if (member.Mother != null && member.Mother.Father != null)   grandFathers.Add(member.Mother.Father);
            if (member.Father != null && member.Father.Father != null)   grandFathers.Add(member.Father.Father);

            return grandFathers;
        }

        //Получаем бабушек:
        public List<FamilyMember> GetGrandMothers(FamilyMember member)
        {
            List<FamilyMember> grandFathers = new List<FamilyMember>();
            if (member.Mother != null && member.Mother.Mother != null)   grandFathers.Add(member.Mother.Mother);
            if (member.Father != null && member.Father.Mother != null)   grandFathers.Add(member.Father.Mother);

            return grandFathers;
        }

        //Находим старейшего члена семьи:
        public FamilyMember? OldFamilyMember()
        {
            var data = Family.Min(x => x.DateOfBirth);
            return Family.LastOrDefault(x => x.DateOfBirth == data);
        }

        //Получаем супруга:
        public FamilyMember? GetSpouse(FamilyMember member) => member.Spouse;

    }

}
