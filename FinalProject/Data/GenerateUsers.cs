using FinalProject.Models;
using static System.Net.WebRequestMethods;

namespace FinalProject.Data
{
    public class GenerateUsers
    {
        public readonly string[] maleNames = new string[] { "Алексей", "Борис", "Афанасий", "Василий", "Борис", "Сергей", "Александр", "Джабраил", "Хамзат", "Ибрагим", "Алексей", "Николай", "Пётр" };
        public readonly string[] femaleNames = new string[] { "Елена", "Мария", "Дарья", "Александра", "Диана", "Галина", "Евдокинья" };
        public readonly string[] lastNames = new string[] { "Пупкин", "Лосев", "Иванов", "Мохаммедов", "Крикин", "Воронов" };
        public readonly string[] middleNames = new string[] { "Алексеевич", "Афанасьевич", "Васильевич", "Борисович", "Сергеевич", "Александрович", "Джабраилович", "Хамзатович", "Ибрагимович", "Алексеевич", "Николаевич", "Пётрович" };

        public List<User> Populate(int count)
        {
            var users = new List<User>();
            for (int i = 0; i < count; i++)
            {
                string firstName;
                string middleName;
                var rand = new Random();

                var male = rand.Next(1, 2) == 1;

                var lastName = lastNames[rand.Next(0, lastNames.Length - 1)];
                if (male)
                {
                    firstName = maleNames[rand.Next(0, maleNames.Length - 1)];
                    middleName = middleNames[rand.Next(0, middleNames.Length - 1)];
                }
                else
                {
                    lastName = lastName + "а";
                    firstName = femaleNames[rand.Next(0, femaleNames.Length - 1)];
                    middleName = middleNames[rand.Next(0, middleNames.Length - 1)].Replace("вич", "вна");
                }

                var item = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    BirthDate = DateTime.Now.AddDays(-rand.Next(1, (DateTime.Now - DateTime.Now.AddYears(-25)).Days)),
                    Email = "blog" + rand.Next(0, 1300) + "@blog.com",
                };

                item.UserName = item.Email;
                item.Image = "https://avavatar.ru/image/" + rand.Next(100, 2400);

                users.Add(item);
            }
            
            return users;
        }
    }
}
