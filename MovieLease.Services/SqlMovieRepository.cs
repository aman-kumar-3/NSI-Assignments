using Microsoft.EntityFrameworkCore;
using MovieLease.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieLease.Services
{
    public class SqlMovieRepository:IMovieRepository
    {
        private readonly MovieLeaseContext context;
        public SqlMovieRepository(MovieLeaseContext context)
        {
            this.context = context;
        }
        //method for movies
        public IEnumerable<Movie> GetAllMovies()
        {
            return context.Movies;
            
        }

        public Movie GetMovieById(int MovieId)
        {
            return context.Movies.Find(MovieId);

        }


        //for users
        //user create
         
        public User Add(User newUser)
        {
            context.Users.Add(newUser);
            context.SaveChanges();
            return newUser;
        }
        //get user by name
        public User GetUserByName(string UserName)
        {
            return context.Users.Where(m => m.UserName == UserName).FirstOrDefault();

        }
        //login User
        public string UserExist(string UserName, string Password)
        {
            var userdetails = context.Users.SingleOrDefault(m => m.UserName == UserName &&
              m.Password == Password);
            if(userdetails==null)
            {
                return "UserName doesn't exist check UserName or Password";
            }
            return "Successfull";

        }

        //records
        public bool AddRecord(Record Record)
        {
            context.Records.Add(Record);
            return true;

        }
        public int Commit()
        {
            return context.SaveChanges();
        }

        public IEnumerable <Record> GetRecordByUser(String UserName)
        {
            var result = context.Records.Include("Movie").Where(m => m.User.UserName == UserName).OrderBy(m => m.LendDate).ToList();
            if(result.Count()>0)
            {
                return result;
            }
            return null;
               

        }
        public IEnumerable<Record> GetDefaulters()
        {
            var result = context.Records.Include("Movie").Include("User").Where(m => m.Status == "Not Returned").ToList();
            return result;
        }
        public IEnumerable<Record> GetReturnedRecords()
        {
            var result = context.Records.Include("Movie").Include("User").Where(m => m.Status == "Returned").ToList();
            return result;
        }
        public Record GetRecordById(int RecordId)
        {
            var result = context.Records.Include("Movie").Where(m => m.RecordId == RecordId).SingleOrDefault();
            return result;

        }

        public Record UpdateRecordById(int Id)
        {
            DateTime ActualReturnDate = System.DateTime.Now;
            var Fine = 0;
            var UserRecord = GetRecordById(Id);
            int days;
            days = (ActualReturnDate - UserRecord.ReturnDate).Days;
            if (days > 0)
            {
                Fine = UserRecord.Movie.Price + 100;
            }
            else
            {
                Fine = UserRecord.Movie.Price;
            }
            string Status = "Returned";
            if (UserRecord != null)
            {
                UserRecord.ActualReturnDate = ActualReturnDate;
                UserRecord.Fine = Fine;
                UserRecord.Status = Status;
            }
           
            context.Records.Update(UserRecord);
            context.SaveChanges();
            return UserRecord;
        }

    }
}
