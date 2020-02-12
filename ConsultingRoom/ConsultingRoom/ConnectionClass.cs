using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultingRoom
{
    public class ConnectionClass
    {
        public int CheckUserLoginAndPassword(string login, string password)
        {
            using (Model1 db = new Model1())
            {
                var user = db.User.FirstOrDefault(x => x.Login == login);
                if (user != null)
                {
                    if(user.Password == password)
                    {
                        return user.Id; //ok
                    }

                    return -1; //zle haslo
                }

                return 0; //brak uzytkownika
            }
        }

        public User GetUser(int userId)
        {
            using (Model1 db = new Model1())
            {
                return db.User.FirstOrDefault(x => x.Id == userId);
            }
        }

        public User GetUserByPersonId(int personId)
        {
            using (Model1 db = new Model1())
            {
                return db.User.FirstOrDefault(x => x.Person_Id == personId);
            }
        }

        internal Visit GetVisit(int visitId)
        {
            using (Model1 db = new Model1())
            {
                return db.Visit.FirstOrDefault(x => x.Id == visitId);
            }
        }

        public Person GetPerson(int personId)
        {
            using (Model1 db = new Model1())
            {
                return db.Person.FirstOrDefault(x => x.Id == personId);
            }
        }

        public int AddPerson(Person p)
        {
            using (Model1 db = new Model1())
            {
                if (p.Id > 0)
                {
                    var person = db.Person.FirstOrDefault(x => x.Id == p.Id);

                    person.Name = p.Name;
                    person.Surname = p.Surname;
                    person.Pesel = p.Pesel;
                    person.Phone = p.Phone;
                    person.Email = p.Email;
                    person.Address = p.Address;
                }
                else
                {
                    db.Person.Add(p);
                }

                db.SaveChanges();

                return p.Id;
            }
        }

        public int AddUser(User p)
        {
            using (Model1 db = new Model1())
            {
                var user = db.User.FirstOrDefault(x => x.Person_Id == p.Person_Id);

                if(user != null)
                {
                    user.Login = p.Login;
                    user.Password = p.Password;
                }
                else
                {
                    db.User.Add(p);
                }
               
                db.SaveChanges();

                return p.Id;
            }
        }

        public int AddVisit(Visit v)
        {
            using (Model1 db = new Model1())
            {
                if (v.Id > 0)
                {
                    var visit = db.Visit.FirstOrDefault(x => x.Id == v.Id);

                    visit.Person_Id = v.Person_Id;
                    visit.Doctor_Id = v.Doctor_Id;
                    visit.VisitWasHeld = v.VisitWasHeld;
                    visit.Date = v.Date;
                    visit.Comment = v.Comment;
                }
                else
                {
                    db.Visit.Add(v);
                }

                db.SaveChanges();

                return v.Id;
            }
        }

        public List<Person> GetPersons()
        {
            using (Model1 db = new Model1())
            {
                return db.Person.ToList();
            }
        }

        //czy lekarz ma wizyte w ciagu 30 minut od wybranego terminu
        public bool CheckDoctorVisitInTime(int doctorId, DateTime date)
        {
            using (Model1 db = new Model1())
            {
                DateTime dateToCheck = date.AddMinutes(30);

                return db.Visit.Where(x => x.Doctor_Id == doctorId && x.Date < dateToCheck && x.Date >= date).Count() > 0;
            }
        }
    }
}
