using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using BokLogg.Model;
using BokLogg.View;

namespace BokLogg.Controller
{
    public class MemberController
    {
        private List<Member> members;
        private string relativePathMembers = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data")), "people.json");
        private static readonly ErrorExceptions errorExceptions = new ErrorExceptions();

        public MemberController()
        {
            members = LoadMembersFromJson();
        }

        private List<Member> LoadMembersFromJson()
        {
            try
            {
                string jsonData = File.ReadAllText(relativePathMembers);
                return JsonSerializer.Deserialize<List<Member>>(jsonData);
            }
            catch (Exception)
            {
                ErrorExceptions.LoadMembersError();
                return new List<Member>();
            }
        }

        private void SaveMembersToJson(List<Member> members)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(members, typeof(List<Member>), new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(relativePathMembers, jsonData);
            }
            catch
            {
                ErrorExceptions.SaveMemberError();
            }
        }

        public void AddMember(Member member)
        {
            members.Add(member);
            SaveMembersToJson(members);
        }

        public List<Member> GetAllMembers()
        {
            return members;
        }

        public Member GetMemberByName(string firstName, string lastName)
        {
            return members.FirstOrDefault(m => m.FirstName == firstName && m.LastName == lastName);
        }
    }
}


