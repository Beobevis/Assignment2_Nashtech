class ProgramUsingLinQ
{
    static void Main(string[] args)
    {
        //1.Get Male Members
        // var malemems = GetMaleMembers();
        // PrintData(malemems);
        //2.Get Oldest Members by Age
        // var oldest = GetOldestMemberbyAge();
        // PrintData(new List<Member> { oldest });
        //2.1 Get Oldest Member by DOB
        // var oldest = GetOldestMemberbyAge();
        // PrintData(new List<Member> { oldest });
        //3. List Member with FullName
        // var fullnames = GetFullName();
        // for(int i = 0;i<fullnames.Count;i++){
        //     string fullname = fullnames[i];
        //     Console.WriteLine($"{i+1}. {fullname}");
        // }
        //4. Split List Member by 2000
        // var result = GetListMemberbyBirthYear(2000);
        // PrintData(result.Item3);
        // Console.WriteLine("===========================");
        // PrintData(result.Item1);
        // Console.WriteLine("===========================");
        // PrintData(result.Item2);
        //5.Print first Member in  Ha Noi using LinQ
        var result = GetMemberbyBirthPlace();
        if (result != null)
        {
            PrintData(new List<Member> { result });
        }
        else
        {
            Console.WriteLine("No data.");
        }
    }
    static List<Member> members = new List<Member>
        {
            new Member
            {
                FirstName = "Phuong",
                LastName = "Nguyen Nam",
                Gender = "Male",
                DOB = new DateTime(2001, 1, 22),
                PhoneNumber = "",
                BirthPlace = "Phu Tho",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Nam",
                LastName = "Nguyen Thanh",
                Gender = "Male",
                DOB = new DateTime(2001, 1, 20),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Son",
                LastName = "Do Hong",
                Gender = "Male",
                DOB = new DateTime(2000, 11, 6),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Huy",
                LastName = "Nguyen Duc",
                Gender = "Male",
                DOB = new DateTime(1996, 1, 26),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Hoang",
                LastName = "Phuong Viet",
                Gender = "Male",
                DOB = new DateTime(1999, 2, 5),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Long",
                LastName = "Lai Quoc",
                Gender = "Male",
                DOB = new DateTime(1997, 5, 30),
                PhoneNumber = "",
                BirthPlace = "Bac Giang",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Thanh",
                LastName = "Tran Chi",
                Gender = "Male",
                DOB = new DateTime(2000, 9, 18),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Member",
                LastName = "Old",
                Gender = "Male",
                DOB = new DateTime(1996, 1, 14),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            }
        };
    static void PrintData(List<Member> data)
    {
        var index = 0;
        foreach (var item in data)
        {
            ++index;
            Console.WriteLine($"{index}. {item.LastName} {item.FirstName} / {item.Gender} / {item.DOB.ToString("dd/MM/yyyy")} / {item.BirthPlace} / [{item.Age}]");
        }
    }
    static List<Member> GetMaleMembers()
    {
        var result = members.Where(m => m.Gender.Equals("Male", StringComparison.CurrentCultureIgnoreCase)).ToList();
        //using LinQ Query
        // var result = (from member in members
        //               where member.Gender == "Male"
        //               select member).ToList();
        return result;
    }
    static Member GetOldestMemberbyAge()
    {
        var MaxAge = members.Max(m => m.Age);

        return members.First(m => m.Age == MaxAge);
        //using OrderBy
        //return members.OrderByDescending(m=>m.Age).First();
        //return members.OrderBy(m=>m.Age).Last();

        //using LinQ Query
        // var OldList = from member in members
        //               orderby member.Age descending
        //               select member;
        // return OldList.First();
    }
    static Member GetOldestMemberbyDOB()
    {

        var MaxDays = members.Max(m => m.TotalDays);
        return members.First(m => m.TotalDays == MaxDays);
    }
    static List<string> GetFullName()
    {
        var result = members.Select(m => m.FullName).ToList();
        return result;
    }
    static Tuple<List<Member>, List<Member>, List<Member>> GetListMemberbyBirthYear(int year)
    {
        var list1 = members.Where(m => m.DOB.Year == year).ToList();
        var list2 = members.Where(m => m.DOB.Year > year).ToList();
        var list3 = members.Where(m => m.DOB.Year < year).ToList();

        return Tuple.Create(list1, list2, list3);
    }
    static Member? GetMemberbyBirthPlace()
    {
        return members.FirstOrDefault(m => m.BirthPlace.Equals("Ha Noi", StringComparison.CurrentCultureIgnoreCase));
    }

}
